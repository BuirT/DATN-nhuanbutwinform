using System;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        // Biến lưu thông tin người dùng đăng nhập (được truyền từ FormLogin)
        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }

        // Biến lưu trữ form con đang được mở
        private Form activeForm = null;

        public FrmTrangChinh()
        {
            InitializeComponent();
        }

        private void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            // BẮT BUỘC GỌI HÀM NÀY ĐỂ PHÂN QUYỀN TRƯỚC KHI MỞ FORM
            ApplyPermissions();

            // Khi vừa mở máy, hiển thị ngay màn hình Tổng Quan
            btnTongQuan_Click(null, null);
        }

        // ==========================================
        // HÀM QUYẾT ĐỊNH SỰ SỐNG CÒN CỦA MENU
        // ==========================================
        private void ApplyPermissions()
        {
            // 1. Tắt hết mấy cái form nhạy cảm đi (Phòng bệnh hơn chữa bệnh)
            btnDuyetChi.Visible = false;
            btnPhieuChi.Visible = false;
            btnTaiKhoan.Visible = false;

            // Dùng ToLower() để chống lỗi gõ hoa/thường sai lệch từ DB
            string role = currentPrivilege?.Trim().ToLower() ?? "";

            // 2. Cấp quyền hiển thị theo đúng vai trò
            if (role == "lãnh đạo")
            {
                btnDuyetChi.Visible = true; // Sếp thì cho duyệt chi
                btnTaiKhoan.Visible = true; // Sếp được xem danh sách tài khoản
            }
            else if (role == "kế toán")
            {
                btnPhieuChi.Visible = true; // Kế toán thì chỉ được lập phiếu chi
            }
            else if (role == "thư ký")
            {
                // Thư ký chỉ thao tác vòng ngoài (Tác giả, Bút danh...), không mở 3 form kia
            }
            else if (role == "admin" || role == "quản trị viên")
            {
                // TRÙM CUỐI: Mở khóa full tính năng
                btnDuyetChi.Visible = true;
                btnPhieuChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
        }

        // --- HÀM CỐT LÕI: MỞ FORM CON & TRUYỀN QUYỀN ---
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close(); // Đóng form cũ để giải phóng bộ nhớ
            }

            activeForm = childForm;

            // TRUYỀN QUYỀN SANG FORM CON ĐỂ KHÓA NÚT THÊM/SỬA/XÓA BÊN TRONG
            var property = childForm.GetType().GetProperty("QuyenHienTai");
            if (property != null)
            {
                property.SetValue(childForm, currentPrivilege);
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- CÁC SỰ KIỆN BẤM NÚT MENU ---

        private void btnTongQuan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTongQuan());
        private void btnSoBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmSoBao());
        private void btnTacGia_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia());
        private void btnButDanh_Click(object sender, EventArgs e) => OpenChildForm(new FrmButDanh());

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTaiKhoan());
        }

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

        // --- ĐĂNG XUẤT ---
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
        }

        // Đảm bảo đóng hẳn chương trình khi tắt form chính
        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}