using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using HETHONGTINHNHUANBUT.Models;
using HETHONGTINHNHUANBUT.DAL;
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        private bool isEditing = false;
        // Kết nối bảng TacGia trên Cloud
        private IMongoCollection<TacGia> tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");

        public FrmTacGia()
        {
            InitializeComponent();
        }

        private void FrmTacGia_Load(object sender, EventArgs e)
        {
            LoadData();

            // Định dạng font VNI cho DataGridView theo yêu cầu của đồng chí
            dgvTacGia.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvTacGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);

            SetFormState(false);
        }

        private void LoadData()
        {
            try
            {
                // Lấy toàn bộ danh sách tác giả từ MongoDB Cloud
                var list = tacGiaColl.Find(_ => true).ToList();

                // Đổ dữ liệu vào Grid
                dgvTacGia.DataSource = list;

                // Thiết lập Header cho các cột
                if (dgvTacGia.Columns["Maso"] != null) dgvTacGia.Columns["Maso"].HeaderText = "Mã tác giả";
                if (dgvTacGia.Columns["Hoten"] != null) dgvTacGia.Columns["Hoten"].HeaderText = "Họ tên";
                if (dgvTacGia.Columns["Diachi"] != null) dgvTacGia.Columns["Diachi"].HeaderText = "Địa chỉ";
                if (dgvTacGia.Columns["Dienthoai"] != null) dgvTacGia.Columns["Dienthoai"].HeaderText = "Điện thoại";

                // Ẩn cột ID tự sinh của MongoDB để bảng đẹp hơn
                if (dgvTacGia.Columns["Id"] != null) dgvTacGia.Columns["Id"].Visible = false;

                dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu từ Cloud: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tác giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTacGia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTacGia.Focus();
                return false;
            }
            return true;
        }

        private void SetFormState(bool editing)
        {
            isEditing = editing;
            // Khi đang sửa thì không cho đổi Mã số (vì nó là khóa định danh)
            txtMaTacGia.Enabled = !editing;

            if (!editing)
            {
                txtMaTacGia.Clear();
                txtTenTacGia.Clear();
                txtDiaChi.Clear();
                txtDienThoai.Clear();
                txtMaTacGia.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormState(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string maSo = txtMaTacGia.Text.Trim();

                // Kiểm tra xem mã này đã tồn tại chưa (Thay thế ExecuteScalar)
                var existingTG = tacGiaColl.Find(x => x.Maso == maSo).FirstOrDefault();

                TacGia tg = new TacGia()
                {
                    Maso = maSo,
                    Hoten = txtTenTacGia.Text.Trim(),
                    Diachi = txtDiaChi.Text.Trim(),
                    Dienthoai = txtDienThoai.Text.Trim()
                };

                if (!isEditing) // Thêm mới
                {
                    if (existingTG != null)
                    {
                        MessageBox.Show("Mã tác giả này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tacGiaColl.InsertOne(tg);
                    MongoProvider.Instance.GhiNhatKy("ADMIN", "Thêm tác giả: " + tg.Hoten);
                    MessageBox.Show("Thêm tác giả lên Cloud thành công!", "Thông báo");
                }
                else // Cập nhật (Sửa)
                {
                    var filter = Builders<TacGia>.Filter.Eq(x => x.Maso, maSo);
                    tacGiaColl.ReplaceOne(filter, tg);
                    MongoProvider.Instance.GhiNhatKy("ADMIN", "Cập nhật tác giả: " + tg.Hoten);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                LoadData();
                SetFormState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu Cloud:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trong MongoDB, Sửa và Lưu thường dùng chung logic hoặc chỉ cần bật trạng thái edit
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTacGia.Text)) return;
            isEditing = true;
            btnLuu_Click(sender, e); // Gọi hàm lưu để cập nhật
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTacGia.Text)) return;

            if (MessageBox.Show("Xóa tác giả này khỏi Cloud?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string maSo = txtMaTacGia.Text.Trim();
                    var result = tacGiaColl.DeleteOne(x => x.Maso == maSo);

                    if (result.DeletedCount > 0)
                    {
                        MongoProvider.Instance.GhiNhatKy("ADMIN", "Xóa tác giả mã: " + maSo);
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        SetFormState(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormState(false);
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy dữ liệu từ Row hiện tại
            var row = dgvTacGia.Rows[e.RowIndex];
            txtMaTacGia.Text = row.Cells["Maso"].Value?.ToString() ?? "";
            txtTenTacGia.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["Diachi"].Value?.ToString() ?? "";
            txtDienThoai.Text = row.Cells["Dienthoai"].Value?.ToString() ?? "";

            SetFormState(true);
        }

        private void dgvTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTacGia_CellClick(sender, e);
        }
    }
}