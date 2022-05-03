using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class CTPNDL
    {
        private static CTPNDL _Instance;
        public static CTPNDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CTPNDL();
                }
                return _Instance;
            }
        }
        private CTPNDL() { }
        #region Thêm Chi Tiết Phiếu Nhập
        public bool ThemCTPN(DataTable dt, int MAPN)
        {
            try
            {
                int rows = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "INSERT INTO CHITIETPHIEUNHAP VALUES('" + MAPN + "','" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][5].ToString() + "','" + dt.Rows[i][4].ToString() + "')";
                    rows = DataAccess.JustExcuteNoParameter(sql);
                    //SanPhamDL.CapNhatSoLuong(int.Parse(dt.Rows[i][0].ToString()), int.Parse(dt.Rows[i][5].ToString()));
                }
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

        #region Lấy Danh Sách Chi Tiết Phiếu Nhập
        public DataTable GetDanhSachPhieuNhap(int MAPN)
        {
            try
            {
                string sql = "SELECT MASP, SOLUONG FROM CHITIETPHIEUNHAP WHERE MAPHIEU=" + MAPN;
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
