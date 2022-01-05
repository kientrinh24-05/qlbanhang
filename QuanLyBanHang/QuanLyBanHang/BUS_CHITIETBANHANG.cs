using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_CHITIETBANHANG

    {
        DAO_CHITIETBANHANG daCT;
        public BUS_CHITIETBANHANG()
        {
            daCT = new DAO_CHITIETBANHANG();
        }

        public void DSSP(ComboBox cb)
        {
            cb.DataSource = daCT.LayDSSP();
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";

        }

        public void DSCTDH(DataGridView dg, string maDH)
        {
            var xx = daCT.LayDSChiTietDonHangBan(maDH);

            dg.DataSource = xx;
        }

        public bool ThemCTDH_DH(DataTable tbDonHang, string maDH)
        {
            bool trangthai = false;


            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (DataRow item in tbDonHang.Rows)
                    {
                        DONHANG_SANPHAM d1 = new DONHANG_SANPHAM();
                        d1.MaDH = maDH;
                        d1.MaSP = item["MaSP"].ToString();
                        d1.DonGia = int.Parse(item["DonGia"].ToString());
                        d1.SoLuong = int.Parse(item["SoLuong"].ToString());
                        d1.DVT= item["DVT"].ToString();

                        if (!daCT.ThemCTDonHang(d1))
                        {
                            throw new Exception("Không Đủ Tồn Kho Thực Tế");
                        }

                    }
                    trangthai = true;
                    tran.Complete();

                }
                catch (Exception ex)
                {

                    trangthai = false;
                    MessageBox.Show(ex.Message.ToString());
                    
                }

            }

            return trangthai;
        }

        public void SuaCTPN(DONHANG_SANPHAM DH)
        {
            if (!daCT.SuaCTDH(DH))
                MessageBox.Show("That bai");
        }


    }
}
