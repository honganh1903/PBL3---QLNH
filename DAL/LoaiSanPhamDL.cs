using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class LoaiSanPhamDL
    {
        private static LoaiSanPhamDL _Instance;
        public static LoaiSanPhamDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiSanPhamDL();
                }
                return _Instance;
            }
        }
        private LoaiSanPhamDL() { }
        #region Lấy Danh Sách Loại Sản Phẩm
        public DataTable GetDanhSachLoaiSanPham()
        {
            try
            {
                string sql = "SELECT MALOAISP AS N'Mã Loại SP', TENLOAISP AS N'Tên Loại SP' FROM LOAISANPHAM WHERE NGUNGKINHDOANH=0";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region Thêm Loại Sản Phẩm
        public bool ThemLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            try
            {
                string sql = "INSERT INTO LOAISANPHAM VALUES(N'" + lspDTO.TenLoaiSP + "',0)";
                int rows = DataAccess.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Ngừng Kinh Doanh Sản Phẩm
        public bool NgungKinhDoanh(string MALOAISP)
        {
            try
            {
                string sql = "UPDATE LOAISANPHAM SET NGUNGKINHDOANH=1 WHERE MALOAISP='" + MALOAISP + "'";
                int rows = DataAccess.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Cập Nhật Loại Sản Phẩm
        public bool CapNhatLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            try
            {
                string sql = "UPDATE LOAISANPHAM SET TENLOAISP=N'" + lspDTO.TenLoaiSP + "' WHERE MALOAISP='" + lspDTO.MaLoaiSP + "'";
                int rows = DataAccess.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Kiểm Tra Mã Loại Sản Phẩm
        public bool CheckMaLoaiSP(string MALOAISP)
        {
            try
            {
                string sql = "SELECT * FROM LOAISANPHAM WHERE MALOAISP='" + MALOAISP + "'";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
