using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoTongHop : Form
    {
        public FrmBaoCaoTongHop()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadTopPhóngViên();
        }

        void LoadThongKe()
        {
            try
            {
                // 1. Tổng quỹ nhuận bút (Tất cả bài viết đã nhập)
                string qAll = "SELECT SUM(TienNhuanbut) FROM Nhuanbut";
                object rAll = DataProvider.Instance.ExecuteScalar(qAll);
                lblTongQuy.Text = (rAll != DBNull.Value) ? string.Format("{0:N0} đ", rAll) : "0 đ";

                // 2. Tiền đã chi (Dựa trên số báo đã Duyệt 'Y')
                string qPaid = @"SELECT SUM(n.TienNhuanbut) 
                                FROM Nhuanbut n JOIN Bao b ON n.MsBao = b.Maso 
                                WHERE b.DaDuyet = 'Y'";
                object rPaid = DataProvider.Instance.ExecuteScalar(qPaid);
                lblDaChi.Text = (rPaid != DBNull.Value) ? string.Format("{0:N0} đ", rPaid) : "0 đ";

                // 3. Tiền chờ chi (Số báo chưa Duyệt 'N')
                string qPending = @"SELECT SUM(n.TienNhuanbut) 
                                   FROM Nhuanbut n JOIN Bao b ON n.MsBao = b.Maso 
                                   WHERE b.DaDuyet = 'N'";
                object rPending = DataProvider.Instance.ExecuteScalar(qPending);
                lblChoChi.Text = (rPending != DBNull.Value) ? string.Format("{0:N0} đ", rPending) : "0 đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        void LoadTopPhóngViên()
        {
            try
            {
                // Truy vấn lấy Top 10 Bút danh có tổng tiền cao nhất
                string sql = @"SELECT TOP 10 Butdanh AS [Bút Danh], 
                               SUM(TienNhuanbut) AS [Tổng Tiền Nhuận Bút]
                               FROM Nhuanbut 
                               GROUP BY Butdanh 
                               ORDER BY SUM(TienNhuanbut) DESC";

                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
                dgvTopPV.DataSource = dt;

                // Fix font VNI để hiện tên Bút danh mã VNI
                Font vniFont = new Font("VNI-Times", 12F);
                dgvTopPV.DefaultCellStyle.Font = vniFont;
                dgvTopPV.ThemeStyle.RowsStyle.Font = vniFont;

                if (dgvTopPV.Columns.Count > 1)
                {
                    dgvTopPV.Columns[1].DefaultCellStyle.Format = "N0";
                    dgvTopPV.Columns[1].DefaultCellStyle.ForeColor = Color.Crimson;
                }
            }
            catch { }
        }
    }
}