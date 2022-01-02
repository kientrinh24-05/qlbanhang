using System;
using System.Windows.Forms;


namespace QuanLyBanHang
{
    public partial class FTonKho : Form
    {
        BUS_TONKHO bsTonKho;
        public FTonKho()
        {
            InitializeComponent();
            bsTonKho = new BUS_TONKHO();
        }

        private void FTonKho_Load(object sender, EventArgs e)
        {
            bsTonKho.DSSP(item);
        }

        private void RenderGrid(ref DataGridView dg, DateTime dFrom, DateTime dTo, string Item)
        {
            bsTonKho.BCTonKho(ref dg, dFrom, dTo, Item);
        }

        private void item_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            string sp = item.SelectedValue.ToString();
            DateTime d0 = new DateTime(dFrom.Value.Year, dFrom.Value.Month, dFrom.Value.Day);
            DateTime d1 = new DateTime(dTo.Value.Year, dTo.Value.Month, dTo.Value.Day);
            RenderGrid(ref dataGridView1, d0, d1, sp.Trim());
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            string name = "d:\\" + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + ".xls";
            workbook.SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //app.Quit();
            app.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNhanVien f = new FNhanVien();
            f.ShowDialog();
            this.Close();        
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FKhachHang f = new FKhachHang();
            f.ShowDialog();
            this.Close();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNhaCungCap f = new FNhaCungCap();
            f.ShowDialog();
            this.Close();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FSanPham f = new FSanPham();
            f.ShowDialog();
            this.Close();
        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNhapHang f = new FNhapHang();
            f.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBanHang f = new FBanHang();
            f.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
    }
}
