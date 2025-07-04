namespace SHOPPE
{
    partial class forgotpassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForgotMsg = new System.Windows.Forms.Label();
            this.btnGetPassword = new System.Windows.Forms.Button();
            this.lnkLoginPage = new System.Windows.Forms.LinkLabel();
            this.txtFPUsername = new System.Windows.Forms.TextBox();
            this.txtHintAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hint";
            // 
            // lblForgotMsg
            // 
            this.lblForgotMsg.AutoSize = true;
            this.lblForgotMsg.Location = new System.Drawing.Point(53, 216);
            this.lblForgotMsg.Name = "lblForgotMsg";
            this.lblForgotMsg.Size = new System.Drawing.Size(0, 20);
            this.lblForgotMsg.TabIndex = 2;
            // 
            // btnGetPassword
            // 
            this.btnGetPassword.Location = new System.Drawing.Point(140, 168);
            this.btnGetPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(84, 29);
            this.btnGetPassword.TabIndex = 3;
            this.btnGetPassword.Text = "Submit";
            this.btnGetPassword.UseVisualStyleBackColor = true;
            // 
            // lnkLoginPage
            // 
            this.lnkLoginPage.AutoSize = true;
            this.lnkLoginPage.Location = new System.Drawing.Point(312, 272);
            this.lnkLoginPage.Name = "lnkLoginPage";
            this.lnkLoginPage.Size = new System.Drawing.Size(89, 20);
            this.lnkLoginPage.TabIndex = 4;
            this.lnkLoginPage.TabStop = true;
            this.lnkLoginPage.Text = "Login Page";
            this.lnkLoginPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginPage_LinkClicked);
            // 
            // txtFPUsername
            // 
            this.txtFPUsername.Location = new System.Drawing.Point(150, 36);
            this.txtFPUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFPUsername.Name = "txtFPUsername";
            this.txtFPUsername.Size = new System.Drawing.Size(148, 26);
            this.txtFPUsername.TabIndex = 5;
            // 
            // txtHintAnswer
            // 
            this.txtHintAnswer.Location = new System.Drawing.Point(150, 94);
            this.txtHintAnswer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHintAnswer.Name = "txtHintAnswer";
            this.txtHintAnswer.Size = new System.Drawing.Size(148, 26);
            this.txtHintAnswer.TabIndex = 6;
            // 
            // forgotpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 396);
            this.Controls.Add(this.txtHintAnswer);
            this.Controls.Add(this.txtFPUsername);
            this.Controls.Add(this.lnkLoginPage);
            this.Controls.Add(this.btnGetPassword);
            this.Controls.Add(this.lblForgotMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "forgotpassword";
            this.Text = "forgotpassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForgotMsg;
        private System.Windows.Forms.Button btnGetPassword;
        private System.Windows.Forms.LinkLabel lnkLoginPage;
        private System.Windows.Forms.TextBox txtFPUsername;
        private System.Windows.Forms.TextBox txtHintAnswer;
    }
}