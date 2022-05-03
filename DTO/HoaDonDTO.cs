using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int SoHD { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal ThanhTien { get; set; }
        public bool DaThanhToan { get; set; }
        public decimal TienKhachHangTra { get; set; }
        public decimal TienThua { get; set; }

    }
}
