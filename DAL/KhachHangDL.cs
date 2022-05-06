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

        #region Lấy danh sách toàn bộ khách hàng
        public DataTable GetDanhSachAllKhachHang()
        {
            try
            {
                string sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG ";
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

        #region Thêm Khách Hàng
        public bool ThemKhachHang(KhachHangDTO khDTO)
        {
            try
            {
                string sql = "INSERT INTO KHACHHANG VALUES(@HOTEN,@DIACHI,@SDT,@GIOITINH,@NGAYDANGKY,@EMAIL,@DOANHSO,@DAXOA)";
                SqlConnection con = DataAccess.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@HOTEN", khDTO.TenKH);
                cmd.Parameters.AddWithValue("@DIACHI", khDTO.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", khDTO.SDT);
                cmd.Parameters.AddWithValue("@GIOITINH", khDTO.GioiTinh);
                cmd.Parameters.AddWithValue("@NGAYDANGKY", khDTO.NgayDangKy);
                cmd.Parameters.AddWithValue("@EMAIL", khDTO.Email);
                cmd.Parameters.AddWithValue("@DOANHSO", khDTO.DoanhSo);
                cmd.Parameters.AddWithValue("@DAXOA", khDTO.DaXoa);
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

        #region Sửa Khách Hàng
        public bool SuaKhachHang(KhachHangDTO khDTO)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET HOTEN = @HOTEN,DIACHI = @DIACHI,SDT = @SDT,GIOITINH = @GIOITINH, NGAYDANGKY = @NGAYDANGKY, EMAIL = @EMAIL, DOANHSO = @DOANHSO, DAXOA = @DAXOA WHERE MAKH = @MAKH";
                SqlConnection con = DataAccess.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MAKH", khDTO.MaKH);
                cmd.Parameters.AddWithValue("@HOTEN", khDTO.TenKH);
                cmd.Parameters.AddWithValue("@DIACHI", khDTO.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", khDTO.SDT);
                cmd.Parameters.AddWithValue("@GIOITINH", khDTO.GioiTinh);
                cmd.Parameters.AddWithValue("@NGAYDANGKY", khDTO.NgayDangKy);
                cmd.Parameters.AddWithValue("@EMAIL", khDTO.Email);
                cmd.Parameters.AddWithValue("@DOANHSO", khDTO.DoanhSo);
                cmd.Parameters.AddWithValue("@DAXOA", khDTO.DaXoa);
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

        #region Xóa khách hàng
        public bool XoaKhachHang(KhachHangDTO khDTO)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET DAXOA = @DAXOA WHERE MAKH = @MAKH";
                SqlConnection con = DataAccess.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MAKH", khDTO.MaKH);
                cmd.Parameters.AddWithValue("@DAXOA", khDTO.DaXoa);
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

        #region Lấy danh sách khách hàng theo tên
        public DataTable GetDanhSachByName(string x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE HOTEN LIKE N'%" + x + "%' AND DAXOA ='" + maDS + "'";
                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE HOTEN LIKE N'%" + x + "%'";
                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng theo địa chỉ
        public DataTable GetDanhSachByDC(string x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE DIACHI LIKE N'%" + x + "%' AND DAXOA ='" + maDS + "'";
                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE DIACHI LIKE N'%" + x + "%'";
                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng theo SĐT
        public DataTable GetDanhSachBySDT(string x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE SDT LIKE N'%" + x + "%' AND DAXOA ='" + maDS + "'";
                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE SDT LIKE N'%" + x + "%'";
                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng theo Giới tính
        public DataTable GetDanhSachByGT(bool x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE GIOITINH = '" + x + "' AND DAXOA ='" + maDS + "'";
                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE GIOITINH = '" + x + "'";
                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng theo Ngày đăng ký
        public DataTable GetDanhSachByNDK(DateTime x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE NGAYDANGKY = '" + x + "' AND DAXOA ='" + maDS + "'";

                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE NGAYDANGKY = '" + x + "'";

                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng theo Email
        public DataTable GetDanhSachByMail(string x, int maDS)
        {
            try
            {
                string sql;
                if (maDS != -1)
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE EMAIL LIKE N'%" + x + "%' AND DAXOA ='" + maDS + "'";
                }
                else
                {
                    sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE EMAIL LIKE N'%" + x + "%'";
                }
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng hiên tại
        public DataTable GetDanhSachKhachHangHT()
        {
            try
            {
                string sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE DAXOA = '0'";
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

        #region Lấy danh sách khách hàng đã xóa
        public DataTable GetDanhSachKhachHangDX()
        {
            try
            {
                string sql = "SELECT MAKH as N'Mã khách hàng',HOTEN as N'Họ tên',DIACHI as N'Địa chỉ',SDT as N'SĐT', CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính',NGAYDANGKY as N'Ngày đăng ký',EMAIL as N'Email',DOANHSO as N'Doanh số',DAXOA as N'Đã xóa' FROM KHACHHANG WHERE DAXOA = '1'";
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
    }
}
