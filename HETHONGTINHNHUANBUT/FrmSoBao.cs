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

        public FrmSoBao()
        {
            InitializeComponent();
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
        }

        private async void FrmSoBao_Load(object sender, EventArgs e)
        {
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _baoColl.Find(_ => true).ToListAsync();

                dgvSoBao.DataSource = list.Select(b => new {
                    b.Id,
                    Maso = b.Maso,
                    Tenbao = b.Tenbao,
                    Ngayra = b.Ngayra.ToString("dd/MM/yyyy"),
                    Sobao = b.Sobao,
                    Sobo = b.Sobo,
                    Loaibao = b.Loaibao,
                    DaDuyet = b.DaDuyet == "Y" ? "Đã duyệt" : "Chưa duyệt"
                }).OrderByDescending(x => x.Ngayra).ToList();

                if (dgvSoBao.Columns["Id"] != null) dgvSoBao.Columns["Id"].Visible = false;

                if (dgvSoBao.Columns.Count > 0)
                {
                    dgvSoBao.Columns["Maso"].HeaderText = "Mã Số";
                    dgvSoBao.Columns["Maso"].Width = 80;

                    dgvSoBao.Columns["Tenbao"].HeaderText = "Tên Kỳ Báo";
                    dgvSoBao.Columns["Tenbao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvSoBao.Columns["Ngayra"].HeaderText = "Ngày Ra";
                    dgvSoBao.Columns["Sobao"].HeaderText = "Số Báo";
                    dgvSoBao.Columns["Sobo"].HeaderText = "Số Bộ";
                    dgvSoBao.Columns["Loaibao"].HeaderText = "Loại Báo";
                    dgvSoBao.Columns["DaDuyet"].HeaderText = "Trạng Thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtTenBao.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số và Tên báo!", "Nhắc nhở");
                return;
            }

            if (!int.TryParse(txtMaso.Text.Trim(), out int maSoParse))
            {
                MessageBox.Show("Mã số phải là một số nguyên hợp lệ!", "Cảnh báo");
                return;
            }

            try
            {
                var exist = await _baoColl.Find(b => b.Maso == maSoParse).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Mã số báo này đã tồn tại trong hệ thống!", "Cảnh báo");
                    return;
                }

                var bao = new Bao
                {
                    Maso = maSoParse,
                    Tenbao = txtTenBao.Text.Trim(),
                    Ngayra = dtpNgayRa.Value,
                    Sobao = txtSoBao.Text.Trim(),
                    Sobo = txtSoBo.Text.Trim(),
                    Loaibao = cboLoaiBao.Text,
                    DaDuyet = "N"
                };

                await _baoColl.InsertOneAsync(bao);
                MessageBox.Show("Thêm kỳ báo thành công!", "Tuyệt vời");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSoBao.CurrentRow == null) return;
            if (!int.TryParse(txtMaso.Text.Trim(), out int maSoParse)) return;

            try
            {
                string id = dgvSoBao.CurrentRow.Cells["Id"].Value.ToString();
                var filter = Builders<Bao>.Filter.Eq(b => b.Id, id);

                var update = Builders<Bao>.Update
                    .Set(b => b.Maso, maSoParse)
                    .Set(b => b.Tenbao, txtTenBao.Text.Trim())
                    .Set(b => b.Ngayra, dtpNgayRa.Value)
                    .Set(b => b.Sobao, txtSoBao.Text.Trim())
                    .Set(b => b.Sobo, txtSoBo.Text.Trim())
                    .Set(b => b.Loaibao, cboLoaiBao.Text);

                await _baoColl.UpdateOneAsync(filter, update);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSoBao.CurrentRow == null) return;

            if (MessageBox.Show("Chắc chắn muốn xóa kỳ báo này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string id = dgvSoBao.CurrentRow.Cells["Id"].Value.ToString();
                    await _baoColl.DeleteOneAsync(b => b.Id == id);
                    await LoadDataAsync();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi khi xóa: " + ex.Message); }
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

                if (DateTime.TryParseExact(row.Cells["Ngayra"].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    dtpNgayRa.Value = dt;
                }
            }
        }
    }
}