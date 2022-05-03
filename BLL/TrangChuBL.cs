using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TrangChuBL
    {
        private static TrangChuBL _Instance;
        public static TrangChuBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TrangChuBL();
                }
                return _Instance;
            }
        }
        private TrangChuBL() { }
    }
}
