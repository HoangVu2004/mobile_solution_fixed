namespace SHOPPE
{
    partial class frmAdminLogin
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
            this.lnkBackToUserLogin = new System.Windows.Forms.LinkLabel();
            this.lblAdminUser = new System.Windows.Forms.Label();
            this.lblAdminPass = new System.Windows.Forms.Label();
            this.txtAdminUser = new System.Windows.Forms.TextBox();
            this.txtAdminPass = new System.Windows.Forms.TextBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lblAdminMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnkBackToUserLogin
            // 
            this.lnkBackToUserLogin.AutoSize = true;
            this.lnkBackToUserLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBackToUserLogin.ForeColor = System.Drawing.Color.Black;
            this.lnkBackToUserLogin.LinkColor = System.Drawing.Color.Black;
            this.lnkBackToUserLogin.Location = new System.Drawing.Point(45, 34);
            this.lnkBackToUserLogin.Name = "lnkBackToUserLogin";
            this.lnkBackToUserLogin.Size = new System.Drawing.Size(66, 29);
            this.lnkBackToUserLogin.TabIndex = 0;
            this.lnkBackToUserLogin.TabStop = true;
            this.lnkBackToUserLogin.Text = "Back";
            this.lnkBackToUserLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBackToUserLogin_LinkClicked);
            // 
            // lblAdminUser
            // 
            this.lblAdminUser.AutoSize = true;
            this.lblAdminUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUser.Location = new System.Drawing.Point(83, 108);
            this.lblAdminUser.Name = "lblAdminUser";
            this.lblAdminUser.Size = new System.Drawing.Size(135, 29);
            this.lblAdminUser.TabIndex = 1;
            this.lblAdminUser.Text = "UserName:";
            // 
            // lblAdminPass
            // 
            this.lblAdminPass.AutoSize = true;
            this.lblAdminPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPass.Location = new System.Drawing.Point(83, 168);
            this.lblAdminPass.Name = "lblAdminPass";
            this.lblAdminPass.Size = new System.Drawing.Size(126, 29);
            this.lblAdminPass.TabIndex = 2;
            this.lblAdminPass.Text = "Password:";
            // 
            // txtAdminUser
            // 
            this.txtAdminUser.Location = new System.Drawing.Point(256, 111);
            this.txtAdminUser.Name = "txtAdminUser";
            this.txtAdminUser.Size = new System.Drawing.Size(155, 26);
            this.txtAdminUser.TabIndex = 3;
            // 
            // txtAdminPass
            // 
            this.txtAdminPass.Location = new System.Drawing.Point(257, 172);
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.PasswordChar = '*';
            this.txtAdminPass.Size = new System.Drawing.Size(154, 26);
            this.txtAdminPass.TabIndex = 4;
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminLogin.Location = new System.Drawing.Point(292, 247);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(100, 44);
            this.btnAdminLogin.TabIndex = 5;
            this.btnAdminLogin.Text = "Login";
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.Black;
            this.lnkForgotPassword.Location = new System.Drawing.Point(45, 255);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(209, 29);
            this.lnkForgotPassword.TabIndex = 6;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot Password?";
            // 
            // lblAdminMsg
            // 
            this.lblAdminMsg.AutoSize = true;
            this.lblAdminMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminMsg.ForeColor = System.Drawing.Color.Red;
            this.lblAdminMsg.Location = new System.Drawing.Point(200, 332);
            this.lblAdminMsg.Name = "lblAdminMsg";
            this.lblAdminMsg.Size = new System.Drawing.Size(0, 29);
            this.lblAdminMsg.TabIndex = 7;
            // 
            // frmAdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 402);
            this.Controls.Add(this.lblAdminMsg);
            this.Controls.Add(this.lnkForgotPassword);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.txtAdminPass);
            this.Controls.Add(this.txtAdminUser);
            this.Controls.Add(this.lblAdminPass);
            this.Controls.Add(this.lblAdminUser);
            this.Controls.Add(this.lnkBackToUserLogin);
            this.Name = "frmAdminLogin";
            this.Text = "Adminlogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkBackToUserLogin;
        private System.Windows.Forms.Label lblAdminUser;
        private System.Windows.Forms.Label lblAdminPass;
        private System.Windows.Forms.TextBox txtAdminUser;
        private System.Windows.Forms.TextBox txtAdminPass;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.Label lblAdminMsg;
    }
}

