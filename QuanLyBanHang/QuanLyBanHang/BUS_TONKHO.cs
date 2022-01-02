using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_TONKHO
    {
        DAO_TONKHO da;
        public BUS_TONKHO()
        {
            da = new DAO_TONKHO();
        }

        public void DSSP(ComboBox cb)
        {
            cb.DataSource = da.LayDSSP();
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";
        }
        public void BCTonKho(ref DataGridView dg, DateTime dFrom, DateTime dTo, string Item)
        {
            dg.DataSource = da.GetTonKho(dFrom, dTo, Item);
        }
    }
}