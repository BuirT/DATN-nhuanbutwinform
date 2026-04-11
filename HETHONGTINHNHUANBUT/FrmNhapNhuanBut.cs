using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using HETHONGTINHNHUANBUT.DAL;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        private IMongoCollection<BsonDocument> _nhuanbutCol;
        private IMongoCollection<BsonDocument> _baoCol;
        private IMongoCollection<BsonDocument> _butdanhCol;
        private bool _isAdding = false;

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
            var db = MongoHelper.GetDatabase();
            _nhuanbutCol = db.GetCollection<BsonDocument>("Nhuanbut");
            _baoCol = db.GetCollection<BsonDocument>("Bao");
            _butdanhCol = db.GetCollection<BsonDocument>("Butdanh");
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            dgvNhuanButCT.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvNhuanButCT.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);

            await LoadComboboxData();
            ResetForm();
        }

        private async Task LoadComboboxData()
        {
            try
            {
                var sobaos = await _baoCol.Find(new BsonDocument()).SortByDescending(x => x["Ngayra"]).ToListAsync();
                DataTable dtBao = new DataTable();
                dtBao.Columns.Add("Maso", typeof(int));
                dtBao.Columns.Add("HienThi");
                foreach (var b in sobaos)
                {
                    string ngay = b.Contains("Ngayra") ? ((DateTime)b["Ngayra"]).ToString("dd/MM/yyyy") : "";
                    dtBao.Rows.Add(b["Maso"], $"{b["Tenbao"]} - Số {b["Sobao"]} ({ngay})");
                }
                cboSoBao.DisplayMember = "HienThi";
                cboSoBao.ValueMember = "Maso";
                cboSoBao.DataSource = dtBao;

                var butdanhs = await _butdanhCol.Find(new BsonDocument()).ToListAsync();
                cboButDanh.Items.Clear();
                foreach (var bd in butdanhs) cboButDanh.Items.Add(bd["Butdanh"].ToString());
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load dữ liệu: " + ex.Message); }
        }

        private async void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null || !(cboSoBao.SelectedValue is int)) return;
            int msBao = (int)cboSoBao.SelectedValue;

            var filterBao = Builders<BsonDocument>.Filter.Eq("Maso", msBao);
            var bao = await _baoCol.Find(filterBao).FirstOrDefaultAsync();
            bool isLocked = (bao != null && bao.GetValue("DaDuyet", "N").ToString() == "Y");

            LockUI(isLocked);
            await LoadNhuanButByBao(msBao);
        }

        private async Task LoadNhuanButByBao(int msBao)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MsBao", msBao);
            var list = await _nhuanbutCol.Find(filter).ToListAsync();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Maso"), new DataColumn("Tenbai"), new DataColumn("Trang"),
                new DataColumn("Muc"), new DataColumn("Butdanh"), new DataColumn("TienNhuanbut", typeof(double))
            });

            double total = 0;
            foreach (var doc in list)
            {
                double money = doc.GetValue("TienNhuanbut", 0).ToDouble();
                dt.Rows.Add(doc["Maso"], doc["Tenbai"], doc["Trang"], doc["Muc"], doc["Butdanh"], money);
                total += money;
            }
            dgvNhuanButCT.DataSource = dt;
            lblTongTien.Text = $"Tổng quỹ số báo: {total:N0} VNĐ";
        }

        private void LockUI(bool isLocked)
        {
            groupBox1.Enabled = !isLocked;
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnSua.Enabled = !isLocked;
            if (isLocked)
            {
                btnChotSo.Text = "🔒 ĐÃ CHỐT SỔ"; btnChotSo.FillColor = Color.Gray; btnChotSo.Enabled = false;
                lblTrangThai.Text = "TRẠNG THÁI: ĐÃ KHÓA DỮ LIỆU"; lblTrangThai.ForeColor = Color.Red;
            }
            else
            {
                btnChotSo.Text = "🔓 KHÓA / CHỐT SỔ"; btnChotSo.FillColor = Color.Crimson; btnChotSo.Enabled = true;
                lblTrangThai.Text = "TRẠNG THÁI: ĐANG NHẬP LIỆU"; lblTrangThai.ForeColor = Color.Green;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            _isAdding = true;
            txtTenBai.Focus();
        }

        // BỔ SUNG HÀM NÚT SỬA MÀ TÔI QUÊN LÚC NÃY
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text))
            {
                MessageBox.Show("Vui lòng chọn bài viết trên bảng để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _isAdding = false;
            txtTenBai.Focus();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBai.Text) || !double.TryParse(txtSoTien.Text, out double tien))
            {
                MessageBox.Show("Đồng chí vui lòng nhập đủ tên bài và số tiền!"); return;
            }

            if (tien > 2000000)
            {
                var rs = MessageBox.Show("Số tiền vượt định mức quy định (2.000.000 VNĐ). Đồng chí có chắc muốn tiếp tục lưu?", "Cảnh báo cao tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.No) return;
            }

            try
            {
                if (_isAdding)
                {
                    var doc = new BsonDocument {
                        { "Maso", new Random().Next(1000, 99999) }, { "Tenbai", txtTenBai.Text },
                        { "Trang", txtTrang.Text }, { "Muc", txtMuc.Text }, { "TienNhuanbut", tien },
                        { "Butdanh", cboButDanh.Text }, { "MsBao", (int)cboSoBao.SelectedValue }
                    };
                    await _nhuanbutCol.InsertOneAsync(doc);
                }
                else
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("Maso", int.Parse(txtMaBai.Text));
                    var update = Builders<BsonDocument>.Update.Set("Tenbai", txtTenBai.Text).Set("TienNhuanbut", tien)
                                 .Set("Trang", txtTrang.Text).Set("Muc", txtMuc.Text).Set("Butdanh", cboButDanh.Text);
                    await _nhuanbutCol.UpdateOneAsync(filter, update);
                }
                await LoadNhuanButByBao((int)cboSoBao.SelectedValue);
                ResetForm();
                MessageBox.Show("Đã lưu thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnChotSo_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Đồng chí chắc chắn muốn CHỐT SỔ báo này? Sau khi chốt, dữ liệu sẽ bị khóa để gửi duyệt!", "Xác nhận Workflow", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Maso", (int)cboSoBao.SelectedValue);
                await _baoCol.UpdateOneAsync(filter, Builders<BsonDocument>.Update.Set("DaDuyet", "Y"));
                LockUI(true);
                MessageBox.Show("Chốt sổ thành công! Dữ liệu đã được chuyển qua bộ phận kiểm tra.");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text)) return;
            if (MessageBox.Show("Xóa bài viết này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _nhuanbutCol.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Maso", int.Parse(txtMaBai.Text)));
                await LoadNhuanButByBao((int)cboSoBao.SelectedValue);
                ResetForm();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => ResetForm();

        private void ResetForm()
        {
            txtMaBai.Clear(); txtTenBai.Clear(); txtTrang.Clear(); txtMuc.Clear(); txtSoTien.Clear();
            cboButDanh.SelectedIndex = -1; _isAdding = false;
        }

        private void dgvNhuanButCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !groupBox1.Enabled) return;
            var r = dgvNhuanButCT.Rows[e.RowIndex];
            txtMaBai.Text = r.Cells["Maso"].Value.ToString();
            txtTenBai.Text = r.Cells["Tenbai"].Value.ToString();
            txtTrang.Text = r.Cells["Trang"].Value.ToString();
            txtMuc.Text = r.Cells["Muc"].Value.ToString();
            txtSoTien.Text = r.Cells["TienNhuanbut"].Value.ToString();
            cboButDanh.Text = r.Cells["Butdanh"].Value.ToString();
            _isAdding = false;
        }
    }
}