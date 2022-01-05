using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{

    class DAO_NHANVIEN
    {
        QLBHDataContext db;
        public DAO_NHANVIEN()
        {
            db = new QLBHDataContext();
        }
        public DataTable DSNV()//phải return vè dsNV
        {
            var dsNV = db.NHANVIENs.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MaNv"));
            dt.Columns.Add(new DataColumn("HoNv"));
            dt.Columns.Add(new DataColumn("TenNV"));
            dt.Columns.Add(new DataColumn("NgaySinh"));
            dt.Columns.Add(new DataColumn("dienthoai"));
            dt.Columns.Add(new DataColumn("CCCD"));
            dt.Columns.Add(new DataColumn("diachi"));
            dt.Columns.Add(new DataColumn("MaTrinhDo"));
            if (dsNV != null && dsNV.Count > 0)
            {
                foreach (var kh in dsNV)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = kh.MaNv;
                    dr[1] = kh.HoNv;
                    dr[2] = kh.TenNV;
                    dr[3] = kh.NgaySinh;
                    dr[4] = kh.dienthoai;
                    dr[5] = kh.CCCD;
                    dr[6] = kh.diachi;
                    dr[7] = kh.MaTrinhDo;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            return dt;
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
