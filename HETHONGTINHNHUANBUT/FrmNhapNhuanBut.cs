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
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private string _selectedNhuanButId = null;
        public string NguoiDangNhap { get; set; }

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
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
                var listBaoRaw = await _baoColl.Find(b => b.DaDuyet == "N").ToListAsync();
                var displayListBao = listBaoRaw.Select(b => new CboBaoItem
                {
                    MaSoBao = b.Maso?.ToString() ?? "",
                    HienThi = $"Số {b.Sobao} - {b.Tenbao} ({b.Ngayra:dd/MM/yyyy})"
                }).ToList();

                cboSoBao.DataSource = displayListBao;
                cboSoBao.DisplayMember = "HienThi";
                cboSoBao.ValueMember = "MaSoBao";

                var listTacGia = await _tacGiaColl.Find(_ => true).ToListAsync();
                List<string> tatCaButDanh = listTacGia.Select(tg => !string.IsNullOrWhiteSpace(tg.ButDanh) ? tg.ButDanh.Trim() : tg.HoTen.Trim()).ToList();
                cboButDanh.DataSource = tatCaButDanh.Distinct().OrderBy(x => x).ToList();
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
                var list = await _nhuanButColl.Find(n => n.MsBao == maSoBao).ToListAsync();

                dgvNhuanBut.DataSource = list.Select(n => new {
                    n.Id,
                    STT = n.STT?.ToString() ?? "",
                    TenBai = n.Tenbai,
                    Trang = n.Trang,
                    Muc = n.Muc,
                    ButDanh = n.Butdanh,
                    TienNhuanBut = n.TienNhuanbut.ToString("N0") + " VNĐ"
                }).ToList();

                if (dgvNhuanBut.Columns["Id"] != null) dgvNhuanBut.Columns["Id"].Visible = false;
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + list.Sum(n => n.TienNhuanbut).ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lưới: " + ex.Message); }
        }

        // ĐÃ KHÔI PHỤC: Hàm click vào dòng nào hiện lên dòng đó
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
                if (string.IsNullOrEmpty(_selectedNhuanButId))
                {
                    var nb = new NhuanBut
                    {
                        Maso = Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                        MsBao = maSoBao,
                        TenSoBao = cboSoBao.Text,
                        Tenbai = txtTenBai.Text.Trim(),
                        Trang = txtTrang.Text.Trim(),
                        Muc = txtMuc.Text.Trim(),
                        Butdanh = cboButDanh.Text,
                        TienNhuanbut = tien,
                        addby = this.NguoiDangNhap,
                        ngaychuyen = DateTime.Now,
                        STT = (dgvNhuanBut.Rows.Count + 1).ToString() // Đã fix int to string[cite: 2]
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

        // ĐÃ KHÔI PHỤC: Hàm xóa bài viết[cite: 2]
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

        // ĐÃ KHÔI PHỤC: Hàm làm mới ô nhập[cite: 2]
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
            txtTenBai.Focus();
        }
    }
}