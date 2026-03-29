using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmPhieuChi : Form
    {
        bool isAddNew = false;

        // Giả sử tài khoản đang đăng nhập là ADMIN (Sau này anh lấy từ Form Login truyền qua nhé)
        string taiKhoanDangNhap = "ADMIN";

        public FrmPhieuChi()
        {
            InitializeComponent();
        }

        private void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            LoadData();
            btnLuu.Enabled = false;
            dgvPhieuChi.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvPhieuChi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);

            // Ghi log: Có người vừa mở màn hình Phiếu chi
            DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, "Truy cập màn hình Quản lý Phiếu Chi");
        }

        void LoadData()
        {
            try
            {
                string sql = "SELECT Sophieu, Ngaylap, Nguoinhan, Lydo, Sotien, Thuesuat, Thue, Conlai FROM Phieuchi ORDER BY Ngaylap DESC";
                dgvPhieuChi.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
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

        private void GuiEmailBienLai(string emailNhan, string tenTacGia, string soPhieu, string soTien)
        {
            try
            {
                string emailGui = "duynguyen31052004@gmail.com";
                string matKhauUngDung = "lpqquubafroscazr";
                string tieuDe = $"[Tòa Soạn] Thông báo chi trả nhuận bút - Phiếu {soPhieu}";
                string noiDungHTML = $@"<div style='font-family: Arial; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                        <h2 style='color: #A26EFF;'>BIÊN LAI ĐIỆN TỬ</h2>
                        <p>Kính chào đồng chí <b>{tenTacGia}</b>, Toà soạn đã chi trả <b>{soTien} VNĐ</b> (Phiếu: {soPhieu}).</p></div>";

                MailMessage message = new MailMessage(emailGui, emailNhan, tieuDe, noiDungHTML) { IsBodyHtml = true };
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true, Credentials = new NetworkCredential(emailGui, matKhauUngDung) };
                smtp.Send(message);

                // 📸 CAMERA GHI HÌNH: Gửi email thành công
                DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Gửi email biên lai thành công cho phiếu {soPhieu}");

                MessageBox.Show("Đã gửi biên lai điện tử thành công!", "Ting Ting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi gửi Email:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool GuiEmailAmTham(string emailNhan, string tenTacGia, string soPhieu, string soTien)
        {
            try
            {
                string emailGui = "duynguyen31052004@gmail.com";
                string matKhauUngDung = "lpqquubafroscazr";
                string tieuDe = $"[Tòa Soạn] Thông báo chi trả nhuận bút - Phiếu {soPhieu}";
                string noiDungHTML = $@"<div style='font-family: Arial; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                        <h2 style='color: #A26EFF;'>BIÊN LAI ĐIỆN TỬ</h2>
                        <p>Kính chào đồng chí <b>{tenTacGia}</b>, Toà soạn đã chi trả <b>{soTien} VNĐ</b> (Phiếu: {soPhieu}).</p></div>";

                MailMessage message = new MailMessage(emailGui, emailNhan, tieuDe, noiDungHTML) { IsBodyHtml = true };
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true, Credentials = new NetworkCredential(emailGui, matKhauUngDung) };
                smtp.Send(message);
                return true;
            }
            catch { return false; }
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            GuiEmailBienLai("duynguyen31052004@gmail.com", txtNguoiNhan.Text, txtSoPhieu.Text, Convert.ToDecimal(txtConLai.Text).ToString("N0"));
        }

        private async void btnGuiHangLoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Gửi Email cho TẤT CẢ các phiếu chi trong bảng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            int thChong = 0, tBai = 0;
            this.Text = "Đang gửi Email hàng loạt... Vui lòng chờ...";
            btnGuiHangLoat.Enabled = false;

            // 📸 CAMERA GHI HÌNH: Bắt đầu chạy gửi hàng loạt
            DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, "Khởi chạy chức năng Gửi Email Biên Lai Hàng Loạt");

            foreach (DataGridViewRow row in dgvPhieuChi.Rows)
            {
                if (row.IsNewRow) continue;

                string soPhieu = row.Cells["Sophieu"].Value?.ToString() ?? "";
                string tenTacGia = row.Cells["Nguoinhan"].Value?.ToString() ?? "";
                decimal conLai = 0;
                if (row.Cells["Conlai"].Value != null) decimal.TryParse(row.Cells["Conlai"].Value.ToString(), out conLai);
                string soTienThucNhan = conLai.ToString("N0");

                string emailNhan = "duynguyen31052004@gmail.com"; // Email Test

                if (string.IsNullOrEmpty(emailNhan)) { tBai++; continue; }

                bool ketQua = await Task.Run(() => GuiEmailAmTham(emailNhan, tenTacGia, soPhieu, soTienThucNhan));
                if (ketQua) thChong++; else tBai++;
            }

            this.Text = "Lập Phiếu Chi Nhuận Bút";
            btnGuiHangLoat.Enabled = true;

            // 📸 CAMERA GHI HÌNH: Tổng kết
            DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Hoàn tất gửi hàng loạt. Thành công: {thChong}, Thất bại: {tBai}");

            MessageBox.Show($"Hoàn tất!\n✔️ Thành công: {thChong}\n❌ Thất bại: {tBai}", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThem_Click(object sender, EventArgs e) { isAddNew = true; btnLuu.Enabled = true; txtSoPhieu.Text = "PC" + DateTime.Now.ToString("yyMMddHHmm"); txtNguoiNhan.Clear(); txtSoTien.Clear(); txtThue.Clear(); txtConLai.Clear(); txtLyDo.Text = "Chi trả nhuận bút"; txtNguoiNhan.Focus(); }

        private void btnSua_Click(object sender, EventArgs e) { if (string.IsNullOrEmpty(txtSoPhieu.Text)) return; isAddNew = false; btnLuu.Enabled = true; txtSoPhieu.ReadOnly = true; }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            try
            {
                if (isAddNew)
                {
                    string sql = @"INSERT INTO Phieuchi (Sophieu, Ngaylap, Nguoinhan, Lydo, Sotien, Thuesuat, Thue, Conlai) VALUES (@sp, @ngay, @nguoi, @lydo, @sotien, @thuesuat, @thue, @conlai)";
                    object[] para = { txtSoPhieu.Text, dtpNgayLap.Value, txtNguoiNhan.Text, txtLyDo.Text, Convert.ToDecimal(txtSoTien.Text), Convert.ToDecimal(txtThueSuat.Text), Convert.ToDecimal(txtThue.Text), Convert.ToDecimal(txtConLai.Text) };
                    DataProvider.Instance.ExecuteNonQuery(sql, para);

                    // 📸 CAMERA GHI HÌNH: Lập phiếu chi mới
                    DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Thêm mới phiếu chi {txtSoPhieu.Text} cho {txtNguoiNhan.Text} - Số tiền: {txtSoTien.Text}");

                    MessageBox.Show("Đã lập Phiếu chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql = @"UPDATE Phieuchi SET Ngaylap=@ngay, Nguoinhan=@nguoi, Lydo=@lydo, Sotien=@sotien, Thuesuat=@thuesuat, Thue=@thue, Conlai=@conlai WHERE Sophieu=@sp";
                    object[] para = { dtpNgayLap.Value, txtNguoiNhan.Text, txtLyDo.Text, Convert.ToDecimal(txtSoTien.Text), Convert.ToDecimal(txtThueSuat.Text), Convert.ToDecimal(txtThue.Text), Convert.ToDecimal(txtConLai.Text), txtSoPhieu.Text };
                    DataProvider.Instance.ExecuteNonQuery(sql, para);

                    // 📸 CAMERA GHI HÌNH: Sửa phiếu chi
                    DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Chỉnh sửa phiếu chi {txtSoPhieu.Text}");

                    MessageBox.Show("Cập nhật Phiếu chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData(); btnHuy_Click(sender, e);
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            if (MessageBox.Show("Hủy phiếu chi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string phieuBiXoa = txtSoPhieu.Text; // Lưu tạm cái tên trước khi xóa
                DataProvider.Instance.ExecuteNonQuery("DELETE FROM Phieuchi WHERE Sophieu = @sp", new object[] { phieuBiXoa });

                // 📸 CAMERA GHI HÌNH: Xóa phiếu chi (Hành vi nguy hiểm)
                DataProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"XÓA HỦY phiếu chi {phieuBiXoa}");
                LoadData(); btnHuy_Click(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) { txtSoPhieu.Clear(); txtNguoiNhan.Clear(); txtSoTien.Clear(); txtThue.Clear(); txtConLai.Clear(); btnLuu.Enabled = false; txtSoPhieu.ReadOnly = false; }

        private void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuChi.CurrentRow == null || e.RowIndex < 0) return;
            DataGridViewRow r = dgvPhieuChi.Rows[e.RowIndex];
            txtSoPhieu.Text = r.Cells["Sophieu"].Value?.ToString() ?? "";
            if (DateTime.TryParse(r.Cells["Ngaylap"].Value?.ToString(), out DateTime dt)) dtpNgayLap.Value = dt;
            txtNguoiNhan.Text = r.Cells["Nguoinhan"].Value?.ToString() ?? ""; txtLyDo.Text = r.Cells["Lydo"].Value?.ToString() ?? "";
            if (decimal.TryParse(r.Cells["Sotien"].Value?.ToString(), out decimal st)) txtSoTien.Text = Math.Round(st, 0).ToString();
            if (decimal.TryParse(r.Cells["Thuesuat"].Value?.ToString(), out decimal ts)) txtThueSuat.Text = Math.Round(ts, 0).ToString();
            if (decimal.TryParse(r.Cells["Thue"].Value?.ToString(), out decimal th)) txtThue.Text = Math.Round(th, 0).ToString();
            if (decimal.TryParse(r.Cells["Conlai"].Value?.ToString(), out decimal cl)) txtConLai.Text = Math.Round(cl, 0).ToString();
            btnLuu.Enabled = false;
        }
    }
}