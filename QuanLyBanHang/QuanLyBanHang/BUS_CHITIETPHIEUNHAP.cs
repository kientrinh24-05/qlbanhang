using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace QuanLyBanHang
{
    
    class BUS_CHITIETPHIEUNHAP
    {
        DAO_CHITIETPHIEUNHAP daCT;
        public BUS_CHITIETPHIEUNHAP()
        {
            daCT = new DAO_CHITIETPHIEUNHAP();
        }
        public void DSSP(ComboBox cb)
        {
            cb.DataSource = daCT.LayDSSP();
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";
            
        }

        public void DSCTPN(DataGridView dg, string maPN)
        {
            var xx = daCT.LayDSChiTietDonHangNhap(maPN);

            dg.DataSource = xx;
        }

        public void ThemCTDH_DH(DataTable tbDonHang, string maPN)
        {
           
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (DataRow item in tbDonHang.Rows)// duyet tung dong 
                    {
                        NHAPHANG_SANPHAM d1 = new NHAPHANG_SANPHAM();
                        d1.MaPN = maPN;
                        d1.MaSP = item["MaSP"].ToString();
                        d1.dongia = int.Parse(item["DonGia"].ToString());
                        d1.Soluong = int.Parse(item["SoLuong"].ToString());                  
                        daCT.ThemCTPhieuNhap(d1);
                       
                    }
                    tran.Complete();
                    
                }
                catch (Exception ex)
                {

                   
                    MessageBox.Show(ex.Message.ToString());
                }
               
            }

        }

        public void SuaCTPN(NHAPHANG_SANPHAM PN)
        {

            if (!daCT.SuaCTPN(PN))
                MessageBox.Show("That bai");



        }



    }
}
