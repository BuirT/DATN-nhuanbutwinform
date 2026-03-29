using System;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        // Các biến toàn cục để nhận dữ liệu từ FormLogin truyền sang
        public string currentUserName = "";
        public string currentGroupID = "";
        public string currentPrivilege = "";

        public FrmTrangChinh()
        {
            InitializeComponent();
        }

        // ====================================================================
        // 1. SỰ KIỆN LOAD TRANG CHÍNH & PHÂN QUYỀN
        // ====================================================================
        private void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng lên tiêu đề Form
            this.Text = $"Hệ Thống Quản Lý Tính và Chi Trả Nhuận Bút - Xin chào đồng chí: {currentUserName.ToUpper()}";

            // Phân quyền Lớp 1 (Admin vs Thường)
            bool isAdmin = currentGroupID.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase);
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
            MoFormCon(new FrmTongQuan());
        }

        // ====================================================================
        // 2. HÀM MỞ FORM CON CHUẨN GIAO DIỆN HIỆN ĐẠI (KHÔNG VIỀN, PHỦ KÍN)
        // ====================================================================
        private void MoFormCon(Form formCon)
        {
            // Tắt hết các form con cũ đang mở để giải phóng bộ nhớ
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            // Nhúng form mới vào khu vực trống của Trang chính
            formCon.MdiParent = this;
            formCon.FormBorderStyle = FormBorderStyle.None; // Xóa viền cửa sổ
            formCon.Dock = DockStyle.Fill;                  // Phủ kín toàn bộ vùng xám
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
                // Thay vì Close() làm tắt luôn phần mềm, mình dùng Restart() để khởi động lại luồng
                Application.Restart();
            }
        }

        private void thoátHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát hoàn toàn phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            MoFormCon(new frmSoBao()); // Chú ý chữ f viết thường theo đúng class anh tạo
        }

        // --- NHÓM TÍNH VÀ CHI TRẢ NHUẬN BÚT ---
        private void tínhNhuậnBútBàiViếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ép Form Nhập Nhuận Bút mở chìm qua hàm MoFormCon thay vì .Show()
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

        private void thoátHệThốngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MoFormCon(new FrmTongQuan());
        }

        private void cấuHìnhĐịnhMứcThamSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmTroLyAI());
        }


        // (Các menu còn lại như Báo cáo Thống kê, Tổng hợp chi trả... khi nào anh em mình làm Form xong thì sẽ gọi hàm MoFormCon() tương tự ở đây)
    }
}