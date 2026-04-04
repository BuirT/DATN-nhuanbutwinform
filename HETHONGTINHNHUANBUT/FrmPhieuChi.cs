using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models; // Quan trọng: Phải dùng Model mới
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmPhieuChi : Form
    {
        bool isAddNew = false;
        string taiKhoanDangNhap = "ADMIN";

        // Khởi tạo Collection MongoDB cho Phiếu Chi và Nhật Ký
        private IMongoCollection<PhieuChi> phieuChiColl = DataProvider.Instance.GetCollection<PhieuChi>("PhieuChi");
        private IMongoCollection<LichSuThaoTac> logColl = DataProvider.Instance.GetCollection<LichSuThaoTac>("LichSuThaoTac");

        public FrmPhieuChi()
        {
            InitializeComponent();
        }

        private void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            LoadData();
            btnLuu.Enabled = false;
            dgvPhieuChi.DefaultCellStyle.Font = new Font("VNI-Times", 10.2F);

            // Ghi nhật ký qua MongoDB
            DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, "Truy cập màn hình Quản lý Phiếu Chi trên Cloud");
        }

        void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ MongoDB và sắp xếp theo ngày lập mới nhất
                var list = phieuChiColl.Find(_ => true).SortByDescending(x => x.Ngaylap).ToList();
                dgvPhieuChi.DataSource = list;

                // Ẩn cột ID của MongoDB để giao diện gọn đẹp
                if (dgvPhieuChi.Columns["Id"] != null) dgvPhieuChi.Columns["Id"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu từ Cloud: " + ex.Message); }
        }

        private decimal TinhThueTNCN(decimal tongTien, decimal thueSuat)
        {
            if (tongTien >= 2000000) return tongTien * (thueSuat / 100);
            return 0;
        }

        private void TinhTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoTien.Text)) return;
                decimal soTien = Convert.ToDecimal(txtSoTien.Text);
                decimal thueSuat = string.IsNullOrEmpty(txtThueSuat.Text) ? 0 : Convert.ToDecimal(txtThueSuat.Text);
                decimal tienThue = TinhThueTNCN(soTien, thueSuat);
                decimal conLai = soTien - tienThue;
                txtThue.Text = Math.Round(tienThue, 0).ToString();
                txtConLai.Text = Math.Round(conLai, 0).ToString();
            }
            catch { }
        }

        #region Xử lý Email (Giữ nguyên logic của đồng chí)
        private async Task<bool> GuiEmailAmTham(string emailNhan, string tenTacGia, string soPhieu, string soTien)
        {
            try
            {
                string emailGui = "duynguyen31052004@gmail.com";
                string matKhauUngDung = "lpqquubafroscazr"; // LƯU Ý: Đổi pass sau khi bảo vệ!
                string tieuDe = $"[Tòa Soạn] Thông báo chi trả nhuận bút - Phiếu {soPhieu}";
                string noiDungHTML = $@"<div style='font-family: Arial; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                        <h2 style='color: #A26EFF;'>BIÊN LAI ĐIỆN TỬ</h2>
                        <p>Kính chào đồng chí <b>{tenTacGia}</b>, Toà soạn đã chi trả <b>{soTien} VNĐ</b> (Phiếu: {soPhieu}).</p></div>";

                MailMessage message = new MailMessage(emailGui, emailNhan, tieuDe, noiDungHTML) { IsBodyHtml = true };
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true, Credentials = new NetworkCredential(emailGui, matKhauUngDung) })
                {
                    await smtp.SendMailAsync(message);
                }
                return true;
            }
            catch { return false; }
        }

        private async void btnGuiHangLoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Gửi Email cho TẤT CẢ các phiếu chi trong bảng?", "Xác nhận Cloud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            int thanhCong = 0, thatBai = 0;
            btnGuiHangLoat.Enabled = false;
            this.Text = "Đang đồng bộ dữ liệu Cloud & Gửi Email...";

            foreach (DataGridViewRow row in dgvPhieuChi.Rows)
            {
                if (row.IsNewRow) continue;
                string soPhieu = row.Cells["Sophieu"].Value?.ToString() ?? "";
                string tenTacGia = row.Cells["Nguoinhan"].Value?.ToString() ?? "";
                decimal conLai = 0;
                if (row.Cells["Conlai"].Value != null) decimal.TryParse(row.Cells["Conlai"].Value.ToString(), out conLai);

                // Gửi email test
                bool ok = await GuiEmailAmTham("duynguyen31052004@gmail.com", tenTacGia, soPhieu, conLai.ToString("N0"));
                if (ok) thanhCong++; else thatBai++;
            }

            this.Text = "Lập Phiếu Chi Nhuận Bút";
            btnGuiHangLoat.Enabled = true;
            DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Hoàn tất gửi mail hàng loạt. Thành công: {thanhCong}");
            MessageBox.Show($"Hoàn tất!\n✔️ Thành công: {thanhCong}\n❌ Thất bại: {thatBai}", "Báo cáo Cloud");
        }
        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnLuu.Enabled = true;
            txtSoPhieu.Text = "PC" + DateTime.Now.ToString("yyMMddHHmm");
            txtNguoiNhan.Clear(); txtSoTien.Clear(); txtThue.Clear(); txtConLai.Clear();
            txtNguoiNhan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            isAddNew = false;
            btnLuu.Enabled = true;
            txtSoPhieu.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;

            try
            {
                PhieuChi pc = new PhieuChi()
                {
                    Sophieu = txtSoPhieu.Text,
                    Ngaylap = dtpNgayLap.Value,
                    Nguoinhan = txtNguoiNhan.Text,
                    Lydo = txtLyDo.Text,
                    Sotien = Convert.ToDecimal(txtSoTien.Text),
                    Thuesuat = (float)Convert.ToDecimal(txtThueSuat.Text),
                    Thue = Convert.ToDecimal(txtThue.Text),
                    Conlai = Convert.ToDecimal(txtConLai.Text),
                    addby = taiKhoanDangNhap
                };

                if (isAddNew)
                {
                    phieuChiColl.InsertOne(pc);
                    DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Thêm mới phiếu chi {pc.Sophieu} lên Cloud");
                    MessageBox.Show("Đã lưu Phiếu chi lên MongoDB thành công!", "Thông báo");
                }
                else
                {
                    // Update trong MongoDB dùng Filter và UpdateBuilder
                    var filter = Builders<PhieuChi>.Filter.Eq(x => x.Sophieu, pc.Sophieu);
                    var update = Builders<PhieuChi>.Update
                        .Set(x => x.Ngaylap, pc.Ngaylap)
                        .Set(x => x.Nguoinhan, pc.Nguoinhan)
                        .Set(x => x.Lydo, pc.Lydo)
                        .Set(x => x.Sotien, pc.Sotien)
                        .Set(x => x.Thuesuat, pc.Thuesuat)
                        .Set(x => x.Thue, pc.Thue)
                        .Set(x => x.Conlai, pc.Conlai);

                    phieuChiColl.UpdateOne(filter, update);
                    DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Chỉnh sửa phiếu chi {pc.Sophieu} trên Cloud");
                    MessageBox.Show("Cập nhật dữ liệu Cloud thành công!", "Thông báo");
                }
                LoadData();
                btnHuy_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thao tác MongoDB: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            if (MessageBox.Show("Xóa phiếu chi này khỏi Cloud?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sophieu = txtSoPhieu.Text;
                phieuChiColl.DeleteOne(x => x.Sophieu == sophieu);

                DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"XÓA phiếu chi {sophieu} trên Cloud");
                LoadData();
                btnHuy_Click(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtSoPhieu.Clear(); txtNguoiNhan.Clear(); txtSoTien.Clear();
            txtThue.Clear(); txtConLai.Clear();
            btnLuu.Enabled = false; txtSoPhieu.ReadOnly = false;
        }

        private void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuChi.CurrentRow == null || e.RowIndex < 0) return;

            // Lấy dữ liệu từ hàng đang chọn
            var row = dgvPhieuChi.Rows[e.RowIndex];
            txtSoPhieu.Text = row.Cells["Sophieu"].Value?.ToString() ?? "";
            txtNguoiNhan.Text = row.Cells["Nguoinhan"].Value?.ToString() ?? "";
            txtLyDo.Text = row.Cells["Lydo"].Value?.ToString() ?? "";

            if (row.Cells["Ngaylap"].Value is DateTime dt) dtpNgayLap.Value = dt;
            if (decimal.TryParse(row.Cells["Sotien"].Value?.ToString(), out decimal st)) txtSoTien.Text = Math.Round(st, 0).ToString();
            if (decimal.TryParse(row.Cells["Thuesuat"].Value?.ToString(), out decimal ts)) txtThueSuat.Text = Math.Round(ts, 0).ToString();
            if (decimal.TryParse(row.Cells["Thue"].Value?.ToString(), out decimal th)) txtThue.Text = Math.Round(th, 0).ToString();
            if (decimal.TryParse(row.Cells["Conlai"].Value?.ToString(), out decimal cl)) txtConLai.Text = Math.Round(cl, 0).ToString();

            btnLuu.Enabled = false;
        }
    }
}