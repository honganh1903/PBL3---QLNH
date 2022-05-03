using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;

namespace BLL
{
    public class LoaiSanPhamBL
    {
        private static LoaiSanPhamBL _Instance;
        public static LoaiSanPhamBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiSanPhamBL();
                }
                return _Instance;
            }
        }
        private LoaiSanPhamBL() { }
        public DataTable GetDanhSachLoaiSanPham()
        {
            return LoaiSanPhamDL.Instance.GetDanhSachLoaiSanPham();
        }
        public bool ThemLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            return LoaiSanPhamDL.Instance.ThemLoaiSanPham(lspDTO);
        }
        public bool NgungKinhDoanh(string MALOAISP)
        {
            return LoaiSanPhamDL.Instance.NgungKinhDoanh(MALOAISP);
        }
        public bool CapNhatLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            return LoaiSanPhamDL.Instance.CapNhatLoaiSanPham(lspDTO);
        }
        public bool CheckMaLoaiSP(string MALOAISP)
        {
            return LoaiSanPhamDL.Instance.CheckMaLoaiSP(MALOAISP);
        }
    }
}
