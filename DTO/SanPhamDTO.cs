using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaLoaiSP { get; set; }
        public string DVT { get; set; }
        public int MaNCC { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public int LoiNhuan { get; set; }
        public decimal GiaBan { get; set; }
        public int KhuyenMai { get; set; }
        public byte[] HinhAnh { get; set; }
        public double TongDoanhThu { get; set; }
    }
}
