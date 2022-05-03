using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int MaNNV { get; set; }
        public string TenNV { get; set; }
        public int MaLoaiNV { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool DaThoiViec { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}
