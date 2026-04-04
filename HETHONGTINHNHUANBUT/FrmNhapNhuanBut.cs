using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        // Biến toàn cục để lưu trạng thái hành động (Thêm mới hay Sửa)
        private bool isThêmMới = false;

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
        }

        private void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            // 1. Tải danh sách Số báo vào cboSoBao
            LoadDuLieuSoBao();

            // 2. Tải danh sách Tác giả/Bút danh vào cboButDanh
            LoadDuLieuButDanh();

            // 3. Khởi tạo trạng thái ban đầu cho giao diện
            ResetThongTin();
            BatTatCacNut(true, false, false, false, false); // Chỉ mở nút Thêm ban đầu
        }

        #region Các hàm hỗ trợ giao diện & Logic

        private void KhoaGiaoDienSoBao(bool isLocked)
        {
            // Vô hiệu hóa các nút nếu Số báo đã chốt
            btnThem.Enabled = !isLocked;
            btnSua.Enabled = !isLocked;
            btnXoa.Enabled = !isLocked;
            btnLuu.Enabled = !isLocked;

            // Đóng/mở khung nhập liệu
            groupBox1.Enabled = !isLocked;

            // Đổi màu và text nút Chốt sổ để nhận diện
            if (isLocked)
            {
                btnChotSo.Text = "🔒 ĐÃ CHỐT SỔ";
                btnChotSo.FillColor = Color.Gray;
                btnChotSo.Enabled = false; // Đã chốt thì không cho bấm lại ở form này
            }
            else
            {
                btnChotSo.Text = "🔓 KHÓA / CHỐT SỔ";
                btnChotSo.FillColor = Color.Crimson;
                btnChotSo.Enabled = true;
            }
        }

        private void BatTatCacNut(bool them, bool sua, bool xoa, bool luu, bool huy)
        {
            btnThem.Enabled = them;
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
            btnLuu.Enabled = luu;
            btnHuy.Enabled = huy;
        }

        private void ResetThongTin()
        {
            txtMaBai.Clear();
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtSoTien.Clear();
            cboButDanh.SelectedIndex = -1;
            txtTenBai.Focus();
        }

        #endregion

        #region Tương tác Database (Đồng chí thay code thực tế vào đây)

        private void LoadDuLieuSoBao()
        {
            // TODO: Truy vấn CSDL lấy danh sách Số Báo
            // Ví dụ: cboSoBao.DataSource = db.SoBaos.ToList();
            // cboSoBao.DisplayMember = "TenSoBao";
            // cboSoBao.ValueMember = "MaSoBao";
        }

        private void LoadDuLieuButDanh()
        {
            // TODO: Truy vấn CSDL lấy danh sách Bút danh / Tác giả
        }

        private void LoadDanhSachBaiViet(string maSoBao)
        {
            // TODO: Truy vấn danh sách bài viết thuộc Mã Số Báo này và đổ vào DataGridView
            // dgvNhuanButCT.DataSource = db.BaiViets.Where(x => x.MaSoBao == maSoBao).ToList();

            // Cập nhật lại Tổng tiền
            TinhTongTien(maSoBao);
        }

        private void TinhTongTien(string maSoBao)
        {
            // TODO: Tính tổng số tiền nhuận bút của Số báo này
            double tongTien = 0; // Thay bằng lệnh SUM trong SQL/EF
            lblTongTien.Text = "Tổng quỹ: " + tongTien.ToString("N0") + " VNĐ";
        }

        private int KiemTraTrangThaiSoBao(string maSoBao)
        {
            // TODO: Truy vấn xem Số báo này có Status là gì (0: Đang nhập, 1: Đã chốt kiểm tra, 2: Đã duyệt)
            // Tạm thời return 0 để test
            return 0;
        }

        #endregion

        #region Sự kiện Các Control

        private void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null)
            {
                string maSoBao = cboSoBao.SelectedValue.ToString();

                // 1. Tải danh sách bài viết
                LoadDanhSachBaiViet(maSoBao);

                // 2. Kiểm tra trạng thái khóa của số báo
                int trangThai = KiemTraTrangThaiSoBao(maSoBao);
                bool isLocked = (trangThai >= 1); // Trạng thái >= 1 nghĩa là đã trình đi, không được sửa
                KhoaGiaoDienSoBao(isLocked);
            }
        }

        private void dgvNhuanButCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào header hoặc số báo đã khóa thì không làm gì cả
            if (e.RowIndex < 0 || !groupBox1.Enabled) return;

            // Đổ dữ liệu từ lưới lên các TextBox
            DataGridViewRow row = dgvNhuanButCT.Rows[e.RowIndex];
            txtMaBai.Text = row.Cells["MaBai"].Value?.ToString();
            txtTenBai.Text = row.Cells["TenBai"].Value?.ToString();
            txtTrang.Text = row.Cells["Trang"].Value?.ToString();
            txtMuc.Text = row.Cells["Muc"].Value?.ToString();
            txtSoTien.Text = row.Cells["SoTien"].Value?.ToString();
            cboButDanh.Text = row.Cells["ButDanh"].Value?.ToString();

            BatTatCacNut(true, true, true, false, true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThêmMới = true;
            ResetThongTin();
            BatTatCacNut(false, false, false, true, true);
            // Có thể tự động sinh Mã Bài mới ở đây
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text))
            {
                MessageBox.Show("Vui lòng chọn bài viết cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isThêmMới = false;
            BatTatCacNut(false, false, false, true, true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetThongTin();
            BatTatCacNut(true, false, false, false, false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtTenBai.Text) || string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Tên bài và Số tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double soTien;
            if (!double.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- LOGIC CHẶN VƯỢT TRẦN THEO WORKFLOW ---
            double mucTran = 2000000; // Định mức 2 triệu/bài (Có thể kéo từ CSDL lên)
            if (soTien > mucTran)
            {
                DialogResult rs = MessageBox.Show($"Số tiền {soTien:N0} VNĐ đang vượt mức trần quy định ({mucTran:N0} VNĐ). Đồng chí có chắc chắn muốn tiếp tục lưu?", "Cảnh báo cao tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.No) return;
            }

            try
            {
                if (isThêmMới)
                {
                    // TODO: Lệnh INSERT bài viết mới vào Database
                }
                else
                {
                    // TODO: Lệnh UPDATE bài viết đang chọn vào Database
                }

                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachBaiViet(cboSoBao.SelectedValue.ToString());
                btnHuy_Click(null, null); // Reset lại UI
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bài viết này khỏi danh sách nhận nhuận bút?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // TODO: Lệnh DELETE bài viết trong Database

                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachBaiViet(cboSoBao.SelectedValue.ToString());
                btnHuy_Click(null, null);
            }
        }

        private void btnChotSo_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) return;

            DialogResult confirm = MessageBox.Show(
                "Đồng chí có chắc chắn muốn CHỐT SỔ báo này để gửi Ban thư ký duyệt? Sau khi chốt, toàn bộ tính năng Thêm/Sửa/Xóa nhuận bút của số báo này sẽ bị KHÓA!",
                "Xác nhận Workflow",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string maSoBao = cboSoBao.SelectedValue.ToString();

                try
                {
                    // TODO: Thực hiện lệnh UPDATE Database để chuyển Status của Số báo này thành 1 (Đã chốt)
                    // Ví dụ: db.ExecuteCommand("UPDATE SoBao SET Status = 1 WHERE MaSoBao = '" + maSoBao + "'");

                    MessageBox.Show("Chốt sổ thành công! Dữ liệu đã được khóa và chuyển qua bộ phận Kiểm tra.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Khóa giao diện ngay lập tức
                    KhoaGiaoDienSoBao(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chốt sổ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}