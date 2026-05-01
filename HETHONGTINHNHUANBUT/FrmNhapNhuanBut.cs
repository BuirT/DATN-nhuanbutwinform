using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<Bao> _baoColl;
        private readonly IMongoCollection<TacGia> _tacGiaColl;

        // Biến lưu ID bài viết đang chọn để cập nhật (null nếu là thêm mới)
        private string _selectedNhuanButId = null;

        // Tên người đang đăng nhập từ Form chính truyền sang
        public string NguoiDangNhap { get; set; }

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            // Thiết lập font cho lưới cho dễ nhìn
            dgvNhuanBut.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Tạm thời ngắt sự kiện để load dữ liệu vào Combobox không bị lỗi giật màn hình
            cboSoBao.SelectedIndexChanged -= cboSoBao_SelectedIndexChanged;

            await LoadComboboxDataAsync();

            cboSoBao.SelectedIndexChanged += cboSoBao_SelectedIndexChanged;

            // Load dữ liệu lần đầu nếu có số báo mặc định
            if (cboSoBao.SelectedValue != null)
            {
                await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
            }
        }

        // --- ĐÚNG Ý ĐỒ: Gộp thông tin Số - Tên - Ngày vào Kỳ xuất bản ---
        private async Task LoadComboboxDataAsync()
        {
            try
            {
                // 1. Load danh sách Số Báo chưa chốt
                var listBaoRaw = await _baoColl.Find(b => b.DaDuyet == "N").ToListAsync();

                // Gộp thông tin hiển thị: Số 15 - Tin tức sáng (13/04/2026)
                var displayListBao = listBaoRaw.Select(b => new {
                    Id = b.Id, // Vẫn giữ Id để làm giá trị ngầm
                    HienThi = $"Số {b.Sobao} - {b.Tenbao} ({b.Ngayra:dd/MM/yyyy})",
                    MaSoBao = b.Maso // Giữ thêm mã số báo gốc để lưu vào Nhuận Bút
                }).ToList();

                cboSoBao.DataSource = displayListBao;
                cboSoBao.DisplayMember = "HienThi";
                cboSoBao.ValueMember = "Id"; // Dùng Id Mongo để ràng buộc

                // 2. Load danh sách Bút danh
                var listTacGia = await _tacGiaColl.Find(_ => true).ToListAsync();
                List<string> tatCaButDanh = new List<string>();

                foreach (var tg in listTacGia)
                {
                    if (!string.IsNullOrWhiteSpace(tg.ButDanh))
                        tatCaButDanh.Add(tg.ButDanh.Trim());
                    else if (!string.IsNullOrWhiteSpace(tg.HoTen))
                        tatCaButDanh.Add(tg.HoTen.Trim());
                }
                cboButDanh.DataSource = tatCaButDanh.Distinct().OrderBy(x => x).ToList();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh mục: " + ex.Message); }
        }

        // Khi thay đổi Kỳ xuất bản -> Load lại danh sách bài viết tương ứng
        private async void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null && cboSoBao.SelectedValue is string idBaoMongo)
            {
                // Truyền Id của bản ghi báo trong MongoDB vào hàm
                await LoadDataGridAsync(idBaoMongo);
                ClearInputs();
            }
        }

        private async Task LoadDataGridAsync(string idBaoMongo)
        {
            try
            {
                // ĐÃ SỬA: Sửa lại tên trường tìm kiếm (Vì ta đang nối thông qua Id của Báo)
                // Lưu ý: Tùy thiết kế, ta có thể nối qua MsBao, nhưng ở đây theo logic cũ đồng chí đang nối bằng Id
                // Anh tạm quy định cboSoBao.SelectedValue sẽ khớp với một cột nào đó. 
                // Tốt nhất là nối qua MsBao (Mã Số Báo gốc)

                // Lấy ra mã số báo thực sự từ selected item (vì mình lưu MsBao chứ không lưu Id mongo)
                var selectedBao = (dynamic)cboSoBao.SelectedItem;
                string maSoBao = selectedBao?.MaSoBao?.ToString();

                var list = await _nhuanButColl.Find(n => n.MsBao == maSoBao).ToListAsync();

                // Đổ dữ liệu lên Grid và định dạng tiền tệ (CẬP NHẬT TÊN TRƯỜNG THEO MODEL MỚI)
                dgvNhuanBut.DataSource = list.Select(n => new {
                    n.Id,
                    STT = n.STT,
                    TenBai = n.Tenbai,
                    Trang = n.Trang,
                    Muc = n.Muc,
                    ButDanh = n.Butdanh,
                    Vung = n.Vung,
                    TienNhuanBut = n.TienNhuanbut.ToString("N0") + " VNĐ",
                    NgoaiGio = n.NgoaiGio == "1" ? "Có" : "Không"
                }).ToList();

                if (dgvNhuanBut.Columns["Id"] != null) dgvNhuanBut.Columns["Id"].Visible = false;

                // Tự động cộng tổng tiền đã chấm cho Kỳ này (CẬP NHẬT TÊN TRƯỜNG THEO MODEL MỚI)
                decimal tongTien = list.Sum(n => n.TienNhuanbut);
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        // --- CLICK DÒNG NÀO LÊN DÒNG ĐÓ: Đồng chí chỉ việc gõ tiền ---
        private void dgvNhuanBut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNhuanBut.CurrentRow == null) return;

            var row = dgvNhuanBut.Rows[e.RowIndex];
            _selectedNhuanButId = row.Cells["Id"].Value?.ToString();

            // Đưa thông tin lên Form (CẬP NHẬT THEO CỘT MỚI)
            txtTenBai.Text = row.Cells["TenBai"].Value?.ToString();
            txtTrang.Text = row.Cells["Trang"].Value?.ToString();
            txtMuc.Text = row.Cells["Muc"].Value?.ToString();
            cboButDanh.Text = row.Cells["ButDanh"].Value?.ToString();

            // Xử lý số tiền: Bỏ chữ VNĐ và dấu phẩy để gõ số mới cho nhanh
            string tienRaw = row.Cells["TienNhuanBut"].Value?.ToString().Replace(" VNĐ", "").Replace(",", "");
            txtTienNhuanBut.Text = tienRaw;

            // Nhảy thẳng vào ô tiền và bôi đen để gõ đè luôn
            txtTienNhuanBut.Focus();
            txtTienNhuanBut.SelectAll();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Kỳ xuất bản!", "Cảnh báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenBai.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên bài viết!", "Thông báo");
                return;
            }

            if (!decimal.TryParse(txtTienNhuanBut.Text, out decimal tien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi");
                return;
            }

            try
            {
                // Lấy thông tin Báo đang được chọn
                var selectedBao = (dynamic)cboSoBao.SelectedItem;
                string maSoBao = selectedBao?.MaSoBao?.ToString();

                if (string.IsNullOrEmpty(_selectedNhuanButId))
                {
                    // THÊM MỚI: Dành cho bài chưa có trong danh sách
                    var nb = new NhuanBut
                    {
                        Maso = Guid.NewGuid().ToString().Substring(0, 6).ToUpper(), // Tạo mã số ngẫu nhiên 6 ký tự
                        MsBao = maSoBao,
                        TenSoBao = cboSoBao.Text,
                        Tenbai = txtTenBai.Text.Trim(),
                        Trang = txtTrang.Text.Trim(),
                        Muc = txtMuc.Text.Trim(),
                        Butdanh = cboButDanh.Text,
                        TienNhuanbut = tien,
                        addby = this.NguoiDangNhap,
                        ngaychuyen = DateTime.Now,
                        DaThanhToan = false,

                        // Các trường mới thêm (Có thể làm TextBox trên giao diện để nhập sau, tạm thời fix cứng)
                        Vung = "HNI",
                        VungChuyenDen = "NULL",
                        NgoaiGio = "0",
                        STT = (dgvNhuanBut.Rows.Count + 1).ToString()
                    };
                    await _nhuanButColl.InsertOneAsync(nb);
                }
                else
                {
                    // CẬP NHẬT: Lưu số tiền vừa chấm
                    var filter = Builders<NhuanBut>.Filter.Eq(x => x.Id, _selectedNhuanButId);
                    var update = Builders<NhuanBut>.Update
                        .Set(x => x.Tenbai, txtTenBai.Text.Trim())
                        .Set(x => x.Trang, txtTrang.Text.Trim())
                        .Set(x => x.Muc, txtMuc.Text.Trim())
                        .Set(x => x.Butdanh, cboButDanh.Text)
                        .Set(x => x.TienNhuanbut, tien)
                        .Set(x => x.addby, this.NguoiDangNhap)
                        .Set(x => x.ngaychuyen, DateTime.Now);

                    await _nhuanButColl.UpdateOneAsync(filter, update);
                }

                // Ghi nhật ký hệ thống
                MongoProvider.Instance.GhiNhatKy(this.NguoiDangNhap, $"Đã chấm {tien:N0} VNĐ cho bài '{txtTenBai.Text}'");

                // Làm sạch và tải lại dữ liệu
                if (cboSoBao.SelectedValue != null)
                {
                    await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
                }

                ClearInputs();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi database: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedNhuanButId)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa bài này khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _nhuanButColl.DeleteOneAsync(n => n.Id == _selectedNhuanButId);

                if (cboSoBao.SelectedValue != null)
                {
                    await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
                }
                ClearInputs();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedNhuanButId = null;
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtTienNhuanBut.Clear();
            txtTenBai.Focus();
        }
    }
}