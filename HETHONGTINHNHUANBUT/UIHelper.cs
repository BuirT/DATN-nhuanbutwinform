using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public static class UIHelper
    {
        public static void FormatGiaoDienBang(Guna2DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgv.RowTemplate.Height = 40;
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}