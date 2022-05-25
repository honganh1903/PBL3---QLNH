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
    public class CTSPDL
    {
        private static CTSPDL _Instance;
        public static CTSPDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CTSPDL();
                }
                return _Instance;
            }
        }
        private CTSPDL() { }
        #region Lấy Danh Sách Nguyên Liệu
        public DataTable GetDanhSachNguyenLieu(int MASP)
        {
            try
            {
                string sql = "SELECT nguyenlieu.MANL as N'Mã NL',nguyenlieu.TENNL as N'Tên NL',DVT as N'ĐVT',CTSP.SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập' FROM NGUYENLIEU join CTSP on NGUYENLIEU.MANL = ctsp.MANL WHERE MASP=" + MASP;
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

        #region Thêm Thành Phần
        public bool ThemThanhPhan(int MASP, int MANL, int SoLuong)
        {
            try
            {
                int rows = 0;
                string sql;
                bool check = CheckNL(MANL,MASP);
                if (check == true) { sql = "INSERT INTO CTSP VALUES('" + MASP + "','" + MANL + "','" + SoLuong + "')"; }

                else
                    sql = "UPDATE CTSP SET SOLUONG= '"+ SoLuong+" WHERE MASP="+ MASP+" AND MANL = "+MANL+" ";
                rows = DataAccess.JustExcuteNoParameter(sql);
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

        public bool CheckNL(int MANL,int MASP)
        {
            string sql = "SELECT *  FROM SANPHAM join CTSP on SANPHAM.MASP = ctsp.MASP where MANL ='" + MANL + "' AND MASP = '" + MASP + "' ";
            DataTable dt = new DataTable();
            dt = DataAccess.GetTable(sql);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}

