using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_KHACHHANG
    {
        DAO_KHACHHANG daoKH;
        public BUS_KHACHHANG()
        {
            daoKH = new DAO_KHACHHANG();
        }

        public void DSKhachHang(DataGridView dg)
        {
            dg.DataSource = daoKH.LayDSKhachHang();
        }
        public void ThemKH(KHACHHANG KhachHang)
        {
            try
            {
                if (!daoKH.ThemKH(KhachHang))
                {
                    throw new Exception("Mã khách hàng đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaKH(KHACHHANG Khachhang)
        {

            if (!daoKH.SuaKH(Khachhang))
                MessageBox.Show("That bai");
        }

        public void TimKiemDSKhachHang(DataGridView dg, String KhachHang)
        {
            dg.DataSource = daoKH.TimKiemKhachHang(KhachHang);
        }

    }
}
