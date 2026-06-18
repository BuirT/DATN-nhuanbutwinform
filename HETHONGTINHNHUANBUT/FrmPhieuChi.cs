using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmPhieuChi : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public string QuyenHienTai { get; set; }
        public string NguoiLapPhieu { get; set; }

        public FrmPhieuChi()
        {
            InitializeComponent();

            dgvChuaThanhToan.AutoGenerateColumns = false;
            dgvChuaThanhToan.Columns.Clear();

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.Name = "colCheck";
            chkCol.HeaderText = "Chọn";
            chkCol.Width = 60;
            chkCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChuaThanhToan.Columns.Add(chkCol);

            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.Name = "Id";
            idCol.Visible = false;
            dgvChuaThanhToan.Columns.Add(idCol);

            DataGridViewTextBoxColumn tenBaiCol = new DataGridViewTextBoxColumn();
            tenBaiCol.Name = "TenBai";
            tenBaiCol.HeaderText = "Tên bài viết";
            tenBaiCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChuaThanhToan.Columns.Add(tenBaiCol);

            DataGridViewTextBoxColumn tienCol = new DataGridViewTextBoxColumn();
            tienCol.Name = "TienNhuanBut";
            tienCol.HeaderText = "Tiền nhuận bút";
            tienCol.DefaultCellStyle.Format = "N0";
            tienCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tienCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tienCol.Width = 140;
            dgvChuaThanhToan.Columns.Add(tienCol);

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvChuaThanhToan, true, null);

            txtDienThoai.KeyPress += OnlyNumber_KeyPress;
            txtCMND.KeyPress += OnlyNumber_KeyPress;
            txtMST.KeyPress += OnlyNumber_KeyPress;
        }

        private async void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvChuaThanhToan);
            dgvChuaThanhToan.ReadOnly = false;
            dgvChuaThanhToan.ThemeStyle.ReadOnly = false;
            cboTacGia.SelectedIndexChanged -= cboTacGia_SelectedIndexChanged;
            await LoadAuthorsAsync();
            cboTacGia.SelectedIndexChanged += cboTacGia_SelectedIndexChanged;

            cboTacGia.DropDownHeight = 200;
            cboTacGia.IntegralHeight = true;
            cboTacGia.MaxDropDownItems = 15;
            cboHinhThuc.DropDownHeight = 200;
            cboHinhThuc.IntegralHeight = true;
            cboHinhThuc.MaxDropDownItems = 15;

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

                    var authors = dt.AsEnumerable().Select(r => r.Field<string>("Butdanh")).ToList();

                    cboTacGia.Items.Clear();
                    cboTacGia.Items.AddRange(authors.ToArray());
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách tác giả: " + ex.Message); }
        }

        private async void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string penName = cboTacGia.Text.Trim();
            if (string.IsNullOrEmpty(penName)) return;

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
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChuaThanhToan.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dgvChuaThanhToan.Rows.Add();
                        dgvChuaThanhToan.Rows[rowIndex].Cells["Id"].Value = row["Maso"];
                        dgvChuaThanhToan.Rows[rowIndex].Cells["TenBai"].Value = row["Tenbai"];
                        dgvChuaThanhToan.Rows[rowIndex].Cells["TienNhuanBut"].Value = row["TienNhuanbut"];
                        dgvChuaThanhToan.Rows[rowIndex].Cells["colCheck"].Value = false;
                    }

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
                if (row.Cells["colCheck"] != null && Convert.ToBoolean(row.Cells["colCheck"].Value))
                {
                    if (row.Cells["TienNhuanBut"].Value != null)
                        tong += Convert.ToDecimal(row.Cells["TienNhuanBut"].Value);
                }
            }

            txtTongTien.Text = tong.ToString("N0");

            // 🔥 ÁP DỤNG ĐÚNG LUẬT: TỪ 2 TRIỆU TRỞ LÊN MỚI TÍNH THUẾ
            decimal thueVnd = 0;
            if (tong >= 2000000)
            {
                if (decimal.TryParse(txtThueSuat.Text, out decimal thuePT))
                {
                    thueVnd = tong * (thuePT / 100);
                }
            }
            else
            {
                // Dưới 2 triệu thì ép hiển thị % thuế bằng 0 cho Kế toán biết
                txtThueSuat.Text = "0";
            }

            txtTienThue.Text = thueVnd.ToString("N0");
            txtThucLinh.Text = (tong - thueVnd).ToString("N0");
        
        }

        private async void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (!IsValidData()) return;

            var selectedItems = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colCheck"].Value))
                    selectedItems.Add(row);
            }

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

                    foreach (DataGridViewRow row in selectedItems)
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
                    await btnHuy_Click_Logic();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu phiếu chi: " + ex.Message);
                }
            }
        }

        private async void btnHuy_Click(object sender, EventArgs e)
        {
            await btnHuy_Click_Logic();
        }

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
            if (e.ColumnIndex == dgvChuaThanhToan.Columns["colCheck"].Index)
                TinhToanTien();
        }

        private void dgvChuaThanhToan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChuaThanhToan.IsCurrentCellDirty)
                dgvChuaThanhToan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void txtThueSuat_TextChanged(object sender, EventArgs e) => TinhToanTien();

    }
}