using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class DAO_HOADONBANHANG
    {
        QLBHDataContext db;
        public DAO_HOADONBANHANG()
        {
            db = new QLBHDataContext();

        }
        public dynamic LayDSMANV()
        {
            var ds = db.NHANVIENs;
            return ds;
        }

        public dynamic LayDSMAKH()
        {
            var ds = db.KHACHHANGs;
            return ds;
        }
        public NHANVIEN LayDSNVTheoMa(string maNV)
        {
            return db.NHANVIENs.Where(k => k.MaNv == maNV).FirstOrDefault();
           
        }

        public KHACHHANG LayDSKHTheoMa(string maKH)
        {
            return db.KHACHHANGs.Where(k=> k.MaKH==maKH).FirstOrDefault();  
        }

        public IList<string> LayDSDONHANG(string maKH, DateTime ngayBan)
        {
            var ds = db.DONHANGs
                .Where(k => k.KHACHHANG_FK == maKH && Convert.ToDateTime(k.NgayBan) <= ngayBan)
                .Select(k=> k.MaDH).ToList();
            return ds;
        }

        public bool ThemHD(HOADONBANHANG hdbh, List<HOADONBANHANG_DONHANG> hdbh_dhs)
        {
            bool trangthai = false;
            if (KiemTraHoaDon(hdbh.MAHD, hdbh.KHHD))
            {
                db.HOADONBANHANGs.InsertOnSubmit(hdbh);
                foreach(var hdbh_dh in hdbh_dhs)
                {
                    db.HOADONBANHANG_DONHANGs.InsertOnSubmit(hdbh_dh);
                }    
                db.SubmitChanges();
                trangthai = true;
            }
            return trangthai;
        }

        public bool KiemTraHoaDon(string maHD, string khHD)
        {
            var count = db.HOADONBANHANGs.Where(c => c.MAHD == maHD && c.KHHD == khHD).Count();
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<CTHDDto> ctHoaDons = new List<CTHDDto>();
        public List<CTHDDto> ThemCTHD(string maDH, int soluong)
        {
            var cthds = db.DONHANG_SANPHAMs.Where(k => k.MaDH == maDH)
                .Select(k=> new CTHDDto() { MaDH= k.MaDH,
                                    MaSP= k.MaSP,
                                    TenSP= k.SANPHAM.TenSP,
                                    Soluong = k.SoLuong*soluong,
                                    ThanhTien=k.SoLuong*soluong*k.DonGia}).ToList();
            
            if(ctHoaDons.Count!=0)
            {
                string check= null;
                int a = ctHoaDons.Select(c => c.MaDH).Distinct().Count();
                foreach(var sp in ctHoaDons.Select(c => c.MaDH).Distinct().ToList())
                {
                    if (sp == maDH)
                    {
                        check = sp; 
                    }
 
                }
                if(check!=null)
                {
                    foreach(var sp in ctHoaDons.Where(c=> c.MaDH==maDH))
                    {
                        sp.Soluong += cthds.Where(c => c.MaSP == sp.MaSP)
                            .FirstOrDefault().Soluong;
                        sp.ThanhTien += cthds.Where(c => c.MaSP == sp.MaSP)
                            .FirstOrDefault().ThanhTien;
                    }    
                    
                }else{
                    ctHoaDons.AddRange(cthds);
                }

            }
            else
            {
                ctHoaDons.AddRange(cthds);
            }  
            
            return ctHoaDons;
        }

        public int TongSoluong(int? soluong, string MaHD)
        {
            int? sl = db.DONHANG_SANPHAMs.Where(c => c.MaDH == MaHD).Select(c => c.SoLuong).FirstOrDefault();

            return (int)(sl != null ? (soluong/sl) : 0);
            
        }

        public List<string> LayMaHoaDon()
        {
            return db.HOADONBANHANGs.Distinct().Select(c => c.MAHD).ToList();
        }
        public List<string> LayMaKHHD(string maHD)
        {
            return db.HOADONBANHANGs.Where(c=> c.MAHD==maHD).Distinct().Select(c => c.KHHD).ToList();
        }

        public TTHOADONDto LayThongTin(string maHD, string KHHD)
        {
            return db.HOADONBANHANGs.Where(c => c.MAHD == maHD && c.KHHD == KHHD)
                .Select(c => new TTHOADONDto() {
                                    MaHD= maHD, KHHD=KHHD,NgayBan= c.NGAYBAN,
                                   MANV= c.MANV,TenNV= c.NHANVIEN.TenNV,
                                   MAKH= c.MAKH, TenKH= c.KHACHHANG.TenKH,
                                   SDT= c.KHACHHANG.SoDT,DiaChi= c.KHACHHANG.Diachi }).FirstOrDefault();
        }

        public bool SuaHoaDon(HOADONBANHANG hd)
        {
            bool trangthai = false;
            try
            {
                var d = db.HOADONBANHANGs.Where(c => c.MAHD == hd.MAHD && c.KHHD == hd.KHHD).FirstOrDefault(); 
                if(d==null)
                {
                    return trangthai;
                }    
                if(d.NGAYBAN.AddDays(2)<DateTime.Now)
                {
                    MessageBox.Show("Hết hạn sửa hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    trangthai = false;
                }
                else
                {
                    d.NGAYBAN = hd.NGAYBAN;
                    db.SubmitChanges();
                    trangthai = true;
                }   
                
            }
            catch (Exception)
            {

                trangthai = false;

            }

            return trangthai;
        }

        public bool XoaDonHang(string MaHD, string KHHD)
        {
            bool trangthai = false;
            try
            {
                var d = db.HOADONBANHANGs.Where(c => c.MAHD == MaHD && c.KHHD == KHHD).FirstOrDefault();
                if (d == null)
                {
                    return trangthai;
                }
                var cttd = db.HOADONBANHANG_DONHANGs.Where(c => c.MAHD == MaHD && c.KHHD == KHHD).ToList();
                if (cttd.Count != 0)
                {
                    db.HOADONBANHANG_DONHANGs.DeleteAllOnSubmit(cttd);
                }
                db.HOADONBANHANGs.DeleteOnSubmit(d);
                db.SubmitChanges();
                trangthai = true;
            }
            catch (Exception)
            {
                trangthai = false;
            }

            return trangthai;

        }

    }
}
