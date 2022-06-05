
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO;

namespace DAL
{
    public class NhanVienDL
    {
        SqlDataAdapter DataAdapter;

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
        SqlCommand sqlCommand;
        private NhanVienDL() { }
        //show toan b nhan vie
        public DataTable getAllNhanVien()
        {
            string sql = "SELECT MANV as N'Mã Nhân Viên', HOTEN as N'Họ Và Tên' , SDT as N'Số Điện Thoại',NGAYSINH as N'Ngày Sinh',EMAIL ,GIOITINH as N'Giới Tính' ,DATHOIVIEC as N'Đã Thôi Việc',TENLOAI as N'Chức Vụ' FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI";

            return DataAccess.GetTable(sql);
        }
        // ke thuc show


        #region Lấy tên nhân viên
        public string GetTenNhanVien(int manv)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE MANV = '" + manv + "'";
            DataTable dt = new DataTable();
            dt = DataAccess.GetTable(sql);
            string ten = dt.Rows[0][1].ToString();
            return ten;
        }
        #endregion
        //TimKiem NHan vien
        public DataTable getNhanVien(string Manv, string tennhanvien, string sdt)
        {
            string sql;
            try
            {
                if (string.IsNullOrWhiteSpace(Manv) == false)
                {
                    sql = "SELECT MANV as N'Mã Nhân Viên', HOTEN as N'Họ Và Tên' , SDT as N'Số Điện Thoại',NGAYSINH as N'Ngày Sinh',EMAIL ,GIOITINH as N'Giới Tính' ,DATHOIVIEC as N'Đã Thôi Việc',TENLOAI as N'Chức Vụ'" +
                        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where MANV LIKE N'%" + Manv + "%'";

                    return DataAccess.GetTable(sql);
                }
                //else
                //if (string.IsNullOrWhiteSpace(Manv) == false && string.IsNullOrWhiteSpace(tennhanvien) == false && string.IsNullOrWhiteSpace(sdt) == true)
                //{
                //    sql = "SELECT MANV, HOTEN, SDT,NGAYSINH,EMAIL,GIOITINH,HINHANH,DATHOIVIEC,TENLOAI " +
                //        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where MANV=N'"
                //        + Manv + "'" + " and HOTEN= N'" + tennhanvien + "'";

                //    return DataAccess.GetTable(sql);
                //}
                //else
                //if (string.IsNullOrWhiteSpace(Manv) == false && string.IsNullOrWhiteSpace(tennhanvien) == true && string.IsNullOrWhiteSpace(sdt) == false)
                //{
                //    sql = "SELECT MANV, HOTEN, SDT,NGAYSINH,EMAIL,GIOITINH,HINHANH,DATHOIVIEC,TENLOAI " +
                //        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where MANV=N'"
                //        + Manv + "' and SDT=N'" + sdt + "'";

                //    return DataAccess.GetTable(sql);
                //}
                else
                if (string.IsNullOrWhiteSpace(tennhanvien) == false)
                {
                    sql = "SELECT MANV as N'Mã Nhân Viên', HOTEN as N'Họ Và Tên' , SDT as N'Số Điện Thoại',NGAYSINH as N'Ngày Sinh',EMAIL ,GIOITINH as N'Giới Tính' ,DATHOIVIEC as N'Đã Thôi Việc',TENLOAI as N'Chức Vụ'" +
                        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where HOTEN LIKE N'%" + tennhanvien + "%'"; ;

                    return DataAccess.GetTable(sql);
                }
                //else
                //if (string.IsNullOrWhiteSpace(Manv) == true && string.IsNullOrWhiteSpace(tennhanvien) == false && string.IsNullOrWhiteSpace(sdt) == false)
                //{
                //    sql = "SELECT MANV, HOTEN, SDT,NGAYSINH,EMAIL,GIOITINH,HINHANH,DATHOIVIEC,TENLOAI " +
                //        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where HOTEN= N'" + tennhanvien + "' and SDT=N'" + sdt + "'";

                //    return DataAccess.GetTable(sql);
                //}

                else
                if (string.IsNullOrWhiteSpace(sdt) == false)
                {
                    sql = "SELECT MANV as N'Mã Nhân Viên', HOTEN as N'Họ Và Tên' , SDT as N'Số Điện Thoại',NGAYSINH as N'Ngày Sinh',EMAIL ,GIOITINH as N'Giới Tính' ,DATHOIVIEC as N'Đã Thôi Việc',TENLOAI as N'Chức Vụ'" +
                        "FROM NHANVIEN INNER JOIN LOAINHANVIEN ON NHANVIEN.MALOAI = LOAINHANVIEN.MALOAI where SDT LIKE N'%" + sdt + "%'";

                    return DataAccess.GetTable(sql);
                }
            }
            catch (Exception ex)
            {


            }
            return null;
        }
        // ket thcu tim kiem

        // xoa nhan vien

        public void deletebyMNV(List<string> listMNV)
        {
            foreach (string MNV in listMNV)
            {
                string sql = "delete from NHANVIEN where MANV ='" + MNV + "'";
                DataAccess.JustExcuteNoParameter(sql);
            }
        }
        // ket thuc xoa




        public void addnhanvien(string ten, DateTime ns, string sdt, string email, bool gioitinh, byte[] anh, string loainhanvien)
        {
            string sql = "insert into NHANVIEN (HOTEN,SDT,NGAYSINH,EMAIL,GIOITINH,HINHANH,MALOAI) VALUES (@HOTEN,@SDT,@NGAYSINH,@EMAIL,@GIOITINH,@HINHANH,@MALOAI) ";
            SqlConnection sqlConnection = new SqlConnection(@"Server=LAPTOP-M0F2IN9G\SQLEXPRESS;Database=PBL33333;User id=lich;pwd=123");
            sqlConnection.Open();
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add("@HOTEN", ten);
            sqlCommand.Parameters.Add("@SDT", sdt);
            sqlCommand.Parameters.Add("@NGAYSINH", ns);
            sqlCommand.Parameters.Add("@EMAIL", email);
            sqlCommand.Parameters.Add("@GIOITINH", gioitinh);
            sqlCommand.Parameters.Add("@HINHANH", anh);
            sqlCommand.Parameters.Add("@MALOAI", GetmanhanvienByTen(loainhanvien));
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool ThemNhanVien(NhanVienDTO nvDTO)
        {
            /*          try
                      {
                          */
            string sql = "INSERT INTO NHANVIEN VALUES(@HOTEN,@SDT,@NGAYSINH,@EMAIL,@GIOITINH,@HINHANH,@DATHOIVIEC,@MALOAI)";
            SqlConnection con = DataAccess.Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@HOTEN", nvDTO.TenNV);
            cmd.Parameters.AddWithValue("@SDT", nvDTO.SDT);
            cmd.Parameters.AddWithValue("@NGAYSINH", nvDTO.NgaySinh);
            cmd.Parameters.AddWithValue("@EMAIL", nvDTO.Email);
            cmd.Parameters.AddWithValue("@GIOITINH", nvDTO.GioiTinh);
            cmd.Parameters.AddWithValue("@HINHANH", nvDTO.HinhAnh);
            cmd.Parameters.AddWithValue("@DATHOIVIEC", 0);
            cmd.Parameters.AddWithValue("@MALOAI", nvDTO.MaLoaiNV);
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
        /*           catch (Exception ex)
                   {

                       return false;
                   }

               }
        */

        /*  public void upnhanvien(int ma,string ten, DateTime ns, string sdt, string email, bool gioitinh, byte[] anh, string loainhanvien)
          {
              int manv = Convert.ToInt32(ma);
              string sql = "update NHANVIEN set HOTEN=@HOTEN,SDT=@SDT,NGAYSINH=@NGAYSINH,EMAIL=@EMAIL,GIOITINH=@GIOITINH,HINHANH=@HINHANH,MALOAI=@MALOAI Where MANV=@MANV";
              SqlConnection sqlConnection = new SqlConnection(@"Server=LAPTOP-M0F2IN9G\SQLEXPRESS;Database=PBL33333;User id=lich;pwd=123");
              sqlConnection.Open();
              sqlCommand = new SqlCommand(sql, sqlConnection);
              sqlCommand.Parameters.Add("MANV", manv);
              sqlCommand.Parameters.Add("@HOTEN", ten);
              sqlCommand.Parameters.Add("@SDT", sdt);
              sqlCommand.Parameters.Add("@NGAYSINH", ns.ToShortDateString());
              sqlCommand.Parameters.Add("@EMAIL", email);
              sqlCommand.Parameters.Add("@GIOITINH", gioitinh);
              sqlCommand.Parameters.Add("@HINHANH", anh);
              sqlCommand.Parameters.Add("@MALOAI", GetmanhanvienByTen(loainhanvien));
              sqlCommand.ExecuteNonQuery();
              sqlConnection.Close();
          }
        */
        public bool upnhanvien(NhanVienDTO nvDOTNV)
        {

            //           try {
            int ma = nvDOTNV.MaNV;
            string sql = "update NHANVIEN set HOTEN=@HOTEN,SDT=@SDT,NGAYSINH=@NGAYSINH,EMAIL=@EMAIL,GIOITINH=@GIOITINH,HINHANH=@HINHANH,MALOAI=@MALOAI Where MANV=@MANV";
            SqlConnection con = DataAccess.Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("@MANV", ma);
            cmd.Parameters.Add("@HOTEN", nvDOTNV.TenNV.ToString());
            cmd.Parameters.Add("@SDT", nvDOTNV.SDT.ToString());
            cmd.Parameters.Add("@NGAYSINH", nvDOTNV.NgaySinh.ToShortDateString());
            cmd.Parameters.Add("@EMAIL", nvDOTNV.Email.ToString());
            cmd.Parameters.Add("@GIOITINH", nvDOTNV.GioiTinh);
            cmd.Parameters.Add("@HINHANH", nvDOTNV.HinhAnh);
            cmd.Parameters.Add("@MALOAI", nvDOTNV.MaLoaiNV);
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
        /*
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }


        }

 */
        public int GetmanhanvienByTen(string loainhanvien)
        {
            if (loainhanvien == "Admin") return 1;
            else return 2;
        }


        List<NhanVienDTO> nv = new List<NhanVienDTO>();
        public List<NhanVienDTO> NhanVien(List<NhanVienDTO> nhanvien)
        {
            nv = nhanvien;
            return nhanvien;
        }
        public NhanVienDTO getnhavienbyma(int Ma)
        {
            foreach (NhanVienDTO v in nv)
            {
                if (v.MaNV == Ma) return v;
            }
            return null;
        }



        public DataTable getAllmaloai()
        {
            string sql = "select (*) form LOAINHANVIEN ";
            return DataAccess.GetTable(sql);
        }
    }
}

