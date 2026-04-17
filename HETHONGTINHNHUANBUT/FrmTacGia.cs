using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
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

            // ==========================================================
            // HÀN DÂY ĐIỆN SỰ KIỆN (Bắt buộc phải có để nút bấm có tác dụng)
            // ==========================================================
            this.Load -= FrmTacGia_Load;
            this.Load += FrmTacGia_Load;

            // 4 Nút CRUD
            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            // Tìm kiếm & Grid
            txtTimKiem.TextChanged -= txtTimKiem_TextChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            dgvTacGia.CellClick -= dgvTacGia_CellClick;
            dgvTacGia.CellClick += dgvTacGia_CellClick;

            // Hình ảnh & PDF
            btnChonAnh.Click -= btnChonAnh_Click;
            btnChonAnh.Click += btnChonAnh_Click;

            btnChonPDF.Click -= btnChonPDF_Click;
            btnChonPDF.Click += btnChonPDF_Click;

            btnXemPDF.Click -= btnXemPDF_Click;
            btnXemPDF.Click += btnXemPDF_Click;
            // ==========================================================
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
                        (t.MaThe != null && t.MaThe.ToLower().Contains(keyword))
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
                    ButDanh = t.ButDanh,
                    DiaChi = t.DiaChi,
                    AvatarPath = t.AvatarPath,
                    PdfPath = t.PdfPath
                }).OrderByDescending(x => x.MaHT).ToList();

                if (dgvTacGia.Columns["Id"] != null) dgvTacGia.Columns["Id"].Visible = false;
                if (dgvTacGia.Columns["AvatarPath"] != null) dgvTacGia.Columns["AvatarPath"].Visible = false;
                if (dgvTacGia.Columns["PdfPath"] != null) dgvTacGia.Columns["PdfPath"].Visible = false;

                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["MaHT"].HeaderText = "Mã HT";
                    dgvTacGia.Columns["MaThe"].HeaderText = "Mã Thẻ";
                    dgvTacGia.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTacGia.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvTacGia.Columns["PhanLoai"].HeaderText = "Loại";
                    dgvTacGia.Columns["Email"].HeaderText = "Email";
                    dgvTacGia.Columns["DienThoai"].HeaderText = "Điện Thoại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Database: " + ex.Message, "Lỗi");
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
            {
                Process.Start(new ProcessStartInfo(currentPdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Không tìm thấy file PDF. Bạn đã xóa file gốc chưa?", "Lỗi");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHT.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã HT và Họ Tên không được để trống!", "Cảnh báo");
                return;
            }

            try
            {
                var tg = new TacGia
                {
                    MaHT = txtMaHT.Text.Trim(),
                    MaThe = txtMaThe.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    ButDanh = txtButDanh.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    PhanLoai = cboPhanLoai.Text,
                    DiaChi = txtDiaChi.Text.Trim(),
                    AvatarPath = currentImagePath,
                    PdfPath = currentPdfPath
                };

                await _tacGiaColl.InsertOneAsync(tg);
                MessageBox.Show("Thêm tác giả thành công!", "Tuyệt vời");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi thêm: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;

            try
            {
                string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                var update = Builders<TacGia>.Update
                    .Set(t => t.MaHT, txtMaHT.Text.Trim())
                    .Set(t => t.MaThe, txtMaThe.Text.Trim())
                    .Set(t => t.HoTen, txtHoTen.Text.Trim())
                    .Set(t => t.ButDanh, txtButDanh.Text.Trim())
                    .Set(t => t.DienThoai, txtDienThoai.Text.Trim())
                    .Set(t => t.Email, txtEmail.Text.Trim())
                    .Set(t => t.NgaySinh, dtpNgaySinh.Value)
                    .Set(t => t.PhanLoai, cboPhanLoai.Text)
                    .Set(t => t.DiaChi, txtDiaChi.Text.Trim())
                    .Set(t => t.AvatarPath, currentImagePath)
                    .Set(t => t.PdfPath, currentPdfPath);

                await _tacGiaColl.UpdateOneAsync(t => t.Id == id, update);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi cập nhật: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;

            if (MessageBox.Show("Đồng chí có chắc chắn muốn xóa tác giả này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                    await _tacGiaColl.DeleteOneAsync(t => t.Id == id);
                    await LoadDataAsync();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi khi xóa: " + ex.Message); }
            }
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
                txtButDanh.Text = row.Cells["ButDanh"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

                if (DateTime.TryParseExact(row.Cells["NgaySinh"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgaySinh.Value = dt;
                }

                currentImagePath = row.Cells["AvatarPath"].Value?.ToString();
                currentPdfPath = row.Cells["PdfPath"].Value?.ToString();

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    picAvatar.Image = Image.FromFile(currentImagePath);
                else
                    picAvatar.Image = null;

                if (!string.IsNullOrEmpty(currentPdfPath) && File.Exists(currentPdfPath))
                {
                    lblFilePDF.Text = Path.GetFileName(currentPdfPath);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHT.Clear(); txtMaThe.Clear(); txtHoTen.Clear();
            txtEmail.Clear(); txtDienThoai.Clear(); txtButDanh.Clear(); txtDiaChi.Clear();
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;

            picAvatar.Image = null;
            currentImagePath = "";
            currentPdfPath = "";
            lblFilePDF.Text = "Chưa có file...";
            lblFilePDF.ForeColor = Color.Gray;
            btnXemPDF.Enabled = false;

            if (txtTimKiem != null) txtTimKiem.Clear();
        }
    }
}