using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButDanh : Form
    {
        private readonly IMongoCollection<ButDanh> _butDanhColl;

        public FrmButDanh()
        {
            InitializeComponent();
            _butDanhColl = MongoProvider.Instance.GetCollection<ButDanh>("Butdanh");
        }

        private async void FrmButDanh_Load(object sender, EventArgs e)
        {
            dgvButDanh.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _butDanhColl.Find(_ => true).ToListAsync();

                dgvButDanh.DataSource = list.Select(b => new {
                    b.Id,
                    Maso = b.Maso,
                    Butdanh = b.Butdanh,
                    MsTacgia = b.MsTacgia
                }).OrderBy(x => x.Maso).ToList();

                if (dgvButDanh.Columns["Id"] != null) dgvButDanh.Columns["Id"].Visible = false;

                if (dgvButDanh.Columns.Count > 0)
                {
                    dgvButDanh.Columns["Maso"].HeaderText = "Mã số (ID)";
                    dgvButDanh.Columns["Butdanh"].HeaderText = "Bút danh hiển thị";
                    dgvButDanh.Columns["MsTacgia"].HeaderText = "Mã tác giả gốc";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtButDanh.Text))
            {
                MessageBox.Show("Đồng chí Tí nhập đầy đủ Mã số và Bút danh giúp Thanh nhé!", "Nhắc nhở");
                return;
            }

            // Ép kiểu Mã số về đúng chuẩn Int giống hình SQL
            if (!int.TryParse(txtMaso.Text.Trim(), out int maSo))
            {
                MessageBox.Show("Mã số phải là con số (Ví dụ: 1000, 1692...)!", "Cảnh báo");
                return;
            }

            try
            {
                var exist = await _butDanhColl.Find(b => b.Maso == maSo).FirstOrDefaultAsync();
                if (exist != null) { MessageBox.Show("Mã số Bút danh này đã tồn tại rồi anh Tí ơi!"); return; }

                var bd = new ButDanh
                {
                    Maso = maSo,
                    Butdanh = txtButDanh.Text.Trim(),
                    MsTacgia = txtMsTacGia.Text.Trim() // Ví dụ: PV1000
                };

                await _butDanhColl.InsertOneAsync(bd);
                MessageBox.Show("Thêm Bút danh thành công rực rỡ!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
            if (!int.TryParse(txtMaso.Text.Trim(), out int maSo)) return;

            try
            {
                string id = dgvButDanh.CurrentRow.Cells["Id"].Value.ToString();
                var update = Builders<ButDanh>.Update
                    .Set(b => b.Maso, maSo)
                    .Set(b => b.Butdanh, txtButDanh.Text.Trim())
                    .Set(b => b.MsTacgia, txtMsTacGia.Text.Trim());

                await _butDanhColl.UpdateOneAsync(b => b.Id == id, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
            if (MessageBox.Show("Chắc chắn muốn xóa bút danh này chứ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dgvButDanh.CurrentRow.Cells["Id"].Value.ToString();
                await _butDanhColl.DeleteOneAsync(b => b.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtButDanh.Clear();
            txtMsTacGia.Clear();
            txtMaso.Focus();
        }

        private void dgvButDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvButDanh.Rows[e.RowIndex];
                txtMaso.Text = row.Cells["Maso"].Value?.ToString();
                txtButDanh.Text = row.Cells["Butdanh"].Value?.ToString();
                txtMsTacGia.Text = row.Cells["MsTacgia"].Value?.ToString();
            }
        }
    }
}