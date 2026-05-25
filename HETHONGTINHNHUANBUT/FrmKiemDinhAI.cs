using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmKiemDinhAI : Form
    {
        // Biến công khai để Form Nhập Nhuận Bút có thể lấy được kết quả sau khi đóng form này
        public AIResult KetQuaAI { get; private set; }

        public FrmKiemDinhAI()
        {
            InitializeComponent();
            
            // Mặc định khóa nút Lưu Điểm khi chưa có kết quả quét
            btnXacNhan.Enabled = false; 
        }

        // =======================================================
        // 1. SỰ KIỆN BẤM NÚT QUÉT AI
        // =======================================================
        private async void btnQuetAI_Click(object sender, EventArgs e)
        {
            string noiDung = rtbNoiDung.Text.Trim();
            
            // Kiểm tra xem người dùng đã dán bài báo vào chưa
            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Đồng chí vui lòng dán (Paste) nội dung bài báo vào khung chữ trước khi quét nhé!", 
                                "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbNoiDung.Focus();
                return;
            }

            // Đổi trạng thái giao diện trong lúc chờ AI xử lý (để tránh người dùng bấm nhiều lần)
            btnQuetAI.Text = "⏳ HỆ THỐNG AI ĐANG PHÂN TÍCH VÀ ĐÁNH GIÁ...";
            btnQuetAI.Enabled = false;
            rtbNoiDung.ReadOnly = true; // Khóa khung nhập text tạm thời

            try
            {
                // Gọi AIHelper chạy bất đồng bộ (không làm đơ/treo giao diện WinForms)
                KetQuaAI = await AIHelper.KiemDinhBaiBaoAsync(noiDung);

                // Nếu AI trả về kết quả thành công
                if (KetQuaAI != null)
                {
                    // Cập nhật kết quả lên các nhãn (Label)
                    lblDiem.Text = $"Điểm chất lượng: {KetQuaAI.DiemChatLuong}/10";
                    lblDaoVan.Text = $"Cảnh báo đạo văn: {KetQuaAI.TyLeDaoVan}";
                    lblNhanXet.Text = $"Tổng biên tập (AI) nhận xét: {KetQuaAI.NhanXet}";
                    
                    // Quét xong thì mở khóa nút LƯU ĐIỂM SỐ
                    btnXacNhan.Enabled = true; 
                    
                    MessageBox.Show("Đã hoàn tất đánh giá bài viết!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không nhận được phản hồi từ Trợ lý AI. Đồng chí vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message, "Sự cố", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Dù thành công hay lỗi, cũng phải trả lại trạng thái ban đầu cho form
                btnQuetAI.Text = "🚀 TIẾN HÀNH QUÉT & ĐÁNH GIÁ";
                btnQuetAI.Enabled = true;
                rtbNoiDung.ReadOnly = false;
            }
        }

        // =======================================================
        // 2. SỰ KIỆN XÁC NHẬN LƯU ĐIỂM
        // =======================================================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Trả về DialogResult.OK để Form cha biết là người dùng đã chốt điểm
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        // =======================================================
        // 3. SỰ KIỆN HỦY BỎ / THOÁT
        // =======================================================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Trả về Cancel để Form cha bỏ qua, không lưu dữ liệu
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}