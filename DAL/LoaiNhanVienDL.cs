using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class LoaiNhanVienDL
    {
        private static LoaiNhanVienDL _Instance;
        public static LoaiNhanVienDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiNhanVienDL();
                }
                return _Instance;
            }
        }
        private LoaiNhanVienDL() { }
        public DataTable SetCBB(string query)
        {
            return DataAccess.GetTable(query);
        }
    }
}
