using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FImport : Form
    {
        BUS_KHACHHANG busKH;
        BUS_NCC busNCC;
        BUS_NHANVIEN busNV;
        BUS_SANPHAM busSP;
        string _url;
        public FImport(string url)
        {
            InitializeComponent();
            _url = url;
            busKH = new BUS_KHACHHANG();
            busNCC = new BUS_NCC();
            busNV = new BUS_NHANVIEN();
            busSP = new BUS_SANPHAM();
        }
        string str;
        DataTableCollection dataTableCollection;
        DataTable dt;
        private void Browse_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                            {
                                txtFilePath.Text = stream.Name;
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                    });
                                    dataTableCollection = result.Tables;

                                    foreach (DataTable b in dataTableCollection)
                                    {
                                        str = b.TableName;
                                    }
                                }
                            }
                            dt = dataTableCollection[str];
                            Browse.Hide();
                            Save.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }    
            }
           
            
        }

        private void FImport_Load(object sender, EventArgs e)
        {
            Save.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(_url=="khachhang")
            {
                ImportKhachhang();
            }

            if (_url == "nhacungcap")
            {
                ImportNCC();
            }

            if (_url == "nhanvien")
            {
                ImportNhanVien();
            }

            if (_url == "sanpham")
            {
                ImportSanPham();
            }
        }

        public void ImportKhachhang()
        {
            int check = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < busKH.DSKhachHang().Rows.Count; j++)
                {

                    if (busKH.DSKhachHang().Rows[j]["MaKH"].ToString() == dt.Rows[i]["MaKH"].ToString())
                    {
                        check = 1;
                    }
                }
            }
            if (check == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    KHACHHANG KhachHang = new KHACHHANG();
                    KhachHang.MaKH = dt.Rows[i]["MaKH"].ToString();
                    KhachHang.TenKH = dt.Rows[i]["TenKH"].ToString();
                    KhachHang.Diachi = dt.Rows[i]["Diachi"].ToString();
                    KhachHang.SoDT = dt.Rows[i]["SoDT"].ToString();
                    busKH.ThemKH(KhachHang);
                }
                MessageBox.Show("Import thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FKhachHang kh = new FKhachHang();
                this.Hide();
                kh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã khách hàng bị trùng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FKhachHang kh = new FKhachHang();
                this.Hide();
                kh.ShowDialog();
            }
        }

        public void ImportNCC()
        {
            int check = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < busNCC.DSNCC().Rows.Count; j++)
                {

                    if (busNCC.DSNCC().Rows[j]["MaNCC"].ToString() == dt.Rows[i]["MaNCC"].ToString())
                    {
                        check = 1;
                    }
                }
            }
            if (check == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    NHACUNGCAP nccap = new NHACUNGCAP();
                    nccap.MaNCC = dt.Rows[i]["MaNCC"].ToString();
                    nccap.TenNCC = dt.Rows[i]["TenNCC"].ToString();
                    nccap.Diachi = dt.Rows[i]["Diachi"].ToString();
                    nccap.SoDT = dt.Rows[i]["SoDT"].ToString();
                    busNCC.ThemNCC(nccap);
                }
                MessageBox.Show("Import thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FNhaCungCap ncc = new FNhaCungCap();
                this.Hide();
                ncc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp bị trùng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FNhaCungCap ncc = new FNhaCungCap();
                this.Hide();
                ncc.ShowDialog();
            }
        }

        public void ImportNhanVien()
        {
            int check = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < busNV.DSNV().Rows.Count; j++)
                {

                    if (busNV.DSNV().Rows[j]["MaNv"].ToString() == dt.Rows[i]["MaNv"].ToString())
                    {
                        check = 1;
                    }
                }
            }
            if (check == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    NHANVIEN NhanVien = new NHANVIEN();
                    NhanVien.MaNv = dt.Rows[i]["MaNv"].ToString();
                    NhanVien.HoNv = dt.Rows[i]["HoNv"].ToString();
                    NhanVien.TenNV = dt.Rows[i]["TenNV"].ToString();
                    NhanVien.NgaySinh = dt.Rows[i]["NgaySinh"].ToString();
                    NhanVien.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    NhanVien.CCCD = dt.Rows[i]["CCCD"].ToString();
                    NhanVien.diachi = dt.Rows[i]["diachi"].ToString();
                    NhanVien.MaTrinhDo = dt.Rows[i]["MaTrinhDo"].ToString();
                    busNV.ThemNV(NhanVien);
                }
                MessageBox.Show("Import thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FNhanVien nv = new FNhanVien();
                this.Hide();
                nv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã nhân viên bị trùng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FNhanVien nv = new FNhanVien();
                this.Hide();
                nv.ShowDialog();
            }
        }

        public void ImportSanPham()
        {
            int check = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < busSP.DSSP().Rows.Count; j++)
                {

                    if (busSP.DSSP().Rows[j]["MaSP"].ToString() == dt.Rows[i]["MaSP"].ToString())
                    {
                        check = 1;
                    }
                }
            }
            if (check == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SANPHAM SanPham = new SANPHAM();
                    SanPham.MaSP = dt.Rows[i]["MaSP"].ToString();
                    SanPham.TenSP = dt.Rows[i]["TenSP"].ToString();
                    SanPham.DVT = dt.Rows[i]["DVT"].ToString();
                    SanPham.DONGIA_NHAP = Convert.ToInt32(dt.Rows[i]["DONGIA_NHAP"]);
                    SanPham.DONGIA_BAN = Convert.ToInt32(dt.Rows[i]["DONGIA_BAN"]);
                    busSP.ThemSanPham(SanPham);
                }
                MessageBox.Show("Import thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FSanPham sp = new FSanPham();
                this.Hide();
                sp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã sản phẩm bị trùng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FSanPham sp = new FSanPham();
                this.Hide();
                sp.ShowDialog();
            }
        }
    }
}

