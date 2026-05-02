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
    public partial class FrmPhieuChi : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private readonly IMongoCollection<PhieuChi> _phieuChiColl;

        // ĐÃ THÊM: Khai báo Collection Bút Danh
        private readonly IMongoCollection<ButDanh> _butDanhColl;

        public string NguoiLapPhieu { get; set; }

        public FrmPhieuChi()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
            _phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");

            // ĐÃ THÊM: Kết nối CSDL Bút Danh
            _butDanhColl = MongoProvider.Instance.GetCollection<ButDanh>("Butdanh");
        }

        private async void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            // Tạm tắt sự kiện để load dữ liệu an toàn
            cboTacGia.SelectedIndexChanged -= cboTacGia_SelectedIndexChanged;
            await LoadAuthorsAsync();
            cboTacGia.SelectedIndexChanged += cboTacGia_SelectedIndexChanged;

            cboHinhThuc.SelectedIndex = 0;
            txtSoPhieu.Text = "PC-" + DateTime.Now.ToString("yyyyMMdd-HHmm");

            // Tự động kích hoạt hiển thị cho người đầu tiên trong danh sách nợ
            if (cboTacGia.Items.Count > 0)
            {
                cboTacGia.SelectedIndex = 0;
                cboTacGia_SelectedIndexChanged(null, null);
            }
        }

        private async Task LoadAuthorsAsync()
        {
            try
            {
                // Lọc những bài chưa thanh toán
                var listChuaThanhToan = await _nhuanButColl.Find(n => n.DaThanhToan == false).ToListAsync();

                var pendingAuthors = listChuaThanhToan
                    .Where(n => !string.IsNullOrWhiteSpace(n.Butdanh))
                    .Select(n => n.Butdanh.Trim())
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                cboTacGia.DataSource = null;
                cboTacGia.DataSource = pendingAuthors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tác giả: " + ex.Message);
            }
        }

        private async void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTacGia.SelectedItem == null)
            {
                dgvChuaThanhToan.DataSource = null;
                return;
            }

            string penName = cboTacGia.SelectedItem.ToString();

            try
            {
                // 1. DÒ TÌM TÁC GIẢ GỐC TỪ BÚT DANH
                var butDanhInfo = await _butDanhColl.Find(b => b.Butdanh == penName).FirstOrDefaultAsync();

                if (butDanhInfo != null && !string.IsNullOrEmpty(butDanhInfo.MsTacgia))
                {
                    string maTacGiaGoc = butDanhInfo.MsTacgia;

                    // ĐÃ SỬA CHUẨN: Dùng 'Maso' vì 'MaHT' bị gắn cờ [BsonIgnore][cite: 6]
                    var tacGiaInfo = await _tacGiaColl.Find(t => t.Maso == maTacGiaGoc).FirstOrDefaultAsync();

                    if (tacGiaInfo != null)
                    {
                        // Đã tìm thấy "chính chủ"! Gán thông tin lên Form Phiếu Chi[cite: 6]
                        txtNguoiNhan.Text = tacGiaInfo.Hoten;  // Dùng Hoten chuẩn
                        txtCMND.Text = tacGiaInfo.MsTG;        // Dùng MsTG chuẩn thay vì MaThe

                        // Nếu anh có lưu Điện thoại hay Mã số thuế trong database thì mở comment ra dùng nhé
                        // txtDienThoai.Text = tacGiaInfo.Email; // Ví dụ tạm
                        // txtMST.Text = tacGiaInfo.SoTaiKhoan; 
                    }
                    else
                    {
                        // Không tìm thấy tác giả gốc
                        txtNguoiNhan.Text = penName;
                        ClearTacGiaInfo();
                    }
                }
                else
                {
                    txtNguoiNhan.Text = penName;
                    ClearTacGiaInfo();
                }

                // 2. LOAD LƯỚI BÀI VIẾT
                var list = await _nhuanButColl.Find(n => n.Butdanh == penName && n.DaThanhToan == false).ToListAsync();

                dgvChuaThanhToan.DataSource = list.Select(n => new {
                    n.Id,
                    n.TenSoBao,
                    n.TenBai,
                    TienNhuanBut = n.TienNhuanbut
                }).ToList();

                if (dgvChuaThanhToan.Columns["Id"] != null) dgvChuaThanhToan.Columns["Id"].Visible = false;

                if (dgvChuaThanhToan.Columns["TienNhuanBut"] != null)
                    dgvChuaThanhToan.Columns["TienNhuanBut"].DefaultCellStyle.Format = "N0";

                TinhToanTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết bài viết: " + ex.Message);
            }
        }

        private void ClearTacGiaInfo()
        {
            txtCMND.Text = "";
            txtDienThoai.Text = "";
            txtMST.Text = "";
        }

        private void TinhToanTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);
                if (isChecked)
                {
                    decimal tien = Convert.ToDecimal(row.Cells["TienNhuanBut"].Value);
                    tong += tien;
                }
            }

            txtTongTien.Text = tong.ToString("N0");

            if (decimal.TryParse(txtThueSuat.Text, out decimal thuePhanTram))
            {
                decimal thueVnd = tong * (thuePhanTram / 100);
                decimal thucLinh = tong - thueVnd;

                txtTienThue.Text = thueVnd.ToString("N0");
                txtThucLinh.Text = thucLinh.ToString("N0");
            }
        }

        private async void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<string> selectedIds = new List<string>();
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colCheck"].Value))
                {
                    selectedIds.Add(row.Cells["Id"].Value.ToString());
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bài viết để thanh toán!", "Cảnh báo");
                return;
            }

            try
            {
                decimal tongTien = decimal.Parse(txtTongTien.Text.Replace(",", ""));
                decimal thueSuat = decimal.Parse(txtThueSuat.Text.Replace(",", ""));
                decimal tienThue = decimal.Parse(txtTienThue.Text.Replace(",", ""));
                decimal thucLinh = decimal.Parse(txtThucLinh.Text.Replace(",", ""));

                string hinhThucSQL = cboHinhThuc.Text.Contains("TM") ? "TM" : "CK";

                var phieu = new PhieuChi
                {
                    SoPhieu = txtSoPhieu.Text,
                    NgayLap = DateTime.Now,
                    LyDo = txtLyDo.Text.Trim(),
                    TenTacGia = cboTacGia.Text,
                    NguoiNhan = txtNguoiNhan.Text.Trim(),

                    TongTien = tongTien,
                    ThueSuat = thueSuat,
                    Thue = tienThue,
                    ThucLinh = thucLinh,

                    HinhThuc = hinhThucSQL,
                    DaThuTien = "N",

                    NguoiLap = string.IsNullOrEmpty(this.NguoiLapPhieu) ? "Admin" : this.NguoiLapPhieu,
                    AddBy = string.IsNullOrEmpty(this.NguoiLapPhieu) ? "Admin" : this.NguoiLapPhieu,

                    MST = txtMST.Text.Trim(),
                    CMND = txtCMND.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),

                    DanhSachBaiViet = selectedIds
                };

                await _phieuChiColl.InsertOneAsync(phieu);

                // Cập nhật các bài viết này thành Đã thanh toán
                var filter = Builders<NhuanBut>.Filter.In(n => n.Id, selectedIds);
                var update = Builders<NhuanBut>.Update
                    .Set(n => n.DaThanhToan, true)
                    .Set(n => n.MaPhieuChi, phieu.SoPhieu);

                await _nhuanButColl.UpdateManyAsync(filter, update);

                MessageBox.Show("Lập phiếu chi thành công rực rỡ!", "Thông báo");

                // Khởi tạo lại form sau khi trả tiền xong
                txtSoPhieu.Text = "PC-" + DateTime.Now.ToString("yyyyMMdd-HHmm");

                // Tạm tắt sự kiện để load lại danh sách
                cboTacGia.SelectedIndexChanged -= cboTacGia_SelectedIndexChanged;
                await LoadAuthorsAsync();
                cboTacGia.SelectedIndexChanged += cboTacGia_SelectedIndexChanged;

                if (cboTacGia.Items.Count > 0)
                {
                    cboTacGia.SelectedIndex = 0;
                    cboTacGia_SelectedIndexChanged(null, null);
                }
                else
                {
                    dgvChuaThanhToan.DataSource = null;
                    txtTongTien.Text = "0";
                    txtTienThue.Text = "0";
                    txtThucLinh.Text = "0";
                    ClearTacGiaInfo();
                    txtNguoiNhan.Text = "";
                }

            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu phiếu chi: " + ex.Message); }
        }

        private void dgvChuaThanhToan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) TinhToanTien();
        }

        private void dgvChuaThanhToan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChuaThanhToan.IsCurrentCellDirty) dgvChuaThanhToan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void txtThueSuat_TextChanged(object sender, EventArgs e) => TinhToanTien();
    }
}