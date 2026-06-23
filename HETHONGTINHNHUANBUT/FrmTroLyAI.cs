using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTroLyAI : Form
    {
        private static readonly string endpoint = AIConfig.GenerateUrl;
        private static readonly string aiModel = AIConfig.OllamaModel;
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmTroLyAI()
        {
            InitializeComponent();
            txtInput.KeyDown += TxtInput_KeyDown;
            flpChat.Resize += FlpChat_Resize;

            ThemBongBongChat("🤖 Chào đồng chí! Tôi là Trợ lý AI hệ thống NewsPay. " +
                "Tôi có thể:\n" +
                "• 📊 Hỏi thống kê tổng quan (tổng bài, tổng tiền, trạng thái duyệt...)\n" +
                "• 👤 Tra cứu tác giả (vd: 'thông tin tác giả Nguyễn Văn A')\n" +
                "• 📅 Báo cáo theo tháng (vd: 'thống kê tháng 6/2026')\n" +
                "• 💰 Phiếu chi, thuế (vd: 'phiếu chi tháng này')\n" +
                "• 🔍 Phát hiện bất thường (vd: 'kiểm tra bài bất thường')\n" +
                "Đồng chí muốn hỏi gì?", false);
        }

        private void FlpChat_Resize(object sender, EventArgs e)
        {
            if (flpChat.IsDisposed) return;
            foreach (Control c in flpChat.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Panel pnl && pnl.Controls.Count > 0 && pnl.Controls[0] is Label lbl)
                {
                    lbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                    if (pnl.FillColor == Color.FromArgb(6, 78, 59)) // isUser
                    {
                        pnl.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - pnl.Width - 25), 10, 10, 10);
                    }
                }
                else if (c is Label oldLbl)
                {
                    oldLbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                    if (oldLbl.BackColor == Color.FromArgb(6, 78, 59)) // isUser
                    {
                        oldLbl.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - oldLbl.Width - 25), 10, 10, 10);
                    }
                }
            }
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGui_Click(null, null);
            }
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed) return;

            try
            {
                string cauHoi = txtInput.Text.Trim();
                if (string.IsNullOrEmpty(cauHoi)) return;

                ThemBongBongChat(cauHoi, true);
                txtInput.Clear();

                btnGui.Enabled = false;
                txtInput.ReadOnly = true;
                btnGui.Text = "ĐANG NGHĨ...";

                string phanHoi = await XuLyCauHoiThongMinhAsync(cauHoi);

                if (this.IsDisposed) return;
                ThemBongBongChat(phanHoi, false);

                btnGui.Enabled = true;
                txtInput.ReadOnly = false;
                btnGui.Text = "GỬI";
                txtInput.Focus();
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ThemBongBongChat("🔄 Đang làm mới dữ liệu hệ thống...", false);
            string thongTin = await LayToanBoThongTinHeThongAsync();
            ThemBongBongChat("✅ Dữ liệu đã cập nhật:\n" + thongTin, false);
        }

        // =========================================================================
        // XỬ LÝ CÂU HỎI THÔNG MINH - TỰ ĐỘNG PHÁT HIỆN Ý ĐỊNH
        // =========================================================================
        private async Task<string> XuLyCauHoiThongMinhAsync(string cauHoi)
        {
            try
            {
                string lower = cauHoi.ToLower();
                string dataContext = "";
                string chuDe = "hệ thống";

                if (lower.Contains("tác giả") || lower.Contains("phóng viên") || lower.Contains("người viết") || lower.Contains("ai viết"))
                {
                    dataContext = await LayThongTinTacGiaAsync(cauHoi);
                    chuDe = "tác giả";
                }
                else if (lower.Contains("phiếu chi") || lower.Contains("thuế") || lower.Contains("thanh toán") || lower.Contains("đã chi"))
                {
                    dataContext = await LayThongTinPhieuChiAsync();
                    chuDe = "phiếu chi";
                }
                else if (lower.Contains("tháng") || lower.Contains("quý") || lower.Contains("năm") || lower.Contains("202"))
                {
                    dataContext = await LayThongTinTheoThangAsync(cauHoi);
                    chuDe = "thống kê tháng";
                }
                else if (lower.Contains("bất thường") || lower.Contains("kiểm tra") || lower.Contains("cảnh báo") || lower.Contains("rủi ro"))
                {
                    dataContext = await LayThongTinBatThuongAsync();
                    chuDe = "bất thường";
                }
                else if (lower.Contains("định mức") || lower.Contains("tối đa") || lower.Contains("khung") || lower.Contains("thể loại"))
                {
                    dataContext = await LayThongTinDinhMucAsync();
                    chuDe = "định mức";
                }
                else
                {
                    dataContext = await LayToanBoThongTinHeThongAsync();
                    chuDe = "hệ thống";
                    // Thêm tri thức hệ thống cho câu hỏi chung
                    dataContext += @"

【QUY TRÌNH NGHIỆP VỤ NEWSPAY】
- Bài viết trải qua 5 bước duyệt:
  Bước 1: Thư ký chấm tiền (TrangThaiDuyet: 0→1)
  Bước 2: Kế toán nhập liệu nhuận bút (TrangThaiDuyet: 1→2)
  Bước 3: Kiểm tra viên kiểm tra (TrangThaiDuyet: 2→3)
  Bước 4: Tổng thư ký ký duyệt (TrangThaiDuyet: 3→4)
  Bước 5: Lập phiếu chi → Lãnh đạo duyệt chi → Thanh toán

【CÁC VAI TRÒ HỆ THỐNG】
- Phóng viên (PV): Nộp bài, tra cứu thu nhập
- Thư ký: Chấm tiền bài viết
- Kế toán: Nhập liệu nhuận bút, quản lý phiếu chi
- Kiểm tra viên: Kiểm tra số liệu
- Tổng thư ký: Ký duyệt bài
- Lãnh đạo: Ký duyệt phiếu chi
- Admin/Quản trị viên: Quản lý toàn bộ hệ thống

【CÁC TÍNH NĂNG CHÍNH】
- Nộp bài: Phóng viên nhập thông tin bài, AI kiểm toán metadata
- Kiểm duyệt: Duyệt qua 4 bước với phân quyền rõ ràng
- Tra cứu: Xem thu nhập cá nhân, trạng thái bài
- Báo cáo: Xuất Excel, biểu đồ, báo cáo AI tự động
- Phiếu chi: Lập phiếu, tính thuế TNCN 10% nếu >= 2.000.000đ
- Quản lý: Tác giả, bút danh, số báo, thể loại, tài khoản

【CÁCH TÍNH THUẾ】
- Nếu tổng tiền chi CHO MỘT LẦN trả từ 2.000.000đ trở lên: KHẤU TRỪ 10% thuế TNCN
- Dưới 2.000.000đ: KHÔNG khấu trừ thuế

【ĐỊNH MỨC NHUẬN BÚT】
- Tin vắn: tối đa 500.000đ
- Phân tích: tối đa 3.000.000đ
- Phỏng vấn: tối đa 2.500.000đ
- Bài định: tối đa 4.000.000đ
- Xã luận: tối đa 5.000.000đ
- Phóng sự: tối đa 3.000.000đ
- Các thể loại khác: tối đa 2.000.000đ";
                }

                if (string.IsNullOrEmpty(dataContext))
                    dataContext = "(Không có dữ liệu phù hợp)";

                return await GuiTinNhanChatAI(cauHoi, dataContext, chuDe);
            }
            catch (Exception ex)
            {
                return "⚠️ Lỗi: " + ex.Message;
            }
        }

        // =========================================================================
        // GỌI OLLAMA
        // =========================================================================
        private async Task<string> GuiTinNhanChatAI(string userMessage, string dataContext, string chuDe = "hệ thống")
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(2);

                string prompt = $@"Bạn là chuyên gia tư vấn về nhuận bút báo chí và Trợ lý AI của hệ thống NewsPay.

Đồng chí đang hỏi về: {chuDe}

DỮ LIỆU THỰC TẾ TỪ HỆ THỐNG (nếu có):
{dataContext}

Hướng dẫn trả lời:
- Ưu tiên dùng dữ liệu từ hệ thống ở trên để trả lời nếu có thông tin liên quan.
- Nếu câu hỏi vượt quá dữ liệu hệ thống, hãy dùng KIẾN THỨC CHUYÊN MÔN của bạn về nghiệp vụ nhuận bút, báo chí, thuế TNCN, quy trình tòa soạn... để tư vấn cho đồng chí.
- Phân biệt rõ: ""Theo dữ liệu hệ thống..."" (khi có số liệu) và ""Theo quy định chung..."" (khi dùng kiến thức).
- Trả lời bằng tiếng Việt, chuyên nghiệp, dễ hiểu.

Câu hỏi: {userMessage}";

                var requestBody = new
                {
                    model = aiModel,
                    prompt = prompt,
                    stream = false,
                    options = new { temperature = 0.1 }
                };

                string jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                    return $"Ollama lỗi: {response.StatusCode}";

                string responseJson = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(responseJson);
                return result["response"]?.ToString().Replace("**", "").Trim() ?? "...";
            }
        }

        // =========================================================================
        // 1. TỔNG QUAN HỆ THỐNG
        // =========================================================================
        private async Task<string> LayToanBoThongTinHeThongAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    // Tổng quan đã duyệt
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS TongBai, ISNULL(SUM(TienNhuanbut),0) AS TongTien,
                               AVG(TienNhuanbut) AS TrungBinh, MAX(TienNhuanbut) AS CaoNhat
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 4", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【TỔNG QUAN ĐÃ DUYỆT】Bài: {r["TongBai"]}, Tiền: {Convert.ToDecimal(r["TongTien"]):N0}đ, TB: {Convert.ToDecimal(r["TrungBinh"]):N0}đ, Cao nhất: {Convert.ToDecimal(r["CaoNhat"]):N0}đ");
                        r.Close();
                    }

                    // Trạng thái duyệt
                    using (var cmd = new SqlCommand(@"
                        SELECT TrangThaiDuyet, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS TongTien
                        FROM Nhuanbut GROUP BY TrangThaiDuyet ORDER BY TrangThaiDuyet", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        sb.AppendLine("【TRẠNG THÁI】");
                        while (r.Read())
                        {
                            int tt = Convert.ToInt32(r["TrangThaiDuyet"]);
                            string ten = tt == 0 ? "Chờ chấm tiền" : tt == 1 ? "Đã chấm - chờ nhập liệu" : tt == 2 ? "Đã nhập - chờ kiểm tra" : tt == 3 ? "Đã kiểm tra - chờ ký duyệt" : "Đã ký duyệt";
                            sb.AppendLine($"• {ten}: {r["SL"]} bài - {Convert.ToDecimal(r["TongTien"]):N0}đ");
                        }
                        r.Close();
                    }

                    // Phiếu chi chờ duyệt
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(Sotien),0) AS Tong FROM Phieuchi WHERE TrangThaiDuyet = 0", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【PHIẾU CHỜ】{r["SL"]} phiếu - {Convert.ToDecimal(r["Tong"]):N0}đ");
                        r.Close();
                    }

                    // Thống kê tháng này
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=MONTH(GETDATE()) AND YEAR(ngaychuyen)=YEAR(GETDATE())", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【THÁNG NÀY】{r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                        r.Close();
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI DB] " + ex.Message;
            }
        }

        // =========================================================================
        // 2. TRA CỨU TÁC GIẢ
        // =========================================================================
        private async Task<string> LayThongTinTacGiaAsync(string cauHoi)
        {
            try
            {
                // Trích xuất tên tác giả từ câu hỏi
                string keyword = cauHoi
                    .Replace("thông tin", "").Replace("tác giả", "").Replace("phóng viên", "")
                    .Replace("người viết", "").Replace("tra cứu", "").Replace("tìm", "")
                    .Trim().Trim(',');

                if (string.IsNullOrEmpty(keyword)) keyword = "%";

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    string sql = @"
                        SELECT tg.Hoten, tg.MsTG, tg.PhongBan, tg.DienThoai, tg.Email, tg.LoaiTacgia,
                               (SELECT COUNT(*) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso) AS SoBai,
                                (SELECT ISNULL(SUM(nb.TienNhuanbut),0) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso AND nb.TrangThaiDuyet >= 4) AS TongTien
                        FROM TacGia tg
                        WHERE tg.Hoten LIKE N'%' + @k + '%' OR tg.MsTG LIKE '%' + @k + '%'";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", keyword);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            int stt = 0;
                            while (r.Read())
                            {
                                stt++;
                                sb.AppendLine($"【TÁC GIẢ {stt}】{r["Hoten"]} (Mã: {r["MsTG"]})");
                                sb.AppendLine($"   Loại: {r["LoaiTacgia"]}, Phòng: {r["PhongBan"]}");
                                sb.AppendLine($"   Email: {r["Email"]}, ĐT: {r["DienThoai"]}");
                                sb.AppendLine($"   Tổng bài: {r["SoBai"]}, Tổng tiền đã duyệt: {Convert.ToDecimal(r["TongTien"]):N0}đ");
                            }
                            if (stt == 0) sb.AppendLine("Không tìm thấy tác giả phù hợp.");
                        }
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI TRA CỨU TÁC GIẢ] " + ex.Message;
            }
        }

        // =========================================================================
        // 3. THỐNG KÊ THEO THÁNG
        // =========================================================================
        private async Task<string> LayThongTinTheoThangAsync(string cauHoi)
        {
            try
            {
                int thang = DateTime.Now.Month, nam = DateTime.Now.Year;

                // Parse tháng/năm từ câu hỏi (vd: "tháng 6/2026")
                var match = System.Text.RegularExpressions.Regex.Match(cauHoi, @"(\d{1,2})\s*[/\-]\s*(\d{4})");
                if (match.Success)
                {
                    thang = int.Parse(match.Groups[1].Value);
                    nam = int.Parse(match.Groups[2].Value);
                }

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();
                    sb.AppendLine($"【BÁO CÁO THÁNG {thang}/{nam}】");

                    // Tổng quan
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong,
                               COUNT(DISTINCT Butdanh) AS SoTG
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                                sb.AppendLine($"Tổng: {r["SL"]} bài, {Convert.ToDecimal(r["Tong"]):N0}đ, {r["SoTG"]} tác giả");
                            r.Close();
                        }
                    }

                    // Top 5 tác giả
                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 5 nb.Butdanh, COUNT(*) AS SL, ISNULL(SUM(nb.TienNhuanbut),0) AS Tong
                        FROM Nhuanbut nb WHERE MONTH(nb.ngaychuyen)=@t AND YEAR(nb.ngaychuyen)=@n
                        GROUP BY nb.Butdanh ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        sb.AppendLine("Top tác giả:");
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            int stt = 1;
                            while (r.Read())
                                sb.AppendLine($"  {stt++}. {r["Butdanh"]}: {r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                            r.Close();
                        }
                    }

                    // Theo thể loại
                    using (var cmd = new SqlCommand(@"
                        SELECT Muc, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n
                        GROUP BY Muc ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        sb.AppendLine("Theo thể loại:");
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            while (r.Read())
                                sb.AppendLine($"  • {r["Muc"]}: {r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                            r.Close();
                        }
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI THỐNG KÊ] " + ex.Message;
            }
        }

        // =========================================================================
        // 4. PHIẾU CHI
        // =========================================================================
        private async Task<string> LayThongTinPhieuChiAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    using (var cmd = new SqlCommand(@"
                        SELECT 
                            COUNT(*) AS TongPhieu,
                            ISNULL(SUM(Sotien),0) AS TongTien,
                            ISNULL(SUM(Thue),0) AS TongThue,
                            SUM(CASE WHEN TrangThaiDuyet = 1 THEN Sotien ELSE 0 END) AS DaDuyet,
                            SUM(CASE WHEN TrangThaiDuyet = 0 THEN Sotien ELSE 0 END) AS ChoDuyet
                        FROM Phieuchi", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                        {
                            sb.AppendLine("【PHIẾU CHI】");
                            sb.AppendLine($"Tổng: {r["TongPhieu"]} phiếu");
                            sb.AppendLine($"Tổng tiền: {Convert.ToDecimal(r["TongTien"]):N0}đ");
                            sb.AppendLine($"Thuế: {Convert.ToDecimal(r["TongThue"]):N0}đ");
                            sb.AppendLine($"Đã duyệt: {Convert.ToDecimal(r["DaDuyet"]):N0}đ");
                            sb.AppendLine($"Chờ duyệt: {Convert.ToDecimal(r["ChoDuyet"]):N0}đ");
                        }
                        r.Close();
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI PHIẾU CHI] " + ex.Message;
            }
        }

        // =========================================================================
        // 5. PHÁT HIỆN BẤT THƯỜNG
        // =========================================================================
        private async Task<string> LayThongTinBatThuongAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var warnings = new List<string>();

                    // Bài chờ quá 7 ngày
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL FROM Nhuanbut 
                        WHERE TrangThaiDuyet < 2 AND ngaychuyen < DATEADD(DAY, -7, GETDATE())", conn))
                    {
                        int sl = (int)(await cmd.ExecuteScalarAsync() ?? 0);
                        if (sl > 0) warnings.Add($"⚠️ {sl} bài chờ ký duyệt quá 7 ngày");
                    }

                    // Tác giả nộp dày đặc 7 ngày
                    using (var cmd = new SqlCommand(@"
                        SELECT Butdanh, COUNT(*) AS SL FROM Nhuanbut
                        WHERE ngaychuyen >= DATEADD(DAY, -7, GETDATE())
                        GROUP BY Butdanh HAVING COUNT(*) >= 5", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            warnings.Add($"⚠️ Tác giả '{r["Butdanh"]}' nộp {r["SL"]} bài/7 ngày");
                        r.Close();
                    }

                    // Vượt định mức
                    using (var cmd = new SqlCommand(@"
                        SELECT nb.Muc, nb.Butdanh, nb.TienNhuanbut, dm.MucToiDa
                        FROM Nhuanbut nb JOIN DinhMuc dm ON nb.Muc = dm.Muc
                        WHERE nb.TienNhuanbut > dm.MucToiDa AND nb.TrangThaiDuyet < 2", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            warnings.Add($"🚨 {r["Butdanh"]}: {r["TienNhuanbut"]:N0}đ > {r["MucToiDa"]:N0}đ (định mức {r["Muc"]})");
                        r.Close();
                    }

                    // Phiếu chi chờ > 5 ngày
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL FROM Phieuchi 
                        WHERE TrangThaiDuyet = 0 AND Ngaylap < DATEADD(DAY, -5, GETDATE())", conn))
                    {
                        int slPc = (int)(await cmd.ExecuteScalarAsync() ?? 0);
                        if (slPc > 0) warnings.Add($"⚠️ {slPc} phiếu chi chờ duyệt quá 5 ngày");
                    }

                    if (warnings.Count == 0) return "✅ Không phát hiện bất thường nào.";
                    return "【PHÁT HIỆN BẤT THƯỜNG】\n" + string.Join("\n", warnings);
                }
            }
            catch (Exception ex)
            {
                return "[LỖI] " + ex.Message;
            }
        }

        // =========================================================================
        // 6. ĐỊNH MỨC
        // =========================================================================
        private async Task<string> LayThongTinDinhMucAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();
                    sb.AppendLine("【ĐỊNH MỨC NHUẬN BÚT】");

                    using (var cmd = new SqlCommand("SELECT Muc, MucToiDa FROM DinhMuc ORDER BY MucToiDa DESC", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            sb.AppendLine($"• {r["Muc"]}: tối đa {Convert.ToDecimal(r["MucToiDa"]):N0}đ");
                        r.Close();
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI] " + ex.Message;
            }
        }

        // =========================================================================
        // HIỂN THỊ BONG BÓNG CHAT
        // =========================================================================
        private void ThemBongBongChat(string tinNhan, bool isUser)
        {
            if (this.IsDisposed || flpChat.IsDisposed) return;

            try
            {
                Label lbl = new Label();
                lbl.Text = tinNhan;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                lbl.Padding = new Padding(16);
                lbl.Font = new Font("Segoe UI", 11.5F);
                lbl.BackColor = Color.Transparent;

                Guna.UI2.WinForms.Guna2Panel bubble = new Guna.UI2.WinForms.Guna2Panel();
                bubble.BorderRadius = 18;
                bubble.AutoSize = true;
                bubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                bubble.Controls.Add(lbl);

                flpChat.Controls.Add(bubble); // Thêm vào trước để WinForms tính toán Width

                if (isUser)
                {
                    bubble.FillColor = Color.FromArgb(6, 78, 59);
                    lbl.ForeColor = Color.White;
                    bubble.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - bubble.Width - 25), 10, 10, 10);
                }
                else
                {
                    bubble.FillColor = Color.FromArgb(241, 245, 249);
                    lbl.ForeColor = Color.FromArgb(6, 78, 59);
                    bubble.Margin = new Padding(10, 10, 10, 10);
                }

                flpChat.ScrollControlIntoView(bubble);
            }
            catch (ObjectDisposedException) { }
        }
    }
}
