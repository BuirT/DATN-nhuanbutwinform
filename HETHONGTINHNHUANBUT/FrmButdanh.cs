using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButdanh : Form
    {
        private IMongoCollection<BsonDocument> butdanhCollection;
        private IMongoCollection<BsonDocument> tacgiaCollection;

        public FrmButdanh()
        {
            InitializeComponent();
            KetNoiMongoDB();
        }

        private void KetNoiMongoDB()
        {
            try
            {
                // Lấy link từ App.config để bảo mật như đồng chí dặn
                string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConn"].ConnectionString;
                string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                butdanhCollection = database.GetCollection<BsonDocument>("Butdanh");
                tacgiaCollection = database.GetCollection<BsonDocument>("TacGia");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối MongoDB: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private async void FrmButdanh_Load(object sender, EventArgs e)
        {
            // Cho phép gõ vào ô mã để tìm kiếm
            txtMaso.ReadOnly = false;

            dgvButDanh.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvButDanh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            await LoadDanhSachTacGiaAsync();
            await LoadDataAsync();
        }

        // --- NẠP TÁC GIẢ VÀO COMBOBOX ---
        private async Task LoadDanhSachTacGiaAsync()
        {
            try
            {
                var list = await tacgiaCollection.Find(new BsonDocument()).ToListAsync();
                DataTable dt = new DataTable();
                dt.Columns.Add("Maso");
                dt.Columns.Add("Hoten");

                foreach (var doc in list)
                {
                    dt.Rows.Add(doc["Maso"].ToString(), doc["Hoten"].ToString());
                }

                cboTacGia.DisplayMember = "Hoten";
                cboTacGia.ValueMember = "Maso";
                cboTacGia.DataSource = dt;
            }
            catch { }
        }

        // --- TẢI DỮ LIỆU BÚT DANH ---
        private async Task LoadDataAsync()
        {
            try
            {
                var docs = await butdanhCollection.Find(new BsonDocument()).ToListAsync();
                var authors = await tacgiaCollection.Find(new BsonDocument()).ToListAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("Maso");
                dt.Columns.Add("Butdanh");
                dt.Columns.Add("TenTacGia");
                dt.Columns.Add("MsTacgia");

                foreach (var doc in docs)
                {
                    string msTG = doc.GetValue("MsTacgia", "").ToString();
                    var authorDoc = authors.Find(x => x["Maso"].ToString() == msTG);
                    string tenTG = authorDoc != null ? authorDoc["Hoten"].ToString() : "N/A";

                    dt.Rows.Add(doc.GetValue("Maso", ""), doc.GetValue("Butdanh", ""), tenTG, msTG);
                }

                dgvButDanh.DataSource = dt;
                if (dgvButDanh.Columns["MsTacgia"] != null) dgvButDanh.Columns["MsTacgia"].Visible = false;
            }
            catch { }
        }

        // --- THAO TÁC TÌM KIẾM KHI NHẬP MÃ ---
        private void txtMaso_TextChanged(object sender, EventArgs e)
        {
            if (dgvButDanh.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Convert(Maso, 'System.String') LIKE '%{0}%'", txtMaso.Text);
            }
        }

        // --- TÌM KIẾM THEO TÊN BÚT DANH ---
        private void txtButDanh_TextChanged(object sender, EventArgs e)
        {
            if (dgvButDanh.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Butdanh LIKE '%{0}%'", txtButDanh.Text);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtButDanh.Clear();
            txtMaso.ReadOnly = false; // Mở để gõ mã mới (nếu muốn nhập tay) hoặc tìm kiếm
            txtButDanh.Focus();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtButDanh.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên bút danh!", "Nhắc nhở");
                return;
            }

            try
            {
                long count = await butdanhCollection.CountDocumentsAsync(new BsonDocument());
                string newId = (1000 + count + 1).ToString();

                var newDoc = new BsonDocument {
                    { "Maso", newId },
                    { "Butdanh", txtButDanh.Text },
                    { "MsTacgia", cboTacGia.SelectedValue.ToString() }
                };

                await butdanhCollection.InsertOneAsync(newDoc);
                MessageBox.Show("Đã lưu bút danh mới!", "Thông báo");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", txtMaso.Text);
                var update = Builders<BsonDocument>.Update
                    .Set("Butdanh", txtButDanh.Text)
                    .Set("MsTacgia", cboTacGia.SelectedValue.ToString());

                await butdanhCollection.UpdateOneAsync(filter, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;
            if (MessageBox.Show("Đồng chí có chắc muốn xóa bút danh này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await butdanhCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Maso", txtMaso.Text));
                btnThem_Click(sender, e);
                await LoadDataAsync();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => btnThem_Click(sender, e);
        private void dgvButDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Sử dụng DataBoundItem để lấy dữ liệu ngầm từ DataTable, tránh lỗi sai tên cột UI
            if (dgvButDanh.Rows[e.RowIndex].DataBoundItem is DataRowView rowView)
            {
                txtMaso.Text = rowView["Maso"]?.ToString() ?? "";
                txtButDanh.Text = rowView["Butdanh"]?.ToString() ?? "";

                // Khóa mã lại không cho sửa khi đang xem thông tin cũ
                txtMaso.ReadOnly = true;

                string msTG = rowView["MsTacgia"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(msTG)) cboTacGia.SelectedValue = msTG;
            }
            else
            {
                // Backup dự phòng nếu DataGridView không được bind qua DataTable
                var row = dgvButDanh.Rows[e.RowIndex];
                txtMaso.Text = row.Cells[0].Value?.ToString() ?? "";
                txtButDanh.Text = row.Cells[1].Value?.ToString() ?? "";
                txtMaso.ReadOnly = true;
            }
        }
    }
}