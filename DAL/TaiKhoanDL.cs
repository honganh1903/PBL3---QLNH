using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDL
    {
        //instance
        private static TaiKhoanDL _Instance;
        public static TaiKhoanDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TaiKhoanDL();
                }
                return _Instance;
            }
        }
        private TaiKhoanDL() { }
        public int GetMaQuyen(int manv)
        {
            string sql = "SELECT * FROM PHANQUYEN WHERE MANV = '" + manv + "'";
            DataTable dt = new DataTable();
            dt = DataAccess.GetTable(sql);
            string maquyen = dt.Rows[0][1].ToString();
            return int.Parse(maquyen);
        }
        public string GetTenQuyen(int maquyen)
        {
            string sql = "SELECT TENQUYEN FROM QUYEN WHERE MAQUYEN = '" + maquyen + "'";
            DataTable dt = new DataTable();
            dt = DataAccess.GetTable(sql);
            string tenquyen = dt.Rows[0][0].ToString();
            return tenquyen;
        }
        public bool KiemTraDangNhap(string manv, string mk)
        {
            try
            {
                string sqlmahoa = "declare @decryptedValue varchar(8000) declare @encryptedValue varbinary(8000) SET @encryptedValue = (SELECT MATKHAU FROM TAIKHOAN WHERE MANV=" + manv + ") Set @decryptedValue = DECRYPTBYPASSPHRASE('!@#<>?', @encryptedValue) select @decryptedValue";
                DataTable dt = new DataTable();
                dt = DataAccess.GetTable(sqlmahoa);
                string mkgiaima = dt.Rows[0][0].ToString();
                if (mk == mkgiaima)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
