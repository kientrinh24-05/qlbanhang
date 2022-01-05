using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_SANPHAM
    {
        DAO_SANPHAM daSP;
        public BUS_SANPHAM()
        {
            daSP = new DAO_SANPHAM();

        }

        public DataTable DSSP()
        {
            return daSP.DSSP();
        }
        public void DSSanPham(DataGridView dg)
        {
            dg.DataSource = daSP.DSSanPham();
        }
        public dynamic DSSanPham()
        {
            return daSP.DSSanPham();
        }
        public SANPHAM GetByID(string ID)
        {
            return daSP.GetByID(ID);
        }
        public void DSDVT(ComboBox cb)
        {
            cb.DataSource = daSP.LayDSDVT();
            cb.DisplayMember = "TenDVT";
            cb.ValueMember = "MaDVT";
        }

        public void ThemSanPham(SANPHAM SanPham)
        {
            try
            {
                if (!daSP.ThemSanPham(SanPham))
                {
                    throw new Exception("Mã sản phẩm đã tồn tại!!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaSanPham(SANPHAM SanPham)
        {

            if (!daSP.SuaSanPham(SanPham))
                MessageBox.Show("That bai");



        }

        public void TimKiemSanPham(DataGridView dg, String SanPham)
        {
            dg.DataSource = daSP.TimKiemSanPham(SanPham);
        }

        public string MaTrinhDo(string trinhdo)
        {
            return daSP.MaTrinhDo(trinhdo);
        }

    }
}
