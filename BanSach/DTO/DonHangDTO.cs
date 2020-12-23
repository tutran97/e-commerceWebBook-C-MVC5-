using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {
        public int MaDonHang { get; set; }
     
        public bool TinhTrangGiaoHang { get; set; }
        public DateTime NgayDat { get; set; }
       
        public int MaKH { get; set; }
        public List<ChiTietDonHangDTO> SanPham { get; set; }

        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

    }
}
