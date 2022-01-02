using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_NCC
    {
        DAO_NCC daNCC;
        public BUS_NCC()
        {
            daNCC = new DAO_NCC();
        }

        public void DSNCC(DataGridView dg)
        {
            dg.DataSource = daNCC.LayDSNCC();
        }
        public void ThemNCC(NHACUNGCAP NCC)
        {
            try
            {
                if (!daNCC.ThemNCC(NCC))
                {
                    throw new Exception("Mã nhà cung cấp đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaNCC(NHACUNGCAP NCC)
        {

            if (!daNCC.SuaNCC(NCC))
                MessageBox.Show("That bai");
        }

        public void TimKiemDSNCC(DataGridView dg, String NCC)
        {
            dg.DataSource = daNCC.TimKiemNCC(NCC);
        }
    }
}
