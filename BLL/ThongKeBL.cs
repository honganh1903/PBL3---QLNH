using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ThongKeBL
    {
        private static ThongKeBL _Instance;
        public static ThongKeBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ThongKeBL();
                }
                return _Instance;
            }
        }
        private ThongKeBL() { }
        public int GetTongSanPhamDaBan()
        {
            return ThongKeDL.Instance.GetTongSanPhamDaBan();
        }
        public double GetTongDoanhThu()
        {
            return ThongKeDL.Instance.GetTongDoanhThu();
        }
        public int GetTongKhachHang()
        {
            return ThongKeDL.Instance.GetTongKhachHang();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomNay()
        {
            return ThongKeDL.Instance.GetTop10SPTheoSoLuongHomNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomQua()
        {
            return ThongKeDL.Instance.GetTop10SPTheoSoLuongHomQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuong7NgayQua()
        {
            return ThongKeDL.Instance.GetTop10SPTheoSoLuong7NgayQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangNay()
        {
            return ThongKeDL.Instance.GetTop10SPTheoSoLuongThangNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangTruoc()
        {
            return ThongKeDL.Instance.GetTop10SPTheoSoLuongThangTruoc();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomNay()
        {
            return ThongKeDL.Instance.GetTop10SPTheoDoanhThuHomNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomQua()
        {
            return ThongKeDL.Instance.GetTop10SPTheoDoanhThuHomQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThu7NgayQua()
        {
            return ThongKeDL.Instance.GetTop10SPTheoDoanhThu7NgayQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangNay()
        {
            return ThongKeDL.Instance.GetTop10SPTheoDoanhThuThangNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangTruoc()
        {
            return ThongKeDL.Instance.GetTop10SPTheoDoanhThuThangTruoc();
        }
        public double GetDoanhThuHomNay()
        {
            return ThongKeDL.Instance.GetDoanhThuHomNay();
        }
        public DoanhThuDTO GetDoanhThuHomQua()
        {
            return ThongKeDL.Instance.GetDoanhThuHomQua();
        }
        public List<DoanhThuDTO> GetDoanhThu(int songay)
        {
            return ThongKeDL.Instance.GetDoanhThu(songay);
        }
        public List<DoanhThuDTO> GetDoanhThu7NgayQua()
        {
            return ThongKeDL.Instance.GetDoanhThu7NgayQua();
        }
        public List<DoanhThuDTO> GetDoanhThuThangNay()
        {
            return ThongKeDL.Instance.GetDoanhThuThangNay();
        }
        public List<DoanhThuDTO> GetDoanhThuThangTruoc()
        {
            return ThongKeDL.Instance.GetDoanhThuThangTruoc();
        }
    }
}
