using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_NHAPHANG
    {
        DAO_NHAPHANG daNhapHang;
        public BUS_NHAPHANG()
        {
            daNhapHang = new DAO_NHAPHANG();
        }

        public void DSDonNhap(DataGridView dg)
        {
            dg.DataSource = daNhapHang.LayDSDonNhap();
        }

        public void DSNV(ComboBox cb)
        {
            cb.DataSource = daNhapHang.LayDSNV();
            cb.DisplayMember = "TenNv";
            cb.ValueMember = "MaNV";
        }

        public void DSNCC(ComboBox cb)
        {
            cb.DataSource = daNhapHang.LayDSNCC();
            cb.DisplayMember = "TenNCC";
            cb.ValueMember = "MaNCC";
        }

        public void ThemDonNhap(NHAPHANG NhapHang)
        {
            try
            {
                if (!daNhapHang.ThemDonNhap(NhapHang))
                {
                    throw new Exception("Mã phiếu nhập đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaDonNhap(NHAPHANG NhapHang)
        {

            if (!daNhapHang.SuaDonNhap(NhapHang))
                MessageBox.Show("That bai");
        }

        public void TimKiemDSNCC(DataGridView dg, String DonNhap)
        {
            dg.DataSource = daNhapHang.TimKiemDonNhap(DonNhap);
        }

        
             public bool KiemTraCTPN(string  mapn)
        {


            bool trangthai = true;
            if (daNhapHang.KiemTraCTPN(mapn))
            {
                MessageBox.Show("Mã phiếu nhập hàng này đã có chi tiết, không thể thêm !!!");
                trangthai = false;
            }

            return trangthai;


        }


        public bool KiemTraNgayPN(string mapn)
        {


            bool trangthai = true;
            if (daNhapHang.KiemTraNgayPN(mapn))
            {
                trangthai = false;
            }

            return trangthai;


        }

        public void XoaPhieuNhap(NHAPHANG NhapHang)
        {
            try
            {
                if (!daNhapHang.XoaPhieuNhap(NhapHang))
                {
                    throw new Exception("Mã phiếu nhập đã tồn tại chi tiết. Không thể xóa !!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
   
    }
}
