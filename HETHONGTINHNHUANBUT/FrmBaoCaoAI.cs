using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoAI : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private static readonly string endpoint = "http://localhost:11434/api/generate";
        private static readonly string aiModel = "qwen2.5";

        public FrmBaoCaoAI()
        {
            InitializeComponent();
            dtpThang.Value = DateTime.Now;
            txtBaoCao.Font = new Font("Consolas", 10F);
        }

        private async void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            btnTaoBaoCao.Enabled = false;
            btnTaoBaoCao.Text = "⏳ ĐANG TẠO BÁO CÁO...";
            txtBaoCao.Text = "";

            try
            {
                var sb = new StringBuilder();
                int thang = dtpThang.Value.Month;
                int nam = dtpThang.Value.Year;

                string header = $"╔══════════════════════════════════════════════╗\n" +
                                $"║     BÁO CÁO THỐNG KÊ THÁNG {thang:D2}/{nam}               ║\n" +
                                $"╚══════════════════════════════════════════════╝\n";
                sb.AppendLine(header);

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // ── 1. TỔNG QUAN ──
                    sb.AppendLine("1. TỔNG QUAN");
                    sb.AppendLine(new string('─', 60));
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS TongBai,
                               ISNULL(SUM(TienNhuanbut),0) AS TongTien,
                               COUNT(DISTINCT Butdanh) AS SoTacGia,
                               ISNULL(AVG(TienNhuanbut),0) AS TrungBinh,
                               ISNULL(MAX(TienNhuanbut),0) AS CaoNhat
                        FROM Nhuanbut
                        WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                            {
                                sb.AppendLine($"  Tổng số bài           : {r["TongBai"],10}");
                                sb.AppendLine($"  Tổng nhuận bút       : {Convert.ToInt64(r["TongTien"]),10:N0} VNĐ");
                                sb.AppendLine($"  Số tác giả           : {r["SoTacGia"],10}");
                                sb.AppendLine($"  Trung bình           : {Convert.ToInt64(r["TrungBinh"]),10:N0} VNĐ");
                                sb.AppendLine($"  Cao nhất             : {Convert.ToInt64(r["CaoNhat"]),10:N0} VNĐ");
                            }
                            r.Close();
                        }
                    }
                    sb.AppendLine();

                    // ── 2. TOP 5 TÁC GIẢ ──
                    sb.AppendLine("2. TOP 5 TÁC GIẢ");
                    sb.AppendLine(new string('─', 60));
                    sb.AppendLine($"  {"Tác giả",-20} {"Bài",5} {"Thành tiền",15}");
                    sb.AppendLine(new string('─', 60));
                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 5 nb.Butdanh, COUNT(*) AS SL, ISNULL(SUM(nb.TienNhuanbut),0) AS Tong
                        FROM Nhuanbut nb
                        WHERE MONTH(nb.ngaychuyen)=@t AND YEAR(nb.ngaychuyen)=@n
                        GROUP BY nb.Butdanh ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                            while (r.Read())
                                sb.AppendLine($"  {r["Butdanh"].ToString(),-20} {Convert.ToInt32(r["SL"]),5} {Convert.ToInt64(r["Tong"]),15:N0}");
                    }
                    sb.AppendLine();

                    // ── 3. THỂ LOẠI ──
                    sb.AppendLine("3. THỂ LOẠI");
                    sb.AppendLine(new string('─', 60));
                    sb.AppendLine($"  {"Thể loại",-20} {"Bài",5} {"Thành tiền",15}");
                    sb.AppendLine(new string('─', 60));
                    using (var cmd = new SqlCommand(@"
                        SELECT Muc, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n
                        GROUP BY Muc ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                            while (r.Read())
                                sb.AppendLine($"  {r["Muc"].ToString(),-20} {Convert.ToInt32(r["SL"]),5} {Convert.ToInt64(r["Tong"]),15:N0}");
                    }
                    sb.AppendLine();

                    // ── 4. TRẠNG THÁI DUYỆT ──
                    sb.AppendLine("4. TRẠNG THÁI DUYỆT");
                    sb.AppendLine(new string('─', 60));
                    sb.AppendLine($"  {"Trạng thái",-25} {"Bài",5} {"Thành tiền",15}");
                    sb.AppendLine(new string('─', 60));
                    string[] ttLabel = { "Chờ duyệt (0)", "TK duyệt (1)", "KT duyệt (2)", "Đã duyệt (3)" };
                    using (var cmd = new SqlCommand(@"
                        SELECT TrangThaiDuyet, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n
                        GROUP BY TrangThaiDuyet ORDER BY TrangThaiDuyet", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                            while (r.Read())
                            {
                                int tt = Convert.ToInt32(r["TrangThaiDuyet"]);
                                string label = tt >= 0 && tt < ttLabel.Length ? ttLabel[tt] : $"TT {tt}";
                                sb.AppendLine($"  {label,-25} {Convert.ToInt32(r["SL"]),5} {Convert.ToInt64(r["Tong"]),15:N0}");
                            }
                    }
                    sb.AppendLine();

                    // ── 5. TÀI CHÍNH ──
                    sb.AppendLine("5. TÀI CHÍNH");
                    sb.AppendLine(new string('─', 60));
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(Sotien),0) AS Tong,
                               ISNULL(SUM(Thue),0) AS Thue
                        FROM Phieuchi
                        WHERE MONTH(Ngaylap)=@t AND YEAR(Ngaylap)=@n AND TrangThaiDuyet=1", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                            {
                                sb.AppendLine($"  Số phiếu chi         : {r["SL"],10}");
                                sb.AppendLine($"  Tổng đã chi          : {Convert.ToInt64(r["Tong"]),10:N0} VNĐ");
                                sb.AppendLine($"  Thuế                 : {Convert.ToInt64(r["Thue"]),10:N0} VNĐ");
                            }
                            r.Close();
                        }
                    }
                    sb.AppendLine();

                    // ── 6. SO SÁNH THÁNG TRƯỚC ──
                    sb.AppendLine("6. SO SÁNH THÁNG TRƯỚC");
                    sb.AppendLine(new string('─', 60));
                    int thangTruoc = thang == 1 ? 12 : thang - 1;
                    int namTruoc = thang == 1 ? nam - 1 : nam;
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut
                        WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thangTruoc);
                        cmd.Parameters.AddWithValue("@n", namTruoc);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                            {
                                sb.AppendLine($"  Bài tháng {thangTruoc:D2}/{namTruoc}   : {r["SL"],10}");
                                sb.AppendLine($"  Tiền tháng {thangTruoc:D2}/{namTruoc}   : {Convert.ToInt64(r["Tong"]),10:N0} VNĐ");
                            }
                            r.Close();
                        }
                    }
                    sb.AppendLine();
                }

                // ── AI NHẬN XÉT ──
                string nhanXet = await AiNhanXetAsync(thang, nam);
                sb.AppendLine("7. NHẬN XÉT CỦA AI");
                sb.AppendLine(new string('─', 60));
                sb.AppendLine(nhanXet);

                txtBaoCao.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtBaoCao.Text = "⚠️ Lỗi: " + ex.Message;
            }

            btnTaoBaoCao.Enabled = true;
            btnTaoBaoCao.Text = "🤖 TẠO BÁO CÁO AI";
        }

        private async Task<string> AiNhanXetAsync(int thang, int nam)
        {
            using (var conn = new SqlConnection(sqlConnectionString))
            {
                await conn.OpenAsync();

                var sbData = new StringBuilder();

                using (var cmd = new SqlCommand(@"
                    SELECT COUNT(*) AS TB, ISNULL(SUM(TienNhuanbut),0) AS TT,
                           COUNT(DISTINCT Butdanh) AS TG, ISNULL(AVG(TienNhuanbut),0) AS TBinh
                    FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n", conn))
                {
                    cmd.Parameters.AddWithValue("@t", thang);
                    cmd.Parameters.AddWithValue("@n", nam);
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sbData.Append($"Tổng bài:{r["TB"]}|Tổng tiền:{r["TT"]}|Tác giả:{r["TG"]}|TB:{r["TBinh"]}");
                        r.Close();
                    }
                }

                using (var cmd = new SqlCommand(@"
                    SELECT TOP 3 Butdanh, SUM(TienNhuanbut) AS T
                    FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n
                    GROUP BY Butdanh ORDER BY T DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@t", thang);
                    cmd.Parameters.AddWithValue("@n", nam);
                    sbData.Append("|Top TG:");
                    using (var r = await cmd.ExecuteReaderAsync())
                        while (r.Read())
                            sbData.Append($" {r["Butdanh"]}({Convert.ToInt64(r["T"]):N0})");
                }

                string data = sbData.ToString();
                string prompt = $@"Dữ liệu tháng {thang}/{nam}: {data}
Viết 2-3 câu NHẬN XÉT NGẮN GỌN bằng tiếng Việt, nhấn mạnh điểm nổi bật (tác giả xuất sắc, thể loại chủ đạo, tình hình tài chính). KHÔNG dùng dấu **, KHÔNG viết lại số liệu, chỉ phân tích.";

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    var body = new { model = aiModel, prompt = prompt, stream = false, options = new { temperature = 0.3 } };
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(endpoint, content);
                    string respJson = await response.Content.ReadAsStringAsync();
                    JObject result = JObject.Parse(respJson);
                    return "  " + (result["response"]?.ToString().Replace("**", "").Trim()
                           ?? "AI không phản hồi.");
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBaoCao.Text) || txtBaoCao.Text == "Báo cáo sẽ hiển thị tại đây...")
            {
                MessageBox.Show("Chưa có báo cáo để copy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Clipboard.SetText(txtBaoCao.Text);
            MessageBox.Show("Đã copy vào clipboard!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBaoCao.Text) || txtBaoCao.Text == "Báo cáo sẽ hiển thị tại đây...")
            {
                MessageBox.Show("Chưa có báo cáo để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text|*.txt",
                FileName = $"BaoCao_AI_{dtpThang.Value:MM_yyyy}.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtBaoCao.Text, Encoding.UTF8);
                MessageBox.Show("Đã lưu báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
