using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SHOPPE
{
    public partial class userlogin : Form
    {
        SqlConnection conn;

        public userlogin()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }

            try
            {
                // SỬA: Đổi tên bảng từ tbl_User thành Users
                // SỬA: Đổi tên cột từ UserName thành Username, PWD thành Pass
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Pass = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    if (count == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công!");

                        // Mở form homepage
                        userhomepage homepage = new userhomepage();
                        homepage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Vui lòng thử lại.");

                        // Xóa password để bảo mật
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show($"Lỗi SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show($"Lỗi khi đăng nhập: {ex.Message}");
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotpassword objLogin = new forgotpassword();
            objLogin.Show();
            this.Hide();
        }

        private void lnkAdminlogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminLogin objLogin = new frmAdminLogin();
            objLogin.Show();
            this.Hide();
        }
    }
}
