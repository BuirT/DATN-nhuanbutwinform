using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
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

        // Khởi tạo Collection MongoDB
        private IMongoCollection<PhieuChi> phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");

        public FrmPhieuChi()
        {
            InitializeComponent();
        }

        private void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            LoadData();
            btnLuu.Enabled = false;

            // Thiết lập font chữ cho bảng
            dgvPhieuChi.DefaultCellStyle.Font = new Font("VNI-Times", 10.2F);

            // Ghi nhật ký qua MongoDB
            MongoProvider.Instance.GhiNhatKy(taiKhoanDangNhap, "Truy cập màn hình Quản lý Phiếu Chi trên Cloud");
        }

        void LoadData()
        {
            try
            {
                var list = phieuChiColl.Find(_ => true).SortByDescending(x => x.Ngaylap).ToList();
                dgvPhieuChi.DataSource = list;

                if (dgvPhieuChi.Columns["Id"] != null) dgvPhieuChi.Columns["Id"].Visible = false;

                // Đổi tên cột hiển thị cho đẹp
                if (dgvPhieuChi.Columns["Sophieu"] != null) dgvPhieuChi.Columns["Sophieu"].HeaderText = "Số Phiếu";
                if (dgvPhieuChi.Columns["Nguoinhan"] != null) dgvPhieuChi.Columns["Nguoinhan"].HeaderText = "Người Nhận";
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

        #region Xử lý Email
        private async Task<bool> GuiEmailAmTham(string emailNhan, string tenTacGia, string soPhieu, string soTien)
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
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true, Credentials = new NetworkCredential(emailGui, matKhauUngDung) })
                {
                    await smtp.SendMailAsync(message);
                }
                return true;
            }
            catch { return false; }
        }

        // Fix lỗi thiếu định nghĩa btnGuiEmail_Click trong Designer
        private async void btnGuiEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            this.Text = "Đang gửi Email...";
            bool ok = await GuiEmailAmTham("duynguyen31052004@gmail.com", txtNguoiNhan.Text, txtSoPhieu.Text, txtConLai.Text);
            this.Text = "Lập Phiếu Chi Nhuận Bút";

            if (ok) MessageBox.Show("Đã gửi biên lai cho tác giả!");
            else MessageBox.Show("Gửi Email thất bại!");
        }

        private async void btnGuiHangLoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Gửi Email hàng loạt?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            int thanhCong = 0;
            btnGuiHangLoat.Enabled = false;

            foreach (DataGridViewRow row in dgvPhieuChi.Rows)
            {
                if (row.IsNewRow) continue;
                string soPhieu = row.Cells["Sophieu"].Value?.ToString() ?? "";
                string tenTG = row.Cells["Nguoinhan"].Value?.ToString() ?? "";
                string tien = row.Cells["Conlai"].Value?.ToString() ?? "0";

                if (await GuiEmailAmTham("duynguyen31052004@gmail.com", tenTG, soPhieu, tien)) thanhCong++;
            }

            btnGuiHangLoat.Enabled = true;
            MongoProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Gửi thành công {thanhCong} email hàng loạt");
            MessageBox.Show($"Hoàn tất gửi {thanhCong} email!");
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
                    MongoProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Thêm mới phiếu {pc.Sophieu}");
                }
                else
                {
                    var filter = Builders<PhieuChi>.Filter.Eq(x => x.Sophieu, pc.Sophieu);
                    var update = Builders<PhieuChi>.Update
                        .Set(x => x.Ngaylap, pc.Ngaylap)
                        .Set(x => x.Nguoinhan, pc.Nguoinhan)
                        .Set(x => x.Lydo, pc.Lydo)
                        .Set(x => x.Sotien, pc.Sotien)
                        .Set(x => x.Thue, pc.Thue)
                        .Set(x => x.Conlai, pc.Conlai);
                    phieuChiColl.UpdateOne(filter, update);
                    MongoProvider.Instance.GhiNhatKy(taiKhoanDangNhap, $"Sửa phiếu {pc.Sophieu}");
                }
                LoadData();
                btnHuy_Click(sender, e);
                MessageBox.Show("Đã lưu dữ liệu lên Cloud!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoPhieu.Text)) return;
            if (MessageBox.Show("Xóa phiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                phieuChiColl.DeleteOne(x => x.Sophieu == txtSoPhieu.Text);
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
            if (e.RowIndex < 0) return;
            var row = dgvPhieuChi.Rows[e.RowIndex];
            txtSoPhieu.Text = row.Cells["Sophieu"].Value?.ToString();
            txtNguoiNhan.Text = row.Cells["Nguoinhan"].Value?.ToString();
            txtLyDo.Text = row.Cells["Lydo"].Value?.ToString();
            // Đổ các trường còn lại tương tự...
            btnLuu.Enabled = false;
        }
    }
}