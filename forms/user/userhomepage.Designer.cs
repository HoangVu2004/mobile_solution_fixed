namespace SHOPPE
{
    partial class userhomepage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbIMEI = new System.Windows.Forms.ComboBox();
            this.cmbSaleModel = new System.Windows.Forms.ComboBox();
            this.cmbSaleCompany = new System.Windows.Forms.ComboBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.txtCustEmail = new System.Windows.Forms.TextBox();
            this.txtCustAddress = new System.Windows.Forms.TextBox();
            this.txtCustMobile = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.btnSubmitSale = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbStockModel = new System.Windows.Forms.ComboBox();
            this.cmbStockCompany = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStockAvailable = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSearchIMEI = new System.Windows.Forms.Button();
            this.dgvCustomerByIMEI = new System.Windows.Forms.DataGridView();
            this.txtSearchIMEI = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerByIMEI)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 666);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbIMEI);
            this.tabPage1.Controls.Add(this.cmbSaleModel);
            this.tabPage1.Controls.Add(this.cmbSaleCompany);
            this.tabPage1.Controls.Add(this.txtSalePrice);
            this.tabPage1.Controls.Add(this.txtCustEmail);
            this.tabPage1.Controls.Add(this.txtCustAddress);
            this.tabPage1.Controls.Add(this.txtCustMobile);
            this.tabPage1.Controls.Add(this.txtCustName);
            this.tabPage1.Controls.Add(this.btnSubmitSale);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(548, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbIMEI
            // 
            this.cmbIMEI.FormattingEnabled = true;
            this.cmbIMEI.Location = new System.Drawing.Point(239, 393);
            this.cmbIMEI.Name = "cmbIMEI";
            this.cmbIMEI.Size = new System.Drawing.Size(187, 28);
            this.cmbIMEI.TabIndex = 21;
            this.cmbIMEI.SelectedIndexChanged += new System.EventHandler(this.cmbIMEI_SelectedIndexChanged);
            // 
            // cmbSaleModel
            // 
            this.cmbSaleModel.FormattingEnabled = true;
            this.cmbSaleModel.Location = new System.Drawing.Point(239, 342);
            this.cmbSaleModel.Name = "cmbSaleModel";
            this.cmbSaleModel.Size = new System.Drawing.Size(187, 28);
            this.cmbSaleModel.TabIndex = 20;
            this.cmbSaleModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // cmbSaleCompany
            // 
            this.cmbSaleCompany.FormattingEnabled = true;
            this.cmbSaleCompany.Location = new System.Drawing.Point(240, 291);
            this.cmbSaleCompany.Name = "cmbSaleCompany";
            this.cmbSaleCompany.Size = new System.Drawing.Size(186, 28);
            this.cmbSaleCompany.TabIndex = 19;
            this.cmbSaleCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(239, 448);
            this.txtSalePrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(130, 26);
            this.txtSalePrice.TabIndex = 18;
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.Location = new System.Drawing.Point(239, 241);
            this.txtCustEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(187, 26);
            this.txtCustEmail.TabIndex = 14;
            // 
            // txtCustAddress
            // 
            this.txtCustAddress.Location = new System.Drawing.Point(239, 185);
            this.txtCustAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustAddress.Name = "txtCustAddress";
            this.txtCustAddress.Size = new System.Drawing.Size(187, 26);
            this.txtCustAddress.TabIndex = 13;
            // 
            // txtCustMobile
            // 
            this.txtCustMobile.Location = new System.Drawing.Point(239, 131);
            this.txtCustMobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustMobile.Name = "txtCustMobile";
            this.txtCustMobile.Size = new System.Drawing.Size(187, 26);
            this.txtCustMobile.TabIndex = 12;
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(239, 81);
            this.txtCustName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(187, 26);
            this.txtCustName.TabIndex = 11;
            // 
            // btnSubmitSale
            // 
            this.btnSubmitSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitSale.Location = new System.Drawing.Point(184, 524);
            this.btnSubmitSale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmitSale.Name = "btnSubmitSale";
            this.btnSubmitSale.Size = new System.Drawing.Size(108, 58);
            this.btnSubmitSale.TabIndex = 10;
            this.btnSubmitSale.Text = "Submit";
            this.btnSubmitSale.UseVisualStyleBackColor = true;
            this.btnSubmitSale.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(178, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 32);
            this.label9.TabIndex = 9;
            this.label9.Text = "Sales";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 449);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "Price/piece";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "IMEI Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Model Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Company Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mobile Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbStockModel);
            this.tabPage2.Controls.Add(this.cmbStockCompany);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtStockAvailable);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(548, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbStockModel
            // 
            this.cmbStockModel.FormattingEnabled = true;
            this.cmbStockModel.Location = new System.Drawing.Point(276, 185);
            this.cmbStockModel.Name = "cmbStockModel";
            this.cmbStockModel.Size = new System.Drawing.Size(182, 28);
            this.cmbStockModel.TabIndex = 8;
            this.cmbStockModel.SelectedIndexChanged += new System.EventHandler(this.cmbStockModel_SelectedIndexChanged);
            // 
            // cmbStockCompany
            // 
            this.cmbStockCompany.FormattingEnabled = true;
            this.cmbStockCompany.Location = new System.Drawing.Point(276, 115);
            this.cmbStockCompany.Name = "cmbStockCompany";
            this.cmbStockCompany.Size = new System.Drawing.Size(182, 28);
            this.cmbStockCompany.TabIndex = 7;
            this.cmbStockCompany.SelectedIndexChanged += new System.EventHandler(this.cmbStockCompany_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(138, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 32);
            this.label13.TabIndex = 6;
            this.label13.Text = "View Stock";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 25);
            this.label12.TabIndex = 5;
            this.label12.Text = "Stock Available";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 25);
            this.label11.TabIndex = 4;
            this.label11.Text = "Select Model Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "Select Company Name";
            // 
            // txtStockAvailable
            // 
            this.txtStockAvailable.Location = new System.Drawing.Point(276, 266);
            this.txtStockAvailable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStockAvailable.Name = "txtStockAvailable";
            this.txtStockAvailable.Size = new System.Drawing.Size(139, 26);
            this.txtStockAvailable.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSearchIMEI);
            this.tabPage3.Controls.Add(this.dgvCustomerByIMEI);
            this.tabPage3.Controls.Add(this.txtSearchIMEI);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(548, 633);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Search customerby EMI";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSearchIMEI
            // 
            this.btnSearchIMEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchIMEI.Location = new System.Drawing.Point(194, 193);
            this.btnSearchIMEI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchIMEI.Name = "btnSearchIMEI";
            this.btnSearchIMEI.Size = new System.Drawing.Size(124, 55);
            this.btnSearchIMEI.TabIndex = 4;
            this.btnSearchIMEI.Text = "Search";
            this.btnSearchIMEI.UseVisualStyleBackColor = true;
            this.btnSearchIMEI.Click += new System.EventHandler(this.btnSearchIMEI_Click);
            // 
            // dgvCustomerByIMEI
            // 
            this.dgvCustomerByIMEI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerByIMEI.Location = new System.Drawing.Point(3, 323);
            this.dgvCustomerByIMEI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCustomerByIMEI.Name = "dgvCustomerByIMEI";
            this.dgvCustomerByIMEI.RowHeadersWidth = 51;
            this.dgvCustomerByIMEI.RowTemplate.Height = 24;
            this.dgvCustomerByIMEI.Size = new System.Drawing.Size(539, 188);
            this.dgvCustomerByIMEI.TabIndex = 3;
            // 
            // txtSearchIMEI
            // 
            this.txtSearchIMEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchIMEI.Location = new System.Drawing.Point(251, 95);
            this.txtSearchIMEI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchIMEI.Name = "txtSearchIMEI";
            this.txtSearchIMEI.Size = new System.Drawing.Size(255, 30);
            this.txtSearchIMEI.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(217, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "Enter IMEI Number";
            // 
            // userhomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 717);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "userhomepage";
            this.Text = "Userhomepage";
            this.Load += new System.EventHandler(this.userhomepage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerByIMEI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmitSale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.TextBox txtCustEmail;
        private System.Windows.Forms.TextBox txtCustAddress;
        private System.Windows.Forms.TextBox txtCustMobile;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStockAvailable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearchIMEI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCustomerByIMEI;
        private System.Windows.Forms.Button btnSearchIMEI;
        private System.Windows.Forms.ComboBox cmbIMEI;
        private System.Windows.Forms.ComboBox cmbSaleModel;
        private System.Windows.Forms.ComboBox cmbSaleCompany;
        private System.Windows.Forms.ComboBox cmbStockModel;
        private System.Windows.Forms.ComboBox cmbStockCompany;
    }
}