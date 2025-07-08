using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SHOPPE
{
    public partial class confirmdetail : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        string custName, mobile, address, email, company, model, imei, price;

        public confirmdetail(string custName, string mobile, string address, string email,
                             string company, string model, string imei, string price)
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());

            this.custName = custName;
            this.mobile = mobile;
            this.address = address;
            this.email = email;
            this.company = company;
            this.model = model;
            this.imei = imei;
            this.price = price;

            lblCustName.Text = custName;
            lblMobile.Text = mobile;
            lblAddress.Text = address;
            lblEmail.Text = email;
            lblCompany.Text = company;
            lblModel.Text = model;
            lblIMEI.Text = imei;
            lblPrice.Text = price;

            LoadWarranty();
        }

        private void LoadWarranty()
        {
            try
            {
                string query = "SELECT Warranty FROM Mobiles WHERE [IMEI No] = @imei";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@imei", imei);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    DateTime warrantyDate = Convert.ToDateTime(result);
                    lblWarranty.Text = warrantyDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    lblWarranty.Text = "Không có thông tin";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải bảo hành: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                // 1. Insert into Customers
                string insertCustomer = @"INSERT INTO Customers (CustName, [Mobile No], Mail, Address)
                                          VALUES (@name, @mobile, @email, @addr);
                                          SELECT SCOPE_IDENTITY();";

                cmd = new SqlCommand(insertCustomer, conn, tran);
                cmd.Parameters.AddWithValue("@name", custName);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@addr", address);
                int custId = Convert.ToInt32(cmd.ExecuteScalar());

                // 2. Insert into Sales
                string insertSales = @"INSERT INTO Sales ([Sales Date], [IMEI No], Price, CustID)
                                       VALUES (@date, @imei, @price, @custId)";
                cmd = new SqlCommand(insertSales, conn, tran);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@imei", imei);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(price));
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.ExecuteNonQuery();

                // 3. Update IMEI status in Mobiles
                string updateMobile = "UPDATE Mobiles SET Status = 'Sold' WHERE [IMEI No] = @imei";
                cmd = new SqlCommand(updateMobile, conn, tran);
                cmd.Parameters.AddWithValue("@imei", imei);
                cmd.ExecuteNonQuery();

                // 4. Giảm AvailableQty trong Model
                string getModelId = "SELECT ModID FROM Mobiles WHERE [IMEI No] = @imei";
                cmd = new SqlCommand(getModelId, conn, tran);
                cmd.Parameters.AddWithValue("@imei", imei);
                object result = cmd.ExecuteScalar();


                if (result != null)
                {
                    int modId = Convert.ToInt32(result);
                    string updateQty = "UPDATE Model SET [Available at] = [Available at] - 1 WHERE ModID = @modId";
                    cmd = new SqlCommand(updateQty, conn, tran);
                    cmd.Parameters.AddWithValue("@modId", modId);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Giao dịch đã được xác nhận và lưu vào hệ thống!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Application.OpenForms["userhomepage"]?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện giao dịch: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["userhomepage"]?.Show();
        }
    }
}
