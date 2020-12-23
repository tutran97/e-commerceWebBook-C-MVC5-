using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class HoaDonModel
    {
        [Key]
        public int MaDonHang { get; set; }
        public bool TinhTrangGiaoHang { get; set; }
        public DateTime NgayDat { get; set; }
        public int MaKH { get; set; }
        //Thông tin giao cua ThongTinGiaoHangModel

        [Required(ErrorMessage = "Thiếu!")]
        public string HoTen { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "So Dien Thoai")]
        [Required(ErrorMessage = "Thiếu!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai! SDT phải gồm 10 số")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "thiếu Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Thiếu!")]
        public string DiaChi { get; set; }


    }
}