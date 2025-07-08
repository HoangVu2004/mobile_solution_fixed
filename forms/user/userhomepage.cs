using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SHOPPE
{
    public partial class userhomepage : Form
    {
        SqlConnection conn;

        public userhomepage()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        }

        private void userhomepage_Load(object sender, EventArgs e)
        {
            LoadSaleCompanies();
            LoadStockCompanies();

            txtStockAvailable.ReadOnly = true;
            txtStockAvailable.Text = "0";
            txtSalePrice.ReadOnly = true;

            SetupCustomerGrid();
        }

        private void LoadSaleCompanies()
        {
            try
            {
                string query = "SELECT CompID, CompName FROM Company ORDER BY CompName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow emptyRow = dt.NewRow();
                emptyRow["CompID"] = DBNull.Value;
                emptyRow["CompName"] = "-- Select Company --";
                dt.Rows.InsertAt(emptyRow, 0);

                cmbSaleCompany.DisplayMember = "CompName";
                cmbSaleCompany.ValueMember = "CompID";
                cmbSaleCompany.DataSource = dt;
                cmbSaleCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading companies: " + ex.Message);
            }
        }

        private void LoadStockCompanies()
        {
            try
            {
                string query = "SELECT CompID, CompName FROM Company ORDER BY CompName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow emptyRow = dt.NewRow();
                emptyRow["CompID"] = DBNull.Value;
                emptyRow["CompName"] = "-- Select Company --";
                dt.Rows.InsertAt(emptyRow, 0);

                cmbStockCompany.DisplayMember = "CompName";
                cmbStockCompany.ValueMember = "CompID";
                cmbStockCompany.DataSource = dt;
                cmbStockCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock companies: " + ex.Message);
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSaleModel.DataSource = null;
            cmbIMEI.DataSource = null;
            txtSalePrice.Text = "";

            if (cmbSaleCompany.SelectedIndex > 0 && cmbSaleCompany.SelectedValue != null && cmbSaleCompany.SelectedValue != DBNull.Value)
            {
                try
                {
                    string compId = cmbSaleCompany.SelectedValue.ToString();
                    string query = "SELECT ModID, ModName FROM Model WHERE CompID = @compId ORDER BY ModName";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@compId", compId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow emptyRow = dt.NewRow();
                    emptyRow["ModID"] = DBNull.Value;
                    emptyRow["ModName"] = "-- Select Model --";
                    dt.Rows.InsertAt(emptyRow, 0);

                    cmbSaleModel.DisplayMember = "ModName";
                    cmbSaleModel.ValueMember = "ModID";
                    cmbSaleModel.DataSource = dt;
                    cmbSaleModel.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading models: " + ex.Message);
                }
            }
        }


        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIMEI.DataSource = null;
            txtSalePrice.Text = "";

            if (cmbSaleModel.SelectedIndex > 0 && cmbSaleModel.SelectedValue != null && cmbSaleModel.SelectedValue != DBNull.Value)
            {
                try
                {
                    string modelId = cmbSaleModel.SelectedValue.ToString();
                    string query = "SELECT [IMEI No] FROM Mobiles WHERE ModID = @modelId AND Status = 'Not sold'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@modelId", modelId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // ✅ Thêm dòng "-- Select IMEI --"
                    DataRow emptyRow = dt.NewRow();
                    emptyRow["IMEI No"] = "-- Select IMEI --"; // giá trị hiển thị
                    dt.Rows.InsertAt(emptyRow, 0); // thêm lên đầu

                    cmbIMEI.DisplayMember = "IMEI No";
                    cmbIMEI.ValueMember = "IMEI No";
                    cmbIMEI.DataSource = dt;
                    cmbIMEI.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading IMEIs: " + ex.Message);
                }
            }
        }



        private void cmbStockCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStockModel.DataSource = null;
            txtStockAvailable.Text = "0";

            if (cmbStockCompany.SelectedValue != null && cmbStockCompany.SelectedValue != DBNull.Value)
            {
                try
                {
                    string compId = cmbStockCompany.SelectedValue.ToString();
                    string query = "SELECT ModID, ModName FROM Model WHERE CompID = @compId ORDER BY ModName";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@compId", compId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow emptyRow = dt.NewRow();
                    emptyRow["ModID"] = DBNull.Value;
                    emptyRow["ModName"] = "-- Select Model --";
                    dt.Rows.InsertAt(emptyRow, 0);

                    cmbStockModel.DisplayMember = "ModName";
                    cmbStockModel.ValueMember = "ModID";
                    cmbStockModel.DataSource = dt;
                    cmbStockModel.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading models: " + ex.Message);
                }
            }
        }

        private void cmbStockModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStockAvailable.Text = "0";

            if (cmbStockModel.SelectedValue != null && cmbStockModel.SelectedValue != DBNull.Value)
            {
                try
                {
                    string modelId = cmbStockModel.SelectedValue.ToString();
                    string query = "SELECT [Available at] FROM Model WHERE ModID = @modelId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@modelId", modelId);

                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        conn.Close();

                        txtStockAvailable.Text = result != null ? result.ToString() : "0";
                        txtStockAvailable.ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    MessageBox.Show("Lỗi khi lấy tồn kho: " + ex.Message);
                    txtStockAvailable.Text = "0";
                }
            }
        }

        private void cmbIMEI_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalePrice.Text = ""; // reset

            // ✅ Kiểm tra hợp lệ: không xử lý nếu đang ở dòng "-- Select IMEI --"
            if (cmbIMEI.SelectedIndex > 0 && cmbIMEI.SelectedValue != null && cmbIMEI.SelectedValue != DBNull.Value)
            {
                try
                {
                    string imei = cmbIMEI.SelectedValue.ToString();
                    string query = "SELECT Price FROM Mobiles WHERE [IMEI No] = @imei";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@imei", imei);

                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        conn.Close();

                        if (result != null)
                        {
                            txtSalePrice.Text = result.ToString();
                        }
                        else
                        {
                            txtSalePrice.Text = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    MessageBox.Show("Lỗi khi lấy giá: " + ex.Message);
                }
            }
            else
            {
                txtSalePrice.Text = ""; // không chọn IMEI thì reset giá
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string custName = txtCustName.Text.Trim();
            string mobile = txtCustMobile.Text.Trim();
            string address = txtCustAddress.Text.Trim();
            string email = txtCustEmail.Text.Trim();
            string companyName = cmbSaleCompany.Text;
            string modelNum = cmbSaleModel.Text;
            string imei = cmbIMEI.Text;
            string price = txtSalePrice.Text.Trim();

            if (string.IsNullOrEmpty(custName) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(modelNum) ||
                string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            confirmdetail confirm = new confirmdetail(custName, mobile, address, email, companyName, modelNum, imei, price);
            confirm.Show();
            this.Hide();
        }

        private void btnSearchIMEI_Click(object sender, EventArgs e)
        {
            string imei = txtSearchIMEI.Text.Trim();

            if (string.IsNullOrEmpty(imei))
            {
                MessageBox.Show("Please enter an IMEI number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT C.CustName, C.[Mobile No], C.Mail, C.Address
                FROM Customers C
                INNER JOIN Sales S ON C.CustID = S.CustID
                WHERE S.[IMEI No] = @imei";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@imei", imei);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                da.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    dgvCustomerByIMEI.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No customer found with this IMEI number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCustomerByIMEI.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void SetupCustomerGrid()
        {
            dgvCustomerByIMEI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerByIMEI.ReadOnly = true;
            dgvCustomerByIMEI.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerByIMEI.MultiSelect = false;
            dgvCustomerByIMEI.AllowUserToAddRows = false;
        }
    }
}
