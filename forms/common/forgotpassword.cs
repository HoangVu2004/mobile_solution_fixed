using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPPE
{
    public partial class forgotpassword : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public forgotpassword()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        }

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            string username = txtFPUsername.Text.Trim();
            string hint = txtHintAnswer.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(hint))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Hint.");
                return;
            }

            try
            {
                // Đúng tên bảng là "Users", đúng tên cột là "Pass" và "Hint"
                string query = "SELECT Pass FROM Users WHERE Username = @username AND Hint = @hint";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@hint", hint);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    lblForgotMsg.Text = $"Mật khẩu của bạn là: {result.ToString()}";
                    lblForgotMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblForgotMsg.Text = "Sai Username hoặc Hint. Vui lòng thử lại.";
                    lblForgotMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi truy vấn: " + ex.Message);
            }
        }

        private void lnkLoginPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userlogin objLogin = new userlogin();
            objLogin.Show();
            this.Hide();
        }
    }
}
