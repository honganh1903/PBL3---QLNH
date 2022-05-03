using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class NCCBL
    {
        private static NCCBL _Instance;
        public static NCCBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NCCBL();
                }
                return _Instance;
            }
        }
        private NCCBL() { }
        public DataTable GetDanhSachNCC()
        {
            return NCCDL.Instance.GetDanhSachNCC();
        }
        public bool ThemNCC(NhaCungCapDTO nccDTO)
        {
            return NCCDL.Instance.ThemNCC(nccDTO);
        }
        public bool ThemNCCFull(NhaCungCapDTO nccDTO)
        {
            return NCCDL.Instance.ThemNCCFull(nccDTO);
        }
        public string GetTenNCC(int MANCC)
        {
            return NCCDL.Instance.GetTenNCC(MANCC);
        }
        public bool XoaNCC(string MANCC)
        {
            return NCCDL.Instance.NgungHopTacNCC(MANCC);
        }
        public bool CapNhatNCC(NhaCungCapDTO nccDTO)
        {
            return NCCDL.Instance.CapNhatNCC(nccDTO);
        }
        public bool CheckMaNCC(string MANCC)
        {
            return NCCDL.Instance.CheckMaNCC(MANCC);
        }
    }
}
