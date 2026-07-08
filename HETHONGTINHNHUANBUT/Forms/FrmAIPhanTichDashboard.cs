using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HETHONGTINHNHUANBUT
{
    public partial class FrmAIPhanTichDashboard : Form
    {
        public string QuyenHienTai { get; set; }
        
        private readonly AIDashboardService _aiService;
        private DashboardData _dashboardData;

        public FrmAIPhanTichDashboard()
        {
            InitializeComponent();
            _aiService = new AIDashboardService();
            guna2ShadowForm1.SetShadowForm(this);
        }

        private async void FrmAIPhanTichDashboard_Load(object sender, EventArgs e)
        {
            await ProcessAIAnalysisAsync();
        }

        private async Task ProcessAIAnalysisAsync()
        {
            if (!HETHONGTINHNHUANBUT.Helpers.PermissionHelper.CanUseAIDashboard(QuyenHienTai))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng AI Phân tích Dashboard.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                SetLoadingState(true);
                rtbResult.Text = "";

                // Lấy dữ liệu thực tế
                _dashboardData = await _aiService.GetDashboardDataAsync();

                if (_dashboardData.TongBaiViet == 0 && _dashboardData.TongNhuanBut == 0 && _dashboardData.TongPhongVien == 0)
                {
                    MessageBox.Show("Dashboard chưa có dữ liệu để phân tích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetLoadingState(false);
                    return;
                }

                // Gọi AI
                var result = await _aiService.AnalyzeDashboardAsync(_dashboardData);
                string aiResult = result.aiReply;
                AIAnalysisInfo info = result.info;

                // Thêm Disclaimer
                aiResult = _aiService.AppendAIDisclaimer(aiResult);
                
                rtbResult.Text = aiResult;
                HighlightDisclaimer();

                // Cập nhật UI Card
                lblInfoData.Text = $"Thời gian: {info.ThoiGianPhanTich:dd/MM/yyyy HH:mm:ss}\n" +
                                   $"Mô hình AI: {info.MoHinhAI}\n" +
                                   $"Thời gian xử lý: {info.ThoiGianXuLyGiay} giây\n" +
                                   $"Nguồn dữ liệu: {info.NguonDuLieu}";

                lblStatsData.Text = $"Tổng số bài viết: {_dashboardData.TongBaiViet:N0}\n" +
                                    $"Tổng phóng viên: {_dashboardData.TongPhongVien:N0} | Tổng tác giả: {_dashboardData.TongTacGia:N0}\n" +
                                    $"Tổng loại bài: {_dashboardData.TongLoaiBai:N0} | Tổng nhuận bút: {_dashboardData.TongNhuanBut:N0} VNĐ\n" +
                                    $"Khoảng thời gian thống kê: {_dashboardData.KhoangThoiGian}";

                pnlInfoCard.Visible = true;
                rtbResult.BringToFront();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Lỗi kết nối") || ex.Message.Contains("AI"))
                {
                    MessageBox.Show("Không thể kết nối tới Ollama.\nVui lòng kiểm tra AI Server.\n\nChi tiết: " + ex.Message, "Lỗi AI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void HighlightDisclaimer()
        {
            string separator = "=================================================";
            int startIndex = rtbResult.Text.LastIndexOf(separator);
            if (startIndex >= 0)
            {
                rtbResult.Select(startIndex, rtbResult.Text.Length - startIndex);
                rtbResult.SelectionColor = Color.FromArgb(239, 68, 68); // Màu đỏ nhạt / cam (hoặc tùy theo thiết kế)
                rtbResult.SelectionFont = new Font(rtbResult.Font, FontStyle.Italic);
                rtbResult.Select(0, 0); // Reset con trỏ về đầu
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            pnlLoading.Visible = isLoading;
            if (isLoading)
            {
                progressRing.Start();
                pnlLoading.BringToFront();
                pnlLoading.Location = new Point(
                    (pnlMain.Width - pnlLoading.Width) / 2,
                    (pnlMain.Height - pnlLoading.Height) / 2
                );
            }
            else
            {
                progressRing.Stop();
            }
            
            btnCopy.Enabled = !isLoading;
            btnSaveTxt.Enabled = !isLoading;
            btnExportPdf.Enabled = !isLoading;
            btnReAnalyze.Enabled = !isLoading;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetFullExportText()
        {
            string export = "";
            if (pnlInfoCard.Visible)
            {
                export += "=================================================\n";
                export += "THÔNG TIN PHIÊN PHÂN TÍCH\n";
                export += lblInfoData.Text + "\n\n";
                export += "=================================================\n";
                export += "DỮ LIỆU ĐƯỢC PHÂN TÍCH\n";
                export += lblStatsData.Text + "\n";
                export += "=================================================\n\n";
            }
            export += rtbResult.Text;
            return export;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbResult.Text))
            {
                Clipboard.SetText(GetFullExportText());
                MessageBox.Show("Đã copy nội dung vào Clipboard!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbResult.Text)) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.FileName = $"AI_PhanTich_Dashboard_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, GetFullExportText());
                    MessageBox.Show("Đã lưu file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbResult.Text)) return;

            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "AI Phan Tich Dashboard";
            
            StringReader reader = new StringReader(GetFullExportText());

            pDoc.PrintPage += (s, ev) =>
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;
                Font printFont = new Font("Arial", 12);
                SolidBrush myBrush = new SolidBrush(Color.Black);

                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                while (count < linesPerPage && ((line = reader.ReadLine()) != null))
                {
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPos, new StringFormat());
                    count++;
                }

                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pDoc;
            printDialog.UseEXDialog = true;
            
            MessageBox.Show("Để lưu dưới dạng PDF, vui lòng chọn máy in 'Microsoft Print to PDF' trong hộp thoại sắp tới.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }
        }

        private async void btnReAnalyze_Click(object sender, EventArgs e)
        {
            await ProcessAIAnalysisAsync();
        }
    }
}
