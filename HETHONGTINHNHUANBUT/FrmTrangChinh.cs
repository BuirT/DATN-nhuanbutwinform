using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }
        public string currentMaTacGia { get; set; }

        private Form activeForm = null;
        private Guna2Button currentActiveButton = null;
        private static bool _dbFixed = false;

        public FrmTrangChinh()
        {
            InitializeComponent();
        }

        private async void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlMenu.SuspendLayout();

            if (!_dbFixed) { await AutoFixDatabaseColumns(); _dbFixed = true; }

            ApplyPermissions();

            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnNhapNhuanBut_Click(null, null);
                SetActiveButton(this.btnNhapNhuanBut);
            }
            else
            {
                btnDashboard_Click(null, null);
                SetActiveButton(btnDashboard);
            }

            pnlMenu.ResumeLayout();
            this.ResumeLayout();
        }

        private void SetActiveButton(Guna2Button clickedButton)
        {
            if (clickedButton == null) return;

            if (currentActiveButton != null)
            {
                currentActiveButton.FillColor = System.Drawing.Color.Transparent;
                currentActiveButton.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            }

            currentActiveButton = clickedButton;
            currentActiveButton.FillColor = System.Drawing.Color.FromArgb(238, 242, 255);
            currentActiveButton.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
        }

        private async Task AutoFixDatabaseColumns()
        {
            string cn = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    await conn.OpenAsync();

                    string fixNhuanbut = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiNhap' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiNhap NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKiemTra NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKeToan' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKeToan NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TongThuKy' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TongThuKy NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiChamTien' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiChamTien NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LyDoBaoSai' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD LyDoBaoSai NVARCHAR(500);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayBaoSai' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayBaoSai DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayChamTien' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayChamTien DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayNhapLieu' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayNhapLieu DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayKiemTra DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayKy' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayKy DATETIME;
                        UPDATE Nhuanbut SET TrangThaiDuyet = 0 WHERE TrangThaiDuyet IS NULL;";
                    using (SqlCommand cmd = new SqlCommand(fixNhuanbut, conn))
                        await cmd.ExecuteNonQueryAsync();

                    string fixNhuanbutCT = @"
                        IF NOT EXISTS(SELECT * FROM sys.objects WHERE Name = N'NhuanbutCT' AND Type = N'U')
                            CREATE TABLE NhuanbutCT (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                MsTacgia NVARCHAR(50),
                                MsNhuanbut INT,
                                Sotien DECIMAL(18,0),
                                SoPC NVARCHAR(50),
                                SauThanhToan NVARCHAR(10)
                            );";
                    using (SqlCommand cmdCT = new SqlCommand(fixNhuanbutCT, conn))
                        await cmdCT.ExecuteNonQueryAsync();

                    string fixPhieuchi = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NguoiDuyet NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NgayDuyet DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LyDoTuChoi' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD LyDoTuChoi NVARCHAR(MAX);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Dathutien' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD Dathutien NVARCHAR(1) DEFAULT 'N';
                        UPDATE Phieuchi SET TrangThaiDuyet = 0 WHERE TrangThaiDuyet IS NULL;";
                    using (SqlCommand cmd2 = new SqlCommand(fixPhieuchi, conn))
                        await cmd2.ExecuteNonQueryAsync();
                }
            }
            catch { }
        }

            private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDashboard(), sender as Guna2Button);
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoThongKe(), sender as Guna2Button);
        }

        private void btnCanhBaoAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCanhBaoAI(), sender as Guna2Button);
        }

    private void ApplyPermissions()
        {
            string role = currentPrivilege?.Trim().ToLower() ?? "";

            // Ẩn toàn bộ nút chức năng (trừ Đăng xuất luôn hiện)
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button btn && btn != btnDangXuat)
                    btn.Visible = false;
            }

            // Nhóm chỉ dành cho admin/quản trị
            if (role == "admin" || role == "quản trị viên")
            {
                SetButtonVisible(true,
                    btnDashboard, btnTroLyAI, btnBaoCaoAI,
                    btnBaoCaoThongKe, btnCanhBaoAI,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet, btnPhieuChi, btnDuyetChi,
                    btnDotThanhToan, btnTaiKhoan,
                    btnTacGia, btnSubTacGiaHoSo, btnSubButDanh,
                    btnQuanLyBao, btnSubSoBao, btnSubLoaiBao,
                    btnBaoCao, btnSubBaoCaoTH, btnSubBaoCaoCN, btnSubBaoCaoLD);
                return;
            }

            // Nhóm phóng viên – chỉ viết bài & tra cứu
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan);
                return;
            }

            // Nhóm thư ký
            if (role == "thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
                return;
            }

            // Nhóm kế toán
            if (role == "kế toán")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnPhieuChi, btnDuyetChi,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan);
                return;
            }

            // Nhóm lãnh đạo
            if (role == "lãnh đạo")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet, btnDuyetChi,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan, btnTaiKhoan);
                return;
            }

            // Nhóm kiểm tra viên
            if (role == "kiểm tra viên")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
                return;
            }

            // Nhóm tổng thư ký
            if (role == "tổng thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
                return;
            }
        }

        private void SetButtonVisible(bool visible, params Guna.UI2.WinForms.Guna2Button[] buttons)
        {
            foreach (var btn in buttons)
                btn.Visible = visible;
        }

        private void OpenChildForm(Form childForm, Guna2Button clickedButton = null)
        {
            if (clickedButton != null) SetActiveButton(clickedButton);

            if (activeForm != null) activeForm.Close();
            activeForm = childForm;

            var propQuyen = childForm.GetType().GetProperty("QuyenHienTai");
            if (propQuyen != null) propQuyen.SetValue(childForm, currentPrivilege);

            var propMaGoc = childForm.GetType().GetProperty("MaTacGiaCuaToi");
            if (propMaGoc != null) propMaGoc.SetValue(childForm, currentMaTacGia);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ==========================================================
        // CÁC SỰ KIỆN MỞ FORM CON
        // ==========================================================
        private void btnBaoCaoAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoAI(), sender as Guna2Button);
        }

        private void btnTroLyAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTroLyAI(), sender as Guna2Button);
        }

        private void btnDotThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThanhToan(), sender as Guna2Button);
        }

        private void btnQuanLyBao_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubSoBao.Visible;
            btnSubSoBao.Visible = !isExpanded;
            btnSubLoaiBao.Visible = !isExpanded;

            if (!isExpanded)
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▲";
            else
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▼";
        }

        private void btnSubSoBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmSoBao(), sender as Guna2Button);
        private void btnSubLoaiBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmLoaiBao(), sender as Guna2Button);
        private void btnTraCuuCaNhan_Click(object sender, EventArgs e)
        {
            FrmTraCuuNhuanBut frm = new FrmTraCuuNhuanBut();
            frm.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frm, sender as Guna2Button);
        }
        private void btnTacGia_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubTacGiaHoSo.Visible;
            btnSubTacGiaHoSo.Visible = !isExpanded;
            btnSubButDanh.Visible = !isExpanded;
            btnTacGia.Text = isExpanded ? "QUẢN LÝ TÁC GIẢ  ▼" : "QUẢN LÝ TÁC GIẢ  ▲";
        }
        private void btnSubTacGiaHoSo_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia(), sender as Guna2Button);
        private void btnButDanh_Click(object sender, EventArgs e) => OpenChildForm(new FrmButDanh(), sender as Guna2Button);
        private void btnTaiKhoan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTaiKhoan(), sender as Guna2Button);

        private void btnNhapNhuanBut_Click(object sender, EventArgs e)
        {
            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                FrmNhapBaiPhongVien frmNhap = new FrmNhapBaiPhongVien();
                frmNhap.NguoiDangNhap = this.currentUserName;
                OpenChildForm(frmNhap, sender as Guna2Button);
            }
            else
            {
                FrmNhapNhuanBut frmNhap = new FrmNhapNhuanBut();
                frmNhap.NguoiDangNhap = this.currentUserName;
                OpenChildForm(frmNhap, sender as Guna2Button);
            }
        }

        private void btnKiemDuyet_Click(object sender, EventArgs e)
        {
            FrmKiemDuyetNhuanBut frm = new FrmKiemDuyetNhuanBut();
            frm.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frm, sender as Guna2Button);
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            FrmPhieuChi frmChi = new FrmPhieuChi();
            frmChi.NguoiLapPhieu = this.currentUserName;
            OpenChildForm(frmChi, sender as Guna2Button);
        }

        private void btnDuyetChi_Click(object sender, EventArgs e)
        {
            FrmDuyetPhieuChi frmDuyet = new FrmDuyetPhieuChi();
            frmDuyet.NguoiDuyet = string.IsNullOrEmpty(this.currentUserName) ? "Ban Giám Đốc" : this.currentUserName;
            OpenChildForm(frmDuyet, sender as Guna2Button);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubBaoCaoTH.Visible;
            btnSubBaoCaoTH.Visible = !isExpanded;
            btnSubBaoCaoCN.Visible = !isExpanded;
            btnSubBaoCaoLD.Visible = !isExpanded;
            btnBaoCao.Text = isExpanded ? "BÁO CÁO  ▼" : "BÁO CÁO  ▲";
        }
        private void btnSubBaoCaoTH_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoTongHop(), sender as Guna2Button);
        private void btnSubBaoCaoCN_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoCongNo(), sender as Guna2Button);
        private void btnSubBaoCaoLD_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoLanhDao(), sender as Guna2Button);

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}