namespace MaliceRAT.RatUI
{
    partial class PasswordManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gunaChromePasswordsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gunaWCMPasswordsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaDragControl = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.exportAsCsvButton = new Guna.UI.WinForms.GunaButton();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaChromePasswordsTable)).BeginInit();
            this.guna2TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaWCMPasswordsTable)).BeginInit();
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
            this.titleLabel.Text = "Password Manager [username]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gunaChromePasswordsTable
            // 
            this.gunaChromePasswordsTable.AllowUserToAddRows = false;
            this.gunaChromePasswordsTable.AllowUserToDeleteRows = false;
            this.gunaChromePasswordsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gunaChromePasswordsTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaChromePasswordsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaChromePasswordsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gunaChromePasswordsTable.ColumnHeadersHeight = 30;
            this.gunaChromePasswordsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnType,
            this.columnSize});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaChromePasswordsTable.DefaultCellStyle = dataGridViewCellStyle16;
            this.gunaChromePasswordsTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaChromePasswordsTable.Location = new System.Drawing.Point(0, 0);
            this.gunaChromePasswordsTable.Margin = new System.Windows.Forms.Padding(0);
            this.gunaChromePasswordsTable.MultiSelect = false;
            this.gunaChromePasswordsTable.Name = "gunaChromePasswordsTable";
            this.gunaChromePasswordsTable.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaChromePasswordsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.gunaChromePasswordsTable.RowHeadersVisible = false;
            this.gunaChromePasswordsTable.RowHeadersWidth = 40;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.gunaChromePasswordsTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaChromePasswordsTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaChromePasswordsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.RowTemplate.ReadOnly = true;
            this.gunaChromePasswordsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaChromePasswordsTable.ShowCellToolTips = false;
            this.gunaChromePasswordsTable.Size = new System.Drawing.Size(796, 345);
            this.gunaChromePasswordsTable.TabIndex = 19;
            this.gunaChromePasswordsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaChromePasswordsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaChromePasswordsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaChromePasswordsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaChromePasswordsTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaChromePasswordsTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gunaChromePasswordsTable.ThemeStyle.HeaderStyle.Height = 30;
            this.gunaChromePasswordsTable.ThemeStyle.ReadOnly = true;
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.Height = 22;
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaChromePasswordsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            // 
            // columnName
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.columnName.DefaultCellStyle = dataGridViewCellStyle15;
            this.columnName.FillWeight = 300F;
            this.columnName.HeaderText = "URL";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnType
            // 
            this.columnType.HeaderText = "Username";
            this.columnType.Name = "columnType";
            this.columnType.ReadOnly = true;
            // 
            // columnSize
            // 
            this.columnSize.HeaderText = "Password";
            this.columnSize.Name = "columnSize";
            this.columnSize.ReadOnly = true;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 25);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.Padding = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(800, 380);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Josefin Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Josefin Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Josefin Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(100, 30);
            this.guna2TabControl1.TabIndex = 20;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.tabPage1.Controls.Add(this.gunaChromePasswordsTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 342);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Chrome";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.tabPage2.Controls.Add(this.gunaWCMPasswordsTable);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 342);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "WCM";
            // 
            // gunaWCMPasswordsTable
            // 
            this.gunaWCMPasswordsTable.AllowUserToAddRows = false;
            this.gunaWCMPasswordsTable.AllowUserToDeleteRows = false;
            this.gunaWCMPasswordsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.gunaWCMPasswordsTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaWCMPasswordsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaWCMPasswordsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.gunaWCMPasswordsTable.ColumnHeadersHeight = 30;
            this.gunaWCMPasswordsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaWCMPasswordsTable.DefaultCellStyle = dataGridViewCellStyle22;
            this.gunaWCMPasswordsTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaWCMPasswordsTable.Location = new System.Drawing.Point(0, 0);
            this.gunaWCMPasswordsTable.Margin = new System.Windows.Forms.Padding(0);
            this.gunaWCMPasswordsTable.MultiSelect = false;
            this.gunaWCMPasswordsTable.Name = "gunaWCMPasswordsTable";
            this.gunaWCMPasswordsTable.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaWCMPasswordsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.gunaWCMPasswordsTable.RowHeadersVisible = false;
            this.gunaWCMPasswordsTable.RowHeadersWidth = 40;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.gunaWCMPasswordsTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaWCMPasswordsTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaWCMPasswordsTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.RowTemplate.ReadOnly = true;
            this.gunaWCMPasswordsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaWCMPasswordsTable.ShowCellToolTips = false;
            this.gunaWCMPasswordsTable.Size = new System.Drawing.Size(796, 345);
            this.gunaWCMPasswordsTable.TabIndex = 20;
            this.gunaWCMPasswordsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaWCMPasswordsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaWCMPasswordsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaWCMPasswordsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaWCMPasswordsTable.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaWCMPasswordsTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gunaWCMPasswordsTable.ThemeStyle.HeaderStyle.Height = 30;
            this.gunaWCMPasswordsTable.ThemeStyle.ReadOnly = true;
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Josefin Sans", 8.25F);
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.Height = 22;
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(27)))));
            this.gunaWCMPasswordsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.Control;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn1.FillWeight = 300F;
            this.dataGridViewTextBoxColumn1.HeaderText = "URL";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Username";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Password";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.TargetControl = this.titleLabel;
            // 
            // exportAsCsvButton
            // 
            this.exportAsCsvButton.Animated = true;
            this.exportAsCsvButton.AnimationHoverSpeed = 0.07F;
            this.exportAsCsvButton.AnimationSpeed = 0.03F;
            this.exportAsCsvButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.exportAsCsvButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.exportAsCsvButton.BorderSize = 1;
            this.exportAsCsvButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportAsCsvButton.FocusedColor = System.Drawing.Color.Empty;
            this.exportAsCsvButton.Font = new System.Drawing.Font("Josefin Sans", 9F);
            this.exportAsCsvButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exportAsCsvButton.Image = null;
            this.exportAsCsvButton.ImageSize = new System.Drawing.Size(20, 20);
            this.exportAsCsvButton.Location = new System.Drawing.Point(12, 414);
            this.exportAsCsvButton.Name = "exportAsCsvButton";
            this.exportAsCsvButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.exportAsCsvButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.exportAsCsvButton.OnHoverForeColor = System.Drawing.Color.White;
            this.exportAsCsvButton.OnHoverImage = null;
            this.exportAsCsvButton.OnPressedColor = System.Drawing.Color.Black;
            this.exportAsCsvButton.Size = new System.Drawing.Size(776, 28);
            this.exportAsCsvButton.TabIndex = 22;
            this.exportAsCsvButton.Text = "Export as CSV";
            this.exportAsCsvButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exportAsCsvButton.Click += new System.EventHandler(this.exportAsCsvButton_Click);
            // 
            // PasswordManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exportAsCsvButton);
            this.Controls.Add(this.guna2TabControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordManagerForm";
            this.Text = "PasswordManagerForm";
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaChromePasswordsTable)).EndInit();
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaWCMPasswordsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2DataGridView gunaChromePasswordsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSize;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2DataGridView gunaWCMPasswordsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Guna.UI.WinForms.GunaButton exportAsCsvButton;
    }
}