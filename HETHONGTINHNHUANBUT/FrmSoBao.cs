using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmSoBao : Form
    {
        private readonly IMongoCollection<Bao> _baoColl;
        private string _tenNguoiDung;

        public FrmSoBao(string tenNguoiDung = "Admin")
        {
            InitializeComponent();
            _tenNguoiDung = tenNguoiDung;
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
        }

        private async void FrmSoBao_Load(object sender, EventArgs e)
        {
            lblXinChao.Text = $"Xin chào, {_tenNguoiDung} 👋";
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                var list = await _baoColl.Find(_ => true).ToListAsync();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower().Trim();
                    list = list.Where(b =>
                        (b.Maso != null && b.Maso.ToString().ToLower().Contains(keyword)) ||
                        (b.Tenbao != null && b.Tenbao.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvSoBao.DataSource = list.Select(b => new {
                    b.Id,
                    Maso = b.Maso?.ToString() ?? "",
                    Tenbao = b.Tenbao,
                    // ĐÃ THÊM THẦN CHÚ: Kéo thời gian về múi giờ địa phương (Việt Nam)
                    Ngayra = b.Ngayra.ToLocalTime().ToString("dd/MM/yyyy"),
                    Sobao = b.Sobao,
                    Sobo = b.Sobo,
                    Loaibao = b.Loaibao,
                    DaDuyet = b.DaDuyet == "Y" ? "Đã duyệt" : "Chưa duyệt"
                }).OrderByDescending(x => x.Ngayra).ToList();

                if (dgvSoBao.Columns["Id"] != null) dgvSoBao.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtTenBao.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số và Tên báo!");
                return;
            }

            try
            {
                string maSoMoi = txtMaso.Text.Trim();
                var exist = await _baoColl.Find(b => b.Maso.ToString() == maSoMoi).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Mã số báo này đã tồn tại!");
                    return;
                }

                var bao = new Bao
                {
                    Maso = maSoMoi,
                    Tenbao = txtTenBao.Text.Trim(),
                    Ngayra = dtpNgayRa.Value,
                    Sobao = txtSoBao.Text.Trim(),
                    Sobo = txtSoBo.Text.Trim(),
                    Loaibao = cboLoaiBao.Text,
                    DaDuyet = "N"
                };

                await _baoColl.InsertOneAsync(bao);
                MessageBox.Show("Thêm kỳ báo thành công!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSoBao.CurrentRow == null) return;
            try
            {
                string id = dgvSoBao.CurrentRow.Cells["Id"].Value.ToString();
                var update = Builders<Bao>.Update
                    .Set(b => b.Maso, txtMaso.Text.Trim())
                    .Set(b => b.Tenbao, txtTenBao.Text.Trim())
                    .Set(b => b.Ngayra, dtpNgayRa.Value)
                    .Set(b => b.Sobao, txtSoBao.Text.Trim())
                    .Set(b => b.Sobo, txtSoBo.Text.Trim())
                    .Set(b => b.Loaibao, cboLoaiBao.Text);

                await _baoColl.UpdateOneAsync(b => b.Id == id, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSoBao.CurrentRow == null) return;
            if (MessageBox.Show("Chắc chắn muốn xóa kỳ báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dgvSoBao.CurrentRow.Cells["Id"].Value.ToString();
                await _baoColl.DeleteOneAsync(b => b.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtTenBao.Clear();
            txtSoBao.Clear();
            txtSoBo.Clear();
            dtpNgayRa.Value = DateTime.Now;
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            if (txtTimKiem != null) txtTimKiem.Clear();
            txtMaso.Focus();
        }

        private void dgvSoBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSoBao.Rows[e.RowIndex];
                txtMaso.Text = row.Cells["Maso"].Value?.ToString();
                txtTenBao.Text = row.Cells["Tenbao"].Value?.ToString();
                txtSoBao.Text = row.Cells["Sobao"].Value?.ToString();
                txtSoBo.Text = row.Cells["Sobo"].Value?.ToString();
                cboLoaiBao.Text = row.Cells["Loaibao"].Value?.ToString();

                // CẬP NHẬT: Xử lý gán lại ngày từ lưới lên DatePicker cho chuẩn
                if (DateTime.TryParseExact(row.Cells["Ngayra"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgayRa.Value = dt;
                }
            }
        }
    }
}