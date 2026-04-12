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
        private readonly IMongoCollection<TaiKhoan> _taiKhoanColl;

        public FrmTaiKhoan()
        {
            InitializeComponent();
            _taiKhoanColl = MongoProvider.Instance.GetCollection<TaiKhoan>("TaiKhoan");
        }

        private async void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            if (cboQuyen.Items.Count > 0) cboQuyen.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _taiKhoanColl.Find(_ => true).ToListAsync();

                dgvTaiKhoan.DataSource = list.Select(tk => new {
                    tk.Id,
                    TenDangNhap = tk.TenDangNhap,
                    // Che pass trên GridView nhìn cho ngầu
                    MatKhau = "********",
                    HoTen = tk.HoTen,
                    Quyen = tk.Quyen,
                    HoatDong = tk.HoatDong ? "Mở" : "Khóa"
                }).ToList();

                if (dgvTaiKhoan.Columns["Id"] != null) dgvTaiKhoan.Columns["Id"].Visible = false;

                // Đổi tên cột
                if (dgvTaiKhoan.Columns.Count > 0)
                {
                    dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Username";
                    dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Password";
                    dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTaiKhoan.Columns["Quyen"].HeaderText = "Vai Trò";
                    dgvTaiKhoan.Columns["HoatDong"].HeaderText = "Trạng Thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Tên đăng nhập và Mật khẩu không được để trống!", "Cảnh báo");
                return;
            }

            try
            {
                // Kiểm tra trùng username
                var exist = await _taiKhoanColl.Find(t => t.TenDangNhap == txtTenDangNhap.Text.Trim()).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác!", "Lỗi");
                    return;
                }

                var tk = new TaiKhoan
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
                var filter = Builders<TaiKhoan>.Filter.Eq(t => t.Id, id);

                // Tránh tình trạng update đè mật khẩu rỗng nếu user không nhập gì vào ô mk lúc sửa
                var updateDef = Builders<TaiKhoan>.Update
                    .Set(t => t.HoTen, txtHoTen.Text.Trim())
                    .Set(t => t.Quyen, cboQuyen.Text)
                    .Set(t => t.HoatDong, chkHoatDong.Checked);

                if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    updateDef = updateDef.Set(t => t.MatKhau, txtMatKhau.Text.Trim());
                }

                await _taiKhoanColl.UpdateOneAsync(filter, updateDef);
                MessageBox.Show("Cập nhật thông tin thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
            string user = dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value.ToString();

            if (user == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản Quản trị gốc!", "Từ chối");
                return;
            }

            if (MessageBox.Show($"Đồng chí chắc chắn muốn xóa tài khoản {user}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _taiKhoanColl.DeleteOneAsync(t => t.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cboQuyen.SelectedIndex = 0;
            chkHoatDong.Checked = true;
            txtTenDangNhap.ReadOnly = false;
            txtTenDangNhap.Focus();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtTenDangNhap.ReadOnly = true; // Không cho sửa Username
                txtMatKhau.Clear(); // Bỏ trống ô MK để nếu muốn đổi MK thì nhập mới
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboQuyen.Text = row.Cells["Quyen"].Value.ToString();
                chkHoatDong.Checked = row.Cells["HoatDong"].Value.ToString() == "Mở";
            }
        }
    }
}