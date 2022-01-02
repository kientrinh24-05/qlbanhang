using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_NHANVIEN
    {
        DAO_NHANVIEN daNV;
        public BUS_NHANVIEN()
        {
            daNV = new DAO_NHANVIEN();
        }

        public void DSNhanVien(DataGridView dg)
        {
            dg.DataSource = daNV.LayDSNhanVien();
        }

        public void DSTrinhDo(ComboBox cb)
        {
            cb.DataSource = daNV.LayDSTrinhDo();
            cb.DisplayMember = "TENTRINHDO";
            cb.ValueMember = "MATRINHDO";
        }

        public void TimKiemDSNhanVien(DataGridView dg, String NhanVien)
        {
            dg.DataSource = daNV.TimKiemNhanVien(NhanVien);
        }

        public void ThemNV(NHANVIEN Nhanvien)
        {
            try
            {
                if (!daNV.ThemNV(Nhanvien))
                {
                    throw new Exception("Mã Nhân viên đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SuaNV(NHANVIEN Nhanvien)
        {

            if (!daNV.SuaNV(Nhanvien))
                MessageBox.Show("That bai");
        }

       

    }
}
