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
    public partial class FNhanVien : Form
    {
        BUS_NHANVIEN busNV;
        public FNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NHANVIEN();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
           bool a= kiemtraThem();
            if (a==true)
            {


                if (txtMaNV.Enabled == false)
                {
                    txtMaNV.Enabled = true;
                    txtTen.Text = "";
                    txtHo.Text = "";
                    txtDiaChi.Text = "";
                    txtCCCD.Text = "";
                    txtDienThoai.Text = "";
                    txtMaNV.Text = "";
                }

                else
                {
                    NHANVIEN NhanVien = new NHANVIEN();
                    NhanVien.MaNv = txtMaNV.Text;
                    NhanVien.HoNv = txtHo.Text;
                    NhanVien.TenNV = txtTen.Text;
                    NhanVien.diachi = txtDiaChi.Text;
                    NhanVien.dienthoai = txtDienThoai.Text;
                    NhanVien.NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");
                    NhanVien.CCCD = txtCCCD.Text;
                    NhanVien.MaTrinhDo = cbTrinhDo.SelectedValue.ToString();
                    busNV.ThemNV(NhanVien);
                    busNV.DSNhanVien(dGNhanVien);
                }
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            
        
    }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void diaChiLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        public bool kiemtraThem()

        {
            if ( !(txtCCCD.Text.Length == 12 || txtCCCD.Text.Length == 10))
            {
                MessageBox.Show("Vui lòng nhập số căn cước 12 số hoặc 10 số");
                txtCCCD.Text = "";
                txtCCCD.Focus();
                return false;
            }

            if (txtDienThoai.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại 10 số");
                txtDienThoai.Text = "";
                txtDienThoai.Focus();
                return false;
            }

            return true;
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGNhanVien.Rows.Count - 1)//dòng 0 đến dòng số dòng-1
            {
                txtMaNV.Enabled = false;
                txtMaNV.Text = dGNhanVien.Rows[e.RowIndex].Cells["MaNv"].Value.ToString();
                txtHo.Text = dGNhanVien.Rows[e.RowIndex].Cells["HoNv"].Value.ToString();
                txtTen.Text = dGNhanVien.Rows[e.RowIndex].Cells["TenNv"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dGNhanVien.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString());
                txtDienThoai.Text = dGNhanVien.Rows[e.RowIndex].Cells["dienthoai"].Value.ToString();
                txtCCCD.Text = dGNhanVien.Rows[e.RowIndex].Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                cbTrinhDo.SelectedValue = dGNhanVien.Rows[e.RowIndex].Cells["MaTrinhdo"].Value.ToString();
            }
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            busNV.DSNhanVien(dGNhanVien);
            busNV.DSTrinhDo(cbTrinhDo);
            
            dGNhanVien.Columns[0].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[1].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[2].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[3].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[4].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[5].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[6].Width = (int)(0.1 * dGNhanVien.Width);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            bool a = kiemtraThem();
            if (a == true)
            {
                NHANVIEN NhanVien = new NHANVIEN();
                NhanVien.MaNv = txtMaNV.Text;
                NhanVien.diachi = txtDiaChi.Text;
                NhanVien.dienthoai = txtDienThoai.Text;
                NhanVien.TenNV = txtTen.Text;
                NhanVien.HoNv = txtHo.Text;
                NhanVien.NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");
                NhanVien.MaTrinhDo = cbTrinhDo.SelectedValue.ToString();
                NhanVien.CCCD = txtCCCD.Text;
                busNV.SuaNV(NhanVien);
                busNV.DSNhanVien(dGNhanVien);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            
            busNV.TimKiemDSNhanVien(dGNhanVien, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();

            busNV.DSNhanVien(dGNhanVien);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNhapHang f = new FNhapHang();
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBanHang f = new FBanHang();
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FTonKho f = new FTonKho();
            f.ShowDialog();
            this.Close();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {

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
                            workbook.Worksheets.Add(busNV.DSNV(), "DSNhanVien");
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
            string url = "nhanvien";
            FImport import = new FImport(url);
            this.Hide();
            import.ShowDialog();
        }
    }
}
