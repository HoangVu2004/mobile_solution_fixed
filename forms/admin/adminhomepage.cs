using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


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

        private void AutoGenID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(compid), 0) + 1 FROM company";
                cmd = new SqlCommand(query, conn);

                conn.Open();
                int newId = (int)cmd.ExecuteScalar(); // Lấy kết quả duy nhất
                txtCompanyID.Text = newId.ToString();    // Gán vào textbox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadCompanyComboBox()
        {
            try
            {
                string query = "SELECT CompID, CompName FROM Company";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCompanyForModel.DataSource = dt;
                cmbCompanyForModel.DisplayMember = "CompName";
                cmbCompanyForModel.ValueMember = "CompID";
                cmbCompanyForModel.SelectedIndex = -1; // chưa chọn gì
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách công ty: " + ex.Message);
            }
        }

        private void GenerateModelID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(ModelId, 2, LEN(ModelId)) AS INT)), 100) + 1 FROM tbl_Model";
                cmd = new SqlCommand(query, conn);
                conn.Open();
                int newId = (int)cmd.ExecuteScalar();
                txtModelID.Text = "M" + newId.ToString(); // Ví dụ: M101
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo Model ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void GenerateTransID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(TransId, 2, LEN(TransId)) AS INT)), 100) + 1 FROM tbl_Transaction";
                cmd = new SqlCommand(query, conn);
                conn.Open();
                int newId = (int)cmd.ExecuteScalar();
                txtTransID.Text = "T" + newId.ToString(); // ví dụ: T101
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo Trans ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void frmAdminHomepage_Load(object sender, EventArgs e)
        {
            AutoGenID();
            LoadCompanyComboBox();
            GenerateModelID();
            GenerateTransID();
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                int compId = int.Parse(txtCompanyID.Text);
                string compName = txtCompanyName.Text;

                string insertQuery = "INSERT INTO company (compid, compname) VALUES (@compid, @compname)";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@compid", compId);
                cmd.Parameters.AddWithValue("@compname", compName);

                conn.Open();
                cmd.ExecuteNonQuery(); // Thực thi lệnh INSERT

                MessageBox.Show("Thêm công ty thành công!");

                AutoGenID(); // Tạo ID mới sau khi thêm
                txtCompanyName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm công ty: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            try
            {
                string modelId = txtModelID.Text.Trim();
                string modelNum = txtModelNum.Text.Trim();
                string compId = cmbCompanyForModel.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(modelNum) || string.IsNullOrEmpty(compId))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string insertQuery = "INSERT INTO tbl_Model (ModelId, CompId, ModelNum, AvailableQty) VALUES (@modelId, @compId, @modelNum, 0)";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@compId", compId);
                cmd.Parameters.AddWithValue("@modelNum", modelNum);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm model thành công!");

                txtModelNum.Clear();
                cmbCompanyForModel.SelectedIndex = -1;

                // Tạo Model ID mới cho lần tiếp theo
                GenerateModelID();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm model: " + ex.Message);
                conn.Close();
            }
        }

        private void cmbCompanyMobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompanyMobile.SelectedValue != null)
            {
                string compId = cmbCompanyMobile.SelectedValue.ToString();

                string query = "SELECT ModelId, ModelNum FROM tbl_Model WHERE CompId = @compid";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@compid", compId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbModelMobile.DataSource = dt;
                cmbModelMobile.DisplayMember = "ModelNum";
                cmbModelMobile.ValueMember = "ModelId";
                cmbModelMobile.SelectedIndex = -1;
            }
        }


        private void btnAddMobile_Click(object sender, EventArgs e)
        {
            try
            {
                string modelId = cmbModelMobile.SelectedValue?.ToString();
                string imei = txtIMEI.Text.Trim();
                string priceText = txtPrice.Text.Trim();
                DateTime warrantyDate = dtpWarranty.Value;
                string status = "Not sold";

                if (string.IsNullOrEmpty(modelId) || string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(priceText))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }

                string query = "INSERT INTO tbl_Mobile (ModelId, IMEINO, Status, Warranty, Price) " +
                               "VALUES (@modelId, @imei, @status, @warranty, @price)";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@imei", imei);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@warranty", warrantyDate);
                cmd.Parameters.AddWithValue("@price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm điện thoại thành công!");

                // Xoá dữ liệu sau khi thêm
                txtIMEI.Clear();
                txtPrice.Clear();
                dtpWarranty.Value = DateTime.Now;
                cmbModelMobile.SelectedIndex = -1;
                cmbCompanyMobile.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm điện thoại: " + ex.Message);
                conn.Close();
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            try
            {
                string transId = txtTransID.Text.Trim();
                string modelId = cmbModelStock.SelectedValue?.ToString();
                string quantityText = txtQuantity.Text.Trim();
                string amountText = txtAmount.Text.Trim();
                DateTime transDate = DateTime.Now;

                if (string.IsNullOrEmpty(modelId) || string.IsNullOrEmpty(quantityText) || string.IsNullOrEmpty(amountText))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ.");
                    return;
                }

                // Bắt đầu insert vào tbl_Transaction
                string insertQuery = "INSERT INTO tbl_Transaction (TransId, ModelId, Quantity, Date, Amount) " +
                                     "VALUES (@transId, @modelId, @quantity, @date, @amount)";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@transId", transId);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@date", transDate);
                cmd.Parameters.AddWithValue("@amount", amount);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                // Tiếp theo, cập nhật AvailableQty trong tbl_Model
                string updateQtyQuery = "UPDATE tbl_Model SET AvailableQty = AvailableQty + @quantity WHERE ModelId = @modelId";
                cmd = new SqlCommand(updateQtyQuery, conn);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@modelId", modelId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật tồn kho thành công!");

                // Reset form
                txtQuantity.Clear();
                txtAmount.Clear();
                cmbCompanyStock.SelectedIndex = -1;
                cmbModelStock.SelectedIndex = -1;
                GenerateTransID(); // Tạo mã giao dịch mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tồn kho: " + ex.Message);
                conn.Close();
            }
        }

        private void btnViewReportDay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpDate.Value.Date;

                string query = @"
            SELECT 
                s.SId,
                c.CompName,
                m.ModelNum,
                mo.IMEINO,
                s.Price
            FROM tbl_Sales s
            INNER JOIN tbl_Mobile mo ON s.IMEINO = mo.IMEINO
            INNER JOIN tbl_Model m ON mo.ModelId = m.ModelId
            INNER JOIN tbl_Company c ON m.CompId = c.CompId
            WHERE CAST(s.PurchaseDate AS DATE) = @selectedDate";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@selectedDate", selectedDate);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSalesReportDay.DataSource = dt;

                // Tính tổng doanh thu
                decimal totalSales = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Price"].ToString(), out decimal price))
                    {
                        totalSales += price;
                    }
                }

                lblTotalAmountDay.Text = $"Tổng doanh thu ngày {selectedDate.ToShortDateString()} là: {totalSales:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo bán hàng: " + ex.Message);
            }
        }

        private void btnViewReportDateToDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtpFrom.Value.Date;
                DateTime endDate = dtpTo.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                    return;
                }

                string query = @"
            SELECT 
                s.SId,
                c.CompName,
                m.ModelNum,
                mo.IMEINO,
                s.Price
            FROM tbl_Sales s
            INNER JOIN tbl_Mobile mo ON s.IMEINO = mo.IMEINO
            INNER JOIN tbl_Model m ON mo.ModelId = m.ModelId
            INNER JOIN tbl_Company c ON m.CompId = c.CompId
            WHERE CAST(s.PurchaseDate AS DATE) BETWEEN @startDate AND @endDate";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                da.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSalesReportDateToDate.DataSource = dt;

                // Tính tổng doanh thu
                decimal totalSales = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Price"].ToString(), out decimal price))
                    {
                        totalSales += price;
                    }
                }

                lblTotalAmountDateToDate.Text = $"Tổng doanh thu từ {startDate:dd/MM/yyyy} đến {endDate:dd/MM/yyyy} là: {totalSales:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo khoảng ngày: " + ex.Message);
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

                // Kiểm tra trùng username
                string checkUserQuery = "SELECT COUNT(*) FROM tbl_User WHERE UserName = @username";
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

                // Thêm vào cơ sở dữ liệu
                string insertQuery = @"
            INSERT INTO tbl_User (UserName, PWD, EmployeeName, Address, MobileNumber, Hint)
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
