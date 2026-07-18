using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmQuanLyPhieuChi : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedPhieuChiId = "";

        public FrmQuanLyPhieuChi()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvPhieuChi, true, null);
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvChiTiet, true, null);
        }

        private async void FrmQuanLyPhieuChi_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvPhieuChi);
            UIHelper.FormatGiaoDienBang(dgvChiTiet);
            
            cboThang.Items.Add("Tất cả");
            for(int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }
            cboThang.SelectedIndex = 0;
            
            await LoadDataPhieuChiAsync();
        }

        private async Task LoadDataPhieuChiAsync()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                int thang = cboThang.SelectedIndex;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Sophieu, Ngaylap, Tacgia as TenTacGia, Lydo, Sotien as TongTien, Conlai as ThucLinh, Dathutien
                                     FROM Phieuchi WHERE 1=1";

                    if (!string.IsNullOrEmpty(keyword))
                        query += " AND (Sophieu LIKE @kw OR Tacgia LIKE @kw)";
                    if (thang > 0)
                        query += " AND MONTH(Ngaylap) = @thang";

                    query += " ORDER BY Ngaylap DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                        if (thang > 0)
                            cmd.Parameters.AddWithValue("@thang", thang);

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }

                        dt.Columns.Add("NgayLapStr", typeof(string));
                        dt.Columns.Add("TrangThaiThanhToan", typeof(string));
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r["Ngaylap"] != DBNull.Value)
                                r["NgayLapStr"] = Convert.ToDateTime(r["Ngaylap"]).ToString("dd/MM/yyyy HH:mm");
                            
                            object val = r["Dathutien"];
                            string tt = (val != null && val != DBNull.Value) ? val.ToString() : "N";
                            r["TrangThaiThanhToan"] = (tt == "Y" || tt == "y") ? "Đã thanh toán" : "Chưa thanh toán";
                        }

                        dgvPhieuChi.DataSource = dt;
                    }
                }

                if (dgvPhieuChi.Columns.Count > 0)
                {
                    if (dgvPhieuChi.Columns["Ngaylap"] != null) dgvPhieuChi.Columns["Ngaylap"].Visible = false;
                    if (dgvPhieuChi.Columns["Dathutien"] != null) dgvPhieuChi.Columns["Dathutien"].Visible = false;

                    UIHelper.ConfigureColumns(dgvPhieuChi,
                        ("Sophieu", "SỐ PHIẾU", false, false),
                        ("NgayLapStr", "NGÀY LẬP", false, false),
                        ("TenTacGia", "TÊN TÁC GIẢ", false, false),
                        ("Lydo", "LÝ DO", false, false),
                        ("TongTien", "TỔNG TIỀN", true, false),
                        ("ThucLinh", "THỰC LĨNH", true, false),
                        ("TrangThaiThanhToan", "TRẠNG THÁI", false, false)
                    );
                }
                
                dgvChiTiet.DataSource = null; // Clear details
                _selectedPhieuChiId = "";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private async void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhieuChi.Rows[e.RowIndex];
                _selectedPhieuChiId = row.Cells["Sophieu"].Value?.ToString();
                
                lblPhieuChiSelect.Text = "Chi tiết Phiếu Chi: " + _selectedPhieuChiId + " - Tác giả: " + row.Cells["TenTacGia"].Value?.ToString();
                
                await LoadDataChiTietAsync(_selectedPhieuChiId);
            }
        }

        private async Task LoadDataChiTietAsync(string soPhieu)
        {
            if (string.IsNullOrEmpty(soPhieu)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT n.Maso, n.Tenbai, n.Trang, n.Muc, n.TienNhuanbut
                                     FROM NhuanbutCT ct
                                     JOIN Nhuanbut n ON ct.MsNhuanbut = n.Maso
                                     WHERE ct.SoPC = @soPhieu";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soPhieu", soPhieu);

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                        dgvChiTiet.DataSource = dt;
                    }
                }

                if (dgvChiTiet.Columns.Count > 0)
                {
                    UIHelper.ConfigureColumns(dgvChiTiet,
                        ("Maso", "MÃ BÀI", false, false),
                        ("Tenbai", "TÊN BÀI / TIN / ẢNH", false, false),
                        ("Trang", "TRANG", false, false),
                        ("Muc", "THỂ LOẠI", false, false),
                        ("TienNhuanbut", "SỐ TIỀN", true, false)
                    );
                    
                    if (dgvChiTiet.Columns["Maso"] != null) dgvChiTiet.Columns["Maso"].Width = 100;
                    if (dgvChiTiet.Columns["Trang"] != null) dgvChiTiet.Columns["Trang"].Width = 100;
                    if (dgvChiTiet.Columns["Muc"] != null) dgvChiTiet.Columns["Muc"].Width = 150;
                    if (dgvChiTiet.Columns["TienNhuanbut"] != null) dgvChiTiet.Columns["TienNhuanbut"].Width = 200;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải chi tiết: " + ex.Message); }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataPhieuChiAsync();
        }

        private async void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDataPhieuChiAsync();
        }
    }
}
