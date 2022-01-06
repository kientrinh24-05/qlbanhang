using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FDanhSachHoaDon : Form
    {
        BUS_HOADONBANHANG busbh;
        BUS_HOADONNHAPHANG busnh;
        string _url;
        public FDanhSachHoaDon(string url)
        {
            _url = url;
            busbh = new BUS_HOADONBANHANG();
            busnh = new BUS_HOADONNHAPHANG();
            InitializeComponent();
        }

        private void FDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            if(_url=="ban")
            {
                busbh.DSHOADONBANHANG(dGHDBH);
            }
            if (_url == "nhap")
            {
                busnh.DSHOADONNHAPHANG(dGHDBH);
            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if(_url=="ban")
            {
                FHoadonban import = new FHoadonban();
                this.Hide();
                import.ShowDialog();
            }
            if (_url == "nhap")
            {
                FHoadonNhap import = new FHoadonNhap();
                this.Hide();
                import.ShowDialog();
            }

        }
    }
}
