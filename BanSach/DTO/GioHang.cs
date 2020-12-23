using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHang
    {
        public int MaGioHang { get; set; }

        public int MaKH { get; set; }

        public DateTime NgayTao { get; set; }

        public List<ChiTietGioHang> SanPham { get; set; }
    }
}
