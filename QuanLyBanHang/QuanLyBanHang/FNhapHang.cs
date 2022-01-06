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
    public partial class FNhapHang : Form
    {
        BUS_NHAPHANG busNhapHang;
        public FNhapHang()
        {
            InitializeComponent();
            busNhapHang = new BUS_NHAPHANG();
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            if (txtMaPN.Enabled == false)
            {
                txtMaPN.Enabled = true;
                txtMaPN.Text = "";
            }
            else
            {
                NHAPHANG NH = new NHAPHANG();
                NH.MaPN = txtMaPN.Text;
                NH.Nhanvien_FK = cbNhanVien.SelectedValue.ToString();
                NH.NCC_FK = cbNCC.SelectedValue.ToString();
                NH.NgayNhap = dtpNgayNhap.Value.ToString("MM/dd/yyyy");
                NH.status = true;
                busNhapHang.ThemDonNhap(NH);
                busNhapHang.DSDonNhap(dGNhapHang);
            }
        }

        private void FNhapHang_Load(object sender, EventArgs e)
        {
            busNhapHang.DSDonNhap(dGNhapHang);
            busNhapHang.DSNCC(cbNCC);
            busNhapHang.DSNV(cbNhanVien);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            NHAPHANG NH = new NHAPHANG();
            NH.MaPN = txtMaPN.Text;
            NH.Nhanvien_FK = cbNhanVien.SelectedValue.ToString();
            NH.NCC_FK = cbNCC.SelectedValue.ToString();
            NH.NgayNhap = dtpNgayNhap.Value.ToString("MM/dd/yyyy");
            busNhapHang.SuaDonNhap(NH);
            busNhapHang.DSDonNhap(dGNhapHang);
        }

        private void dGNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGNhapHang.Rows.Count - 1)
            {
                txtMaPN.Enabled = false;
                
                txtMaPN.Text = dGNhapHang.Rows[e.RowIndex].Cells["MaPN"].Value.ToString();
                cbNCC.SelectedValue = dGNhapHang.Rows[e.RowIndex].Cells["NCC_FK"].Value.ToString();
                cbNhanVien.SelectedValue = dGNhapHang.Rows[e.RowIndex].Cells["Nhanvien_FK"].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(dGNhapHang.Rows[e.RowIndex].Cells["NgayNhap"].Value.ToString());
                if (busNhapHang.KiemTraNgayPN(dGNhapHang.Rows[e.RowIndex].Cells["MaPN"].Value.ToString()))
                {
                    btSua.Enabled = true;
                    btXoa.Enabled = true;
                }
                else
                {
                    btSua.Enabled = false;
                    btXoa.Enabled = false;
                }


            }
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

            busNhapHang.TimKiemDSNCC(dGNhapHang, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
            busNhapHang.DSDonNhap(dGNhapHang);
          
        }

        private void btnThemCTDH_Click(object sender, EventArgs e)
        {
            if (busNhapHang.KiemTraCTPN(dGNhapHang.CurrentRow.Cells["MaPN"].Value.ToString()))
            { 
                FChiTietDonHangNhap f = new FChiTietDonHangNhap();
                f.maPN = txtMaPN.Text;
                f.ShowDialog();
            }

        }

        private void dGNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FChiTietDonHangNhap f = new FChiTietDonHangNhap();
            f.maPN = dGNhapHang.CurrentRow.Cells["MaPN"].Value.ToString();
            f.bien = 1;
            f.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            NHAPHANG NhapHang = new NHAPHANG();
            NhapHang.MaPN = txtMaPN.Text;
            busNhapHang.XoaPhieuNhap(NhapHang);
            busNhapHang.DSDonNhap(dGNhapHang);
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
            this.Hide();
            FSanPham f = new FSanPham();
            f.ShowDialog();
            this.Close();
        }
    }
}
