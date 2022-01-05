using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_CHITIETBANHANG
    {
        QLBHDataContext db;

        public DAO_CHITIETBANHANG()
        {
            db = new QLBHDataContext();

        }

        public dynamic LayDSSP()
        {
            var ds = db.SANPHAMs.Select(k => new { k.MaSP, k.TenSP });
            return ds;
        }

        public dynamic LayDSChiTietDonHangBan(string maDH)
        {
            var ds = db.DONHANG_SANPHAMs.Where(s => s.MaDH == maDH)
                                     .Select(s => new
                                     {
                                         s.MaDH,
                                         s.MaSP,
                                         s.SoLuong,
                                         s.DonGia,
                                         s.DVT
                                     }
                                            ).ToList();
            return ds;
        }

        public bool ThemCTDonHang(DONHANG_SANPHAM CTDH)
        {

           


            bool trangthai = false;
            if (db.KiemTraTonKho(CTDH.MaSP) != 0)
            {
                db.DONHANG_SANPHAMs.InsertOnSubmit(CTDH);
                db.SubmitChanges();
                trangthai = true;
            }

            return trangthai;

        }

        public bool SuaCTDH(DONHANG_SANPHAM CTDH)
        {
            bool trangthai = false;
            try
            {
                var d = db.DONHANG_SANPHAMs.First(s => s.MaSP == CTDH.MaSP);
                trangthai = true;
                d.MaSP = CTDH.MaSP;
                d.SoLuong = CTDH.SoLuong;

                db.SubmitChanges();


            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;

        }

    }
}
