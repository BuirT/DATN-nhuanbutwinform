using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private string currentImagePath = "";
        private string currentPdfPath = "";

        public FrmTacGia()
        {
            InitializeComponent();
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");

            // Gán sự kiện chặn nhập chữ ngay từ lúc khởi tạo
            txtDienThoai.KeyPress += txtDienThoai_KeyPress;
        }

        // Kiểm tra định dạng 10 chữ số
        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        // Chặn nhập ký tự không phải là số
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                var list = await _tacGiaColl.Find(_ => true).ToListAsync();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower().Trim();
                    list = list.Where(t =>
                        (t.MaHT != null && t.MaHT.ToLower().Contains(keyword)) ||
                        (t.HoTen != null && t.HoTen.ToLower().Contains(keyword)) ||
                        (t.MaThe != null && t.MaThe.ToLower().Contains(keyword)) ||
                        (t.SoTaiKhoan != null && t.SoTaiKhoan.ToLower().Contains(keyword)) ||
                        (t.DienThoai != null && t.DienThoai.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvTacGia.DataSource = list.Select(t => new {
                    t.Id,
                    MaHT = t.MaHT,
                    MaThe = t.MaThe,
                    HoTen = t.HoTen,
                    NgaySinh = t.NgaySinh.ToString("dd/MM/yyyy"),
                    PhanLoai = t.PhanLoai,
                    Email = t.Email,
                    DienThoai = t.DienThoai,
                    PhongBan = t.PhongBan,
                    SoTaiKhoan = t.SoTaiKhoan,
                    NganHang = t.NganHang,
                    AvatarPath = t.AvatarPath,
                    PdfPath = t.PdfPath
                }).OrderByDescending(x => x.MaHT).ToList();

                if (dgvTacGia.Columns["Id"] != null) dgvTacGia.Columns["Id"].Visible = false;
                if (dgvTacGia.Columns["AvatarPath"] != null) dgvTacGia.Columns["AvatarPath"].Visible = false;
                if (dgvTacGia.Columns["PdfPath"] != null) dgvTacGia.Columns["PdfPath"].Visible = false;
                if (dgvTacGia.Columns["NganHang"] != null) dgvTacGia.Columns["NganHang"].Visible = false;

                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["MaHT"].HeaderText = "Mã HT";
                    dgvTacGia.Columns["MaThe"].HeaderText = "Mã Thẻ";
                    dgvTacGia.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTacGia.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTacGia.Columns["SoTaiKhoan"].HeaderText = "Số Tài Khoản";
                    dgvTacGia.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvTacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvTacGia.Columns["PhanLoai"].HeaderText = "Phân Loại";
                    dgvTacGia.Columns["PhongBan"].HeaderText = "Phòng Ban";
                    dgvTacGia.Columns["Email"].HeaderText = "Email";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picAvatar.Image = Image.FromFile(currentImagePath);
                }
            }
        }

        private void btnChonPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentPdfPath = ofd.FileName;
                    lblFilePDF.Text = "Đã đính kèm: " + Path.GetFileName(currentPdfPath);
                    lblFilePDF.ForeColor = Color.Green;
                    btnXemPDF.Enabled = true;
                }
            }
        }

        private void btnXemPDF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPdfPath) && File.Exists(currentPdfPath))
                Process.Start(new ProcessStartInfo(currentPdfPath) { UseShellExecute = true });
            else
                MessageBox.Show("Không tìm thấy file PDF!");
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHT.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã hệ thống và Họ tên không được trống!");
                return;
            }

            // Kiểm tra 10 số điện thoại
            if (!IsValidPhone(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại phải nhập đúng 10 chữ số!", "Lỗi nhập liệu");
                txtDienThoai.Focus();
                return;
            }

            try
            {
                var exist = await _tacGiaColl.Find(t => t.Maso == txtMaHT.Text.Trim()).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Mã hệ thống đã tồn tại!");
                    return;
                }

                var tg = new TacGia
                {
                    Maso = txtMaHT.Text.Trim(),
                    MsTG = txtMaThe.Text.Trim(),
                    Hoten = txtHoTen.Text.Trim(),
                    Ngaysinh = dtpNgaySinh.Value,
                    LoaiTacgia = cboPhanLoai.Text,
                    Email = txtEmail.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    SoTaiKhoan = txtSoTaiKhoan.Text.Trim(),
                    PhongBan = txtPhongBan.Text.Trim(),
                    NganHang = txtNganHang.Text.Trim(),
                    AvatarPath = currentImagePath,
                    PdfPath = currentPdfPath
                };

                await _tacGiaColl.InsertOneAsync(tg);
                MessageBox.Show("Thêm hồ sơ thành công!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;

            if (!IsValidPhone(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại phải nhập đúng 10 chữ số!", "Lỗi nhập liệu");
                txtDienThoai.Focus();
                return;
            }

            try
            {
                string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                var update = Builders<TacGia>.Update
                    .Set(t => t.Maso, txtMaHT.Text.Trim())
                    .Set(t => t.MsTG, txtMaThe.Text.Trim())
                    .Set(t => t.Hoten, txtHoTen.Text.Trim())
                    .Set(t => t.Ngaysinh, dtpNgaySinh.Value)
                    .Set(t => t.LoaiTacgia, cboPhanLoai.Text)
                    .Set(t => t.Email, txtEmail.Text.Trim())
                    .Set(t => t.DienThoai, txtDienThoai.Text.Trim())
                    .Set(t => t.SoTaiKhoan, txtSoTaiKhoan.Text.Trim())
                    .Set(t => t.PhongBan, txtPhongBan.Text.Trim())
                    .Set(t => t.NganHang, txtNganHang.Text.Trim())
                    .Set(t => t.AvatarPath, currentImagePath)
                    .Set(t => t.PdfPath, currentPdfPath);

                await _tacGiaColl.UpdateOneAsync(t => t.Id == id, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;

            if (MessageBox.Show("Chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                await _tacGiaColl.DeleteOneAsync(t => t.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHT.Clear(); txtMaThe.Clear(); txtHoTen.Clear();
            txtEmail.Clear(); txtPhongBan.Clear(); txtSoTaiKhoan.Clear(); txtNganHang.Clear();
            txtDienThoai.Clear();

            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;

            picAvatar.Image = null; currentImagePath = ""; currentPdfPath = "";
            lblFilePDF.Text = "Chưa có file..."; lblFilePDF.ForeColor = Color.Gray; btnXemPDF.Enabled = false;
            txtMaHT.Focus();
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];

                txtMaHT.Text = row.Cells["MaHT"].Value?.ToString();
                txtMaThe.Text = row.Cells["MaThe"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                cboPhanLoai.Text = row.Cells["PhanLoai"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
                txtPhongBan.Text = row.Cells["PhongBan"].Value?.ToString();
                txtSoTaiKhoan.Text = row.Cells["SoTaiKhoan"].Value?.ToString();
                txtNganHang.Text = row.Cells["NganHang"].Value?.ToString();

                if (DateTime.TryParseExact(row.Cells["NgaySinh"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                    dtpNgaySinh.Value = dt;

                currentImagePath = row.Cells["AvatarPath"].Value?.ToString();
                currentPdfPath = row.Cells["PdfPath"].Value?.ToString();

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    picAvatar.Image = Image.FromFile(currentImagePath);
                else picAvatar.Image = null;

                if (!string.IsNullOrEmpty(currentPdfPath) && File.Exists(currentPdfPath))
                {
                    lblFilePDF.Text = "Đã đính kèm: " + Path.GetFileName(currentPdfPath);
                    lblFilePDF.ForeColor = Color.Green;
                    btnXemPDF.Enabled = true;
                }
                else
                {
                    lblFilePDF.Text = "Chưa có file...";
                    lblFilePDF.ForeColor = Color.Gray;
                    btnXemPDF.Enabled = false;
                }
            }
        }

        // Đã bổ sung hàm này để hết lỗi dòng 277
        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
        }
    }
}