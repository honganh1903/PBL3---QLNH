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
    public class NguyenLieuDL
    {
        private static NguyenLieuDL _Instance;
        public static NguyenLieuDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NguyenLieuDL();
                }
                return _Instance;
            }
        }
        private NguyenLieuDL() { }
        #region Lấy Danh Sách Nguyên Liệu
        public DataTable GetDanhSachNguyenLieu()
        {
            try
            {
                string sql = "SELECT MANL as N'Mã NL',TENNL as N'Tên NL',DVT as N'ĐVT',MANCC as N'Mã NCC',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập' FROM NguyenLieu ";
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

        #region Lấy Tên Nguyên Liệu
        public string GetTenNL(int MANL)
        {
            try
            {
                string sql = "SELECT TENNL FROM NGUYENLIEU WHERE MANL=" + MANL;
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sql);
                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        #region Lấy Danh Sách Nguyên Liệu Theo NCC
        public DataTable GetDanhSachNguyenLieuTheoNCC(int MANCC)
        {
            try
            {
                string sql = "SELECT MANL as N'Mã NL',TENNL as N'Tên NL',DVT as N'ĐVT',MANCC as N'Mã NCC',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập' FROM NGUYENLIEU WHERE MANCC =" + MANCC;
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

        #region Cập Nhật Số Lượng
        public bool CapNhatSoLuong(int MaNL, int SoLuong)
        {
            try
            {
                string sql = "UPDATE NGUYENLIEU SET SoLuong = SoLuong+@SoLuong WHERE MANL = @MANL";
                SqlConnection con = DataAccess.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MASP", MaNL);
                cmd.Parameters.AddWithValue("@SOLUONG", SoLuong);
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

        #region Thêm nguyên liệu
        public bool ThemNL(NguyenLieuDTO nlDTO)
        {
            try
            {
                string sql = "INSERT INTO NGUYENLIEU(TENNL,DVT,DONGIANHAP,MANCC,SOLUONG) VALUES(N'" + nlDTO.TenNL + "',N'" + nlDTO.DVT + "','" + nlDTO.DonGiaNhap + "',N'" + nlDTO.MaNCC + "',N'" + nlDTO.SoLuong+ "')";
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

        #region Cập Nhật Nguyên Liệu
        public bool CapNhatNL(NguyenLieuDTO nlDTO)
        {
            try
            {
                string sql = "UPDATE NGUYENLIEU SET TENNL=N'" + nlDTO.TenNL + "',DVT=N'" + nlDTO.DVT + "',DONGIANHAP=N'" + nlDTO.DonGiaNhap + "',MANCC=N'" + nlDTO.MaNCC +"',SOLUONG=N'"+ nlDTO.SoLuong+"' WHERE MANL='" +nlDTO.MaNL+ "'";
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
                // MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Xóa nguyên liệu
        public bool XoaNguyenLieu(int nlDTO)
        {
            try
            {
                string sql = "DELETE FROM NGUYENLIEU WHERE MANL = "+nlDTO;
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
    }
}
