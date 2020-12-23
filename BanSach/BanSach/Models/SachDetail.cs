using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.Models
{
    public class SachDetail
    {
     
        public int MaSach { get; set; }

      
        public string TenSach { get; set; }

        public double GiaBan { get; set; }

        public double GiaCu { get; set; }

        public double GiaGiam { get; set; }

        public string MoTa { get; set; }

   
        public string AnhBia { get; set; }

        public DateTime NgayCapNhat { get; set; }
        
        public int SoLuongTon { get; set; }

        public string NhaXuatBan { get; set; }

        public string ChuDe { get; set; }

        public string TacGia { get; set; }
        public bool TrangThai { get; set; }

    }
}
