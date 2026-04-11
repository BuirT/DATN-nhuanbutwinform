using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // Để đọc App.config
using MongoDB.Bson;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class frmSoBao : Form
    {
        // Khai báo Collection MongoDB cho bảng Bao
        private IMongoCollection<BsonDocument> baoCollection;

        public frmSoBao()
        {
            InitializeComponent();
            KetNoiMongoDB();
        }

        private void KetNoiMongoDB()
        {
            try
            {
                // Đọc cấu hình bảo mật từ App.config
                string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConn"].ConnectionString;
                string databaseName = ConfigurationManager.AppSettings["DatabaseName"];

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                // Trỏ đúng vào collection Bao theo file SQL
                baoCollection = database.GetCollection<BsonDocument>("Bao");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình MongoDB: " + ex.Message, "Thông báo lỗi");
            }
        }

        private async void frmSoBao_Load(object sender, EventArgs e)
        {
            // Ép font Segoe UI cho đồng bộ giao diện hiện đại
            dgvSoBao.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dgvSoBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);

            // Load dữ liệu chạy ngầm không gây đơ máy
            await LoadDataAsync();
        }

        // --- HÀM TẢI DỮ LIỆU BẤT ĐỒNG BỘ ---
        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy danh sách số báo mới nhất lên đầu
                var documents = await baoCollection.Find(new BsonDocument())
                                                   .Sort(Builders<BsonDocument>.Sort.Descending("Ngayra"))
                                                   .ToListAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("Maso", typeof(int));
                dt.Columns.Add("Tenbao");
                dt.Columns.Add("Ngayra");
                dt.Columns.Add("Sobao");
                dt.Columns.Add("Sobo");
                dt.Columns.Add("Loaibao");
                dt.Columns.Add("DaDuyet");

                foreach (var doc in documents)
                {
                    DataRow row = dt.NewRow();
                    row["Maso"] = doc.GetValue("Maso", 0).AsInt32;
                    row["Tenbao"] = doc.GetValue("Tenbao", "").ToString();

                    if (doc.Contains("Ngayra") && doc["Ngayra"].IsBsonDateTime)
                        row["Ngayra"] = doc["Ngayra"].ToUniversalTime().ToString("dd/MM/yyyy");
                    else
                        row["Ngayra"] = "";

                    row["Sobao"] = doc.GetValue("Sobao", "").ToString();
                    row["Sobo"] = doc.GetValue("Sobo", "").ToString();
                    row["Loaibao"] = doc.GetValue("Loaibao", "").ToString();
                    row["DaDuyet"] = doc.GetValue("DaDuyet", "N").ToString();
                    dt.Rows.Add(row);
                }

                dgvSoBao.DataSource = dt;

                // Đổi tên cột hiển thị tiếng Việt cho chuyên nghiệp
                if (dgvSoBao.Columns.Count > 0)
                {
                    dgvSoBao.Columns["Maso"].HeaderText = "Mã số";
                    dgvSoBao.Columns["Tenbao"].HeaderText = "Tên báo";
                    dgvSoBao.Columns["Ngayra"].HeaderText = "Ngày ra";
                    dgvSoBao.Columns["Sobao"].HeaderText = "Ký hiệu (Số)";
                    dgvSoBao.Columns["Sobo"].HeaderText = "Số lượng bộ";
                    dgvSoBao.Columns["DaDuyet"].HeaderText = "Đã duyệt";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtTenBao.Clear();
            txtSoBao.Clear();
            txtSoBo.Clear();
            dtpNgayRa.Value = DateTime.Now;
            txtMaso.ReadOnly = false;
            txtMaso.Focus();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text) || string.IsNullOrEmpty(txtTenBao.Text))
            {
                MessageBox.Show("Đồng chí vui lòng nhập đầy đủ Mã số và Tên báo nha!", "Nhắc nhở");
                return;
            }

            try
            {
                int maSo = int.Parse(txtMaso.Text);

                // Kiểm tra trùng mã
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", maSo);
                var exist = await baoCollection.Find(filter).FirstOrDefaultAsync();

                if (exist != null)
                {
                    MessageBox.Show("Mã số báo này đã tồn tại!");
                    return;
                }

                // Tạo đối tượng theo đúng Schema SQL của anh
                var newDoc = new BsonDocument
                {
                    { "Maso", maSo },
                    { "Tenbao", txtTenBao.Text },
                    { "Ngayra", new BsonDateTime(dtpNgayRa.Value) },
                    { "Sobao", txtSoBao.Text },
                    { "Sobo", txtSoBo.Text },
                    { "Loaibao", "NG" }, // Mặc định báo ngày
                    { "DaDuyet", "N" }   // Mặc định chưa duyệt
                };

                await baoCollection.InsertOneAsync(newDoc);
                MessageBox.Show("Thêm Số báo thành công!", "Thông báo");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", int.Parse(txtMaso.Text));
                var update = Builders<BsonDocument>.Update
                    .Set("Tenbao", txtTenBao.Text)
                    .Set("Ngayra", new BsonDateTime(dtpNgayRa.Value))
                    .Set("Sobao", txtSoBao.Text)
                    .Set("Sobo", txtSoBo.Text);

                await baoCollection.UpdateOneAsync(filter, update);
                MessageBox.Show("Cập nhật Số báo thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            if (MessageBox.Show("Đồng chí chắc chắn muốn xóa số báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("Maso", int.Parse(txtMaso.Text));
                    await baoCollection.DeleteOneAsync(filter);

                    MessageBox.Show("Xóa thành công!");
                    btnThem_Click(sender, e);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void dgvSoBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSoBao.CurrentRow == null || e.RowIndex < 0) return;

            int i = dgvSoBao.CurrentRow.Index;

            txtMaso.Text = dgvSoBao.Rows[i].Cells["Maso"].Value?.ToString() ?? "";
            txtTenBao.Text = dgvSoBao.Rows[i].Cells["Tenbao"].Value?.ToString() ?? "";
            txtSoBao.Text = dgvSoBao.Rows[i].Cells["Sobao"].Value?.ToString() ?? "";
            txtSoBo.Text = dgvSoBao.Rows[i].Cells["Sobo"].Value?.ToString() ?? "";

            txtMaso.ReadOnly = true; // Khóa mã số khi sửa

            if (DateTime.TryParse(dgvSoBao.Rows[i].Cells["Ngayra"].Value?.ToString(), out DateTime ngayRa))
            {
                dtpNgayRa.Value = ngayRa;
            }
        }
    }
}