using Guna.UI2.WinForms;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public static class UIHelper
    {
        public static void FormatGiaoDienBang(Guna2DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 38;
            dgv.EnableHeadersVisualStyles = false;

            // Column headers
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            dgv.ColumnHeadersHeight = 42;

            // Default rows
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Guna ThemeStyle (required for Guna2DataGridView)
            dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.ThemeStyle.BackColor = Color.White;
            dgv.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ThemeStyle.HeaderStyle.Height = 42;
            dgv.ThemeStyle.ReadOnly = true;
            dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ThemeStyle.RowsStyle.Height = 38;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        public static void ConfigureColumns(Guna2DataGridView dgv, params (string Name, string Header, bool IsNumeric, bool IsCenter)[] columns)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            foreach (var col in columns)
            {
                if (dgv.Columns[col.Name] == null) continue;

                if (!string.IsNullOrEmpty(col.Header))
                    dgv.Columns[col.Name].HeaderText = col.Header;

                if (col.IsNumeric)
                    dgv.Columns[col.Name].DefaultCellStyle.Format = "N0";

                dgv.Columns[col.Name].DefaultCellStyle.Alignment = col.IsCenter ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.MiddleLeft;
            }

            int visibleCount = 0;
            foreach (DataGridViewColumn c in dgv.Columns)
                if (c.Visible) visibleCount++;

            if (visibleCount > 0)
            {
                float equalWeight = 100f / visibleCount;
                foreach (DataGridViewColumn c in dgv.Columns)
                    if (c.Visible) c.FillWeight = equalWeight;
            }
        }
    }
}
