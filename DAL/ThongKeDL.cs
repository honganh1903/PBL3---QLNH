using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class ThongKeDL
    {
        private static ThongKeDL _Instance;
        public static ThongKeDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ThongKeDL();
                }
                return _Instance;
            }
        }
        private ThongKeDL() { }
        #region Lấy Tổng Sản Phẩm Đã Bán
        public int GetTongSanPhamDaBan()
        {
            try
            {
                string sql = "SELECT SUM(SOLUONG) FROM CTHD";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                int sl = 0;
                sl = int.Parse(dt.Rows[0][0].ToString());
                return sl;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Lấy Tổng Doanh Thu
        public double GetTongDoanhThu()
        {
            try
            {
                string sql = "SELECT SUM(THANHTIEN) FROM HOADON";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                double doanhthu = double.Parse(dt.Rows[0][0].ToString());
                return doanhthu;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Lấy Tổng Khách Hàng
        public int GetTongKhachHang()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM KHACHHANG";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                int kh = int.Parse(dt.Rows[0][0].ToString());
                return kh;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Số Lượng Hôm Nay
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomNay()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.SoLuong = int.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Số Lượng Hôm Qua
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomQua()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "')-1 AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.SoLuong = int.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Số Lượng 7 Ngày Qua
        public List<SanPhamDTO> GetTop10SPTheoSoLuong7NgayQua()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP = sp.MASP JOIN HOADON hd ON cthd.SOHD = hd.SOHD WHERE YEAR(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  YEAR(hd.NGAYLAP) FROM HOADON hd) AND MONTH(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  MONTH(hd.NGAYLAP) FROM HOADON hd) AND DAY(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  DAY(hd.NGAYLAP) FROM HOADON hd) AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.SoLuong = int.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Số Lượng Tháng Này
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangNay()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) <= YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.SoLuong = int.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Số Lượng Tháng Trước
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangTruoc()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) <= YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = (MONTH('" + DateTime.Now + "')-1) AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.SoLuong = int.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Doanh Thu Hôm Nay
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomNay()
        {
            try
            {
                DataAccess.Openconnect();
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.TongDoanhThu = double.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Doanh Thu Hôm Qua
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomQua()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "')-1 AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.TongDoanhThu = double.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Doanh Thu 7 Ngày Qua
        public List<SanPhamDTO> GetTop10SPTheoDoanhThu7NgayQua()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP = sp.MASP JOIN HOADON hd ON cthd.SOHD = hd.SOHD WHERE YEAR(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  YEAR(hd.NGAYLAP) FROM HOADON hd) AND MONTH(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  MONTH(hd.NGAYLAP) FROM HOADON hd) AND DAY(hd.NGAYLAP) IN(SELECT DISTINCT TOP 7  DAY(hd.NGAYLAP) FROM HOADON hd) AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.TongDoanhThu = double.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top 10 SP Theo Doanh Thu Tháng Này
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangNay()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) <= YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.TongDoanhThu = double.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Top SP Theo Doanh Thu Tháng Trước
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangTruoc()
        {
            try
            {
                string sql = "SELECT TOP 10 cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP JOIN HOADON hd ON cthd.SOHD=hd.SOHD WHERE YEAR(hd.NGAYLAP) <= YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = (MONTH('" + DateTime.Now + "')-1) AND hd.DATHANHTOAN = '1' GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG*sp.DONGIABAN-(((cthd.SOLUONG*sp.DONGIABAN)*sp.KHUYENMAI)/100)) DESC";
                DataTable dt = new DataTable();
                List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDTO spDTO = new SanPhamDTO();
                    spDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    spDTO.TenSP = dt.Rows[i][1].ToString();
                    spDTO.TongDoanhThu = double.Parse(dt.Rows[i][2].ToString());

                    lstSP.Add(spDTO);
                }
                return lstSP;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Doanh Thu Hôm Nay
        public double GetDoanhThuHomNay()
        {
            try
            {
                string sql = "SELECT SUM(hd.THANHTIEN) FROM HOADON hd WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1'";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                double doanhthu = double.Parse(dt.Rows[0][0].ToString());
                return doanhthu;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        #endregion

        #region Lấy Doanh Thu Hôm Qua
        public DoanhThuDTO GetDoanhThuHomQua()
        {
            try
            {
                string sql = "SELECT CONVERT(VARCHAR(10),hd.NGAYLAP,101), SUM(hd.THANHTIEN) FROM HOADON hd WHERE YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "')-1 AND hd.DATHANHTOAN = '1' GROUP BY CONVERT(VARCHAR(10),hd.NGAYLAP,101)";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                DoanhThuDTO dtDTO = new DoanhThuDTO();
                dtDTO.Ngay = Convert.ToDateTime(dt.Rows[0][0]);
                dtDTO.DoanhThu = double.Parse(dt.Rows[0][1].ToString());
                return dtDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Lấy Doanh Thu Theo Số Ngày
        public List<DoanhThuDTO> GetDoanhThu(int songay)
        {
            try
            {
                string sql = "SELECT TOP " + songay + " hd.NGAYLAP, SUM(hd.THANHTIEN) FROM HOADON hd GROUP BY hd.NGAYLAP ORDER BY hd.NGAYLAP DESC";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                List<DoanhThuDTO> lstdtDTO = new List<DoanhThuDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DoanhThuDTO dtDTO = new DoanhThuDTO();
                    dtDTO.Ngay = Convert.ToDateTime(dt.Rows[i][0].ToString());
                    dtDTO.DoanhThu = double.Parse(dt.Rows[i][1].ToString());

                    lstdtDTO.Add(dtDTO);
                }
                return lstdtDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Lấy Doanh Thu 7 Ngày Qua
        public List<DoanhThuDTO> GetDoanhThu7NgayQua()
        {
            try
            {
                string sql = "SELECT TOP 7 CONVERT(VARCHAR(10),hd.NGAYLAP,101), SUM(hd.THANHTIEN) FROM HOADON hd WHERE (YEAR(hd.NGAYLAP) <= YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) <= MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) <= DAY('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1' )GROUP BY CONVERT(VARCHAR(10),hd.NGAYLAP,101) ORDER BY CONVERT(VARCHAR(10),hd.NGAYLAP,101) DESC";
                DataTable dt = new DataTable();
                List<DoanhThuDTO> lstdtDTO = new List<DoanhThuDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DoanhThuDTO dtDTO = new DoanhThuDTO();
                    dtDTO.Ngay = Convert.ToDateTime(dt.Rows[i][0].ToString());
                    dtDTO.DoanhThu = double.Parse(dt.Rows[i][1].ToString());

                    lstdtDTO.Add(dtDTO);
                }
                return lstdtDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Lấy Doanh Thu Tháng Này
        public List<DoanhThuDTO> GetDoanhThuThangNay()
        {
            try
            {
                string sql = "SELECT CONVERT(VARCHAR(10),hd.NGAYLAP,101), SUM(hd.THANHTIEN) FROM HOADON hd WHERE (YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND hd.DATHANHTOAN = '1') GROUP BY CONVERT(VARCHAR(10),hd.NGAYLAP,101) ORDER BY CONVERT(VARCHAR(10),hd.NGAYLAP,101) DESC";
                DataTable dt = new DataTable();
                List<DoanhThuDTO> lstdtDTO = new List<DoanhThuDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DoanhThuDTO dtDTO = new DoanhThuDTO();
                    dtDTO.Ngay = Convert.ToDateTime(dt.Rows[i][0].ToString());
                    dtDTO.DoanhThu = double.Parse(dt.Rows[i][1].ToString());

                    lstdtDTO.Add(dtDTO);
                }
                return lstdtDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Lấy Doanh Thu Tháng Trước
        public List<DoanhThuDTO> GetDoanhThuThangTruoc()
        {
            try
            {
                string sql = "SELECT CONVERT(VARCHAR(10),hd.NGAYLAP,101), SUM(hd.THANHTIEN) FROM HOADON hd WHERE (YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = (MONTH('" + DateTime.Now + "')-1) AND hd.DATHANHTOAN = '1') GROUP BY CONVERT(VARCHAR(10),hd.NGAYLAP,101)";
                DataTable dt = new DataTable();
                List<DoanhThuDTO> lstdtDTO = new List<DoanhThuDTO>();
                dt = DataAccess.GetTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DoanhThuDTO dtDTO = new DoanhThuDTO();
                    dtDTO.Ngay = Convert.ToDateTime(dt.Rows[i][0].ToString());
                    dtDTO.DoanhThu = double.Parse(dt.Rows[i][1].ToString());

                    lstdtDTO.Add(dtDTO);
                }
                return lstdtDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion
    }
}
