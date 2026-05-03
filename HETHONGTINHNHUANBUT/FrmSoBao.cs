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
        private string _selectedId = "";

        public FrmSoBao(string tenNguoiDung = "Admin")
        {
            InitializeComponent();
            _tenNguoiDung = tenNguoiDung;
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
        }

        private async void FrmSoBao_Load(object sender, EventArgs e)
        {
            if (this.Controls.Find("lblXinChao", true).FirstOrDefault() is Label lblXinChao)
            {
                lblXinChao.Text = $"Xin chào, {_tenNguoiDung} 👋";
            }

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
                    Ngayra = b.Ngayra.ToLocalTime().ToString("dd/MM/yyyy"),
                    Sobao = b.Sobao,
                    Sobo = b.Sobo,
                    Loaibao = b.Loaibao,
                    // ĐÃ SỬA: Thay đổi hoàn toàn thuật ngữ hiển thị
                    DaDuyet = b.DaDuyet == "Y" ? "🔒 Đã khóa sổ" : "Đang mở"
                }).OrderByDescending(x => x.Ngayra).ToList();

                if (dgvSoBao.Columns["Id"] != null) dgvSoBao.Columns["Id"].Visible = false;

                if (dgvSoBao.Columns.Count > 0)
                {
                    dgvSoBao.Columns["Maso"].HeaderText = "Mã số";
                    dgvSoBao.Columns["Tenbao"].HeaderText = "Tên kỳ báo";
                    dgvSoBao.Columns["Ngayra"].HeaderText = "Ngày ra";
                    dgvSoBao.Columns["Sobao"].HeaderText = "Số báo";
                    dgvSoBao.Columns["Sobo"].HeaderText = "Số bộ";
                    dgvSoBao.Columns["Loaibao"].HeaderText = "Loại báo";
                    // ĐÃ SỬA: Đổi tên cột
                    dgvSoBao.Columns["DaDuyet"].HeaderText = "Tình trạng sổ";
                }

                // Tự động reset lại nút khi tải xong dữ liệu
                if (this.Controls.Find("btnKhoaSo", true).FirstOrDefault() is Guna.UI2.WinForms.Guna2Button btnKhoaSo)
                {
                    btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
                    btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(16, 185, 129); // Xanh lá
                }
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
                    DaDuyet = "N" // Mặc định là Đang mở
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
            if (string.IsNullOrEmpty(_selectedId)) return;
            try
            {
                var update = Builders<Bao>.Update
                    .Set(b => b.Maso, txtMaso.Text.Trim())
                    .Set(b => b.Tenbao, txtTenBao.Text.Trim())
                    .Set(b => b.Ngayra, dtpNgayRa.Value)
                    .Set(b => b.Sobao, txtSoBao.Text.Trim())
                    .Set(b => b.Sobo, txtSoBo.Text.Trim())
                    .Set(b => b.Loaibao, cboLoaiBao.Text);

                await _baoColl.UpdateOneAsync(b => b.Id == _selectedId, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) return;
            if (MessageBox.Show("Chắc chắn muốn xóa kỳ báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _baoColl.DeleteOneAsync(b => b.Id == _selectedId);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        // --- ĐÃ SỬA: SỰ KIỆN NÚT KHÓA SỔ ---
        private async void btnKhoaSo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId))
            {
                MessageBox.Show("Vui lòng chọn 1 kỳ báo từ danh sách bên dưới để Khóa hoặc Mở sổ!", "Nhắc nhở");
                return;
            }

            try
            {
                var bao = await _baoColl.Find(b => b.Id == _selectedId).FirstOrDefaultAsync();
                if (bao != null)
                {
                    string newStatus = bao.DaDuyet == "Y" ? "N" : "Y";
                    string action = newStatus == "Y" ? "KHÓA SỔ" : "MỞ KHÓA SỔ";

                    var update = Builders<Bao>.Update.Set(b => b.DaDuyet, newStatus);
                    await _baoColl.UpdateOneAsync(b => b.Id == _selectedId, update);

                    MessageBox.Show($"Đã {action} kỳ báo thành công!");
                    await LoadDataAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedId = "";
            txtMaso.Clear();
            txtTenBao.Clear();
            txtSoBao.Clear();
            txtSoBo.Clear();
            dtpNgayRa.Value = DateTime.Now;
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            if (txtTimKiem != null) txtTimKiem.Clear();
            txtMaso.Focus();

            if (this.Controls.Find("btnKhoaSo", true).FirstOrDefault() is Guna.UI2.WinForms.Guna2Button btnKhoaSo)
            {
                btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
                btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            }
        }

        private void dgvSoBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSoBao.Rows[e.RowIndex];
                _selectedId = row.Cells["Id"].Value?.ToString();

                txtMaso.Text = row.Cells["Maso"].Value?.ToString();
                txtTenBao.Text = row.Cells["Tenbao"].Value?.ToString();
                txtSoBao.Text = row.Cells["Sobao"].Value?.ToString();
                txtSoBo.Text = row.Cells["Sobo"].Value?.ToString();
                cboLoaiBao.Text = row.Cells["Loaibao"].Value?.ToString();

                if (DateTime.TryParseExact(row.Cells["Ngayra"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgayRa.Value = dt;
                }

                // Xử lý đổi trạng thái nút Khóa sổ
                if (this.Controls.Find("btnKhoaSo", true).FirstOrDefault() is Guna.UI2.WinForms.Guna2Button btnKhoaSo)
                {
                    string trangThai = row.Cells["DaDuyet"].Value?.ToString();
                    if (trangThai == "🔒 Đã khóa sổ")
                    {
                        btnKhoaSo.Text = "MỞ KHÓA LẠI";
                        btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(239, 68, 68); // Đỏ
                    }
                    else
                    {
                        btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
                        btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(16, 185, 129); // Xanh lá
                    }
                }
            }
        }
    }
}