using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_NHAPHANG
    {
        QLBHDataContext db;
        public DAO_NHAPHANG()
        {
            db = new QLBHDataContext();
        }

        public dynamic LayDSDonNhap()
        {
            dynamic dsNhapHang = db.NHAPHANGs.Select(s => new
            {
                s.MaPN,
                s.NgayNhap,
                s.NCC_FK,
                s.Nhanvien_FK,
                TongTien = s.NHAPHANG_SANPHAMs.Select(a => a.dongia * a.Soluong).Sum()
            });
            return dsNhapHang;
        }

        public dynamic LayDSNV()
        {
            var ds = db.NHANVIENs.Select(k => new { k.MaNv, k.TenNV });
            return ds;
        }

        public dynamic LayDSNCC()
        {
            var ds = db.NHACUNGCAPs.Select(k => new { k.MaNCC, k.TenNCC });
            return ds;
        }

        public bool ThemDonNhap(NHAPHANG NhapHang)
        {

            bool trangthai = false;
            if (db.KiemTraMaPN(NhapHang.MaPN) == 0)
            {
                db.NHAPHANGs.InsertOnSubmit(NhapHang);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaDonNhap(NHAPHANG NhapHang)
        {
            bool trangthai = false;
            try
            {
                var d = db.NHAPHANGs.First(s => s.MaPN == NhapHang.MaPN);
                trangthai = true;
                d.NgayNhap = NhapHang.NgayNhap;
                d.Nhanvien_FK = NhapHang.Nhanvien_FK;
                d.NCC_FK = NhapHang.NCC_FK;
                db.SubmitChanges();


            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemDonNhap(String DonNhap)
        {
            dynamic dsNCC = db.NHAPHANGs.Where(s => s.MaPN.Contains(DonNhap)
                                                || s.Nhanvien_FK.Contains(DonNhap)
                                                || s.NCC_FK.Contains(DonNhap)
                                                || s.NgayNhap.Contains(DonNhap)
                                                )
                                        .Select(s => new
                                        {
                                            s.MaPN,
                                            s.Nhanvien_FK,
                                            s.NHANVIEN.TenNV,
                                            s.NCC_FK,
                                            s.NHACUNGCAP.TenNCC,
                                            s.NgayNhap


                                        });

            return dsNCC;
        }

        public bool KiemTraCTPN(string maPN)
        {
            bool trangthai = false;
            try
            {

                var ds = db.NHAPHANG_SANPHAMs.First(s => s.MaPN == maPN);
                trangthai = true;

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }


        public bool KiemTraNgayPN(string maPN)
        {
            bool trangthai = false;
            try
            {

                var ds = db.NHAPHANG_SANPHAMs.First(s => s.MaPN == maPN);
                trangthai = true;

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }




        public bool XoaPhieuNhap(NHAPHANG NhapHang)
        {

            bool trangthai = false;
            if (db.KiemTraXoaPN(NhapHang.MaPN) == 0)
            {
                var deleteItem = db.NHAPHANGs.FirstOrDefault(x => x.MaPN == NhapHang.MaPN);
                db.NHAPHANGs.DeleteOnSubmit(deleteItem);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

    }
}
