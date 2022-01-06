using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FSuaXoaHoaDonBan : Form
    {
        BUS_HOADONBANHANG bushdBanHang;
        public FSuaXoaHoaDonBan()
        {
            InitializeComponent();
            bushdBanHang = new BUS_HOADONBANHANG();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FSuaXoaHoaDonBan_Load(object sender, EventArgs e)
        {
            bushdBanHang.LayMaHoaDon(cbbMaHD);
            //bushdBanHang.LayMaKHHD(cbbKHHD);
        }

        private void cbbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahd = cbbMaHD.SelectedItem as string;
            bushdBanHang.LayMaKHHD(mahd, cbbKHHD);
            var thongtin = bushdBanHang.LayThongTin(mahd, cbbKHHD.SelectedValue.ToString());
            NgayBan.Value = thongtin.NgayBan;
            txtMaNV.Text = thongtin.MANV;
            txtTenNV.Text = thongtin.TenNV;
            txtMaKH.Text = thongtin.MAKH.ToString();
            txtTenKH.Text = thongtin.TenKH;
            txtSDT.Text = thongtin.SDT;
            txtDiachi.Text = thongtin.DiaChi;
            bushdBanHang.DSCTHOADON(mahd, cbbKHHD.SelectedValue.ToString(), dGHDBH);
            txtTongTien.Text = bushdBanHang.TongTien(mahd, cbbKHHD.SelectedValue.ToString()).ToString();
        }

        private void cbbKHHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kh = cbbKHHD.SelectedItem as string;  
            var thongtin = bushdBanHang.LayThongTin(cbbMaHD.SelectedValue.ToString(), kh);
            if(thongtin!=null)
            {
                NgayBan.Value = thongtin.NgayBan;
                txtMaNV.Text = thongtin.MANV;
                txtTenNV.Text = thongtin.TenNV;
                txtMaKH.Text = thongtin.MAKH.ToString();
                txtTenKH.Text = thongtin.TenKH;
                txtSDT.Text = thongtin.SDT;
                txtDiachi.Text = thongtin.DiaChi;
                bushdBanHang.DSCTHOADON(cbbMaHD.SelectedValue.ToString(), kh, dGHDBH);
                txtTongTien.Text = bushdBanHang.TongTien(cbbMaHD.SelectedValue.ToString(), kh).ToString();
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HOADONBANHANG hd = new HOADONBANHANG()
            {
                MAHD = cbbMaHD.SelectedValue.ToString(),
                KHHD = cbbKHHD.SelectedValue.ToString(),
                NGAYBAN = NgayBan.Value,
            };
            
            var check=  bushdBanHang.SuaHoaDon(hd);
            if(check)
            {
                MessageBox.Show("Sửa thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else
            //{
            //    MessageBox.Show("Sửa không thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}   
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            var check = bushdBanHang.XoaDonHang(cbbMaHD.SelectedValue.ToString(), cbbKHHD.SelectedValue.ToString());
            if (check)
            {
                MessageBox.Show("Xóa thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                FHoadonban hd = new FHoadonban();
                this.Hide();
                hd.ShowDialog();
            }
        }
    }
}
