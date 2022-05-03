using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool DaXoa { get; set; }
        public decimal DoanhSo { get; set; }
    }
}
