using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhachHangDL
    {
        private static KhachHangDL _Instance;
        public static KhachHangDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KhachHangDL();
                }
                return _Instance;
            }
        }
        private KhachHangDL() { }
        #region Lấy Mã Khách Hàng MAX
        public int GetMaKHMax()
        {
            try
            {
                string sql = "SELECT MAX(MAKH) FROM KHACHHANG";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Lấy Tên Khách Hàng
        public string GetTenKhachHang(string SDT)
        {
            try
            {
                string sql = "SELECT HOTEN FROM KHACHHANG WHERE SDT = '" + SDT + "' AND DAXOA=0";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                string ten = dt.Rows[0][0].ToString();
                return ten;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Tên Khách Hàng
        public string GetTenMaKH(string SDT)
        {
            try
            {
                string sql = "SELECT MAKH FROM KHACHHANG WHERE SDT = '" + SDT + "' AND DAXOA=0";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                string ten = dt.Rows[0][0].ToString();
                return ten;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Kiểm Tra Mã Khách Hàng
        public bool CheckMaKH(string MAKH)
        {
            try
            {
                string sql = "SELECT * FROM KHACHHANG WHERE MAKH='" + MAKH + "'";
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

        #region Lấy Danh Sách Khách Hàng
        public DataTable GetDanhSachKhachHang()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT MAKH as N'Mã KH',HOTEN as N'Tên KH',DIACHI as N'Địa Chỉ',SDT as N'SĐT',NGAYDANGKY as N'Ngày Đăng Ký',Email as N'Email',DOANHSO as N'Doanh Số' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM KHACHHANG WHERE DAXOA=0 AND MAKH != 1";
                dt = new DataTable();
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

        #region Cập Nhật Doanh Số Khách Hàng
        public bool CapNhatDoanhSoKhachHang(int MAKH, decimal DOANHSO)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET DOANHSO=DOANHSO+@DOANHSO WHERE MAKH = @MAKH";
                SqlConnection con = DataAccess.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MAKH", MAKH);
                cmd.Parameters.AddWithValue("@DOANHSO", DOANHSO);
                cmd.Connection = con;
                int rows = cmd.ExecuteNonQuery();
                DataAccess.Disconnect(con);
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
    }
}
