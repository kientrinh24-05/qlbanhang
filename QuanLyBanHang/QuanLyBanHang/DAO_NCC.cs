using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_NCC
    {

        DataQuanLyBanHangDataContext db;
        public DAO_NCC()
        {
            db = new DataQuanLyBanHangDataContext();
        }
        public dynamic LayDSNCC()//phải return vè dsNV
        {
            dynamic dsNCC = db.NHACUNGCAPs.Select(s => new
            {
                s.MaNCC,
                s.TenNCC,
                s.Diachi,
                s.SoDT
            });
            return dsNCC;
        }
        public bool ThemNCC(NHACUNGCAP NCC)
        {
            bool trangthai = false;
            if (db.KiemTraMaNCC(NCC.MaNCC) == 0)
            {
                db.NHACUNGCAPs.InsertOnSubmit(NCC);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;
        }

        public bool SuaNCC(NHACUNGCAP NCC)
        {
            bool trangthai = false;
            try
            {
                var d = db.NHACUNGCAPs.First(s => s.MaNCC == NCC.MaNCC);
                trangthai = true;
                d.TenNCC = NCC.TenNCC;
                d.Diachi = NCC.Diachi;
                d.SoDT = NCC.SoDT;
                db.SubmitChanges();

            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

        public dynamic TimKiemNCC(String NCC)//phải return vè dsNV
        {
            dynamic dsNCC = db.NHACUNGCAPs.Where(s => s.MaNCC.Contains(NCC)
                                                || s.TenNCC.Contains(NCC)
                                                || s.Diachi.Contains(NCC)
                                                || s.SoDT.Contains(NCC)
                                                )
                                        .Select(s => new
                                        {
                                            s.MaNCC,
                                            s.TenNCC,
                                            s.Diachi,
                                            s.SoDT,


                                        });

            return dsNCC;
        }

    }
}
