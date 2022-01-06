using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public class BUS_HOADONNHAPHANG
    {
        DAO_HOADONNHAPHANG hdNhapHang;
        public BUS_HOADONNHAPHANG()
        {
            hdNhapHang = new DAO_HOADONNHAPHANG();
        }

        public void DSMANV(ComboBox cb)
        {
            cb.DataSource = hdNhapHang.LayDSMANV();
            cb.DisplayMember = "MaNV";
            cb.ValueMember = "MaNV";
        }

        public void DSMANCC(ComboBox cb)
        {
            cb.DataSource = hdNhapHang.LayDSMANCC();
            cb.DisplayMember = "MaNCC";
            cb.ValueMember = "MaNCC";
        }
        public NHANVIEN DSNVTheoMa(string maNV)
        {
            return hdNhapHang.LayDSNVTheoMa(maNV);

        }
        public NHACUNGCAP DSKHheoMa(string maNCC)
        {
            return hdNhapHang.LayDSNCCTheoMa(maNCC);
        }

        public void DSNHAPHANG(string maNCC, DateTime ngayBan, ComboBox cb)
        {
            //var a= hdBanHang.LayDSDONHANG(maKH, ngayBan)
            if (hdNhapHang.LayDSNHAPHANG(maNCC, ngayBan).Count != 0)
            {
                cb.DataSource = hdNhapHang.LayDSNHAPHANG(maNCC, ngayBan);
                // cb.DisplayMember = "MaDH";
                // cb.ValueMember = "MaDH";
            }
            else
            {
                cb.DataSource = null;
            }
        }

        public List<CTHDNHAPDto> ThemCTHD(string maHD, int soluong)
        {
            return hdNhapHang.ThemCTHD(maHD, soluong);
        }

        public bool ThemHD(HOADONNHAPHANG hdbh, List<HOADONNHAPHANG_NHAPHANG> hdbh_dh)
        {
            return hdNhapHang.ThemHD(hdbh, hdbh_dh);
        }

        public int TongSoluong(int? soluong, string MaHD)
        {
            return hdNhapHang.TongSoluong(soluong, MaHD);
        }
        public void DSCTHOADON(string maHD, string KHHD, DataGridView gv)
        {
            gv.DataSource = hdNhapHang.DSCTHOADON(maHD, KHHD);

        }
        public int TongTien(string maHD, string KHHD)
        {
            return hdNhapHang.TongTien(maHD, KHHD);
        }
        public void DSHOADONNHAPHANG(DataGridView gv)
        {
            gv.DataSource = hdNhapHang.DSHOADONNHAP();
        }

        public void LayMaHoaDon(ComboBox cb)
        {
            cb.DataSource = hdNhapHang.LayMaHoaDon();
        }

        public void LayMaKHHD(string maHD, ComboBox cb)
        {
            cb.DataSource = hdNhapHang.LayMaKHHD(maHD);
        }

        public TTHOADONNHAPDto LayThongTin(string maHD, string KHHD)
        {
            return hdNhapHang.LayThongTin(maHD, KHHD);
        }

        public bool SuaHoaDon(HOADONNHAPHANG hd)
        {
            return hdNhapHang.SuaHoaDon(hd);
        }

        public bool XoaDonHang(string MaHD, string KHHD)
        {
            return hdNhapHang.XoaDonHang(MaHD, KHHD);
        }

    }
}
