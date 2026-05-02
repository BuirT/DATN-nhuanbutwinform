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
            // Khi vừa mở máy, hiển thị ngay màn hình Tổng Quan cho chuyên nghiệp
            btnTongQuan_Click(null, null);
        }

        // --- HÀM CỐT LÕI: MỞ FORM CON BÊN TRONG PANEL MAIN ---
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close(); // Đóng form cũ để giải phóng bộ nhớ
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- CÁC SỰ KIỆN BẤM NÚT MENU ---

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTongQuan());
        }

        private void btnSoBao_Click(object sender, EventArgs e)
        {
            // Sử dụng tên file frmSoBao (chữ f thường) như đồng chí đã tạo
            OpenChildForm(new FrmSoBao());
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTacGia());
        }

        private void btnButDanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmButDanh());
        }

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
            // Truyền tên người lập phiếu để lưu vết
            FrmPhieuChi frmChi = new FrmPhieuChi();
            frmChi.NguoiLapPhieu = this.currentUserName;
            OpenChildForm(frmChi);
        }

        // ==========================================
        // MỚI THÊM: SỰ KIỆN NÚT LÃNH ĐẠO DUYỆT CHI
        // ==========================================
        private void btnDuyetChi_Click(object sender, EventArgs e)
        {
            FrmDuyetPhieuChi frmDuyet = new FrmDuyetPhieuChi();
            // Truyền tên tài khoản đang đăng nhập vào làm người duyệt (nếu trống thì để mặc định)
            frmDuyet.NguoiDuyet = string.IsNullOrEmpty(this.currentUserName) ? "Ban Giám Đốc" : this.currentUserName;
            OpenChildForm(frmDuyet);
        }

        // --- NHÓM MENU BÁO CÁO ---

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Sử dụng đúng tên class baocaotonghop (không viết hoa, không dấu cách)
            OpenChildForm(new FrmBaoCaoTongHop());
        }

        private void btnBaoCaoChiTiet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoChiTiet());
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoCongNo());
        }

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