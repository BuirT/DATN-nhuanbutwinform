using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        private IMongoCollection<BsonDocument> tacgiaCollection;

        public FrmTacGia()
        {
            InitializeComponent();
            KetNoiMongoDB();
        }

        private void KetNoiMongoDB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConn"].ConnectionString;
                string databaseName = ConfigurationManager.AppSettings["DatabaseName"];

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                // Trỏ đúng vào collection TacGia trong file SQL
                tacgiaCollection = database.GetCollection<BsonDocument>("TacGia");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối MongoDB: " + ex.Message, "Lỗi Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            txtMaso.ReadOnly = false;
            // Ép font Segoe UI cho đẹp, bỏ font VNI-Times lỗi thời
            dgvTacGia.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvTacGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            if (cboLoaiTG.Items.Count > 0) cboLoaiTG.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Tải dữ liệu ngầm để không bị đơ giao diện
                var documents = await tacgiaCollection.Find(new BsonDocument()).ToListAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("Maso");
                dt.Columns.Add("MsTG");
                dt.Columns.Add("Hoten");
                dt.Columns.Add("Ngaysinh");
                dt.Columns.Add("LoaiTacgia");
                dt.Columns.Add("Email");
                dt.Columns.Add("Dienthoai");
                dt.Columns.Add("Ddong"); // Đây là Bút danh
                dt.Columns.Add("Diachi");

                foreach (var doc in documents)
                {
                    DataRow row = dt.NewRow();
                    row["Maso"] = doc.GetValue("Maso", "").ToString();
                    row["MsTG"] = doc.GetValue("MsTG", "").ToString();
                    row["Hoten"] = doc.GetValue("Hoten", "").ToString();

                    if (doc.Contains("Ngaysinh") && doc["Ngaysinh"].IsBsonDateTime)
                        row["Ngaysinh"] = doc["Ngaysinh"].ToUniversalTime().ToString("dd/MM/yyyy");
                    else
                        row["Ngaysinh"] = doc.GetValue("Ngaysinh", "").ToString();

                    row["LoaiTacgia"] = doc.GetValue("LoaiTacgia", "").ToString();
                    row["Email"] = doc.GetValue("Email", "").ToString();
                    row["Dienthoai"] = doc.GetValue("Dienthoai", "").ToString();
                    row["Ddong"] = doc.GetValue("Ddong", "").ToString();
                    row["Diachi"] = doc.GetValue("Diachi", "").ToString();
                    dt.Rows.Add(row);
                }

                dgvTacGia.DataSource = dt;

                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["Maso"].HeaderText = "Mã hệ thống";
                    dgvTacGia.Columns["MsTG"].HeaderText = "Mã TG/Thẻ";
                    dgvTacGia.Columns["Hoten"].HeaderText = "Họ và tên";
                    dgvTacGia.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
                    dgvTacGia.Columns["LoaiTacgia"].HeaderText = "Loại";
                    dgvTacGia.Columns["Ddong"].HeaderText = "Bút danh";
                    dgvTacGia.Columns["Dienthoai"].HeaderText = "Điện thoại";
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaso.Clear(); txtMsTG.Clear(); txtHoTen.Clear();
            txtEmail.Clear(); txtDienThoai.Clear(); txtButDanh.Clear(); txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtMaso.ReadOnly = false;
            txtMaso.Focus();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text) || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Đồng chí vui lòng nhập đủ Mã và Tên!", "Nhắc nhở");
                return;
            }

            try
            {
                // Kiểm tra trùng mã trên MongoDB
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", txtMaso.Text);
                var exist = await tacgiaCollection.Find(filter).FirstOrDefaultAsync();
                if (exist != null) { MessageBox.Show("Mã này đã tồn tại!"); return; }

                string loai = cboLoaiTG.SelectedIndex == 0 ? "PV" : (cboLoaiTG.SelectedIndex == 1 ? "CT" : "TN");

                var newDoc = new BsonDocument {
                    { "Maso", txtMaso.Text },
                    { "MsTG", txtMsTG.Text },
                    { "Hoten", txtHoTen.Text },
                    { "Ngaysinh", new BsonDateTime(dtpNgaySinh.Value) },
                    { "LoaiTacgia", loai },
                    { "Email", txtEmail.Text },
                    { "Dienthoai", txtDienThoai.Text },
                    { "Ddong", txtButDanh.Text },
                    { "Diachi", txtDiaChi.Text }
                };

                await tacgiaCollection.InsertOneAsync(newDoc);
                MessageBox.Show("Thêm thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;
            try
            {
                string loai = cboLoaiTG.SelectedIndex == 0 ? "PV" : (cboLoaiTG.SelectedIndex == 1 ? "CT" : "TN");
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", txtMaso.Text);
                var update = Builders<BsonDocument>.Update
                    .Set("MsTG", txtMsTG.Text)
                    .Set("Hoten", txtHoTen.Text)
                    .Set("Ngaysinh", new BsonDateTime(dtpNgaySinh.Value))
                    .Set("LoaiTacgia", loai)
                    .Set("Email", txtEmail.Text)
                    .Set("Dienthoai", txtDienThoai.Text)
                    .Set("Ddong", txtButDanh.Text)
                    .Set("Diachi", txtDiaChi.Text);

                await tacgiaCollection.UpdateOneAsync(filter, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;
            if (MessageBox.Show("Xóa tác giả này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await tacgiaCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Maso", txtMaso.Text));
                btnThem_Click(sender, e);
                await LoadDataAsync();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => btnThem_Click(sender, e);

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTacGia.CurrentRow == null || e.RowIndex < 0) return;
            var row = dgvTacGia.Rows[e.RowIndex];
            txtMaso.Text = row.Cells["Maso"].Value.ToString();
            txtMsTG.Text = row.Cells["MsTG"].Value.ToString();
            txtHoTen.Text = row.Cells["Hoten"].Value.ToString();
            txtMaso.ReadOnly = true;
            if (DateTime.TryParse(row.Cells["Ngaysinh"].Value.ToString(), out DateTime ns)) dtpNgaySinh.Value = ns;
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtDienThoai.Text = row.Cells["Dienthoai"].Value.ToString();
            txtButDanh.Text = row.Cells["Ddong"].Value.ToString();
            txtDiaChi.Text = row.Cells["Diachi"].Value.ToString();
        }
    }
}