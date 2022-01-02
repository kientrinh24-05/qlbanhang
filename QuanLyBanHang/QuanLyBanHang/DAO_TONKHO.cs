using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_TONKHO
    {
        DataQuanLyBanHangDataContext db;

        public DAO_TONKHO()
        {
            db = new DataQuanLyBanHangDataContext();
        }

        public dynamic GetTonKho(DateTime dFrom, DateTime dTo, string Item)
        {
            var ds = db.TonKho(dFrom, dTo, Item);
            return ds;
        }

        public dynamic LayDSSP()
        {
            var ds = db.SANPHAMs.Select(k => new { k.MaSP, k.TenSP });
            return ds;
        }
    }
}
