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
        // Kết nối CSDL MongoDB
        private readonly IMongoCollection<TacGia> _tacGiaColl;

        // Biến lưu trữ đường dẫn file
        private string currentImagePath = "";
        private string currentPdfPath = "";

        public FrmTacGia()
        {
            InitializeComponent();
            // Khởi tạo Collection Tác giả từ MongoDB
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        // ==========================================
        // 1. SỰ KIỆN LOAD FORM & DATA GRID VIEW
        // ==========================================
        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho ComboBox
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;

            // Gọi hàm tải dữ liệu lên bảng
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                // Lấy toàn bộ dữ liệu từ Collection
                var list = await _tacGiaColl.Find(_ => true).ToListAsync();

                // Xử lý tìm kiếm nếu người dùng nhập từ khóa
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower().Trim();
                    list = list.Where(t =>
                        (t.MaHT != null && t.MaHT.ToLower().Contains(keyword)) ||
                        (t.HoTen != null && t.HoTen.ToLower().Contains(keyword)) ||
                        (t.MaThe != null && t.MaThe.ToLower().Contains(keyword)) ||
                        (t.ButDanh != null && t.ButDanh.ToLower().Contains(keyword))
                    ).ToList();
                }

                // Gắn dữ liệu vào GridView
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

                // Ẩn các cột không cần thiết hiển thị cho người dùng
                if (dgvTacGia.Columns["Id"] != null) dgvTacGia.Columns["Id"].Visible = false;
                if (dgvTacGia.Columns["AvatarPath"] != null) dgvTacGia.Columns["AvatarPath"].Visible = false;
                if (dgvTacGia.Columns["PdfPath"] != null) dgvTacGia.Columns["PdfPath"].Visible = false;
                if (dgvTacGia.Columns["DiaChi"] != null) dgvTacGia.Columns["DiaChi"].Visible = false;

                // Đổi tên Header cho đẹp
                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["MaHT"].HeaderText = "Mã HT";
                    dgvTacGia.Columns["MaThe"].HeaderText = "Mã Thẻ";
                    dgvTacGia.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTacGia.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTacGia.Columns["ButDanh"].HeaderText = "Bút Danh";
                    dgvTacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvTacGia.Columns["PhanLoai"].HeaderText = "Phân Loại";
                    dgvTacGia.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvTacGia.Columns["Email"].HeaderText = "Email";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Database: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }

        // ==========================================
        // 2. XỬ LÝ ĐÍNH KÈM FILE (ẢNH & PDF)
        // ==========================================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện tác giả";
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
                ofd.Title = "Chọn file CV/Hồ sơ (PDF)";
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
                // Mở file PDF bằng trình duyệt/phần mềm mặc định của Windows
                Process.Start(new ProcessStartInfo(currentPdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Không tìm thấy file PDF. Đường dẫn có thể đã bị thay đổi hoặc file bị xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // 3. CÁC NGHIỆP VỤ CRUD (THÊM, SỬA, XÓA)
        // ==========================================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHT.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã hệ thống và Họ tên không được để trống!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHT.Focus();
                return;
            }

            try
            {
                // Kiểm tra trùng mã hệ thống
                var exist = await _tacGiaColl.Find(t => t.MaHT == txtMaHT.Text.Trim()).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Mã hệ thống này đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                MessageBox.Show("Thêm hồ sơ tác giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
                btnLamMoi_Click(null, null); // Xóa trắng form sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tác giả từ danh sách bên dưới để cập nhật!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                MessageBox.Show("Cập nhật thông tin tác giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tác giả cần xóa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Đồng chí có chắc chắn muốn xóa hồ sơ tác giả này khỏi hệ thống không? Dữ liệu bị xóa sẽ không thể phục hồi!", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                    await _tacGiaColl.DeleteOneAsync(t => t.Id == id);

                    MessageBox.Show("Đã xóa hồ sơ tác giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Reset toàn bộ TextBox
            txtMaHT.Clear();
            txtMaThe.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtButDanh.Clear();
            txtDiaChi.Clear();

            // Reset ComboBox và DatePicker
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;

            // Reset đường dẫn và hiển thị File
            picAvatar.Image = null;
            currentImagePath = "";
            currentPdfPath = "";

            lblFilePDF.Text = "Chưa có file...";
            lblFilePDF.ForeColor = Color.Gray;
            btnXemPDF.Enabled = false;

            if (txtTimKiem != null) txtTimKiem.Clear();
            txtMaHT.Focus();
        }

        // ==========================================
        // 4. ĐỔ ĐỮ LIỆU TỪ GRID LÊN TEXTBOX KHI CLICK
        // ==========================================
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

                // Cột địa chỉ bị ẩn nhưng vẫn lấy được Value
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

                if (DateTime.TryParseExact(row.Cells["NgaySinh"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgaySinh.Value = dt;
                }

                // Xử lý nạp File Hình và PDF
                currentImagePath = row.Cells["AvatarPath"].Value?.ToString();
                currentPdfPath = row.Cells["PdfPath"].Value?.ToString();

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                {
                    picAvatar.Image = Image.FromFile(currentImagePath);
                }
                else
                {
                    picAvatar.Image = null; // Hoặc gắn 1 ảnh mặc định (Default Avatar)
                }

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
    }
}