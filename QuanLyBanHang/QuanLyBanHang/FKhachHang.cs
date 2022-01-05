using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FKhachHang : Form
    {
        BUS_KHACHHANG busKH;
        
        public FKhachHang()
        {
           
            InitializeComponent();
            busKH = new BUS_KHACHHANG();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bool a = kiemtraThem();
            if (a == true)
            {

                if (txtMaKH.Enabled == false)
                {
                    txtMaKH.Enabled = true;
                    txtTenKH.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    txtMaKH.Text = "";

                }

                else
                {
                    KHACHHANG KhachHang = new KHACHHANG();
                    KhachHang.MaKH = txtMaKH.Text;
                    KhachHang.TenKH = txtTenKH.Text;
                    KhachHang.Diachi = txtDiaChi.Text;
                    KhachHang.SoDT = txtSDT.Text;

                    busKH.ThemKH(KhachHang);
                    busKH.DSKhachHang(dGKH);
                }
            }
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            busKH.DSKhachHang(dGKH);

            dGKH.Columns[0].Width = (int)(0.2 * dGKH.Width);
            dGKH.Columns[1].Width = (int)(0.2 * dGKH.Width);
            dGKH.Columns[2].Width = (int)(0.3 * dGKH.Width);
            dGKH.Columns[3].Width = (int)(0.2 * dGKH.Width);
           
        }

        public bool kiemtraThem()

        {
            

            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại 10 số");
                txtSDT.Text = "";
                txtSDT.Focus();
                return false;
            }

            return true;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            KHACHHANG Khachhang = new KHACHHANG();
            Khachhang.MaKH = txtMaKH.Text;
            Khachhang.TenKH = txtTenKH.Text;
            Khachhang.SoDT = txtSDT.Text;
            Khachhang.Diachi = txtDiaChi.Text;      
            busKH.SuaKH(Khachhang);
            busKH.DSKhachHang(dGKH);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dGKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGKH.Rows.Count - 1)//dòng 0 đến dòng số dòng-1
            {
                txtMaKH.Enabled = false;
                txtMaKH.Text = dGKH.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dGKH.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = dGKH.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dGKH.Rows[e.RowIndex].Cells["SoDT"].Value.ToString();

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;

            busKH.TimKiemDSKhachHang(dGKH, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
            busKH.DSKhachHang(dGKH);
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
            this.Hide();
            FTonKho f = new FTonKho();
            f.ShowDialog();
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

           
        }

        private void Export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(busKH.DSKhachHang(), "DSKhachHang");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("You have successfully exported", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            string url = "khachhang";
            FImport import = new FImport(url);
            this.Hide();
            import.ShowDialog();
        }
    }
}
