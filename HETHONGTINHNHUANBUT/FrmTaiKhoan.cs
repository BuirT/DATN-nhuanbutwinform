using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTaiKhoan : Form
    {
        private readonly IMongoCollection<User> _taiKhoanColl;

        public FrmTaiKhoan()
        {
            InitializeComponent();
            _taiKhoanColl = MongoProvider.Instance.GetCollection<User>("User");
        }

        private async void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            // Thiết lập vai trò chuẩn theo quy trình tòa soạn
            cboQuyen.Items.Clear();
            cboQuyen.Items.AddRange(new object[] { "Lãnh đạo", "Thư ký", "Kế toán" });
            if (cboQuyen.Items.Count > 0) cboQuyen.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                var list = await _taiKhoanColl.Find(_ => true).ToListAsync();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower().Trim();
                    list = list.Where(t =>
                        (t.TenDangNhap != null && t.TenDangNhap.ToLower().Contains(keyword)) ||
                        (t.HoTen != null && t.HoTen.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvTaiKhoan.DataSource = list.Select(tk => new {
                    tk.Id,
                    TenDangNhap = tk.TenDangNhap,
                    MatKhau = "********",
                    tk.HoTen,
                    tk.Quyen,
                    TrangThai = tk.HoatDong ? "Đang hoạt động" : "Bị khóa"
                }).ToList();

                if (dgvTaiKhoan.Columns["Id"] != null) dgvTaiKhoan.Columns["Id"].Visible = false;

                if (dgvTaiKhoan.Columns.Count > 0)
                {
                    dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
                    dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTaiKhoan.Columns["Quyen"].HeaderText = "Vai trò";
                    dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên đăng nhập và Mật khẩu!", "Nhắc nhở");
                return;
            }

            try
            {
                var exist = await _taiKhoanColl.Find(t => t.TenDangNhap == txtTenDangNhap.Text.Trim()).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Cảnh báo");
                    return;
                }

                var tk = new User
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    Quyen = cboQuyen.Text,
                    HoatDong = chkHoatDong.Checked
                };

                await _taiKhoanColl.InsertOneAsync(tk);
                MessageBox.Show("Thêm tài khoản thành công!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            try
            {
                string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
                var update = Builders<User>.Update
                    .Set(t => t.HoTen, txtHoTen.Text.Trim())
                    .Set(t => t.Quyen, cboQuyen.Text)
                    .Set(t => t.HoatDong, chkHoatDong.Checked);

                if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    update = update.Set(t => t.MatKhau, txtMatKhau.Text.Trim());

                await _taiKhoanColl.UpdateOneAsync(t => t.Id == id, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            string user = dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            if (user.ToLower() == "admin") { MessageBox.Show("Không thể xóa Admin hệ thống!"); return; }

            if (MessageBox.Show($"Xác nhận xóa tài khoản {user}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
                await _taiKhoanColl.DeleteOneAsync(t => t.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear(); txtMatKhau.Clear(); txtHoTen.Clear();
            cboQuyen.SelectedIndex = 0; chkHoatDong.Checked = true;
            txtTenDangNhap.ReadOnly = false; txtTenDangNhap.Focus();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtTenDangNhap.ReadOnly = true;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                cboQuyen.Text = row.Cells["Quyen"].Value?.ToString();
                chkHoatDong.Checked = row.Cells["TrangThai"].Value?.ToString() == "Đang hoạt động";
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }
    }
}