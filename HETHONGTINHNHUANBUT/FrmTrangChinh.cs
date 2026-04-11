using System;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        // Các biến toàn cục để nhận dữ liệu từ FormLogin truyền sang
        public string currentUserName = "";
        public string currentGroupID = "";
        public string currentPrivilege = "";

        // Biến ghi nhớ form con đang mở
        private Form activeForm = null;

        public FrmTrangChinh()
        {
            InitializeComponent();
            // Áp dụng viền mượt cho Menu nền sáng
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new LightModeColorTable());
        }

        // ====================================================================
        // 1. SỰ KIỆN LOAD TRANG CHÍNH & PHÂN QUYỀN
        // ====================================================================
        private void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            // FIX LỖI CRASH: Đảm bảo các biến không bị NULL khi chạy Test trực tiếp
            currentUserName = currentUserName ?? "Admin";
            currentGroupID = currentGroupID ?? "Admin";
            currentPrivilege = currentPrivilege ?? "";

            // Hiển thị tên người dùng lên tiêu đề Form
            this.Text = $"Hệ Thống Quản Lý Tính và Chi Trả Nhuận Bút - Xin chào đồng chí: {currentUserName.ToUpper()}";

            // Phân quyền Lớp 1 (Admin vs Thường)
            // Fix lỗi ẩn Menu: Nếu currentGroupID rỗng (chạy test), tự động cho là Admin
            bool isAdmin = string.IsNullOrEmpty(currentGroupID) || currentGroupID.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase);

            quảnLýTàiKhoảnToolStripMenuItem.Visible = isAdmin;
            cấuHìnhĐịnhMứcThamSốToolStripMenuItem.Visible = isAdmin;

            // Phân quyền Lớp 2 (Nghiệp vụ chi tiết cho nhân viên thường)
            string privileges = currentPrivilege.ToLower();

            if (!isAdmin)
            {
                // Nếu KHÔNG CÓ chữ "nhuanbut" thì ẨN menu Nhập nhuận bút
                if (!privileges.Contains("nhuanbut"))
                {
                    tínhNhuậnBútBàiViếtToolStripMenuItem.Visible = false;
                }

                // Nếu KHÔNG CÓ chữ "phieuchi" thì ẨN menu Lập phiếu chi
                if (!privileges.Contains("phieuchi"))
                {
                    lậpPhiếuChiToolStripMenuItem.Visible = false;
                    chiTrảNhuậnBútToolStripMenuItem.Visible = false;
                }
            }

            // Sau khi kiểm tra phân quyền xong -> Mở trang Tổng Quan
            MoFormCon(new FrmTongQuan());
        }

        // ====================================================================
        // 2. HÀM MỞ FORM CON (KHÔNG VIỀN, LẤP ĐẦY TRANG CHÍNH)
        // ====================================================================
        private void MoFormCon(Form formCon)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = formCon;
            formCon.MdiParent = this;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            formCon.Show();
        }

        // ====================================================================
        // 3. SỰ KIỆN CLICK CÁC MENU (GỌI FORM)
        // ====================================================================

        // --- NHÓM HỆ THỐNG ---
        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmQuanLyTaiKhoan());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đồng chí muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void thoátHệThốngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Trở về trang chủ
            MoFormCon(new FrmTongQuan());
        }

        private void cấuHìnhĐịnhMứcThamSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gọi Trợ lý AI
            MoFormCon(new FrmTroLyAI());
        }

        // --- NHÓM QUẢN LÝ DANH MỤC ---
        private void hồSơPhóngViênTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmTacGia());
        }

        private void bútDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmButdanh());
        }

        private void sốBáoKỳXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmSoBao());
        }

        // --- NHÓM TÍNH VÀ CHI TRẢ NHUẬN BÚT ---
        private void tínhNhuậnBútBàiViếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmNhapNhuanBut());
        }

        private void lậpPhiếuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmPhieuChi());
        }

        private void chiTrảNhuậnBútToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmThanhToan());
        }

        // --- NHÓM BÁO CÁO THỐNG KÊ ---
        private void bảngKêNhuậnBútChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmBaoCaoChiTiet());
        }

        private void báoCáoCôngNợPhóngViênTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmBaoCaoCongNo());
        }

        private void tổngHợpChiTrảNhuậnBútTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmTongHopThang());
        }

        private void báoCáoTổngHợpToànTòaSoạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmBaoCaoTongHop());
        }
    }

    // ====================================================================
    // KHU VỰC BẢNG MÀU CHUYÊN NGHIỆP CHO MENU (LIGHT THEME)
    // ====================================================================
    public class LightModeColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.FromArgb(232, 238, 255);
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemPressedGradientBegin => Color.White;
        public override Color MenuItemPressedGradientEnd => Color.White;
        public override Color ToolStripDropDownBackground => Color.White;
    }
}