using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDL
    {
        private static NhanVienDL _Instance;
        public static NhanVienDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NhanVienDL();
                }
                return _Instance;
            }
        }
        private NhanVienDL() { }
        #region Lấy Tên Nhân Viên
        public string GetTenNhanVien(int manv)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE MANV = '" + manv + "'";
            DataTable dt = new DataTable();
            dt = DataAccess.GetTable(sql);
            string ten = dt.Rows[0][1].ToString();
            return ten;
        }
        #endregion
    }
}
