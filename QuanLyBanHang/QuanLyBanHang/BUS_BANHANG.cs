using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_BANHANG
    {
        DAO_BANHANG daBanHang;
        public BUS_BANHANG()
        {
            daBanHang = new DAO_BANHANG();
        }

        public void DSDonHang(DataGridView dg)
        {
            dg.DataSource = daBanHang.LayDSDonHang();
        }

        public void DSNV(ComboBox cb)
        {
            cb.DataSource = daBanHang.LayDSNV();
            cb.DisplayMember = "TenNv";
            cb.ValueMember = "MaNV";
        }

        public void DSKH(ComboBox cb)
        {
            cb.DataSource = daBanHang.LayDSKH();
            cb.DisplayMember = "TenKH";
            cb.ValueMember = "MaKH";
        }

        public void ThemDonHang(DONHANG DonHang)
        {
            try
            {
                if (!daBanHang.ThemDonHang(DonHang))
                {
                    throw new Exception("Mã đơn hàng đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaDonHang(DONHANG DonHang)
        {

            if (!daBanHang.SuaDonHang(DonHang))
                MessageBox.Show("That bai");
        }

        public void TimKiemDSNCC(DataGridView dg, String DonHang)
        {
            dg.DataSource = daBanHang.TimKiemDonHang(DonHang);
        }

        public bool KiemTraCTDH(string maDH)
        {


            bool trangthai = true;

            if (daBanHang.KiemTraCTDH(maDH))
            {
                MessageBox.Show("Mã đơn hàng hàng này đã có chi tiết, không thể thêm !!!");
                trangthai = false;
            }

            return trangthai;


        }

        public bool KiemTraNgayCTDH(string mapn)
        {


            bool trangthai = true;
            if (daBanHang.KiemTraNgayCTDH(mapn))
            {
                trangthai = false;
            }

            return trangthai;


        }

        public void XoaDonHang(DONHANG DonHang)
        {
            try
            {
                if (!daBanHang.XoaDonHang(DonHang))
                {
                    throw new Exception("Mã đơn hàng đã tồn tại chi tiết. Không thể xóa !!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
