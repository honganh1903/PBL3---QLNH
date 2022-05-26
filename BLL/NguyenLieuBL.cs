using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class NguyenLieuBL
    {
        private static NguyenLieuBL _Instance;
        public static NguyenLieuBL Instance
        {
            get
            { 
                if (_Instance == null)
                {
                    _Instance = new NguyenLieuBL();
                }
                return _Instance;
            }
        }
        private NguyenLieuBL() { }
        public DataTable GetDanhSachNguyenLieu()
        {
            return NguyenLieuDL.Instance.GetDanhSachNguyenLieu();
        }
        public string GetTenNL(int MANL)
        {
            return NguyenLieuDL.Instance.GetTenNL(MANL);
        }
        public DataTable GetDanhSachNguyenLieuTheoNCC(int MANCC)
        {
            return NguyenLieuDL.Instance.GetDanhSachNguyenLieuTheoNCC(MANCC);
        }
        public bool ThemNL(NguyenLieuDTO nlDTO)
        {
            return NguyenLieuDL.Instance.ThemNL(nlDTO);
        }
        public bool CapNhatNL(NguyenLieuDTO nlDTO)
        {
            return NguyenLieuDL.Instance.CapNhatNL(nlDTO);
        }
        public bool XoaNL(int nlDTO)
        {
            return NguyenLieuDL.Instance.XoaNguyenLieu(nlDTO);
        }
    }
}
