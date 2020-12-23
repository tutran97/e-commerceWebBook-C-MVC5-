using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class LoginModel
    {
        [Required]
        public int MaKH { get; set; }

        [Display(Name ="Tài Khoản")]
        [Required(ErrorMessage ="Thiếu!")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage ="Thiếu!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}