using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FChiTietDonHangNhap : Form
    {
        BUS_CHITIETPHIEUNHAP busCTNhap;
        public string maPN;
        bool co = false;
        public int bien = 0;
        private string _productID;
        public FChiTietDonHangNhap()
        {
            InitializeComponent();
            busCTNhap = new BUS_CHITIETPHIEUNHAP();
        }
        DataTable tbDonNhapHang;
        private void btThem_Click(object sender, EventArgs e)
        {
            
            bool co = true;
            DataRow r = tbDonNhapHang.NewRow();

            foreach (DataRow item in tbDonNhapHang.Rows)
            {
                if (cbTest.SelectedValue.ToString() == item["MaSP"].ToString())
                {
                    item["SoLuong"] = int.Parse(item["SoLuong"].ToString()) + numSoLuong.Value;
                    item["thanhtien"]= int.Parse(item["SoLuong"].ToString()) * int.Parse(txtDonGia.Text);
                    //cap nhap lai he thong
                    co = false;
                    break;
                }
            }
            if (co)
            {
                decimal a = int.Parse(txtDonGia.Text) * numSoLuong.Value;
                r[0] = cbTest.SelectedValue.ToString();
                r[1] = cbTest.Text;
                r[2] = txtDonGia.Text;
                r[3] = numSoLuong.Value.ToString();
                r[4] = a;

                tbDonNhapHang.Rows.Add(r);

            }
        }

        private void FChiTietDonHangNhap_Load(object sender, EventArgs e)
        {
            tbDonNhapHang = new DataTable();
            txtMaPN.Text = maPN.ToString();
            txtMaPN.Enabled = false;
            busCTNhap.DSSP(cbTest);
            tbDonNhapHang.Columns.Add("MaSP");
            tbDonNhapHang.Columns.Add("TenSP");
            tbDonNhapHang.Columns.Add("DonGia");
            tbDonNhapHang.Columns.Add("SoLuong");
            tbDonNhapHang.Columns.Add("ThanhTien");
            co = true;
            if (bien == 1)
            {
                busCTNhap.DSCTPN(dGSP, maPN);
                groupBox2.Visible = false;
            }
            else
            {
                dGSP.DataSource = tbDonNhapHang;
                dGSP.Columns[0].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[1].Width = (int)(dGSP.Width * 0.3);
                dGSP.Columns[2].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[3].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[4].Width = (int)(dGSP.Width * 0.1);
            }

           
        }

        private void btnTaoDonNhap_Click(object sender, EventArgs e)
        {
               
                
            
        }

        private void cbSP_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BUS_SANPHAM bus = new BUS_SANPHAM();
            //string spSelected = cbSP.SelectedValue.ToString() ;
            //SANPHAM sp = bus.GetByID(spSelected);
            //txtDonGia.Text = sp.DONGIA_BAN.ToString();
        }

      
        private void cbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTest.SelectedIndex <= -1)
                return;
            BUS_SANPHAM bus = new BUS_SANPHAM();
            string spSelected = cbTest.SelectedItem as string; 
            try
            {
                SANPHAM sp = bus.GetByID(spSelected);
                if(sp!=null)
                {
                    txtDonGia.Text = sp.DONGIA_NHAP.ToString();
                    txtDVT.Text = sp.DVT.ToString();
                }    
                
            }
            catch
            {

            }
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (_productID.Length>0)
            {
                for (int i = tbDonNhapHang.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = tbDonNhapHang.Rows[i];
                    string productID = Convert.ToString(dr["MaSP"]);
                    if (productID == _productID)
                    {
                        dr.Delete();
                    }

                }
                tbDonNhapHang.AcceptChanges();
            }
        }

    

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGSP.Rows.Count - 1)
            {
                _productID = Convert.ToString(dGSP.Rows[e.RowIndex].Cells["MaSp"].Value);

                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                numSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                string producID = dGSP.Rows[e.RowIndex].Cells["MaSp"].Value.ToString();
                cbTest.SelectedValue = producID;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (_productID.Length>0)
            {
                for (int i = tbDonNhapHang.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = tbDonNhapHang.Rows[i];
                    string productID = Convert.ToString(dr["MaSP"]);
                    if (productID == _productID)
                    {
                        dr.Delete();
                    }

                }
                tbDonNhapHang.AcceptChanges();

                //Thêm
                bool co = true;
                DataRow r = tbDonNhapHang.NewRow();

                foreach (DataRow item in tbDonNhapHang.Rows)
                {
                    if (cbTest.SelectedValue.ToString() == item["MaSp"].ToString())
                    {
                        item["SoLuong"] = int.Parse(item["SoLuong"].ToString()) + numSoLuong.Value;
                        item["thanhtien"] = int.Parse(item["SoLuong"].ToString()) * int.Parse(txtDonGia.Text);

                        co = false;
                        break;
                    }
                }
                if (co)
                {
                    decimal a = int.Parse(txtDonGia.Text) * numSoLuong.Value;
                    r[0] = cbTest.SelectedValue.ToString();
                    r[1] = cbTest.Text;
                    r[2] = txtDonGia.Text;
                    r[3] = numSoLuong.Value.ToString();
                    r[4] = a;


                    tbDonNhapHang.Rows.Add(r);

                }
                //bind lại gridd
                dGSP.Refresh();
            }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát khỏi giao diện này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTaoDonNhap_Click_1(object sender, EventArgs e)
        {
            busCTNhap.ThemCTDH_DH(tbDonNhapHang, maPN);
            FNhapHang f = new FNhapHang();

            f.ShowDialog();
            this.Close();
        }
    }
}
