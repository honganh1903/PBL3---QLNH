using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class CTHDBL
    {
        private static CTHDBL _Instance;
        public static CTHDBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CTHDBL();
                }
                return _Instance;
            }
        }
        private CTHDBL() { }
        public bool ThemCTHD(DataTable dt, int SOHD, decimal THANHTIEN)
        {
            return CTHDDL.Instance.ThemCTHD(dt, SOHD, THANHTIEN);
        }
    }
}
