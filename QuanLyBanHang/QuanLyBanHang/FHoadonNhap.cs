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
    public partial class FHoadonNhap : Form
    {
        BUS_HOADONNHAPHANG bushdNhapHang;
        public FHoadonNhap()
        {
            InitializeComponent();
            bushdNhapHang = new BUS_HOADONNHAPHANG();
        }

        private void FHoadonNhap_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            bushdNhapHang.DSMANCC(maNCC);
            bushdNhapHang.DSMANV(cbboxmanv);
        }

        private void cbboxmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            NHANVIEN nv = cbboxmanv.SelectedItem as NHANVIEN;
            txtTenNV.Text = nv.TenNV;
        }

        private void maNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            NHACUNGCAP kh = maNCC.SelectedItem as NHACUNGCAP;
            txtTenNCC.Text = kh.TenNCC;
            txtDiachi.Text = kh.Diachi;
            txtSDT.Text = kh.SoDT;
            bushdNhapHang.DSNHAPHANG(kh.MaNCC, NgayBan.Value, cbbDH);
        }

        List<CTHDNHAPDto> cthds = new List<CTHDNHAPDto>();
        private void btnThem_Click(object sender, EventArgs e)
        {
            cthds = bushdNhapHang.ThemCTHD(cbbDH.SelectedValue.ToString(), (int)nbSoluong.Value);

            dGHDBH.DataSource = cthds.Select(c => new { c.MaSP, c.TenSP, c.Soluong, c.ThanhTien }).ToList();
            txtTongTien.Text = (cthds.Sum(c => c.ThanhTien) != null ? cthds.Sum(c => c.ThanhTien) : 0).ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "" && txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập Mã hóa đơn và kí hiệu hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtMaHD.Text == "")
            {
                MessageBox.Show("Nhập Mã hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtKHHD.Text == "")
            {
                MessageBox.Show("Nhập kí hiệu hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cthds.Count != 0)
                {
                    HOADONNHAPHANG dh = new HOADONNHAPHANG()
                    {
                        MAHD = txtMaHD.Text,
                        KHHD = txtKHHD.Text,
                        MANCC = maNCC.SelectedValue.ToString(),
                        MANV = cbboxmanv.SelectedValue.ToString(),
                        NGAYNHAP = NgayBan.Value
                    };
                    List<HOADONNHAPHANG_NHAPHANG> hddhs = new List<HOADONNHAPHANG_NHAPHANG>();

                    foreach (var cthd in cthds)
                    {
                        int check = 0;
                        foreach (var hd1 in hddhs)
                        {
                            if (hd1.MAPN == cthd.MaPN)
                            {
                                check = 1;
                            }
                        }
                        if (check == 0)
                        {
                            HOADONNHAPHANG_NHAPHANG hddh = new HOADONNHAPHANG_NHAPHANG()
                            {
                                MAHD = txtMaHD.Text,
                                KHHD = txtKHHD.Text,
                                MAPN = cthd.MaPN,
                                SOLUONG = bushdNhapHang.TongSoluong(cthd.Soluong, cthd.MaPN)
                            };
                            hddhs.Add(hddh);
                        }
                    }
                    bushdNhapHang.ThemHD(dh, hddhs);
                    MessageBox.Show("Bạn hóa đơn thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string url = "nhap";
                    FDanhSachHoaDon hd = new FDanhSachHoaDon(url);
                    this.Hide();
                    hd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập chi tiết hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FSuaXoaHoaDonNhap hd = new FSuaXoaHoaDonNhap();
            this.Hide();
            hd.ShowDialog();
        }
    }
}
