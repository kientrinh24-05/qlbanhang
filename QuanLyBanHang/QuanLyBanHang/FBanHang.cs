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
    public partial class FBanHang : Form
    {
        BUS_BANHANG busBanHang;
        public FBanHang()
        {
            InitializeComponent();
            busBanHang = new BUS_BANHANG();
        }

        private void FBanHang_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            busBanHang.DSDonHang(dGBanHang);
            busBanHang.DSKH(cbKH);
            busBanHang.DSNV(cbNhanVien);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Enabled == false)
            {
                txtMaDH.Enabled = true;
                txtMaDH.Text = "";
                txtTongTien.Text = "0";
            }
            else
            {
                DONHANG NH = new DONHANG();
                NH.MaDH = txtMaDH.Text;
                NH.NHANVIEN_FK = cbNhanVien.SelectedValue.ToString();
                NH.KHACHHANG_FK = cbKH.SelectedValue.ToString();
                NH.NgayBan = dtpNgayBan.Value.ToString("MM/dd/yyyy");
                NH.status = true;
                busBanHang.ThemDonHang(NH);
                busBanHang.DSDonHang(dGBanHang);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DONHANG NH = new DONHANG();
            NH.MaDH = txtMaDH.Text;
            NH.NHANVIEN_FK = cbNhanVien.SelectedValue.ToString();
            NH.KHACHHANG_FK = cbKH.SelectedValue.ToString();
            NH.NgayBan = dtpNgayBan.Value.ToString("MM/dd/yyyy");
            busBanHang.SuaDonHang(NH);
            busBanHang.DSDonHang(dGBanHang);
        }

        private void dGBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGBanHang.Rows.Count - 1)
            {
                txtMaDH.Enabled = false;
                txtTongTien.Enabled = false;
                txtMaDH.Text = dGBanHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString();
                cbKH.SelectedValue = dGBanHang.Rows[e.RowIndex].Cells["KhachHang_fk"].Value.ToString();
                cbNhanVien.SelectedValue = dGBanHang.Rows[e.RowIndex].Cells["Nhanvien_FK"].Value.ToString();
                dtpNgayBan.Value = Convert.ToDateTime(dGBanHang.Rows[e.RowIndex].Cells["NgayBan"].Value.ToString());
                txtTongTien.Text= dGBanHang.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();


                if (busBanHang.KiemTraNgayCTDH(dGBanHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString()))
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

            busBanHang.TimKiemDSNCC(dGBanHang, timkiem);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
            busBanHang.DSDonHang(dGBanHang);
        }

        private void btnThemCTDH_Click(object sender, EventArgs e)
        {
            if (busBanHang.KiemTraCTDH(dGBanHang.CurrentRow.Cells["MaDH"].Value.ToString()))
            {
                FChitietDonHangBan f = new FChitietDonHangBan();
                f.maDH = txtMaDH.Text;
                f.ShowDialog();
          
            }
        }

        private void dGBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FChitietDonHangBan f = new FChitietDonHangBan();
            f.maDH = dGBanHang.CurrentRow.Cells["MaDH"].Value.ToString();
            f.bien = 1;
            f.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DONHANG DonHang = new DONHANG();
            DonHang.MaDH = txtMaDH.Text;
            busBanHang.XoaDonHang(DonHang);
            busBanHang.DSDonHang(dGBanHang);
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
