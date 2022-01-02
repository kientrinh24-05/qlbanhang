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
    public partial class FNhaCungCap : Form
    {
        BUS_NCC busNCC;
        public FNhaCungCap()
        {
            InitializeComponent();
            busNCC = new BUS_NCC();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bool a = kiemtraThem();
            if (a == true)
            {


                if (txtMaNCC.Enabled == false)
                {
                    txtMaNCC.Enabled = true;
                    txtTenNCC.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    txtMaNCC.Text = "";
                  
                }

                else
                {
                    NHACUNGCAP NCC = new NHACUNGCAP();
                    NCC.MaNCC = txtMaNCC.Text;
                    NCC.TenNCC = txtTenNCC.Text;
                    NCC.Diachi = txtDiaChi.Text;
                    NCC.SoDT = txtSDT.Text;
                    busNCC.ThemNCC(NCC);
                    busNCC.DSNCC(dGNCC);
                }
            }
        }

        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            busNCC.DSNCC(dGNCC);

            dGNCC.Columns[0].Width = (int)(0.2 * dGNCC.Width);
            dGNCC.Columns[1].Width = (int)(0.2 * dGNCC.Width);
            dGNCC.Columns[2].Width = (int)(0.3 * dGNCC.Width);
            dGNCC.Columns[3].Width = (int)(0.2 * dGNCC.Width);
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
            NHACUNGCAP NCC = new NHACUNGCAP();
            NCC.MaNCC = txtMaNCC.Text;
            NCC.TenNCC = txtTenNCC.Text;
            NCC.SoDT = txtSDT.Text;
            NCC.Diachi = txtDiaChi.Text;
            busNCC.SuaNCC(NCC);
            busNCC.DSNCC(dGNCC);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dGNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGNCC.Rows.Count - 1)//dòng 0 đến dòng số dòng-1
            {
                txtMaNCC.Enabled = false;
                txtMaNCC.Text = dGNCC.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dGNCC.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = dGNCC.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dGNCC.Rows[e.RowIndex].Cells["SoDT"].Value.ToString();

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;

            busNCC.TimKiemDSNCC(dGNCC, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
            busNCC.DSNCC(dGNCC);
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
