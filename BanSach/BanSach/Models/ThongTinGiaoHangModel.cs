using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class ThongTinGiaoHangModel
    {
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "thiếu")]
        public string HoTen { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "SDT")]
        [Required(ErrorMessage = "Thiếu!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai! SDT phải gồm 10 số")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "thiếu Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ!")]
        public string Email { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "thiếu")]
        public string DiaChi { get; set; }

        //[Display(Name = "Ngày Giao")]
        //[Required(ErrorMessage = "thiếu!")]
        //[DataType(DataType.Date)]
        //public DateTime NgayGiao { get; set; } 
    }
}