using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{

    class DAO_NHANVIEN
    {
        DataQuanLyBanHangDataContext db;
        public DAO_NHANVIEN()
        {
            db = new DataQuanLyBanHangDataContext();
        }

        public dynamic LayDSNhanVien()//phải return vè dsNV
        {
            dynamic dsNV = db.NHANVIENs.Select(s => new
            {
                s.MaNv,
                s.HoNv,
                s.TenNV,
                s.diachi,
                s.NgaySinh,
                s.dienthoai,
                s.CCCD,
                s.TRINHDO.TENTRINHDO,
                s.TRINHDO.MATRINHDO
            });
            return dsNV;
        }

        public dynamic LayDSTrinhDo()
        {
            var ds = db.TRINHDOs.Select(k => new { k.MATRINHDO, k.TENTRINHDO });
            return ds;
        }

        public bool ThemNV(NHANVIEN NhanVien)
        {
            bool trangthai = false;
            if(db.KiemTraMaNV(NhanVien.MaNv)==0)
            { 
                db.NHANVIENs.InsertOnSubmit(NhanVien);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaNV(NHANVIEN NhanVien)
        {
            bool trangthai = false;
            try
            {
                var d = db.NHANVIENs.First(s => s.MaNv == NhanVien.MaNv);
                trangthai = true;
                d.TenNV = NhanVien.TenNV;
                d.HoNv = NhanVien.HoNv;
                d.diachi = NhanVien.diachi;
                d.NgaySinh = NhanVien.NgaySinh;
                d.dienthoai = NhanVien.dienthoai;
                d.CCCD = NhanVien.CCCD;
                d.MaTrinhDo = NhanVien.MaTrinhDo;
                db.SubmitChanges();

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemNhanVien(String NhanVien)//phải return vè dsNV
        {
            dynamic dsNV = db.NHANVIENs.Where(s => s.HoNv.Contains(NhanVien) 
                                                || s.TenNV.Contains(NhanVien)
                                                || s.MaNv.Contains(NhanVien)
                                                || s.diachi.Contains(NhanVien)
                                                || s.NgaySinh.Contains(NhanVien)
                                                || s.dienthoai.Contains(NhanVien)
                                                || s.CCCD.Contains(NhanVien)
                                                || s.MaTrinhDo.Contains(NhanVien)
                                                || s.TRINHDO.TENTRINHDO.Contains(NhanVien)


                                                )
                                        .Select(s => new
                                        {
                                            s.MaNv,
                                            s.HoNv,
                                            s.TenNV,
                                            s.diachi,
                                            s.NgaySinh,
                                            s.dienthoai,
                                            s.CCCD,
                                            s.MaTrinhDo
                                            
                                        });

            return dsNV;
        }

    }
}
