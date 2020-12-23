using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class GioHangHeader
    {
        public int MaGioHang { get; set; }

        public int MaKH { get; set; }

        public DateTime NgayTao { get; set; }

        public List<GioHangLine> Line { get; set; }
    }
}