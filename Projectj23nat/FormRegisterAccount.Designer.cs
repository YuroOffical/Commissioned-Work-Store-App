namespace Projectj23nat
{
    partial class FormRegisterAccount
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
            this.tbox_name = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.tbox_pass = new System.Windows.Forms.TextBox();
            this.adwwd = new System.Windows.Forms.Label();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_submit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_skip = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbox_name
            // 
            this.tbox_name.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_name.Location = new System.Drawing.Point(16, 35);
            this.tbox_name.Name = "tbox_name";
            this.tbox_name.Size = new System.Drawing.Size(269, 27);
            this.tbox_name.TabIndex = 34;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Username.Font = new System.Drawing.Font("Inter Light", 14F);
            this.Username.ForeColor = System.Drawing.Color.Black;
            this.Username.Location = new System.Drawing.Point(12, 9);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(101, 23);
            this.Username.TabIndex = 33;
            this.Username.Text = "Username";
            // 
            // tbox_pass
            // 
            this.tbox_pass.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_pass.Location = new System.Drawing.Point(16, 105);
            this.tbox_pass.Name = "tbox_pass";
            this.tbox_pass.Size = new System.Drawing.Size(269, 27);
            this.tbox_pass.TabIndex = 36;
            // 
            // adwwd
            // 
            this.adwwd.AutoSize = true;
            this.adwwd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adwwd.Font = new System.Drawing.Font("Inter Light", 14F);
            this.adwwd.ForeColor = System.Drawing.Color.Black;
            this.adwwd.Location = new System.Drawing.Point(12, 79);
            this.adwwd.Name = "adwwd";
            this.adwwd.Size = new System.Drawing.Size(98, 23);
            this.adwwd.TabIndex = 35;
            this.adwwd.Text = "Password";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BorderRadius = 20;
            this.btn_cancel.BorderThickness = 1;
            this.btn_cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancel.FillColor = System.Drawing.Color.White;
            this.btn_cancel.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.Location = new System.Drawing.Point(16, 155);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(124, 40);
            this.btn_cancel.TabIndex = 51;
            this.btn_cancel.Text = "Back";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BorderRadius = 20;
            this.btn_submit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_submit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_submit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_submit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_submit.FillColor = System.Drawing.Color.Red;
            this.btn_submit.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(146, 155);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(139, 40);
            this.btn_submit.TabIndex = 50;
            this.btn_submit.Text = "Create";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_skip
            // 
            this.btn_skip.BorderRadius = 20;
            this.btn_skip.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_skip.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_skip.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_skip.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_skip.FillColor = System.Drawing.Color.Red;
            this.btn_skip.Font = new System.Drawing.Font("Inter SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_skip.ForeColor = System.Drawing.Color.White;
            this.btn_skip.Location = new System.Drawing.Point(146, 198);
            this.btn_skip.Name = "btn_skip";
            this.btn_skip.Size = new System.Drawing.Size(139, 40);
            this.btn_skip.TabIndex = 52;
            this.btn_skip.Text = "Skip";
            // 
            // FormRegisterAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(297, 247);
            this.Controls.Add(this.btn_skip);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.tbox_pass);
            this.Controls.Add(this.adwwd);
            this.Controls.Add(this.tbox_name);
            this.Controls.Add(this.Username);
            this.Name = "FormRegisterAccount";
            this.Text = "FormRegisterAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_name;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox tbox_pass;
        private System.Windows.Forms.Label adwwd;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_submit;
        private Guna.UI2.WinForms.Guna2Button btn_skip;
    }
}