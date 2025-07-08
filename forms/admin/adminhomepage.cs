using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SHOPPE
{
    public partial class frmAdminHomepage : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public frmAdminHomepage()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        }

        private void frmAdminHomepage_Load(object sender, EventArgs e)
        {
            LoadCompanyComboBox();
            txtTransID.ReadOnly = true;
            LoadNextTransID();
        }
        private void LoadCompanyComboBox()
        {
            try
            {
                string query = "SELECT CompID, CompName FROM Company ORDER BY CompName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ✅ Thêm dòng "-- Select Company --"
                DataRow emptyRow = dt.NewRow();
                emptyRow["CompID"] = DBNull.Value;
                emptyRow["CompName"] = "-- Select Company --";
                dt.Rows.InsertAt(emptyRow, 0);

                // ✅ Gán cho từng ComboBox (dùng Copy để không dùng chung DataTable)
                cmbCompanyForModel.DataSource = dt.Copy();
                cmbCompanyMobile.DataSource = dt.Copy();
                cmbCompanyStock.DataSource = dt.Copy();

                cmbCompanyForModel.DisplayMember = cmbCompanyMobile.DisplayMember = cmbCompanyStock.DisplayMember = "CompName";
                cmbCompanyForModel.ValueMember = cmbCompanyMobile.ValueMember = cmbCompanyStock.ValueMember = "CompID";

                cmbCompanyForModel.SelectedIndex = 0;
                cmbCompanyMobile.SelectedIndex = 0;
                cmbCompanyStock.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách công ty: " + ex.Message);
            }
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                string compName = txtCompanyName.Text.Trim();
                if (string.IsNullOrEmpty(compName))
                {
                    MessageBox.Show("Vui lòng nhập tên công ty.");
                    return;
                }

                string query = "INSERT INTO Company (CompName) VALUES (@name)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", compName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm công ty thành công!");
                txtCompanyName.Clear();
                LoadCompanyComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm công ty: " + ex.Message);
                conn.Close();
            }
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            try
            {
                string modelName = txtModelNum.Text.Trim();

                // Kiểm tra thông tin
                if (string.IsNullOrEmpty(modelName) || cmbCompanyForModel.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string query = "INSERT INTO Model (ModName, [Available at], CompID) VALUES (@name, 0, @compId)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", modelName);
                cmd.Parameters.AddWithValue("@compId", cmbCompanyForModel.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm model thành công!");
                txtModelNum.Clear();
                cmbCompanyForModel.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm model: " + ex.Message);
                conn.Close();
            }
        }

        private void cmbCompanyMobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompanyMobile.SelectedValue != null && cmbCompanyMobile.SelectedValue != DBNull.Value)
            {
                string query = "SELECT ModID, ModName FROM Model WHERE CompID = @compId ORDER BY ModName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@compId", cmbCompanyMobile.SelectedValue);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ✅ Thêm dòng "-- Select Model --"
                DataRow emptyRow = dt.NewRow();
                emptyRow["ModID"] = DBNull.Value;
                emptyRow["ModName"] = "-- Select Model --";
                dt.Rows.InsertAt(emptyRow, 0);

                cmbModelMobile.DataSource = dt;
                cmbModelMobile.DisplayMember = "ModName";
                cmbModelMobile.ValueMember = "ModID";
                cmbModelMobile.SelectedIndex = 0;
            }
        }

        private void btnAddMobile_Click(object sender, EventArgs e)
        {
            try
            {
                string imei = txtIMEI.Text.Trim();
                string priceText = txtPrice.Text.Trim();
                DateTime warranty = dtpWarranty.Value;
                string status = "Not sold";

                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(priceText) || cmbModelMobile.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }

                // ✅ Lấy số lượng Mobiles hiện tại cho model đó
                string countQuery = "SELECT COUNT(*) FROM Mobiles WHERE ModID = @modId AND Status = 'Not sold'";
                SqlCommand countCmd = new SqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@modId", cmbModelMobile.SelectedValue);

                conn.Open();
                int currentMobiles = (int)countCmd.ExecuteScalar();
                conn.Close();

                // ✅ Lấy tồn kho (Available at) từ bảng Model
                string stockQuery = "SELECT [Available at] FROM Model WHERE ModID = @modId";
                SqlCommand stockCmd = new SqlCommand(stockQuery, conn);
                stockCmd.Parameters.AddWithValue("@modId", cmbModelMobile.SelectedValue);

                conn.Open();
                int stockAvailable = Convert.ToInt32(stockCmd.ExecuteScalar());
                conn.Close();

                // ✅ So sánh tồn kho với số lượng đã thêm
                if (currentMobiles >= stockAvailable)
                {
                    MessageBox.Show("Đã đạt số lượng tối đa trong tồn kho. Vui lòng cập nhật thêm kho trước khi thêm điện thoại.");
                    return;
                }

                // ✅ Thêm Mobile nếu hợp lệ
                string query = @"INSERT INTO Mobiles ([IMEI No], Status, Warranty, Price, ModID)
                         VALUES (@imei, @status, @warranty, @price, @modelId)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@imei", imei);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@warranty", warranty);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@modelId", cmbModelMobile.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm điện thoại thành công!");

                // Reset input
                txtIMEI.Clear();
                txtPrice.Clear();
                dtpWarranty.Value = DateTime.Now;
                cmbModelMobile.SelectedIndex = 0;
                cmbCompanyMobile.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm điện thoại: " + ex.Message);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        private void cmbCompanyStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompanyStock.SelectedValue != null && cmbCompanyStock.SelectedValue != DBNull.Value)
            {
                string query = "SELECT ModID, ModName FROM Model WHERE CompID = @compId ORDER BY ModName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@compId", cmbCompanyStock.SelectedValue);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ✅ Thêm dòng "-- Select Model --"
                DataRow emptyRow = dt.NewRow();
                emptyRow["ModID"] = DBNull.Value;
                emptyRow["ModName"] = "-- Select Model --";
                dt.Rows.InsertAt(emptyRow, 0);

                cmbModelStock.DataSource = dt;
                cmbModelStock.DisplayMember = "ModName";
                cmbModelStock.ValueMember = "ModID";
                cmbModelStock.SelectedIndex = 0;
            }
        }


        private void LoadNextTransID()
        {
            string query = "SELECT ISNULL(MAX(TransID), 0) + 1 FROM [Transaction]";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();
                txtTransID.Text = result?.ToString();
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbModelStock.SelectedIndex <= 0 ||
                    !int.TryParse(txtQuantity.Text, out int qty) ||
                    !decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    MessageBox.Show("Vui lòng nhập đúng thông tin.");
                    return;
                }

                DateTime transDate = DateTime.Now;
                int modelId = (int)cmbModelStock.SelectedValue;

                // Thêm transaction
                string insertTrans = @"
            INSERT INTO [Transaction] (Quantity, Date, Amount, ModID)
            VALUES (@qty, @date, @amount, @modelId);
            SELECT SCOPE_IDENTITY();";

                cmd = new SqlCommand(insertTrans, conn);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@date", transDate);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@modelId", modelId);

                conn.Open();
                object insertedId = cmd.ExecuteScalar();
                conn.Close();

                if (insertedId != null)
                {
                    txtTransID.Text = insertedId.ToString();
                }

                // Cập nhật tồn kho
                string updateQty = @"UPDATE Model 
                             SET [Available at] = CAST([Available at] AS INT) + @qty 
                             WHERE ModID = @modelId";

                cmd = new SqlCommand(updateQty, conn);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@modelId", modelId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật tồn kho thành công!");

                txtQuantity.Clear();
                txtAmount.Clear();
                cmbModelStock.SelectedIndex = 0;
                cmbCompanyStock.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật kho: " + ex.Message);
                conn.Close();
            }
        }

        private void btnViewReportDay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpDate.Value.Date;
                string query = @"
                    SELECT s.SalesID, c.CompName, m.ModName, mo.[IMEI No], s.Price
                    FROM Sales s
                    INNER JOIN Mobiles mo ON s.[IMEI No] = mo.[IMEI No]
                    INNER JOIN Model m ON mo.ModID = m.ModID
                    INNER JOIN Company c ON m.CompID = c.CompID
                    WHERE CAST(s.[Sales Date] AS DATE) = @date";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@date", selectedDate);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSalesReportDay.DataSource = dt;

                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
                lblTotalAmountDay.Text = $"Tổng doanh thu ngày {selectedDate:dd/MM/yyyy}: {total:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo ngày: " + ex.Message);
            }
        }

        private void btnViewReportDateToDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date;

                if (from > to)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc.");
                    return;
                }

                string query = @"
                    SELECT s.SalesID, c.CompName, m.ModName, mo.[IMEI No], s.Price
                    FROM Sales s
                    INNER JOIN Mobiles mo ON s.[IMEI No] = mo.[IMEI No]
                    INNER JOIN Model m ON mo.ModID = m.ModID
                    INNER JOIN Company c ON m.CompID = c.CompID
                    WHERE CAST(s.[Sales Date] AS DATE) BETWEEN @from AND @to";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSalesReportDateToDate.DataSource = dt;

                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
                lblTotalAmountDateToDate.Text = $"Tổng doanh thu từ {from:dd/MM/yyyy} đến {to:dd/MM/yyyy}: {total:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo khoảng ngày: " + ex.Message);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string empName = txtEmpName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string mobile = txtMobile.Text.Trim();
                string userName = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string retypePassword = txtConfirmPassword.Text;
                string hint = txtHint.Text.Trim();

                // Kiểm tra dữ liệu rỗng
                if (string.IsNullOrEmpty(empName) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(retypePassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc.");
                    return;
                }

                // Kiểm tra mật khẩu khớp nhau
                if (password != retypePassword)
                {
                    MessageBox.Show("Mật khẩu và Nhập lại mật khẩu không khớp.");
                    return;
                }

                // Kiểm tra độ dài password
                if (password.Length < 5)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 5 ký tự.");
                    return;
                }

                // Kiểm tra trùng username - SỬA TÊN BẢNG VÀ CỘT
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                cmd = new SqlCommand(checkUserQuery, conn);
                cmd.Parameters.AddWithValue("@username", userName);
                conn.Open();
                int userExists = (int)cmd.ExecuteScalar();
                conn.Close();

                if (userExists > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                    return;
                }

                // Thêm vào cơ sở dữ liệu - SỬA TÊN BẢNG VÀ CỘT CHO KHỚP
                string insertQuery = @"
            INSERT INTO Users (Username, Pass, Employeename, Address, [Mobile No], Hint)
            VALUES (@username, @password, @empName, @address, @mobile, @hint)";

                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", password); // Lưu ý: Chưa mã hoá
                cmd.Parameters.AddWithValue("@empName", empName);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@hint", hint);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm nhân viên thành công!");

                // Xoá dữ liệu sau khi thêm
                txtEmpName.Clear();
                txtAddress.Clear();
                txtMobile.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtHint.Clear();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

    }
}
