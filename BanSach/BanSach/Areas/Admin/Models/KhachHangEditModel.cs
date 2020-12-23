using BanSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class KhachHangEditModel
    {
        [Required]
        [Key]
        public int MaKH { get; set; }

        [Display(Name = "Tên Tài Khoản")]
        //[Required(ErrorMessage = "Thiếu")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Nhập Mật Khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        //DOI THONG TIN
        [Display(Name = "Email")]
        [Required(ErrorMessage = "thiếu Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ!")]
        public string Email { get; set; }

        [Display(Name = "HọTên")]
        [Required(ErrorMessage = "Thiếu!")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Thiếu!")]
        public GioiTinh GioiTinh { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Thiếu!")]
        public DateTime NgaySinh { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "So Dien Thoai")]
        [Required(ErrorMessage = "Thiếu!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai! SDT phải gồm 10 số")]
        public string SDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Yeu Cau Nhap So Dia Chi!")]
        public string DiaChi { get; set; }

    }

}