using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TrangChuDL
    {
        private static TrangChuDL _Instance;
        public static TrangChuDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TrangChuDL();
                }
                return _Instance;
            }
        }
        private TrangChuDL() { }
    }
}
