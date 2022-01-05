using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_BANHANG
    {
        QLBHDataContext db;
        public DAO_BANHANG()
        {
            db = new QLBHDataContext();

        }

        public dynamic LayDSDonHang()
        {
            dynamic dsDonHang = db.DONHANGs.Select(s => new
            {
                s.MaDH,
                s.NgayBan,
                s.KHACHHANG_FK,
                s.NHANVIEN_FK,
                TongTien = s.DONHANG_SANPHAMs.Any()? s.DONHANG_SANPHAMs.Select(a => a.DonGia * a.SoLuong).Sum():0
            });
            return dsDonHang;
        }

        public dynamic LayDSNV()
        {
            var ds = db.NHANVIENs.Select(k => new { k.MaNv, k.TenNV });
            return ds;
        }

        public dynamic LayDSKH()
        {
            var ds = db.KHACHHANGs.Select(k => new { k.MaKH, k.TenKH });
            return ds;
        }

        public bool ThemDonHang(DONHANG DonHang)
        {

            bool trangthai = false;
            if (db.KiemTraMaDH(DonHang.MaDH) == 0)
            {
                db.DONHANGs.InsertOnSubmit(DonHang);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaDonHang(DONHANG DonHang)
        {
            bool trangthai = false;
            try
            {
                var d = db.DONHANGs.First(s => s.MaDH == DonHang.MaDH);
                trangthai = true;
                d.NgayBan = DonHang.NgayBan;
                d.NHANVIEN_FK = DonHang.NHANVIEN_FK;
                d.KHACHHANG_FK = DonHang.KHACHHANG_FK;
                db.SubmitChanges();


            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemDonHang(String DonHang)
        {
            dynamic dsNCC = db.DONHANGs.Where(s => s.MaDH.Contains(DonHang)
                                                || s.NHANVIEN_FK.Contains(DonHang)
                                                || s.KHACHHANG_FK.Contains(DonHang)
                                                || s.NgayBan.Contains(DonHang)
                                                )
                                        .Select(s => new
                                        {
                                            s.MaDH,
                                            s.NHANVIEN_FK,                                           
                                            s.NHANVIEN.TenNV,
                                            s.KHACHHANG_FK,
                                            s.KHACHHANG.TenKH,
                                            s.NgayBan


                                        });

            return dsNCC;
        }

        public bool KiemTraCTDH(string maDH)
        {
            bool trangthai = false;
            try
            {

                var ds = db.DONHANG_SANPHAMs.First(s => s.MaDH == maDH);
                trangthai = true;

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public bool KiemTraNgayCTDH(string maDH)
        {
            bool trangthai = false;
            try
            {

                var ds = db.DONHANG_SANPHAMs.First(s => s.MaDH == maDH);
                trangthai = true;

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public bool XoaDonHang(DONHANG DonHang)
        {

            bool trangthai = false;
            if (db.KiemTraXoaDH(DonHang.MaDH) == 0)
            {
                var deleteItem = db.DONHANGs.FirstOrDefault(x => x.MaDH == DonHang.MaDH);
                db.DONHANGs.DeleteOnSubmit(deleteItem);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }


    }
}
