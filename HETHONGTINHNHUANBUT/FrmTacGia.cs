using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        // Khai báo Collection sử dụng Model TacGia thay vì BsonDocument
        private readonly IMongoCollection<TacGia> _tacGiaColl;

        public FrmTacGia()
        {
            InitializeComponent();
            // Gọi kết nối từ Singleton Provider (rất tối ưu và gọn)
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            txtMaso.ReadOnly = false;
            dgvTacGia.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvTacGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            if (cboLoaiTG.Items.Count > 0) cboLoaiTG.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy toàn bộ dữ liệu từ Cloud
                var list = await _tacGiaColl.Find(_ => true).ToListAsync();

                // Bind thẳng List vào DataGridView qua LINQ để tùy biến hiển thị
                dgvTacGia.DataSource = list.Select(t => new
                {
                    Maso = t.Maso,
                    MsTG = t.MsTG,
                    Hoten = t.Hoten,
                    Ngaysinh = t.Ngaysinh.ToString("dd/MM/yyyy"),
                    LoaiTacgia = t.LoaiTacgia,
                    Email = t.Email,
                    Dienthoai = t.Dienthoai,
                    Ddong = t.Ddong, // Bút danh
                    Diachi = t.Diachi
                }).ToList();

                // Đổi tên cột hiển thị
                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["Maso"].HeaderText = "Mã hệ thống";
                    dgvTacGia.Columns["MsTG"].HeaderText = "Mã TG/Thẻ";
                    dgvTacGia.Columns["Hoten"].HeaderText = "Họ và tên";
                    dgvTacGia.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
                    dgvTacGia.Columns["LoaiTacgia"].HeaderText = "Loại";
                    dgvTacGia.Columns["Ddong"].HeaderText = "Bút danh";
                    dgvTacGia.Columns["Dienthoai"].HeaderText = "Điện thoại";
                    dgvTacGia.Columns["Diachi"].HeaderText = "Địa chỉ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
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
                // Kiểm tra trùng lặp
                var exist = await _tacGiaColl.Find(t => t.Maso == txtMaso.Text.Trim()).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Mã hệ thống này đã tồn tại!");
                    return;
                }

                string loai = cboLoaiTG.SelectedIndex == 0 ? "PV" : (cboLoaiTG.SelectedIndex == 1 ? "CT" : "TN");

                // Thêm bằng Model rất trực quan
                var newTacGia = new TacGia
                {
                    Maso = txtMaso.Text.Trim(),
                    MsTG = txtMsTG.Text.Trim(),
                    Hoten = txtHoTen.Text.Trim(),
                    Ngaysinh = dtpNgaySinh.Value,
                    LoaiTacgia = loai,
                    Email = txtEmail.Text.Trim(),
                    Dienthoai = txtDienThoai.Text.Trim(),
                    Ddong = txtButDanh.Text.Trim(),
                    Diachi = txtDiaChi.Text.Trim()
                };

                await _tacGiaColl.InsertOneAsync(newTacGia);
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

                var filter = Builders<TacGia>.Filter.Eq(t => t.Maso, txtMaso.Text.Trim());
                var update = Builders<TacGia>.Update
                    .Set(t => t.MsTG, txtMsTG.Text.Trim())
                    .Set(t => t.Hoten, txtHoTen.Text.Trim())
                    .Set(t => t.Ngaysinh, dtpNgaySinh.Value)
                    .Set(t => t.LoaiTacgia, loai)
                    .Set(t => t.Email, txtEmail.Text.Trim())
                    .Set(t => t.Dienthoai, txtDienThoai.Text.Trim())
                    .Set(t => t.Ddong, txtButDanh.Text.Trim())
                    .Set(t => t.Diachi, txtDiaChi.Text.Trim());

                await _tacGiaColl.UpdateOneAsync(filter, update);
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
                await _tacGiaColl.DeleteOneAsync(t => t.Maso == txtMaso.Text.Trim());
                btnThem_Click(sender, e);
                await LoadDataAsync();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => btnThem_Click(sender, e);

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTacGia.CurrentRow == null || e.RowIndex < 0) return;
            var row = dgvTacGia.Rows[e.RowIndex];

            txtMaso.Text = row.Cells["Maso"].Value?.ToString();
            txtMsTG.Text = row.Cells["MsTG"].Value?.ToString();
            txtHoTen.Text = row.Cells["Hoten"].Value?.ToString();
            txtMaso.ReadOnly = true; // Khóa mã lại không cho sửa

            // Xử lý ngày sinh an toàn hơn
            if (DateTime.TryParseExact(row.Cells["Ngaysinh"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
            {
                dtpNgaySinh.Value = ns;
            }

            // Gán lại loại tác giả
            string loai = row.Cells["LoaiTacgia"].Value?.ToString();
            if (loai == "PV") cboLoaiTG.SelectedIndex = 0;
            else if (loai == "CT") cboLoaiTG.SelectedIndex = 1;
            else cboLoaiTG.SelectedIndex = 2;

            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDienThoai.Text = row.Cells["Dienthoai"].Value?.ToString();
            txtButDanh.Text = row.Cells["Ddong"].Value?.ToString();
            txtDiaChi.Text = row.Cells["Diachi"].Value?.ToString();
        }
    }
}