using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SHOPPE
{
    public partial class userlogin : Form
    {
        public userlogin()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkAdminlogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminLogin objLogin = new frmAdminLogin();
            objLogin.Show();
            this.Hide();
        }
    }
}
