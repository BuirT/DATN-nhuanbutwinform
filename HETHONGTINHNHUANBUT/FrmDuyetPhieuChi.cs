using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmDuyetPhieuChi : Form
    {
        private readonly IMongoCollection<PhieuChi> _phieuChiColl;
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private string _selectedId = "";

        public string NguoiDuyet { get; set; } = "Ban Giám Đốc";

        public FrmDuyetPhieuChi()
        {
            InitializeComponent();
            _phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
        }

        private async void FrmDuyetPhieuChi_Load(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                int trangThai = 0;
                if (cboTrangThai.SelectedIndex == 1) trangThai = 1;
                else if (cboTrangThai.SelectedIndex == 2) trangThai = -1;

                var filter = Builders<PhieuChi>.Filter.Eq(p => p.TrangThaiDuyet, trangThai);
                string keyword = txtTimKiem.Text.Trim().ToLower();

                var listRaw = await _phieuChiColl.Find(filter).ToListAsync();

                if (!string.IsNullOrEmpty(keyword))
                {
                    listRaw = listRaw.Where(p =>
                        (p.SoPhieu != null && p.SoPhieu.ToLower().Contains(keyword)) ||
                        (p.TenTacGia != null && p.TenTacGia.ToLower().Contains(keyword))
                    ).ToList();
                }

                dgvPhieuChi.DataSource = listRaw.Select(p => new {
                    p.Id,
                    p.SoPhieu,
                    NgayLap = p.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    p.TenTacGia,
                    p.NguoiNhan,
                    p.LyDo,
                    TongTien = p.TongTien.ToString("N0"),
                    ThucLinh = p.ThucLinh.ToString("N0")
                }).OrderByDescending(x => x.NgayLap).ToList();

                if (dgvPhieuChi.Columns["Id"] != null) dgvPhieuChi.Columns["Id"].Visible = false;

                ClearDetails();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();

            bool isChoDuyet = cboTrangThai.SelectedIndex == 0;
            btnDuyet.Visible = isChoDuyet;
            btnTuChoi.Visible = isChoDuyet;

            txtLyDoTuChoi.Visible = isChoDuyet || cboTrangThai.SelectedIndex == 2;
            lblLyDoTuChoi.Visible = isChoDuyet || cboTrangThai.SelectedIndex == 2;
        }

        private void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhieuChi.Rows[e.RowIndex];
                _selectedId = row.Cells["Id"].Value?.ToString();

                lblChiTietSoPhieu.Text = "Số phiếu: " + row.Cells["SoPhieu"].Value?.ToString();
                lblChiTietTacGia.Text = "Thanh toán cho: " + row.Cells["TenTacGia"].Value?.ToString();
                lblChiTietTien.Text = row.Cells["ThucLinh"].Value?.ToString() + " VNĐ";

                if (cboTrangThai.SelectedIndex == 2)
                {
                    var phieu = _phieuChiColl.Find(p => p.Id == _selectedId).FirstOrDefault();
                    if (phieu != null) txtLyDoTuChoi.Text = phieu.LyDoTuChoi;
                }
                else
                {
                    var phieu = _phieuChiColl.Find(p => p.Id == _selectedId).FirstOrDefault();
                    if (phieu != null && cboTrangThai.SelectedIndex == 0) txtLyDoTuChoi.Text = phieu.LyDo;
                    else txtLyDoTuChoi.Clear();
                }
            }
        }

        private void ClearDetails()
        {
            _selectedId = "";
            lblChiTietSoPhieu.Text = "Số phiếu: ---";
            lblChiTietTacGia.Text = "Thanh toán cho: ---";
            lblChiTietTien.Text = "0 VNĐ";
            txtLyDoTuChoi.Clear();
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần duyệt!"); return; }
            if (MessageBox.Show("Xác nhận DUYỆT phiếu chi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var update = Builders<PhieuChi>.Update
                    .Set(p => p.TrangThaiDuyet, 1)
                    .Set(p => p.NguoiDuyet, this.NguoiDuyet)
                    .Set(p => p.NgayDuyet, DateTime.Now);

                await _phieuChiColl.UpdateOneAsync(p => p.Id == _selectedId, update);
                MessageBox.Show("Đã duyệt phiếu chi thành công! Kế toán có thể xuất tiền.");
                await LoadDataAsync();
            }
        }

        private async void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần từ chối!"); return; }
            if (string.IsNullOrWhiteSpace(txtLyDoTuChoi.Text)) { MessageBox.Show("Vui lòng nhập lý do từ chối để Kế toán biết đường sửa!"); txtLyDoTuChoi.Focus(); return; }

            if (MessageBox.Show("Xác nhận TỪ CHỐI phiếu chi này? Các bài viết trong phiếu sẽ được mở khóa để Kế toán làm lại.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var update = Builders<PhieuChi>.Update
                    .Set(p => p.TrangThaiDuyet, -1)
                    .Set(p => p.LyDoTuChoi, txtLyDoTuChoi.Text.Trim())
                    .Set(p => p.NguoiDuyet, this.NguoiDuyet)
                    .Set(p => p.NgayDuyet, DateTime.Now);
                await _phieuChiColl.UpdateOneAsync(p => p.Id == _selectedId, update);

                var phieuInfo = await _phieuChiColl.Find(p => p.Id == _selectedId).FirstOrDefaultAsync();
                if (phieuInfo != null && phieuInfo.DanhSachBaiViet != null && phieuInfo.DanhSachBaiViet.Count > 0)
                {
                    var filterNb = Builders<NhuanBut>.Filter.In(n => n.Id, phieuInfo.DanhSachBaiViet);
                    var updateNb = Builders<NhuanBut>.Update
                                    .Set(n => n.DaThanhToan, false)
                                    .Set(n => n.MaPhieuChi, "");
                    await _nhuanButColl.UpdateManyAsync(filterNb, updateNb);
                }

                MessageBox.Show("Đã từ chối phiếu chi! Hệ thống đã nhả các bài viết ra để làm lại.");
                await LoadDataAsync();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần xóa!"); return; }

            if (MessageBox.Show("Xác nhận XÓA VĨNH VIỄN phiếu chi này? Các bài viết trong phiếu sẽ được mở khóa.", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                try
                {
                    var phieuInfo = await _phieuChiColl.Find(p => p.Id == _selectedId).FirstOrDefaultAsync();
                    if (phieuInfo != null && phieuInfo.DanhSachBaiViet != null && phieuInfo.DanhSachBaiViet.Count > 0)
                    {
                        var filterNb = Builders<NhuanBut>.Filter.In(n => n.Id, phieuInfo.DanhSachBaiViet);
                        var updateNb = Builders<NhuanBut>.Update
                                        .Set(n => n.DaThanhToan, false)
                                        .Set(n => n.MaPhieuChi, "");
                        await _nhuanButColl.UpdateManyAsync(filterNb, updateNb);
                    }

                    await _phieuChiColl.DeleteOneAsync(p => p.Id == _selectedId);

                    MessageBox.Show("Đã xóa phiếu chi thành công! Hệ thống đã nhả các bài viết ra.");
                    await LoadDataAsync();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}