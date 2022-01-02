using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_KHACHHANG
    {
        DataQuanLyBanHangDataContext db;
        public DAO_KHACHHANG()
        {
            db = new DataQuanLyBanHangDataContext();
        }

        public DataTable DSKhachHang()//phải return vè dsNV
        {
            var dsKH = db.KHACHHANGs.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MaKH"));
            dt.Columns.Add(new DataColumn("TenKH"));
            dt.Columns.Add(new DataColumn("Diachi"));
            dt.Columns.Add(new DataColumn("SoDT"));
            if (dsKH != null && dsKH.Count > 0)
            {
                foreach (var kh in dsKH)
                {
                    DataRow dr = dt.NewRow(); 
                    dr[0] = kh.MaKH;
                    dr[1] = kh.TenKH;
                    dr[2] = kh.Diachi;
                    dr[3] = kh.SoDT;
                    dt.Rows.Add(dr);
                }
                return dt;  
            }
            return dt;
        }

        public dynamic LayDSKhachHang()//phải return vè dsNV
        {
            dynamic dsKH = db.KHACHHANGs.Select(s => new
            {
                s.MaKH,
                s.TenKH,
                s.Diachi,
                s.SoDT
            });
            return dsKH;
        }
        public bool ThemKH(KHACHHANG Khachhang)
        {
            bool trangthai = false;
            if (db.KiemTraMaKH(Khachhang.MaKH) == 0)
            {
                db.KHACHHANGs.InsertOnSubmit(Khachhang);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaKH(KHACHHANG Khachhang)
        {
            bool trangthai = false;
            try
            {
                var d = db.KHACHHANGs.First(s => s.MaKH == Khachhang.MaKH);
                trangthai = true;
                d.TenKH = Khachhang.TenKH;
                d.Diachi = Khachhang.Diachi;
                d.SoDT = Khachhang.SoDT;
                db.SubmitChanges();

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemKhachHang(String Khachhang)//phải return vè dsNV
        {
            dynamic dsKH = db.KHACHHANGs.Where(s => s.MaKH.Contains(Khachhang)
                                                || s.TenKH.Contains(Khachhang)
                                                || s.Diachi.Contains(Khachhang)
                                                || s.SoDT.Contains(Khachhang)
                                                )
                                        .Select(s => new
                                        {
                                            s.MaKH,
                                            s.TenKH,
                                            s.Diachi,
                                            s.SoDT,
                                           

                                        });

            return dsKH;
        }

    }
}
