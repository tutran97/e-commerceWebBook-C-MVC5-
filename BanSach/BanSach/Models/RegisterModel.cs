using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Models
{
    public class RegisterModel
    {
        [Key]
        public int MaKH { get; set; }

        [Display(Name = "Tên Tài Khoản")]
        [Required(ErrorMessage = "Thiếu")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật Khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="ít nhất 6 ký tự!")]
        [Required(ErrorMessage = "Thiếu!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Nhập Lại Mật Khẩu!")]
        [Compare("MatKhau",ErrorMessage ="xác nhận thất bại!")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Thiếu")]
        public string NhapLaiMatKhau { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "thiếu Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ!")]
        public string Email { get; set; }

        [Display(Name = "HọTên")]
        [Required(ErrorMessage = "thiếu!")]
        public string HoTen { get; set; }

        [Display(Name = "Giới Tính")]
        [Required(ErrorMessage = "thiếu!")]
        public GioiTinh GioiTinh { get; set; }

        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "thiếu!")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "So Dien Thoai")]
        [Required(ErrorMessage = "Thiếu!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai! SDT phải gồm 10 số")]
        public string SDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "thiếu!")]
        public string DiaChi { get; set; }
    }

    public enum GioiTinh
    {
        Nam,
        Nữ
    }
}