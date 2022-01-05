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
    public partial class FChitietDonHangBan : Form
    {
        BUS_CHITIETBANHANG busCTBan;
        public string maDH;
        public int bien = 0;
        private string _productID;
        public FChitietDonHangBan()
        {
            InitializeComponent();
            busCTBan = new BUS_CHITIETBANHANG();
        }
        DataTable tbDonBanHang;
        private void FChitietDonHangBan_Load(object sender, EventArgs e)
        {
            tbDonBanHang = new DataTable();
            txtMaDH.Text = maDH.ToString();
            txtMaDH.Enabled = false;
            busCTBan.DSSP(cbSanPham);
            tbDonBanHang.Columns.Add("MaSP");
            tbDonBanHang.Columns.Add("TenSP");
            tbDonBanHang.Columns.Add("DVT");
            tbDonBanHang.Columns.Add("DonGia");
            tbDonBanHang.Columns.Add("SoLuong");
            tbDonBanHang.Columns.Add("ThanhTien");
           
            if (bien == 1)
            {
                busCTBan.DSCTDH(dGSP, maDH);
                groupBox2.Visible = false;
            }
            else
            {
                dGSP.DataSource = tbDonBanHang;
                dGSP.Columns[0].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[1].Width = (int)(dGSP.Width * 0.3);
                dGSP.Columns[2].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[3].Width = (int)(dGSP.Width * 0.2);
                dGSP.Columns[4].Width = (int)(dGSP.Width * 0.1);
                dGSP.Columns[5].Width = (int)(dGSP.Width * 0.1);
            }


        }

        private void btnTaoDonBan_Click(object sender, EventArgs e)
        {
            if (busCTBan.ThemCTDH_DH(tbDonBanHang, maDH))
            {
                FBanHang f = new FBanHang();

                f.ShowDialog();
                this.Close();
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

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (_productID == null)
            {
                MessageBox.Show("Vui lòng chọn vào dòng muốn sửa");
                return;
            }
            if (_productID.Length > 0)
            {
                for (int i = tbDonBanHang.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = tbDonBanHang.Rows[i];
                    string productID = Convert.ToString(dr["MaSP"]);
                    if (productID == _productID)
                    {
                        dr.Delete();
                    }

                }
                tbDonBanHang.AcceptChanges();

                //Thêm
                bool co = true;
                DataRow r = tbDonBanHang.NewRow();

                foreach (DataRow item in tbDonBanHang.Rows)
                {
                    if (cbSanPham.SelectedValue.ToString() == item["MaSp"].ToString())
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
                    r[0] = cbSanPham.SelectedValue.ToString();
                    r[1] = cbSanPham.Text;
                    r[2] = txtDVT.Text;
                    r[3] = txtDonGia.Text;
                    r[4] = numSoLuong.Value.ToString();
                    r[5] = a;


                    tbDonBanHang.Rows.Add(r);

                }
                //bind lại gridd
                dGSP.Refresh();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (_productID.Length > 0)
            {
                for (int i = tbDonBanHang.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = tbDonBanHang.Rows[i];
                    string productID = Convert.ToString(dr["MaSP"]);
                    if (productID == _productID)
                    {
                        dr.Delete();
                    }

                }
                tbDonBanHang.AcceptChanges();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            bool co = true;
            DataRow r = tbDonBanHang.NewRow();

            foreach (DataRow item in tbDonBanHang.Rows)
            {
                if (cbSanPham.SelectedValue.ToString() == item["MaSP"].ToString())
                {
                    item["SoLuong"] = int.Parse(item["SoLuong"].ToString()) + numSoLuong.Value;
                    item["thanhtien"] = int.Parse(item["SoLuong"].ToString()) * int.Parse(txtDonGia.Text);
                    //cap nhap lai he thong
                    co = false;
                    break;
                }
            }
            if (co)
            {
                decimal a = long.Parse(txtDonGia.Text) * numSoLuong.Value;
                r[0] = cbSanPham.SelectedValue.ToString();
                r[1] = cbSanPham.Text;
                r[2] = txtDVT.Text;
                r[3] = txtDonGia.Text;
                r[4] = numSoLuong.Value.ToString();
                r[5] = a;

                tbDonBanHang.Rows.Add(r);

            }
        }

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (cbSanPham.SelectedIndex <= -1)
            //    return;
            //BUS_SANPHAM bus = new BUS_SANPHAM();
            //string spSelected = cbSanPham.SelectedValue.ToString();
            //try
            //{
            //    SANPHAM sp = bus.GetByID(spSelected);
            //    txtDonGia.Text = sp.DONGIA_BAN.ToString();
            //    txtDVT.Text = sp.DVT.ToString();
            //}
            //catch
            //{

            //}
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGSP.Rows.Count - 1)
            {
                _productID = Convert.ToString(dGSP.Rows[e.RowIndex].Cells["MaSp"].Value);

                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                numSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                string producID = dGSP.Rows[e.RowIndex].Cells["MaSp"].Value.ToString();
                cbSanPham.SelectedValue = producID;
            }
        }
    }
}
