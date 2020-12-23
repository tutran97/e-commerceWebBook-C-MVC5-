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
        
        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }
        public string HoTen { get; set; }

        
        public DateTime NgaySinh { get; set; }
        
        public string Email { get; set; }
        
        public string GioiTinh { get; set; }
        
        public string DienThoai { get; set; }

        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }

        public int MaLoaiKH { get; set; }
    }

   
}
