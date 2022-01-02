using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_SANPHAM
    {
        DataQuanLyBanHangDataContext db;
       public DAO_SANPHAM()
        {
            db = new DataQuanLyBanHangDataContext();
        }

        public dynamic DSSanPham()
        {
            var ds = db.SANPHAMs.Select(s => new
            {
                s.MaSP,
                s.TenSP,
                s.DONVITINH.TenDVT,
                s.DONGIA_NHAP,
                s.DONGIA_BAN


            }

            );
            return ds;
        }

        public SANPHAM GetByID(string ID)
        {
            return db.SANPHAMs.FirstOrDefault(x => x.MaSP == ID);
        }

        public dynamic LayDSDVT()
        {
            var ds = db.DONVITINHs.Select(k => new { k.MaDVT, k.TenDVT });
            return ds;
        }

        public bool ThemSanPham(SANPHAM Product)
        {
            bool trangthai = false;
            if (db.KiemTraMaSP(Product.MaSP) == 0)
            {
                db.SANPHAMs.InsertOnSubmit(Product);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaSanPham(SANPHAM Product)
        {
            bool trangthai = false;
            try
            {
                var d = db.SANPHAMs.First(s => s.MaSP == Product.MaSP);
                trangthai = true;
                d.TenSP = Product.TenSP;
                d.DVT = Product.DVT;
                d.DONGIA_BAN = Product.DONGIA_BAN;
                d.DONGIA_NHAP = Product.DONGIA_NHAP;
                db.SubmitChanges();


            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemSanPham(String MaSP)//phải return vè dsNV
        {
            dynamic dsSP = db.SANPHAMs.Where(s => s.MaSP.Contains(MaSP)
                                                || s.TenSP.Contains(MaSP)
                                                || s.DONVITINH.TenDVT.Contains(MaSP)
                                                || s.DVT.Contains(MaSP)
                                              

                                                )
                                        .Select(s => new
                                        {
                                            s.MaSP,
                                            s.TenSP,
                                            s.DONVITINH.TenDVT,
                                            s.DONGIA_NHAP,
                                            s.DONGIA_BAN
                                       


                                        });

            return dsSP;
        }

    }
}
