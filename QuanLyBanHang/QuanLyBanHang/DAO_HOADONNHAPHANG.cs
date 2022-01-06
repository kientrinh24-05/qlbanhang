using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public class DAO_HOADONNHAPHANG
    {
        QLBHDataContext db;
        public DAO_HOADONNHAPHANG()
        {
            db = new QLBHDataContext();

        }
        public dynamic LayDSMANV()
        {
            var ds = db.NHANVIENs;
            return ds;
        }

        public dynamic LayDSMANCC()
        {
            var ds = db.NHACUNGCAPs;
            return ds;
        }
        public NHANVIEN LayDSNVTheoMa(string maNV)
        {
            return db.NHANVIENs.Where(k => k.MaNv == maNV).FirstOrDefault();

        }

        public NHACUNGCAP LayDSNCCTheoMa(string maNCC)
        {
            return db.NHACUNGCAPs.Where(k => k.MaNCC == maNCC).FirstOrDefault();
        }

        public IList<string> LayDSNHAPHANG(string maNCC, DateTime ngayBan)
        {
            var ds = db.NHAPHANGs
                .Where(k => k.NCC_FK == maNCC && Convert.ToDateTime(k.NgayNhap) <= ngayBan && k.status)
                .Select(k => k.MaPN).ToList();
            return ds;
        }

        public static List<CTHDNHAPDto> ctHoaDons = new List<CTHDNHAPDto>();
        public List<CTHDNHAPDto> ThemCTHD(string maPH, int soluong)
        {
            var cthds = db.NHAPHANG_SANPHAMs.Where(k => k.MaPN == maPH)
                .Select(k => new CTHDNHAPDto()
                {
                    MaPN = k.MaPN,
                    MaSP = k.MaSP,
                    TenSP = k.SANPHAM.TenSP,
                    Soluong = k.Soluong * soluong,
                    ThanhTien = k.Soluong * soluong * k.dongia
                }).ToList();

            if (ctHoaDons.Count != 0)
            {
                string check = null;
                foreach (var sp in ctHoaDons.Select(c => c.MaPN).Distinct().ToList())
                {
                    if (sp == maPH)
                    {
                        check = sp;
                    }

                }
                if (check != null)
                {
                    foreach (var sp in ctHoaDons.Where(c => c.MaPN == maPH))
                    {
                        sp.Soluong += cthds.Where(c => c.MaSP == sp.MaSP)
                            .FirstOrDefault().Soluong;
                        sp.ThanhTien += cthds.Where(c => c.MaSP == sp.MaSP)
                            .FirstOrDefault().ThanhTien;
                    }

                }
                else
                {
                    ctHoaDons.AddRange(cthds);
                }
            }
            else
            {
                ctHoaDons.AddRange(cthds);
            }

            return ctHoaDons;
        }

        public int TongSoluong(int? soluong, string MaPH)
        {
            int? sl = db.NHAPHANG_SANPHAMs.Where(c => c.MaPN == MaPH).Select(c => c.Soluong).FirstOrDefault();

            return (int)(sl != null ? (soluong / sl) : 0);

        }

        public bool ThemHD(HOADONNHAPHANG hdnh, List<HOADONNHAPHANG_NHAPHANG> hdnh_dhs)
        {
            bool trangthai = false;
            if (KiemTraHoaDon(hdnh.MAHD, hdnh.KHHD))
            {
                db.HOADONNHAPHANGs.InsertOnSubmit(hdnh);
                foreach (var hdbh_dh in hdnh_dhs)
                {
                    db.HOADONNHAPHANG_NHAPHANGs.InsertOnSubmit(hdbh_dh);
                }
                db.SubmitChanges();
                foreach (var madh in hdnh_dhs.Select(c => c.MAPN).Distinct())
                {
                    var dh = db.NHAPHANGs.Where(c => c.MaPN == madh).FirstOrDefault();
                    if (dh != null)
                    {
                        dh.status = false;
                    }
                }
                db.SubmitChanges();
                trangthai = true;
            }
            return trangthai;
        }

        public bool KiemTraHoaDon(string maHD, string khHD)
        {
            var count = db.HOADONNHAPHANGs.Where(c => c.MAHD == maHD && c.KHHD == khHD).Count();
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> LayMaHoaDon()
        {
            return db.HOADONNHAPHANGs.Distinct().Select(c => c.MAHD).ToList();
        }
        public List<string> LayMaKHHD(string maHD)
        {
            return db.HOADONNHAPHANGs.Where(c => c.MAHD == maHD).Distinct().Select(c => c.KHHD).ToList();
        }

        public TTHOADONNHAPDto LayThongTin(string maHD, string KHHD)
        {
            return db.HOADONNHAPHANGs.Where(c => c.MAHD == maHD && c.KHHD == KHHD)
                .Select(c => new TTHOADONNHAPDto()
                {
                    MaHD = maHD,
                    KHHD = KHHD,
                    NgayBan = c.NGAYNHAP,
                    MANV = c.MANV,
                    TenNV = c.NHANVIEN.TenNV,
                    MANCC = c.MANCC,
                    TenNCC = c.NHACUNGCAP.TenNCC,
                    SDT = c.NHACUNGCAP.SoDT,
                    DiaChi = c.NHACUNGCAP.Diachi
                }).FirstOrDefault();
        }

        public bool SuaHoaDon(HOADONNHAPHANG hd)
        {
            bool trangthai = false;
            try
            {
                var d = db.HOADONNHAPHANGs.Where(c => c.MAHD == hd.MAHD && c.KHHD == hd.KHHD).FirstOrDefault();
                if (d == null)
                {
                    return trangthai;
                }
                if ((d.NGAYNHAP.AddDays(2)) < DateTime.Now)
                {
                    MessageBox.Show("Hết hạn sửa hóa đơn", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    trangthai = false;
                }
                else
                {
                    d.NGAYNHAP = hd.NGAYNHAP;
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
                var d = db.HOADONNHAPHANGs.Where(c => c.MAHD == MaHD && c.KHHD == KHHD).FirstOrDefault();
                if (d == null)
                {
                    return trangthai;
                }
                var cttd = db.HOADONNHAPHANG_NHAPHANGs.Where(c => c.MAHD == MaHD && c.KHHD == KHHD).ToList();
                if (cttd.Count != 0)
                {
                    db.HOADONNHAPHANG_NHAPHANGs.DeleteAllOnSubmit(cttd);
                }
                db.HOADONNHAPHANGs.DeleteOnSubmit(d);
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
