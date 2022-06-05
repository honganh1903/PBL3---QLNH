using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class NhanVienBL
    {
        private static NhanVienBL _Instance;
        public static NhanVienBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NhanVienBL();
                }
                return _Instance;
            }
        }
        private NhanVienBL() { }
        public string GetTenNhanVien(int manv)
        {
            return NhanVienDL.Instance.GetTenNhanVien(manv);
        }
        public DataTable getAllNhanVien()
        {
            return NhanVienDL.Instance.getAllNhanVien();
        }
        public DataTable getNhanVien(string Manv, string tennhanvien, string sdt)
        {
            return NhanVienDL.Instance.getNhanVien(Manv, tennhanvien, sdt);
        }
        public void deletebyMNV(List<string> MNV)
        {
            NhanVienDL.Instance.deletebyMNV(MNV);
        }
        public bool ThemNhanVien(NhanVienDTO nvDTO)
        {
            return NhanVienDL.Instance.ThemNhanVien(nvDTO);
        }
        public bool upnhanvien(NhanVienDTO nhanvien)
        {
            return NhanVienDL.Instance.upnhanvien(nhanvien);
        }
        public void addlist(List<NhanVienDTO> NV)
        {
            NhanVienDL.Instance.NhanVien(NV);
        }
        public NhanVienDTO getnhanvienbyma(string ma)
        {
            int manv = Convert.ToInt32(ma);
            return NhanVienDL.Instance.getnhavienbyma(manv);
        }

    }
}
