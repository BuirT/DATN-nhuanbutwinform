using System;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        // THÊM BIẾN NÀY: Để nhận mã tác giả từ FormLogin truyền sang
        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }
        public string currentMaTacGia { get; set; } // <--- CHÌA KHÓA TRA LƯƠNG ĐÂY!

        private Form activeForm = null;

        public FrmTrangChinh()
        {
            InitializeComponent();
        }

        private void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            ApplyPermissions();

            // Nếu là tác giả thì mặc định mở ngay trang Tra cứu, không xem Tổng quan hệ thống
            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnTraCuuCaNhan_Click(null, null);
            }
            else
            {
                btnTongQuan_Click(null, null);
            }
        }

        private void ApplyPermissions()
        {
            // 1. Tắt mặc định các form nhạy cảm
            btnDuyetChi.Visible = false;
            btnPhieuChi.Visible = false;
            btnTaiKhoan.Visible = false;

            // Nút Tra cứu cá nhân (Giả định ông đã thêm nút này vào Designer rồi nhé)
            if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuu)
                btnTraCuu.Visible = false;

            string role = currentPrivilege?.Trim().ToLower() ?? "";

            // 2. PHÂN QUYỀN CHO TÁC GIẢ (PHÓNG VIÊN, CTV, KHÁCH MỜI)
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                // Giấu hết menu quản trị
                btnTongQuan.Visible = false;
                btnSoBao.Visible = false;
                btnTacGia.Visible = false;
                btnButDanh.Visible = false;
                btnNhapNhuanBut.Visible = false;
                btnBaoCao.Visible = false;
                btnBaoCaoChiTiet.Visible = false;
                btnBaoCaoCongNo.Visible = false;

                // CHỈ MỞ NÚT TRA CỨU CỦA HỌ
                if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuuVisible)
                    btnTraCuuVisible.Visible = true;
            }
            // 3. QUYỀN NỘI BỘ (GIỮ NGUYÊN CODE CŨ CỦA ÔNG)
            else if (role == "lãnh đạo")
            {
                btnDuyetChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
            else if (role == "kế toán")
            {
                btnPhieuChi.Visible = true;
            }
            else if (role == "admin" || role == "quản trị viên")
            {
                btnDuyetChi.Visible = true;
                btnPhieuChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;

            // Truyền quyền chung cho các form con
            var propQuyen = childForm.GetType().GetProperty("QuyenHienTai");
            if (propQuyen != null) propQuyen.SetValue(childForm, currentPrivilege);

            // ĐẶC BIỆT: Truyền mã tác giả nếu là Form Tra Cứu
            var propMaGoc = childForm.GetType().GetProperty("MaTacGiaCuaToi");
            if (propMaGoc != null) propMaGoc.SetValue(childForm, currentMaTacGia);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // SỰ KIỆN MỞ FORM TRA CỨU CÁ NHÂN
        private void btnTraCuuCaNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTraCuuNhuanBut());
        }

        // --- CÁC SỰ KIỆN KHÁC GIỮ NGUYÊN ---
        private void btnTongQuan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTongQuan());
        private void btnSoBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmSoBao());
        private void btnTacGia_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia());
        private void btnButDanh_Click(object sender, EventArgs e) => OpenChildForm(new FrmButDanh());
        private void btnTaiKhoan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTaiKhoan());

        private void btnNhapNhuanBut_Click(object sender, EventArgs e)
        {
            FrmNhapNhuanBut frmNhap = new FrmNhapNhuanBut();
            frmNhap.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frmNhap);
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            FrmPhieuChi frmChi = new FrmPhieuChi();
            frmChi.NguoiLapPhieu = this.currentUserName;
            OpenChildForm(frmChi);
        }

        private void btnDuyetChi_Click(object sender, EventArgs e)
        {
            FrmDuyetPhieuChi frmDuyet = new FrmDuyetPhieuChi();
            frmDuyet.NguoiDuyet = string.IsNullOrEmpty(this.currentUserName) ? "Ban Giám Đốc" : this.currentUserName;
            OpenChildForm(frmDuyet);
        }

        private void btnBaoCao_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoTongHop());
        private void btnBaoCaoChiTiet_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoChiTiet());
        private void btnBaoCaoCongNo_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoCongNo());

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}