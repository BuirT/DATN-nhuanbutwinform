using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmPhieuChi : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private readonly IMongoCollection<PhieuChi> _phieuChiColl;

        public string NguoiLapPhieu { get; set; } // Lấy từ Form chính

        public FrmPhieuChi()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
            _phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");
        }

        private async void FrmPhieuChi_Load(object sender, EventArgs e)
        {
            await LoadAuthorsAsync();
            cboHinhThuc.SelectedIndex = 0;
            txtSoPhieu.Text = "PC-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
        }

        private async Task LoadAuthorsAsync()
        {
            var authors = await _tacGiaColl.Find(_ => true).ToListAsync();
            cboTacGia.DataSource = authors;
            cboTacGia.DisplayMember = "Hoten";
            cboTacGia.ValueMember = "Ddong"; // Bút danh dùng làm định danh liên kết
        }

        // Tải danh sách bài viết CHƯA THANH TOÁN của tác giả được chọn
        private async void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTacGia.SelectedValue == null) return;
            string penName = cboTacGia.SelectedValue.ToString();

            // Tìm các bài có Bút danh này và DaThanhToan == false
            var list = await _nhuanButColl.Find(n => n.ButDanh == penName && n.DaThanhToan == false).ToListAsync();

            dgvChuaThanhToan.DataSource = list.Select(n => new {
                n.Id,
                n.TenSoBao,
                n.TenBai,
                n.TienNhuanBut
            }).ToList();

            if (dgvChuaThanhToan.Columns["Id"] != null) dgvChuaThanhToan.Columns["Id"].Visible = false;
            TinhToanTien();
        }

        // Logic tính tiền khi người dùng tích chọn Checkbox
        private void TinhToanTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);
                if (isChecked)
                {
                    // Giả sử cột TienNhuanBut ở vị trí 4 (sau Id, TenSoBao, TenBai)
                    decimal tien = Convert.ToDecimal(row.Cells["TienNhuanBut"].Value);
                    tong += tien;
                }
            }

            txtTongTien.Text = tong.ToString("N0");

            if (decimal.TryParse(txtThue.Text, out decimal thuePhanTram))
            {
                decimal thueVnd = tong * (thuePhanTram / 100);
                decimal thucLinh = tong - thueVnd;
                txtThucLinh.Text = thucLinh.ToString("N0");
            }
        }

        private async void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<string> selectedIds = new List<string>();
            foreach (DataGridViewRow row in dgvChuaThanhToan.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colCheck"].Value))
                {
                    selectedIds.Add(row.Cells["Id"].Value.ToString());
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bài viết để thanh toán!");
                return;
            }

            try
            {
                // 1. Lưu phiếu chi mới
                var phieu = new PhieuChi
                {
                    SoPhieu = txtSoPhieu.Text,
                    TenTacGia = cboTacGia.Text,
                    TongTien = decimal.Parse(txtTongTien.Text),
                    Thue = decimal.Parse(txtThue.Text),
                    ThucLinh = decimal.Parse(txtThucLinh.Text),
                    HinhThuc = cboHinhThuc.Text,
                    NguoiLap = this.NguoiLapPhieu,
                    DanhSachBaiViet = selectedIds
                };
                await _phieuChiColl.InsertOneAsync(phieu);

                // 2. Cập nhật trạng thái "Đã thanh toán" cho các bài viết được chọn
                var filter = Builders<NhuanBut>.Filter.In(n => n.Id, selectedIds);
                var update = Builders<NhuanBut>.Update
                    .Set(n => n.DaThanhToan, true)
                    .Set(n => n.MaPhieuChi, phieu.SoPhieu);

                await _nhuanButColl.UpdateManyAsync(filter, update);

                MessageBox.Show("Lập phiếu chi thành công!");
                cboTacGia_SelectedIndexChanged(null, null); // Refresh Grid
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Các sự kiện hỗ trợ cập nhật tiền thời gian thực
        private void dgvChuaThanhToan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) TinhToanTien();
        }

        private void dgvChuaThanhToan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChuaThanhToan.IsCurrentCellDirty) dgvChuaThanhToan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void txtThue_TextChanged(object sender, EventArgs e) => TinhToanTien();
    }
}