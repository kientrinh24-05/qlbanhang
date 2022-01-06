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
    public partial class FSuaXoaHoaDonNhap : Form
    {
        BUS_HOADONNHAPHANG bushdNhapHang;
        public FSuaXoaHoaDonNhap()
        {
            InitializeComponent();
            bushdNhapHang = new BUS_HOADONNHAPHANG();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FSuaXoaHoaDonNhap_Load(object sender, EventArgs e)
        {
            bushdNhapHang.LayMaHoaDon(cbbMaHD);
        }

        private void cbbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahd = cbbMaHD.SelectedItem as string;
            bushdNhapHang.LayMaKHHD(mahd, cbbKHHD);
            var thongtin = bushdNhapHang.LayThongTin(mahd, cbbKHHD.SelectedValue.ToString());
            NgayBan.Value = thongtin.NgayBan;
            txtMaNV.Text = thongtin.MANV;
            txtTenNV.Text = thongtin.TenNV;
            txtMaNCC.Text = thongtin.MANCC.ToString();
            txtTenNCC.Text = thongtin.TenNCC;
            txtSDT.Text = thongtin.SDT;
            txtDiachi.Text = thongtin.DiaChi;
        }

        private void cbbKHHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kh = cbbKHHD.SelectedItem as string;
            var thongtin = bushdNhapHang.LayThongTin(cbbMaHD.SelectedValue.ToString(), kh);
            if (thongtin != null)
            {
                NgayBan.Value = thongtin.NgayBan;
                txtMaNV.Text = thongtin.MANV;
                txtTenNV.Text = thongtin.TenNV;
                txtMaNCC.Text = thongtin.MANCC.ToString();
                txtTenNCC.Text = thongtin.TenNCC;
                txtSDT.Text = thongtin.SDT;
                txtDiachi.Text = thongtin.DiaChi;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HOADONNHAPHANG hd = new HOADONNHAPHANG()
            {
                MAHD = cbbMaHD.SelectedValue.ToString(),
                KHHD = cbbKHHD.SelectedValue.ToString(),
                NGAYNHAP = NgayBan.Value,
            };

            var check = bushdNhapHang.SuaHoaDon(hd);
            if (check)
            {
                MessageBox.Show("Sửa thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            var check = bushdNhapHang.XoaDonHang(cbbMaHD.SelectedValue.ToString(), cbbKHHD.SelectedValue.ToString());
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
                FHoadonNhap hd = new FHoadonNhap();
                this.Hide();
                hd.ShowDialog();
            }
        }
    }
}
