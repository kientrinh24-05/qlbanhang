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
    public partial class FSanPham : Form
    {
        BUS_SANPHAM busSP;
        public FSanPham()
        {
            InitializeComponent();
            busSP = new BUS_SANPHAM();
        }

        private void btThem_Click(object sender, EventArgs e)
        {


           
                if (txtMaSP.Enabled == false)
                {
                    txtMaSP.Enabled = true;
                    txtMaSP.Text = "";
                    txtTenSP.Text = "";
                }

                else
                {
                    SANPHAM SP = new SANPHAM();
                    SP.MaSP = txtMaSP.Text;
                    SP.TenSP = txtTenSP.Text;
                    SP.DVT = cbDVT.SelectedValue.ToString();
                    SP.DONGIA_BAN = int.Parse(txtDgBan.Text);
                    SP.DONGIA_NHAP = int.Parse(txtDgNhap.Text);

                if (txtDgBan.Text.Length <= 0 || int.Parse(txtDgBan.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đơn giá bán hoặc đơn giá bán phải lớn hơn không");
                    return;
                }

                if (txtDgNhap.Text.Length <= 0 || int.Parse(txtDgNhap.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đơn giá nhập hoặc đơn giá nhập phải lớn hơn 0");
                    return;
                }

                if (int.Parse(txtDgNhap.Text) >= int.Parse(txtDgBan.Text))
                {
                    MessageBox.Show("Đơn Giá Bán phải lớn hơn Đơn Giá Nhập");
                    return;
                }
                busSP.ThemSanPham(SP);
                    busSP.DSSanPham(dGSP);
                }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SANPHAM SP = new SANPHAM();
            SP.MaSP = txtMaSP.Text;
            SP.TenSP = txtTenSP.Text;
            SP.DVT = cbDVT.SelectedValue.ToString();
            SP.DONGIA_BAN = int.Parse(txtDgBan.Text);
            SP.DONGIA_NHAP = int.Parse(txtDgNhap.Text);
            if (txtDgBan.Text.Length <= 0 || int.Parse(txtDgBan.Text)<=0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá bán hoặc đơn giá bán phải lớn hơn 0");
                return;
            }

            if (txtDgNhap.Text.Length <= 0 || int.Parse(txtDgNhap.Text) <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá nhập hoặc đơn giá nhập phải lớn hơn 0");
                return;
            }

            if (int.Parse(txtDgNhap.Text) >= int.Parse(txtDgBan.Text))
            {
                MessageBox.Show("Đơn Giá Bán phải lớn hơn Đơn Giá Nhập");
                return;
            }
            
            busSP.SuaSanPham(SP);
            busSP.DSSanPham(dGSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;

            busSP.TimKiemSanPham(dGSP, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
            busSP.DSSanPham(dGSP);
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            busSP.DSDVT(cbDVT);
            busSP.DSSanPham(dGSP);

            dGSP.Columns[0].Width = (int)(0.1 * dGSP.Width);
            dGSP.Columns[1].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[2].Width = (int)(0.2 * dGSP.Width);
           
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGSP.Rows.Count - 1)//dòng 0 đến dòng số dòng-1
            {
                txtMaSP.Enabled = false;
                txtMaSP.Text = dGSP.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                cbDVT.Text = dGSP.Rows[e.RowIndex].Cells["TenDVT"].Value.ToString();
                txtDgNhap.Text = dGSP.Rows[e.RowIndex].Cells["DONGIA_NHAP"].Value.ToString();
                txtDgBan.Text = dGSP.Rows[e.RowIndex].Cells["DONGIA_BAN"].Value.ToString();

            }
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

        private void quảnLýSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
        }

        private void txtDgNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu  muốn,có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDgBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu  muốn,có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
