namespace MaliceRAT.RatUI
{
    partial class ScreenViewForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UpdateButton = new Guna.UI.WinForms.GunaButton();
            this.UpdateIntervalButton = new Guna.UI.WinForms.GunaButton();
            this.StopButton = new Guna.UI.WinForms.GunaButton();
            this.pictureBox = new Guna.UI.WinForms.GunaPictureBox();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.gunaDragControl = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.UpdateButton);
            this.flowLayoutPanel1.Controls.Add(this.UpdateIntervalButton);
            this.flowLayoutPanel1.Controls.Add(this.StopButton);
            this.flowLayoutPanel1.Controls.Add(this.intervalTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 414);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 36);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Animated = true;
            this.UpdateButton.AnimationHoverSpeed = 0.07F;
            this.UpdateButton.AnimationSpeed = 0.03F;
            this.UpdateButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.UpdateButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.UpdateButton.BorderSize = 1;
            this.UpdateButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.UpdateButton.FocusedColor = System.Drawing.Color.Empty;
            this.UpdateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Image = null;
            this.UpdateButton.ImageSize = new System.Drawing.Size(20, 20);
            this.UpdateButton.Location = new System.Drawing.Point(3, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.UpdateButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.UpdateButton.OnHoverForeColor = System.Drawing.Color.White;
            this.UpdateButton.OnHoverImage = null;
            this.UpdateButton.OnPressedColor = System.Drawing.Color.Black;
            this.UpdateButton.Size = new System.Drawing.Size(60, 28);
            this.UpdateButton.TabIndex = 5;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // UpdateIntervalButton
            // 
            this.UpdateIntervalButton.Animated = true;
            this.UpdateIntervalButton.AnimationHoverSpeed = 0.07F;
            this.UpdateIntervalButton.AnimationSpeed = 0.03F;
            this.UpdateIntervalButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.UpdateIntervalButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.UpdateIntervalButton.BorderSize = 1;
            this.UpdateIntervalButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.UpdateIntervalButton.FocusedColor = System.Drawing.Color.Empty;
            this.UpdateIntervalButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UpdateIntervalButton.ForeColor = System.Drawing.Color.White;
            this.UpdateIntervalButton.Image = null;
            this.UpdateIntervalButton.ImageSize = new System.Drawing.Size(20, 20);
            this.UpdateIntervalButton.Location = new System.Drawing.Point(69, 3);
            this.UpdateIntervalButton.Name = "UpdateIntervalButton";
            this.UpdateIntervalButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.UpdateIntervalButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.UpdateIntervalButton.OnHoverForeColor = System.Drawing.Color.White;
            this.UpdateIntervalButton.OnHoverImage = null;
            this.UpdateIntervalButton.OnPressedColor = System.Drawing.Color.Black;
            this.UpdateIntervalButton.Size = new System.Drawing.Size(97, 28);
            this.UpdateIntervalButton.TabIndex = 6;
            this.UpdateIntervalButton.Text = "Update interval";
            this.UpdateIntervalButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateIntervalButton.Click += new System.EventHandler(this.UpdateIntervalButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Animated = true;
            this.StopButton.AnimationHoverSpeed = 0.07F;
            this.StopButton.AnimationSpeed = 0.03F;
            this.StopButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.StopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.StopButton.BorderSize = 1;
            this.StopButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.StopButton.FocusedColor = System.Drawing.Color.Empty;
            this.StopButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StopButton.ForeColor = System.Drawing.Color.White;
            this.StopButton.Image = null;
            this.StopButton.ImageSize = new System.Drawing.Size(20, 20);
            this.StopButton.Location = new System.Drawing.Point(172, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.StopButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.StopButton.OnHoverForeColor = System.Drawing.Color.White;
            this.StopButton.OnHoverImage = null;
            this.StopButton.OnPressedColor = System.Drawing.Color.Black;
            this.StopButton.Size = new System.Drawing.Size(97, 28);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Stop";
            this.StopButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BaseColor = System.Drawing.Color.Transparent;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(799, 380);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(24)))));
            this.intervalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intervalTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.intervalTextBox.Location = new System.Drawing.Point(275, 3);
            this.intervalTextBox.MaxLength = 4;
            this.intervalTextBox.Multiline = true;
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.ShortcutsEnabled = false;
            this.intervalTextBox.Size = new System.Drawing.Size(30, 28);
            this.intervalTextBox.TabIndex = 8;
            this.intervalTextBox.Text = "1000";
            this.intervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervalTextBox.WordWrap = false;
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
            this.titleLabel.Text = "Screen viewer [username]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.TargetControl = this.titleLabel;
            // 
            // ScreenViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenViewForm";
            this.Text = "Screen viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenViewForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI.WinForms.GunaButton UpdateButton;
        private Guna.UI.WinForms.GunaButton UpdateIntervalButton;
        private Guna.UI.WinForms.GunaButton StopButton;
        private Guna.UI.WinForms.GunaPictureBox pictureBox;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl;
    }
}