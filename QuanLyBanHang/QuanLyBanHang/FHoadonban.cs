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
    public partial class FHoadonban : Form
    {
        BUS_HOADONBANHANG bushdBanHang;
        public FHoadonban()
        {
            InitializeComponent();
            bushdBanHang = new BUS_HOADONBANHANG();
        }

       
        private void FHoadonban_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            bushdBanHang.DSMAKH(maKH);
            bushdBanHang.DSMANV(cbboxmanv);
            //bushdBanHang.DSDONHANG(maKH.SelectedValue.ToString(), NgayBan.Value, cbbDH);
        }

        private void cbboxmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            NHANVIEN nv = cbboxmanv.SelectedItem as NHANVIEN;
            txtTenNV.Text = nv.TenNV;
        }

        private void maKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            KHACHHANG kh = maKH.SelectedItem as KHACHHANG;
            txtTenKH.Text = kh.TenKH;
            txtDiachi.Text = kh.Diachi;
            txtSDT.Text = kh.SoDT;
            bushdBanHang.DSDONHANG(kh.MaKH, NgayBan.Value, cbbDH);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //bushdBanHang.ThemCTHD(cbbDH.SelectedValue.ToString(), (int)nbSoluong.Value, dGHDBH);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "" && txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập Mã hóa đơn và kí hiệu hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (txtMaHD.Text== "")
            {
                MessageBox.Show("Nhập Mã hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập kí hiệu hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                if (cthds.Count != 0)
                {
                    HOADONBANHANG dh = new HOADONBANHANG()
                    {
                        MAHD = txtMaHD.Text,
                        KHHD = txtKHHD.Text,
                        MAKH = maKH.SelectedValue.ToString(),
                        MANV = cbboxmanv.SelectedValue.ToString(),
                        NGAYBAN = NgayBan.Value
                    };
                    List<HOADONBANHANG_DONHANG> hddhs = new List<HOADONBANHANG_DONHANG>();

                    foreach(var cthd in cthds)
                    {
                        int check = 0;
                        foreach(var hd in hddhs)
                        {
                            if(hd.MADH== cthd.MaDH)
                            {
                                check = 1;
                            }    
                        }
                        if(check==0)
                        {
                            HOADONBANHANG_DONHANG hddh = new HOADONBANHANG_DONHANG()
                            {
                                MAHD = txtMaHD.Text,
                                KHHD = txtKHHD.Text,
                                MADH = cthd.MaDH,
                                SOLUONG = bushdBanHang.TongSoluong(cthd.Soluong, cthd.MaDH)
                            };
                            hddhs.Add(hddh);
                        }    
                    }    
                    bushdBanHang.ThemHD(dh, hddhs);
                    MessageBox.Show("Bạn hóa đơn thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập chi tiết hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
            
        }
        List<CTHDDto> cthds = new List<CTHDDto>();
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            cthds= bushdBanHang.ThemCTHD(cbbDH.SelectedValue.ToString(), (int)nbSoluong.Value);

            dGHDBH.DataSource = cthds.Select(c=> new { c.MaSP, c.TenSP, c.Soluong, c.ThanhTien}).ToList();
            txtTongTien.Text = (cthds.Sum(c => c.ThanhTien)!=null? cthds.Sum(c => c.ThanhTien): 0).ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FSuaXoaHoaDonBan hd = new FSuaXoaHoaDonBan();
            this.Hide();
            hd.ShowDialog();
        }
    }
}
