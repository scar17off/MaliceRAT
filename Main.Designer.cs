using Guna.UI2.WinForms;

namespace MaliceRAT
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gunaTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gunaVictimsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gunaLAN = new Guna.UI2.WinForms.Guna2Button();
            this.buildDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.gunaGetMSBuild = new Guna.UI2.WinForms.Guna2Button();
            this.gunaHostPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gunaHostIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaFindProj = new Guna.UI2.WinForms.Guna2Button();
            this.gunaProjPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaBuildPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaFindBuild = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaHideConsole = new Guna.UI2.WinForms.Guna2CheckBox();
            this.gunaForwardedPorts = new Guna.UI2.WinForms.Guna2CheckBox();
            this.gunaOpenFolder = new Guna.UI2.WinForms.Guna2CheckBox();
            this.buildButton = new Guna.UI2.WinForms.Guna2Button();
            this.gunaCopyStartUp = new Guna.UI2.WinForms.Guna2CheckBox();
            this.gunaDragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2TabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaVictimsTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 53F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 71);
            this.label1.TabIndex = 2;
            this.label1.Text = "MaliceRat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage3);
            this.guna2TabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.Padding = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1230, 630);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(100, 30);
            this.guna2TabControl1.TabIndex = 3;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.tabPage2.Controls.Add(this.gunaTextBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.guna2PictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1222, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "News";
            // 
            // gunaTextBox1
            // 
            this.gunaTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTextBox1.DefaultText = resources.GetString("gunaTextBox1.DefaultText");
            this.gunaTextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaTextBox1.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaTextBox1.FocusedState.ForeColor = System.Drawing.Color.White;
            this.gunaTextBox1.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gunaTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaTextBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaTextBox1.HoverState.ForeColor = System.Drawing.Color.White;
            this.gunaTextBox1.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaTextBox1.Location = new System.Drawing.Point(391, 6);
            this.gunaTextBox1.Multiline = true;
            this.gunaTextBox1.Name = "gunaTextBox1";
            this.gunaTextBox1.PasswordChar = '\0';
            this.gunaTextBox1.PlaceholderText = "";
            this.gunaTextBox1.ReadOnly = true;
            this.gunaTextBox1.SelectedText = "";
            this.gunaTextBox1.Size = new System.Drawing.Size(823, 578);
            this.gunaTextBox1.TabIndex = 3;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::MaliceRAT.Properties.Resources.Logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(80, 200);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(226, 226);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.tabPage1.Controls.Add(this.gunaVictimsTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1222, 592);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Victims";
            // 
            // gunaVictimsTable
            // 
            this.gunaVictimsTable.AllowUserToAddRows = false;
            this.gunaVictimsTable.AllowUserToDeleteRows = false;
            this.gunaVictimsTable.AllowUserToOrderColumns = true;
            this.gunaVictimsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gunaVictimsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gunaVictimsTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaVictimsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaVictimsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gunaVictimsTable.ColumnHeadersHeight = 30;
            this.gunaVictimsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LastActive,
            this.Flag,
            this.IP,
            this.OS,
            this.User,
            this.PC});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaVictimsTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.gunaVictimsTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaVictimsTable.Location = new System.Drawing.Point(8, 3);
            this.gunaVictimsTable.MultiSelect = false;
            this.gunaVictimsTable.Name = "gunaVictimsTable";
            this.gunaVictimsTable.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaVictimsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gunaVictimsTable.RowHeadersVisible = false;
            this.gunaVictimsTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaVictimsTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaVictimsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaVictimsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaVictimsTable.RowTemplate.ReadOnly = true;
            this.gunaVictimsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaVictimsTable.ShowCellToolTips = false;
            this.gunaVictimsTable.Size = new System.Drawing.Size(1206, 581);
            this.gunaVictimsTable.TabIndex = 0;
            this.gunaVictimsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.SystemColors.Control;
            this.gunaVictimsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaVictimsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaVictimsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaVictimsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaVictimsTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaVictimsTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gunaVictimsTable.ThemeStyle.HeaderStyle.Height = 30;
            this.gunaVictimsTable.ThemeStyle.ReadOnly = true;
            this.gunaVictimsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaVictimsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaVictimsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gunaVictimsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaVictimsTable.ThemeStyle.RowsStyle.Height = 22;
            this.gunaVictimsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaVictimsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            // 
            // ID
            // 
            this.ID.FillWeight = 20F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // LastActive
            // 
            this.LastActive.HeaderText = "Last Active";
            this.LastActive.Name = "LastActive";
            this.LastActive.ReadOnly = true;
            // 
            // Flag
            // 
            this.Flag.FillWeight = 20F;
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // OS
            // 
            this.OS.HeaderText = "OS";
            this.OS.Name = "OS";
            this.OS.ReadOnly = true;
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // PC
            // 
            this.PC.HeaderText = "PC";
            this.PC.Name = "PC";
            this.PC.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.tabPage3.Controls.Add(this.gunaLAN);
            this.tabPage3.Controls.Add(this.buildDownloadProgressBar);
            this.tabPage3.Controls.Add(this.gunaGetMSBuild);
            this.tabPage3.Controls.Add(this.gunaHostPort);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.gunaHostIP);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.gunaFindProj);
            this.tabPage3.Controls.Add(this.gunaProjPath);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.gunaBuildPath);
            this.tabPage3.Controls.Add(this.gunaFindBuild);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.gunaHideConsole);
            this.tabPage3.Controls.Add(this.gunaForwardedPorts);
            this.tabPage3.Controls.Add(this.gunaOpenFolder);
            this.tabPage3.Controls.Add(this.buildButton);
            this.tabPage3.Controls.Add(this.gunaCopyStartUp);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1222, 592);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Build";
            // 
            // gunaLAN
            // 
            this.gunaLAN.Animated = true;
            this.gunaLAN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaLAN.BorderThickness = 1;
            this.gunaLAN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaLAN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLAN.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLAN.Location = new System.Drawing.Point(303, 3);
            this.gunaLAN.Name = "gunaLAN";
            this.gunaLAN.Size = new System.Drawing.Size(53, 26);
            this.gunaLAN.TabIndex = 24;
            this.gunaLAN.Text = "LAN";
            this.gunaLAN.Click += new System.EventHandler(this.gunaLAN_Click);
            // 
            // buildDownloadProgressBar
            // 
            this.buildDownloadProgressBar.ForeColor = System.Drawing.SystemColors.Control;
            this.buildDownloadProgressBar.Location = new System.Drawing.Point(414, 166);
            this.buildDownloadProgressBar.Name = "buildDownloadProgressBar";
            this.buildDownloadProgressBar.Size = new System.Drawing.Size(200, 26);
            this.buildDownloadProgressBar.TabIndex = 23;
            this.buildDownloadProgressBar.Visible = false;
            // 
            // gunaGetMSBuild
            // 
            this.gunaGetMSBuild.Animated = true;
            this.gunaGetMSBuild.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaGetMSBuild.BorderThickness = 1;
            this.gunaGetMSBuild.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaGetMSBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gunaGetMSBuild.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaGetMSBuild.Location = new System.Drawing.Point(354, 166);
            this.gunaGetMSBuild.Name = "gunaGetMSBuild";
            this.gunaGetMSBuild.Size = new System.Drawing.Size(54, 26);
            this.gunaGetMSBuild.TabIndex = 22;
            this.gunaGetMSBuild.Text = "Get";
            this.gunaGetMSBuild.Click += new System.EventHandler(this.gunaGetMSBuild_Click);
            // 
            // gunaHostPort
            // 
            this.gunaHostPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaHostPort.DefaultText = "6666";
            this.gunaHostPort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaHostPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostPort.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaHostPort.FocusedState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostPort.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaHostPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaHostPort.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostPort.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaHostPort.HoverState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostPort.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaHostPort.Location = new System.Drawing.Point(122, 35);
            this.gunaHostPort.Name = "gunaHostPort";
            this.gunaHostPort.PasswordChar = '\0';
            this.gunaHostPort.PlaceholderText = "";
            this.gunaHostPort.SelectedText = "";
            this.gunaHostPort.Size = new System.Drawing.Size(175, 26);
            this.gunaHostPort.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(11, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Host PORT:";
            // 
            // gunaHostIP
            // 
            this.gunaHostIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaHostIP.DefaultText = "";
            this.gunaHostIP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaHostIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostIP.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaHostIP.FocusedState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostIP.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaHostIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaHostIP.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHostIP.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaHostIP.HoverState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHostIP.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaHostIP.Location = new System.Drawing.Point(122, 3);
            this.gunaHostIP.Name = "gunaHostIP";
            this.gunaHostIP.PasswordChar = '\0';
            this.gunaHostIP.PlaceholderText = "";
            this.gunaHostIP.SelectedText = "";
            this.gunaHostIP.Size = new System.Drawing.Size(175, 26);
            this.gunaHostIP.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(11, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Host IP:";
            // 
            // gunaFindProj
            // 
            this.gunaFindProj.Animated = true;
            this.gunaFindProj.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaFindProj.BorderThickness = 1;
            this.gunaFindProj.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaFindProj.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaFindProj.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaFindProj.Location = new System.Drawing.Point(303, 196);
            this.gunaFindProj.Name = "gunaFindProj";
            this.gunaFindProj.Size = new System.Drawing.Size(45, 26);
            this.gunaFindProj.TabIndex = 17;
            this.gunaFindProj.Text = "...";
            this.gunaFindProj.Click += new System.EventHandler(this.gunaFindProj_Click);
            // 
            // gunaProjPath
            // 
            this.gunaProjPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaProjPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaProjPath.DefaultText = "";
            this.gunaProjPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaProjPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaProjPath.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaProjPath.FocusedState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProjPath.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaProjPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaProjPath.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProjPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaProjPath.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaProjPath.HoverState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaProjPath.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaProjPath.Location = new System.Drawing.Point(122, 196);
            this.gunaProjPath.Name = "gunaProjPath";
            this.gunaProjPath.PasswordChar = '\0';
            this.gunaProjPath.PlaceholderText = "";
            this.gunaProjPath.ReadOnly = true;
            this.gunaProjPath.SelectedText = "";
            this.gunaProjPath.Size = new System.Drawing.Size(175, 26);
            this.gunaProjPath.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(11, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "CSProject path:";
            // 
            // gunaBuildPath
            // 
            this.gunaBuildPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaBuildPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaBuildPath.DefaultText = "";
            this.gunaBuildPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.gunaBuildPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaBuildPath.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaBuildPath.FocusedState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaBuildPath.FocusedState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaBuildPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaBuildPath.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaBuildPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaBuildPath.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.gunaBuildPath.HoverState.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaBuildPath.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.gunaBuildPath.Location = new System.Drawing.Point(122, 166);
            this.gunaBuildPath.Name = "gunaBuildPath";
            this.gunaBuildPath.PasswordChar = '\0';
            this.gunaBuildPath.PlaceholderText = "";
            this.gunaBuildPath.ReadOnly = true;
            this.gunaBuildPath.SelectedText = "";
            this.gunaBuildPath.Size = new System.Drawing.Size(175, 26);
            this.gunaBuildPath.TabIndex = 14;
            // 
            // gunaFindBuild
            // 
            this.gunaFindBuild.Animated = true;
            this.gunaFindBuild.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaFindBuild.BorderThickness = 1;
            this.gunaFindBuild.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaFindBuild.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaFindBuild.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaFindBuild.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaFindBuild.Location = new System.Drawing.Point(303, 166);
            this.gunaFindBuild.Name = "gunaFindBuild";
            this.gunaFindBuild.Size = new System.Drawing.Size(45, 26);
            this.gunaFindBuild.TabIndex = 13;
            this.gunaFindBuild.Text = "...";
            this.gunaFindBuild.Click += new System.EventHandler(this.gunaFindBuild_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "MSBuild.exe path:";
            // 
            // gunaHideConsole
            // 
            this.gunaHideConsole.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHideConsole.CheckedState.BorderRadius = 0;
            this.gunaHideConsole.CheckedState.BorderThickness = 1;
            this.gunaHideConsole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHideConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gunaHideConsole.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaHideConsole.Location = new System.Drawing.Point(11, 145);
            this.gunaHideConsole.Name = "gunaHideConsole";
            this.gunaHideConsole.Size = new System.Drawing.Size(101, 20);
            this.gunaHideConsole.TabIndex = 8;
            this.gunaHideConsole.Text = "Hide console";
            this.gunaHideConsole.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaHideConsole.UncheckedState.BorderRadius = 0;
            this.gunaHideConsole.UncheckedState.BorderThickness = 1;
            this.gunaHideConsole.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            // 
            // gunaForwardedPorts
            // 
            this.gunaForwardedPorts.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaForwardedPorts.CheckedState.BorderRadius = 0;
            this.gunaForwardedPorts.CheckedState.BorderThickness = 1;
            this.gunaForwardedPorts.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaForwardedPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gunaForwardedPorts.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaForwardedPorts.Location = new System.Drawing.Point(11, 119);
            this.gunaForwardedPorts.Name = "gunaForwardedPorts";
            this.gunaForwardedPorts.Size = new System.Drawing.Size(122, 20);
            this.gunaForwardedPorts.TabIndex = 7;
            this.gunaForwardedPorts.Text = "Forwarded ports";
            this.gunaForwardedPorts.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaForwardedPorts.UncheckedState.BorderRadius = 0;
            this.gunaForwardedPorts.UncheckedState.BorderThickness = 1;
            this.gunaForwardedPorts.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            // 
            // gunaOpenFolder
            // 
            this.gunaOpenFolder.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaOpenFolder.CheckedState.BorderRadius = 0;
            this.gunaOpenFolder.CheckedState.BorderThickness = 1;
            this.gunaOpenFolder.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gunaOpenFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaOpenFolder.Location = new System.Drawing.Point(11, 93);
            this.gunaOpenFolder.Name = "gunaOpenFolder";
            this.gunaOpenFolder.Size = new System.Drawing.Size(220, 20);
            this.gunaOpenFolder.TabIndex = 6;
            this.gunaOpenFolder.Text = "Open the folder after compilation";
            this.gunaOpenFolder.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaOpenFolder.UncheckedState.BorderRadius = 0;
            this.gunaOpenFolder.UncheckedState.BorderThickness = 1;
            this.gunaOpenFolder.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            // 
            // buildButton
            // 
            this.buildButton.Animated = true;
            this.buildButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.buildButton.BorderThickness = 1;
            this.buildButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.buildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buildButton.ForeColor = System.Drawing.SystemColors.Control;
            this.buildButton.Location = new System.Drawing.Point(14, 230);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(271, 28);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Build";
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // gunaCopyStartUp
            // 
            this.gunaCopyStartUp.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaCopyStartUp.CheckedState.BorderRadius = 0;
            this.gunaCopyStartUp.CheckedState.BorderThickness = 1;
            this.gunaCopyStartUp.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaCopyStartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gunaCopyStartUp.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaCopyStartUp.Location = new System.Drawing.Point(11, 67);
            this.gunaCopyStartUp.Name = "gunaCopyStartUp";
            this.gunaCopyStartUp.Size = new System.Drawing.Size(122, 20);
            this.gunaCopyStartUp.TabIndex = 0;
            this.gunaCopyStartUp.Text = "Copy to StartUp";
            this.gunaCopyStartUp.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaCopyStartUp.UncheckedState.BorderRadius = 0;
            this.gunaCopyStartUp.UncheckedState.BorderThickness = 1;
            this.gunaCopyStartUp.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.DockIndicatorTransparencyValue = 0.6D;
            this.gunaDragControl.TargetControl = this.guna2TabControl1;
            this.gunaDragControl.UseTransparentDrag = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1230, 630);
            this.Controls.Add(this.guna2TabControl1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "MaliceRAT";
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaVictimsTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private Guna.UI2.WinForms.Guna2DataGridView gunaVictimsTable;
        private Guna.UI2.WinForms.Guna2CheckBox gunaCopyStartUp;
        private Guna.UI2.WinForms.Guna2Button buildButton;
        private Guna.UI2.WinForms.Guna2CheckBox gunaOpenFolder;
        private Guna.UI2.WinForms.Guna2TextBox gunaTextBox1;
        private Guna.UI2.WinForms.Guna2CheckBox gunaForwardedPorts;
        private Guna.UI2.WinForms.Guna2CheckBox gunaHideConsole;
        private Guna.UI2.WinForms.Guna2DragControl gunaDragControl;
        private Guna.UI2.WinForms.Guna2Button gunaFindBuild;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button gunaFindProj;
        private Guna.UI2.WinForms.Guna2TextBox gunaProjPath;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox gunaBuildPath;
        private Guna.UI2.WinForms.Guna2TextBox gunaHostPort;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox gunaHostIP;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button gunaGetMSBuild;
        private System.Windows.Forms.ProgressBar buildDownloadProgressBar;
        private Guna.UI2.WinForms.Guna2Button gunaLAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastActive;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn OS;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC;
    }
}

