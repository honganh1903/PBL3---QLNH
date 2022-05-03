using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiNhanVienBL
    {
        private static LoaiNhanVienBL _Instance;
        public static LoaiNhanVienBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiNhanVienBL();
                }
                return _Instance;
            }
        }
        private LoaiNhanVienBL() { }
    }
}
