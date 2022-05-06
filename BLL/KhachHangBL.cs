using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHangBL
    {
        private static KhachHangBL _Instance;
        public static KhachHangBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KhachHangBL();
                }
                return _Instance;
            }
        }
        private KhachHangBL() { }
        public string GetTenKhachHang(string SDT)
        {
            return KhachHangDL.Instance.GetTenKhachHang(SDT);
        }
        public string GetTenMaKH(string SDT)
        {
            return KhachHangDL.Instance.GetTenMaKH(SDT);
        }
        public int GetMaKHMax()
        {
            return KhachHangDL.Instance.GetMaKHMax() + 1;
        }
        public bool CheckMaKH(string MAKH)
        {
            return KhachHangDL.Instance.CheckMaKH(MAKH);
        }
        public DataTable GetDanhSachKhachHang()
        {
            return KhachHangDL.Instance.GetDanhSachKhachHang();

        }
        public bool CapNhatDoanhSoKhachHang(int MAKH, decimal DOANHSO)
        {
            return KhachHangDL.Instance.CapNhatDoanhSoKhachHang(MAKH, DOANHSO);
        }
        public DataTable GetDanhSachAllKhachHang()
        {
            return KhachHangDL.Instance.GetDanhSachAllKhachHang();
        }
        public DataTable GetDanhSachKhachHangHT()
        {
            return KhachHangDL.Instance.GetDanhSachKhachHangHT();
        }
        public DataTable GetDanhSachKhachHangDX()
        {
            return KhachHangDL.Instance.GetDanhSachKhachHangDX();
        }
        public bool ThemKhachHang(KhachHangDTO khDTO)
        {
            return KhachHangDL.Instance.ThemKhachHang(khDTO);
        }
        public bool SuaKhachHang(KhachHangDTO khDTO)
        {
            return KhachHangDL.Instance.SuaKhachHang(khDTO);
        }
        public bool XoaKhachHang(KhachHangDTO khDTO)
        {
            return KhachHangDL.Instance.XoaKhachHang(khDTO);
        }
        public DataTable GetDanhSachByName(string x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachByName(x, maDS);
        }
        public DataTable GetDanhSachByDC(string x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachByDC(x, maDS);
        }
        public DataTable GetDanhSachBySDT(string x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachBySDT(x, maDS);
        }
        public DataTable GetDanhSachByMail(string x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachByMail(x, maDS);
        }
        public DataTable GetDanhSachByGT(bool x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachByGT(x, maDS);
        }
        public DataTable GetDanhSachByNDK(DateTime x, int maDS)
        {
            return KhachHangDL.Instance.GetDanhSachByNDK(x, maDS);
        }
    }
}
