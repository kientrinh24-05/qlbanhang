using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_HOADONBANHANG
    {
        DAO_HOADONBANHANG hdBanHang;
        public BUS_HOADONBANHANG()
        {
            hdBanHang = new DAO_HOADONBANHANG();
        }

        public void DSMANV(ComboBox cb)
        {
            cb.DataSource = hdBanHang.LayDSMANV();
            cb.DisplayMember = "MaNV";
            cb.ValueMember = "MaNV";
        }

        public void DSMAKH(ComboBox cb)
        {
            cb.DataSource = hdBanHang.LayDSMAKH();
            cb.DisplayMember = "MaKH";
            cb.ValueMember = "MaKH";
        }
        public NHANVIEN DSNVTheoMa(string maNV)
        {
            return hdBanHang.LayDSNVTheoMa(maNV);
            
        }
        public KHACHHANG DSKHheoMa(string maKH)
        {
            return hdBanHang.LayDSKHTheoMa(maKH);
        }

        public void DSCTHOADON(string maHD, string KHHD, DataGridView gv)
        {
            gv.DataSource = hdBanHang.DSCTHOADON(maHD, KHHD);
            
        }
        public int TongTien(string maHD, string KHHD)
        {
            return hdBanHang.TongTien(maHD, KHHD);
        }
        public void DSDONHANG(string maKH, DateTime ngayBan, ComboBox cb)
        {
            //var a= hdBanHang.LayDSDONHANG(maKH, ngayBan)
            if (hdBanHang.LayDSDONHANG(maKH, ngayBan).Count != 0)
            {
                cb.DataSource = hdBanHang.LayDSDONHANG(maKH, ngayBan);
                // cb.DisplayMember = "MaDH";
                // cb.ValueMember = "MaDH";
            }
            else
            {
                cb.DataSource = null;
            }
        }

        public List<CTHDDto> ThemCTHD(string maHD, int soluong)
        {
            return hdBanHang.ThemCTHD(maHD, soluong);
        }

        public bool ThemHD(HOADONBANHANG hdbh, List<HOADONBANHANG_DONHANG> hdbh_dh)
        {
            return hdBanHang.ThemHD(hdbh, hdbh_dh);
        }

        public int TongSoluong(int? soluong, string MaHD)
        {
            return hdBanHang.TongSoluong(soluong, MaHD);
        }

        public void DSHOADONBANHANG(DataGridView gv)
        {
            gv.DataSource = hdBanHang.DSHOADONBAN();
        }

        public void LayMaHoaDon(ComboBox cb)
        {
            cb.DataSource= hdBanHang.LayMaHoaDon();
        }

        public void LayMaKHHD(string maHD, ComboBox cb)
        {
            cb.DataSource = hdBanHang.LayMaKHHD(maHD);
        }

        public TTHOADONDto LayThongTin(string maHD, string KHHD)
        {
            return hdBanHang.LayThongTin(maHD, KHHD);
        }

        public bool SuaHoaDon(HOADONBANHANG hd)
        {
            return hdBanHang.SuaHoaDon(hd);
        }

        public bool XoaDonHang(string MaHD, string KHHD)
        {
            return hdBanHang.XoaDonHang(MaHD, KHHD);
        }

    }
}
