using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class GioHangLine
    {
        public int MaGioHang { get; set; }

        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public string HinhAnh { get; set; }

        public double GiaBan { get; set; }

        public int SoLuong { get; set; }

    }
}