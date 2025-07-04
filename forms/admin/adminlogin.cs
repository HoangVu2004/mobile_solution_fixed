using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHOPPE;

namespace SHOPPE
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void lnkBackToUserLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userlogin objLogin = new userlogin();
            objLogin.Show();
            this.Hide();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (txtAdminUser.Text == "admin" && txtAdminPass.Text == "admin")
            {
                frmAdminHomepage objAdminHome = new frmAdminHomepage();
                objAdminHome.Show();
                this.Hide();
            }
            else
            {
                lblAdminMsg.Text = "User is not valid";
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotpassword objLogin = new forgotpassword();
            objLogin.Show();
            this.Hide();
        }
    }
}
