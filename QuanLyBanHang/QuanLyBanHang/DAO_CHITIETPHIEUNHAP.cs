using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_CHITIETPHIEUNHAP
    {
        DataQuanLyBanHangDataContext db;
        public DAO_CHITIETPHIEUNHAP()
        {
            db = new DataQuanLyBanHangDataContext();
        }

        public dynamic LayDSSP()
        {
            var ds = db.SANPHAMs.Select(k => new { k.MaSP, k.TenSP });
            return ds;
        }

        public dynamic LayDSChiTietDonHangNhap(string maPn)
        {
            var ds = db.NHAPHANG_SANPHAMs.Where(s => s.MaPN== maPn)
                                     .Select(s => new
                                     {
                                         s.MaPN,
                                         s.MaSP,
                                         s.Soluong,
                                         s.dongia
                                     }
                                            ).ToList();
            

            return ds;
        }



        public void ThemCTPhieuNhap(NHAPHANG_SANPHAM CTPN)
        {

                db.NHAPHANG_SANPHAMs.InsertOnSubmit(CTPN);
                db.SubmitChanges();

        }

        public bool SuaCTPN(NHAPHANG_SANPHAM PN)
        {
            bool trangthai = false;
            try
            {
                var d = db.NHAPHANG_SANPHAMs.First(s => s.MaSP == PN.MaSP);
                trangthai = true;
                d.MaSP = PN.MaSP;
                d.Soluong = PN.Soluong;
                
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
