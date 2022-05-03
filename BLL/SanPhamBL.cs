using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using DTO;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBL
    {
        private static SanPhamBL _Instance;
        public static SanPhamBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SanPhamBL();
                }
                return _Instance;
            }
        }
        private SanPhamBL() { }
        public int GetTongSanPhamDaBan()
        {
            return SanPhamDL.Instance.GetTongSanPhamDaBan();
        }
        public int GetMaSPMoi()
        {
            return SanPhamDL.Instance.GetMaSPMax() + 1;
        }
        public string GetTenSP(int MASP)
        {
            return SanPhamDL.Instance.GetTenSP(MASP);
        }
        public DataTable GetDanhSachSanPhamTheoNCC(int MANCC)
        {
            return SanPhamDL.Instance.GetDanhSachSanPhamTheoNCC(MANCC);
        }
        public bool CheckMaSP(string MASP)
        {
            return SanPhamDL.Instance.CheckMaSP(MASP);
        }
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            return SanPhamDL.Instance.NgungKinhDoanhSanPham(MASP);
        }
        public bool ThemSanPham(SanPhamDTO spDTO)
        {
            return SanPhamDL.Instance.ThemSanPham(spDTO);
        }
        public bool SuaSanPham(SanPhamDTO spDTO)
        {
            return SanPhamDL.Instance.SuaSanPham(spDTO);
        }
        public DataTable GetDanhSachSanPhamTheoBoLoc(string TENSP, string MALOAISP, string MANCC)
        {
            return SanPhamDL.Instance.GetDanhSachSanPhamTheoBoLoc(TENSP, MALOAISP, MANCC);
        }
        public bool CapNhatSoLuong(int MaSP, int SoLuong)
        {
            return SanPhamDL.Instance.CapNhatSoLuong(MaSP, SoLuong);
        }
        public bool CapNhatSoLuongKhiBanHang(int MaSP, int SoLuong)
        {
            return SanPhamDL.Instance.CapNhatSoLuongKhiBanHang(MaSP, SoLuong);
        }
        public DataTable GetDanhSachSanPham()
        {
            return SanPhamDL.Instance.GetDanhSachSanPham();
        }

    }
}
