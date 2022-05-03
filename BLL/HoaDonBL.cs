    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class HoaDonBL
    {
        private static HoaDonBL _Instance;
        public static HoaDonBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HoaDonBL();
                }
                return _Instance;
            }
        }
        private HoaDonBL() { }
        public bool ThemHoaDon(HoaDonDTO hdDTO)
        {
            return HoaDonDL.Instance.ThemHoaDon(hdDTO);
        }
        public int GetSOHDMAX()
        {
            return HoaDonDL.Instance.GetSOHDMax();
        }
        public bool XoaHD(int SOHD)
        {
            return HoaDonDL.Instance.XoaHD(SOHD);
        }
        public DataSet InHoaDon(int SOHD)
        {
            return HoaDonDL.Instance.InHoaDon(SOHD);
        }
        public bool CapNhatSoLuongTienKhachHang(int SOHD, decimal TienKhachHangTra, decimal TienThua)
        {
            return HoaDonDL.Instance.CapNhatSoLuongTienKhachHang(SOHD, TienKhachHangTra, TienThua);
        }
    }
}
