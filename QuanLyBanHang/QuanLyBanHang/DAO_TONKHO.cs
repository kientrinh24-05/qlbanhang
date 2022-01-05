using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBanHang
{
    class DAO_TONKHO
    {
        QLBHDataContext db;

        public DAO_TONKHO()
        {
            db = new QLBHDataContext();
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
