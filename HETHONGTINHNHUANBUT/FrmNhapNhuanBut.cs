using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<Bao> _baoColl;
        private readonly IMongoCollection<ButDanh> _butDanhColl;

        private string _selectedNhuanButId = null;
        public string NguoiDangNhap { get; set; }

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
            _butDanhColl = MongoProvider.Instance.GetCollection<ButDanh>("Butdanh");
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            dgvNhuanBut.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboSoBao.SelectedIndexChanged -= cboSoBao_SelectedIndexChanged;

            await LoadComboboxDataAsync();
            cboSoBao.SelectedIndexChanged += cboSoBao_SelectedIndexChanged;

            if (cboSoBao.SelectedValue != null)
                await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
        }

        public class CboBaoItem
        {
            public string MaSoBao { get; set; }
            public string HienThi { get; set; }
        }

        private async Task LoadComboboxDataAsync()
        {
            try
            {
                // 1. Load Kỳ Báo - ĐÃ SỬA: Loại bỏ "Số {b.Sobao}" cho đỡ rối mắt
                var listBaoRaw = await _baoColl.Find(b => b.DaDuyet == "N").ToListAsync();
                var displayListBao = listBaoRaw.Select(b => new CboBaoItem
                {
                    MaSoBao = b.Maso?.ToString() ?? "",
                    HienThi = $"{b.Tenbao} ({b.Ngayra.ToLocalTime():dd/MM/yyyy})" // Chuẩn xịn
                }).ToList();

                cboSoBao.DataSource = displayListBao;
                cboSoBao.DisplayMember = "HienThi";
                cboSoBao.ValueMember = "MaSoBao";

                // 2. Load BÚT DANH
                var listButDanh = await _butDanhColl.Find(_ => true).ToListAsync();
                List<string> tatCaButDanh = listButDanh
                    .Where(b => !string.IsNullOrWhiteSpace(b.Butdanh))
                    .Select(b => b.Butdanh.Trim())
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                cboButDanh.DataSource = tatCaButDanh;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh mục: " + ex.Message); }
        }

        private async void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null)
                await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
        }

        private async Task LoadDataGridAsync(string maSoBao)
        {
            try
            {
                var filterBuilder = Builders<NhuanBut>.Filter;
                var filter = filterBuilder.Eq("MsBao", maSoBao);

                if (int.TryParse(maSoBao, out int maInt))
                {
                    filter = filterBuilder.Or(filter, filterBuilder.Eq("MsBao", maInt));
                }

                var list = await _nhuanButColl.Find(filter).ToListAsync();

                dgvNhuanBut.DataSource = list.Select(n => new {
                    n.Id,
                    STT = n.STT?.ToString() ?? "",
                    TenBai = n.Tenbai,
                    Trang = n.Trang,
                    Muc = n.Muc,
                    ButDanh = n.Butdanh,
                    VungPhatHanh = n.Vung ?? "",
                    VungTaiBan = n.VungChuyenDen ?? "",
                    TienNhuanBut = n.TienNhuanbut.ToString("N0") + " VNĐ"
                }).ToList();

                if (dgvNhuanBut.Columns["Id"] != null) dgvNhuanBut.Columns["Id"].Visible = false;
                if (dgvNhuanBut.Columns["VungPhatHanh"] != null) dgvNhuanBut.Columns["VungPhatHanh"].Visible = false;
                if (dgvNhuanBut.Columns["VungTaiBan"] != null) dgvNhuanBut.Columns["VungTaiBan"].Visible = false;

                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + list.Sum(n => n.TienNhuanbut).ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lưới: " + ex.Message); }
        }

        private void dgvNhuanBut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNhuanBut.CurrentRow == null) return;

            var row = dgvNhuanBut.Rows[e.RowIndex];
            _selectedNhuanButId = row.Cells["Id"].Value?.ToString();

            txtTenBai.Text = row.Cells["TenBai"].Value?.ToString();
            txtTrang.Text = row.Cells["Trang"].Value?.ToString();
            txtMuc.Text = row.Cells["Muc"].Value?.ToString();
            cboButDanh.Text = row.Cells["ButDanh"].Value?.ToString();

            string tienRaw = row.Cells["TienNhuanBut"].Value?.ToString().Replace(" VNĐ", "").Replace(",", "");
            txtTienNhuanBut.Text = tienRaw;

            cboVung.Text = row.Cells["VungPhatHanh"].Value?.ToString();
            cboVungChuyenDen.Text = row.Cells["VungTaiBan"].Value?.ToString();

            txtTienNhuanBut.Focus();
            txtTienNhuanBut.SelectAll();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Kỳ báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập Tên bài!"); return; }
            if (!decimal.TryParse(txtTienNhuanBut.Text, out decimal tien)) { MessageBox.Show("Số tiền không hợp lệ!"); return; }

            try
            {
                string maSoBao = cboSoBao.SelectedValue.ToString();
                var baoInfo = await _baoColl.Find(b => b.Maso.ToString() == maSoBao).FirstOrDefaultAsync();
                string tenSoBaoHienThi = cboSoBao.Text;

                // ĐÃ SỬA: Đồng bộ cách hiển thị Tên báo khi lưu vào DB NhuanBut
                if (baoInfo != null)
                {
                    tenSoBaoHienThi = $"{baoInfo.Tenbao} ({baoInfo.Ngayra.ToLocalTime():dd/MM/yyyy})";
                }

                if (string.IsNullOrEmpty(_selectedNhuanButId))
                {
                    var nb = new NhuanBut
                    {
                        Maso = Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                        MsBao = maSoBao,
                        TenSoBao = tenSoBaoHienThi,
                        Tenbai = txtTenBai.Text.Trim(),
                        Trang = txtTrang.Text.Trim(),
                        Muc = txtMuc.Text.Trim(),
                        Butdanh = cboButDanh.Text,
                        TienNhuanbut = tien,
                        Vung = cboVung.Text,
                        VungChuyenDen = cboVungChuyenDen.Text,
                        addby = this.NguoiDangNhap,
                        ngaychuyen = DateTime.Now,
                        STT = (dgvNhuanBut.Rows.Count + 1).ToString()
                    };
                    await _nhuanButColl.InsertOneAsync(nb);
                }
                else
                {
                    var update = Builders<NhuanBut>.Update
                        .Set(x => x.Tenbai, txtTenBai.Text.Trim())
                        .Set(x => x.Trang, txtTrang.Text.Trim())
                        .Set(x => x.Muc, txtMuc.Text.Trim())
                        .Set(x => x.Butdanh, cboButDanh.Text)
                        .Set(x => x.TienNhuanbut, tien)
                        .Set(x => x.Vung, cboVung.Text)
                        .Set(x => x.VungChuyenDen, cboVungChuyenDen.Text)
                        .Set(x => x.TenSoBao, tenSoBaoHienThi)
                        .Set(x => x.addby, this.NguoiDangNhap)
                        .Set(x => x.ngaychuyen, DateTime.Now);
                    await _nhuanButColl.UpdateOneAsync(x => x.Id == _selectedNhuanButId, update);
                }

                await LoadDataGridAsync(maSoBao);
                ClearInputs();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedNhuanButId)) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa bài này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _nhuanButColl.DeleteOneAsync(n => n.Id == _selectedNhuanButId);
                if (cboSoBao.SelectedValue != null)
                    await LoadDataGridAsync(cboSoBao.SelectedValue.ToString());
                ClearInputs();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedNhuanButId = null;
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtTienNhuanBut.Clear();
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            txtTenBai.Focus();
        }
    }
}