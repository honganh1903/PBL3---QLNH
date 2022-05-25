using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class CTSPBL
    {
        private static CTSPBL _Instance;
        public static CTSPBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CTSPBL();
                }
                return _Instance;
            }
        }
        private CTSPBL() { }
        public DataTable GetDanhSachNguyenLieu(int MASP)
        {
            return CTSPDL.Instance.GetDanhSachNguyenLieu(MASP);
        }
        public bool ThemThanhPhan(int MASP, int MANL, int SoLuong)
        {
            return CTSPDL.Instance.ThemThanhPhan(MASP, MANL, SoLuong);
        }
    }
}
