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
        public FImport()
        {
            InitializeComponent();
            busKH = new BUS_KHACHHANG();
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
                        using (var stream= File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            txtFilePath.Text = stream.Name;
                            using (IExcelDataReader reader=ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable= (_) => new ExcelDataTableConfiguration() { UseHeaderRow=true}
                                });
                                dataTableCollection = result.Tables;
                            
                                foreach(DataTable b in dataTableCollection)
                                {
                                    str = b.TableName;
                                }    
                            }    
                        }    
                    }    
            }
            dt = dataTableCollection[str];
            Browse.Hide();
            Save.Show();
        }

        private void FImport_Load(object sender, EventArgs e)
        {
            Save.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int check = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for(int j = 0; j < busKH.DSKhachHang().Rows.Count; j++)
                {

                    if(busKH.DSKhachHang().Rows[j]["MaKH"].ToString() == dt.Rows[i]["MaKH"].ToString())
                    {
                        check = 1;  
                    }
                }            
            } 
            if(check==0)
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
            }
            else
            {
                MessageBox.Show("Mã khách hàng bị trùng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FKhachHang kh = new FKhachHang();
                this.Hide();
                kh.ShowDialog();
            }   
        }
    }
    }

