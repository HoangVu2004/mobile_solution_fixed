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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 29);
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
            this.btnGetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPassword.Location = new System.Drawing.Point(195, 216);
            this.btnGetPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(116, 52);
            this.btnGetPassword.TabIndex = 3;
            this.btnGetPassword.Text = "Submit";
            this.btnGetPassword.UseVisualStyleBackColor = true;
            this.btnGetPassword.Click += new System.EventHandler(this.btnGetPassword_Click);
            // 
            // lnkLoginPage
            // 
            this.lnkLoginPage.AutoSize = true;
            this.lnkLoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLoginPage.Location = new System.Drawing.Point(320, 318);
            this.lnkLoginPage.Name = "lnkLoginPage";
            this.lnkLoginPage.Size = new System.Drawing.Size(111, 25);
            this.lnkLoginPage.TabIndex = 4;
            this.lnkLoginPage.TabStop = true;
            this.lnkLoginPage.Text = "Login Page";
            this.lnkLoginPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginPage_LinkClicked);
            // 
            // txtFPUsername
            // 
            this.txtFPUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFPUsername.Location = new System.Drawing.Point(171, 53);
            this.txtFPUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFPUsername.Name = "txtFPUsername";
            this.txtFPUsername.Size = new System.Drawing.Size(173, 30);
            this.txtFPUsername.TabIndex = 5;
            // 
            // txtHintAnswer
            // 
            this.txtHintAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHintAnswer.Location = new System.Drawing.Point(171, 128);
            this.txtHintAnswer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHintAnswer.Name = "txtHintAnswer";
            this.txtHintAnswer.Size = new System.Drawing.Size(173, 30);
            this.txtHintAnswer.TabIndex = 6;
            // 
            // forgotpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 446);
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