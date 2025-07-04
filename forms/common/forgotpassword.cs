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
    public partial class forgotpassword : Form
    {
        public forgotpassword()
        {
            InitializeComponent();
        }

        private void lnkLoginPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userlogin objLogin = new userlogin();
            objLogin.Show();
            this.Hide();
        }
    }
}
