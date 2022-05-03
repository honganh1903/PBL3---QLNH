using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBL
    {
        private static TaiKhoanBL _Instance;
        public static TaiKhoanBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TaiKhoanBL();
                }
                return _Instance;
            }
        }
        private TaiKhoanBL() { }
        public int GetMaQuyen(int manv)
        {
            return TaiKhoanDL.Instance.GetMaQuyen(manv);
        }
        public bool CheckLogin(string manv, string mk)
        {
            if (TaiKhoanDL.Instance.KiemTraDangNhap(manv.Trim().ToString(), mk.Trim().ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetTenQuyen(int maquyen)
        {
            return TaiKhoanDL.Instance.GetTenQuyen(maquyen);
        }
    }
}
