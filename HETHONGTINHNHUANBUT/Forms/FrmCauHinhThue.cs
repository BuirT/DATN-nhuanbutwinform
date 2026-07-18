using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmCauHinhThue : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public string QuyenHienTai { get; set; }
        public string MaTacGiaCuaToi { get; set; }

        public FrmCauHinhThue()
        {
            InitializeComponent();
        }

        private async void FrmCauHinhThue_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT TOP 1 MucChiuThue, PhanTramThue FROM CauHinhThue";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal mucChiuThue = reader["MucChiuThue"] != DBNull.Value ? Convert.ToDecimal(reader["MucChiuThue"]) : 2000000;
                                float phanTramThue = reader["PhanTramThue"] != DBNull.Value ? Convert.ToSingle(reader["PhanTramThue"]) : 10;
                                
                                txtMucChiuThue.Text = mucChiuThue.ToString("N0");
                                txtPhanTramThue.Text = phanTramThue.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string strMuc = txtMucChiuThue.Text.Replace(",", "").Replace(".", "").Trim();
                if (!decimal.TryParse(strMuc, out decimal mucChiuThue))
                {
                    MessageBox.Show("Mức chịu thuế không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (!float.TryParse(txtPhanTramThue.Text.Trim(), out float phanTramThue))
                {
                    MessageBox.Show("Phần trăm thuế không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "UPDATE CauHinhThue SET MucChiuThue = @muc, PhanTramThue = @phan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@muc", mucChiuThue);
                        cmd.Parameters.AddWithValue("@phan", phanTramThue);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                
                MessageBox.Show("Cập nhật cấu hình thuế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
