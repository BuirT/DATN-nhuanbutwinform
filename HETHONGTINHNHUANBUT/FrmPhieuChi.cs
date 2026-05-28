using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmPhieuChi : Form
    {
        // --- CHUỖI KẾT NỐI SQL SERVER CHUẨN MÁY ĐỒNG CHÍ ---
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public string QuyenHienTai { get; set; }
        public string NguoiLapPhieu { get; set; }

        public FrmPhieuChi()
        {
            InitializeComponent();

            // Chặn nhập ký tự không phải số
            txtDienThoai.KeyPress += OnlyNumber_KeyPress;
            txtCMND.KeyPress += OnlyNumber_KeyPress;
            txtMST.KeyPress += OnlyNumber_KeyPress;
        }

        private async void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            cboTacGia.SelectedIndexChanged -= cboTacGia_SelectedIndexChanged;
            await LoadAuthorsAsync();
            cboTacGia.SelectedIndexChanged += cboTacGia_SelectedIndexChanged;

            if (cboHinhThuc.Items.Count > 0) cboHinhThuc.SelectedIndex = 0;
            txtSoPhieu.Text = "PC-" + DateTime.Now.ToString("yyyyMMdd-HHmm");

            if (cboTacGia.Items.Count > 0)
            {
                cboTacGia.SelectedIndex = 0;
                cboTacGia_SelectedIndexChanged(null, null);
            }

            PhanQuyenThaoTac();
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = (role == "kế toán" || role == "admin" || role == "quản trị viên");
            btnLapPhieu.Enabled = coQuyen;
            dgvChuaThanhToan.Enabled = coQuyen;
        }

        private bool IsValidData()
        {
            if (!Regex.IsMatch(txtDienThoai.Text.Trim(), @"^\d{10}$") && txtDienThoai.Text.Trim() != "")
            {
                MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Lỗi");
                return false;
            }
            return true;
        }

        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private async Task LoadAuthorsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT DISTINCT Butdanh FROM Nhuanbut 
                                     WHERE Butdanh IS NOT NULL AND Butdanh <> ''
                                     AND Maso NOT IN (SELECT MsNhuanbut FROM NhuanbutCT)
                                     ORDER BY Butdanh";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    List<string> authors = dt.AsEnumerable().Select(r => r.Field<string>("Butdanh")).ToList();
                    cboTacGia.DataSource = authors;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách tác giả: " + ex.Message); }
        }

        private async void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTacGia.SelectedItem == null) return;
            string penName = cboTacGia.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    string sqlInfo = @"SELECT t.Hoten, t.MsTG, t.Dienthoai 
                                       FROM TacGia t 
                                       JOIN Butdanh b ON t.Maso = b.MsTacgia 
                                       WHERE b.Butdanh = @butdanh";

                    using (SqlCommand cmd = new SqlCommand(sqlInfo, conn))
                    {
                        cmd.Parameters.AddWithValue("@butdanh", penName);
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                        {
                            if (await r.ReadAsync())
                            {
                                txtNguoiNhan.Text = r["Hoten"].ToString();
                                txtCMND.Text = r["MsTG"].ToString();
                                txtDienThoai.Text = r["Dienthoai"].ToString();
                            }
                            else
                            {
                                txtNguoiNhan.Text = penName;
                                ClearTacGiaInfo();
                            }
                        }
                    }

                    string sqlArticles = @"SELECT Maso, Tenbai, TienNhuanbut 
                                           FROM Nhuanbut 
                                           WHERE Butdanh = @butdanh 
                                           AND Maso NOT IN (SELECT MsNhuanbut FROM NhuanbutCT)";

                    SqlDataAdapter da = new SqlDataAdapter(sqlArticles, conn);
                    da.SelectCommand.Parameters.AddWithValue("@butdanh", penName);
                    DataTable dtArticles = new DataTable();
                    da.Fill(dtArticles);

                    dgvChuaThanhToan.DataSource = dtArticles.AsEnumerable().Select(n => new {
                        Id = n["Maso"],
                        TenBai = n["Tenbai"],
                        TienNhuanBut = n["TienNhuanbut"]
                    }).ToList();

                    if (dgvChuaThanhToan.Columns["Id"] != null) dgvChuaThanhToan.Columns["Id"].Visible = false;
                    TinhToanTien();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải chi tiết: " + ex.Message); }
        }

        private void ClearTacGiaInfo()
        {
            txtCMND.Clear(); txtDienThoai.Clear(); txtMST.Clear();
        }

        private void TinhToanTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colCheck"].Value))
                    tong += Convert.ToDecimal(row.Cells["TienNhuanBut"].Value);
            }

            txtTongTien.Text = tong.ToString("N0");
            if (decimal.TryParse(txtThueSuat.Text, out decimal thuePT))
            {
                decimal thueVnd = tong * (thuePT / 100);
                txtTienThue.Text = thueVnd.ToString("N0");
                txtThucLinh.Text = (tong - thueVnd).ToString("N0");
            }
        }

        private async void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (!IsValidData()) return;

            var selectedItems = dgvChuaThanhToan.Rows.Cast<DataGridViewRow>()
                                .Where(r => Convert.ToBoolean(r.Cells["colCheck"].Value))
                                .ToList();

            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bài viết!"); return;
            }

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                await conn.OpenAsync();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sqlPhieu = @"INSERT INTO Phieuchi (Sophieu, Ngaylap, Sotien, Thue, Conlai, Lydo, Nguoinhan, Tacgia, Nguoilap, loaiTT, MST, CMND, Dienthoai, Thuesuat, Dathutien) 
                                        VALUES (@so, @ngay, @tong, @thue, @cl, @lydo, @nhan, @tg, @lap, @loai, @mst, @cccd, @sdt, @ts, 'N')";

                    using (SqlCommand cmd = new SqlCommand(sqlPhieu, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@so", txtSoPhieu.Text);
                        cmd.Parameters.AddWithValue("@ngay", DateTime.Now);
                        cmd.Parameters.AddWithValue("@tong", decimal.Parse(txtTongTien.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@thue", decimal.Parse(txtTienThue.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@cl", decimal.Parse(txtThucLinh.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@lydo", txtLyDo.Text);
                        cmd.Parameters.AddWithValue("@nhan", txtNguoiNhan.Text);
                        cmd.Parameters.AddWithValue("@tg", cboTacGia.Text);
                        cmd.Parameters.AddWithValue("@lap", NguoiLapPhieu ?? "Admin");
                        cmd.Parameters.AddWithValue("@loai", cboHinhThuc.Text.Contains("TM") ? "TM" : "CK");
                        cmd.Parameters.AddWithValue("@mst", txtMST.Text);
                        cmd.Parameters.AddWithValue("@cccd", txtCMND.Text);
                        cmd.Parameters.AddWithValue("@sdt", txtDienThoai.Text);
                        cmd.Parameters.AddWithValue("@ts", decimal.Parse(txtThueSuat.Text));
                        await cmd.ExecuteNonQueryAsync();
                    }

                    string msTG = "";
                    using (SqlCommand cmdGetMs = new SqlCommand("SELECT MsTacgia FROM Butdanh WHERE Butdanh = @bd", conn, trans))
                    {
                        cmdGetMs.Parameters.AddWithValue("@bd", cboTacGia.Text);
                        msTG = cmdGetMs.ExecuteScalar()?.ToString() ?? "";
                    }

                    foreach (var row in selectedItems)
                    {
                        string sqlCT = @"INSERT INTO NhuanbutCT (MsTacgia, MsNhuanbut, Sotien, SoPC, SauThanhToan) 
                                         VALUES (@ms, @nb, @tien, @pc, 'Y')";
                        using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                        {
                            cmdCT.Parameters.AddWithValue("@ms", msTG);
                            cmdCT.Parameters.AddWithValue("@nb", row.Cells["Id"].Value);
                            cmdCT.Parameters.AddWithValue("@tien", row.Cells["TienNhuanBut"].Value);
                            cmdCT.Parameters.AddWithValue("@pc", txtSoPhieu.Text);
                            await cmdCT.ExecuteNonQueryAsync();
                        }
                    }

                    trans.Commit();
                    MessageBox.Show("Lập phiếu chi thành công!");
                    await btnHuy_Click_Logic(); // Gọi hàm xử lý làm mới
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu phiếu chi: " + ex.Message);
                }
            }
        }

        // Đã sửa thành async để giải quyết cảnh báo "not awaited"
        private async void btnHuy_Click(object sender, EventArgs e)
        {
            await btnHuy_Click_Logic();
        }

        // Tách logic hủy ra để dùng chung và đảm bảo có await
        private async Task btnHuy_Click_Logic()
        {
            txtSoPhieu.Text = "PC-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
            ClearTacGiaInfo();
            txtNguoiNhan.Clear();
            txtTongTien.Text = "0"; txtTienThue.Text = "0"; txtThucLinh.Text = "0";
            await LoadAuthorsAsync();
        }

        private void dgvChuaThanhToan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) TinhToanTien();
        }

        private void dgvChuaThanhToan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChuaThanhToan.IsCurrentCellDirty) dgvChuaThanhToan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void txtThueSuat_TextChanged(object sender, EventArgs e) => TinhToanTien();

        // --- ĐÃ BỔ SUNG 2 HÀM NÀY ĐỂ TRỊ DỨT ĐIỂM LỖI COMPILER TRONG DESIGNER ---
        private void txtCMND_TextChanged(object sender, EventArgs e) { }
        private void txtDienThoai_TextChanged(object sender, EventArgs e) { }
    }
}