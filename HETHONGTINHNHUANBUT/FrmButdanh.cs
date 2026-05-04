using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButDanh : Form
    {
        private readonly IMongoCollection<ButDanh> _butDanhColl;
        private readonly IMongoCollection<TacGia> _tacGiaColl; // KHAI BÁO THÊM BẢNG TÁC GIẢ

        public FrmButDanh()
        {
            InitializeComponent();
            _butDanhColl = MongoProvider.Instance.GetCollection<ButDanh>("Butdanh");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia"); // KHỞI TẠO
        }

        private async void FrmButDanh_Load(object sender, EventArgs e)
        {
            dgvButDanh.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            await LoadComboBoxTacGia(); // GỌI HÀM LOAD COMBOBOX TRƯỚC
            await LoadDataAsync();
        }

        // VIẾT THÊM HÀM NÀY ĐỂ ĐỔ DỮ LIỆU VÀO COMBOBOX
        private async Task LoadComboBoxTacGia()
        {
            try
            {
                var listTacGia = await _tacGiaColl.Find(_ => true).ToListAsync();
                cboTacGia.DataSource = listTacGia;
                cboTacGia.DisplayMember = "Hoten"; // Hiển thị tên
                cboTacGia.ValueMember = "Maso";    // Giá trị là mã hệ thống
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách tác giả: " + ex.Message); }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _butDanhColl.Find(_ => true).ToListAsync();

                dgvButDanh.DataSource = list.Select(b => new {
                    b.Id,
                    Maso = b.Maso,
                    Butdanh = b.Butdanh,
                    MsTacgia = b.MsTacgia
                }).OrderBy(x => x.Maso).ToList();

                if (dgvButDanh.Columns["Id"] != null) dgvButDanh.Columns["Id"].Visible = false;

                if (dgvButDanh.Columns.Count > 0)
                {
                    dgvButDanh.Columns["Maso"].HeaderText = "Mã số (ID)";
                    dgvButDanh.Columns["Butdanh"].HeaderText = "Bút danh hiển thị";
                    dgvButDanh.Columns["MsTacgia"].HeaderText = "Mã tác giả gốc";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtButDanh.Text))
            {
                MessageBox.Show("Đồng chí Tí nhập đầy đủ Mã số và Bút danh giúp Thanh nhé!", "Nhắc nhở");
                return;
            }

            if (!int.TryParse(txtMaso.Text.Trim(), out int maSo))
            {
                MessageBox.Show("Mã số phải là con số (Ví dụ: 1000, 1692...)!", "Cảnh báo");
                return;
            }

            // BẮT LỖI CHƯA CHỌN TÁC GIẢ
            if (cboTacGia.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn Tác giả chủ quản kìa!", "Bắt lỗi");
                return;
            }

            try
            {
                string tenBD = txtButDanh.Text.Trim();

                // FILTER BẮT LỖI TRÙNG MÃ HOẶC TRÙNG TÊN BÚT DANH
                var filter = Builders<ButDanh>.Filter.Or(
                    Builders<ButDanh>.Filter.Eq(b => b.Maso, maSo),
                    Builders<ButDanh>.Filter.Eq(b => b.Butdanh, tenBD)
                );

                var exist = await _butDanhColl.Find(filter).FirstOrDefaultAsync();
                if (exist != null)
                {
                    if (exist.Maso == maSo)
                        MessageBox.Show("Mã số Bút danh này đã tồn tại rồi anh Tí ơi!");
                    else
                        MessageBox.Show("Tên Bút danh này đã bị người khác chiếm mất rồi, chọn tên khác đi!");
                    return;
                }

                var bd = new ButDanh
                {
                    Maso = maSo,
                    Butdanh = tenBD,
                    MsTacgia = cboTacGia.SelectedValue.ToString() // LẤY MÃ TỪ COMBOBOX
                };

                await _butDanhColl.InsertOneAsync(bd);
                MessageBox.Show("Thêm Bút danh thành công rực rỡ!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
            if (!int.TryParse(txtMaso.Text.Trim(), out int maSo)) return;
            if (cboTacGia.SelectedValue == null) return;

            try
            {
                string id = dgvButDanh.CurrentRow.Cells["Id"].Value.ToString();
                string tenBD = txtButDanh.Text.Trim();

                // KIỂM TRA TRÙNG KHI CẬP NHẬT (LOẠI TRỪ CHÍNH NÓ RA)
                var filter = Builders<ButDanh>.Filter.And(
                    Builders<ButDanh>.Filter.Ne(b => b.Id, id),
                    Builders<ButDanh>.Filter.Or(
                        Builders<ButDanh>.Filter.Eq(b => b.Maso, maSo),
                        Builders<ButDanh>.Filter.Eq(b => b.Butdanh, tenBD)
                    )
                );

                var exist = await _butDanhColl.Find(filter).FirstOrDefaultAsync();
                if (exist != null)
                {
                    MessageBox.Show("Lỗi: Mã số hoặc Tên Bút danh định sửa thành đã bị trùng với dữ liệu khác!");
                    return;
                }

                var update = Builders<ButDanh>.Update
                    .Set(b => b.Maso, maSo)
                    .Set(b => b.Butdanh, tenBD)
                    .Set(b => b.MsTacgia, cboTacGia.SelectedValue.ToString()); // LẤY TỪ COMBOBOX

                await _butDanhColl.UpdateOneAsync(b => b.Id == id, update);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
            if (MessageBox.Show("Chắc chắn muốn xóa bút danh này chứ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dgvButDanh.CurrentRow.Cells["Id"].Value.ToString();
                await _butDanhColl.DeleteOneAsync(b => b.Id == id);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtButDanh.Clear();
            if (cboTacGia.Items.Count > 0) cboTacGia.SelectedIndex = 0; // RESET LUÔN COMBOBOX
            txtMaso.Focus();
        }

        private void dgvButDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvButDanh.Rows[e.RowIndex];
                txtMaso.Text = row.Cells["Maso"].Value?.ToString();
                txtButDanh.Text = row.Cells["Butdanh"].Value?.ToString();

                // HIỂN THỊ LẠI ĐÚNG TÁC GIẢ TRÊN COMBOBOX
                string maTacGia = row.Cells["MsTacgia"].Value?.ToString();
                if (!string.IsNullOrEmpty(maTacGia))
                {
                    cboTacGia.SelectedValue = maTacGia;
                }
            }
        }
    }
}