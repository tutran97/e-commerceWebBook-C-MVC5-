using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Reqquired BAT BUOC PHAI CO
//DataType KEU DU LIEU
//Compare Rang Buoc
namespace BanSach.Models
{
    public class doimatkhauModel
    {
        [Required]
        [Key]
        public int MaKH { get; set; }

        [Display(Name = "Tên Tài Khoản")]
        public string TaiKhoan {get; set; }

        [Display(Name = "Mật Khẩu Cũ")]//thiu ktra
        [Required(ErrorMessage = "Nhập Mật Khẩu Cũ")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Mật Khẩu Mới")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "ít nhất 6 ký tự!")]
        [Required(ErrorMessage = "Nhập Mật Khẩu Mới")]
        [DataType(DataType.Password)]
        public string MatKhauMoi { get; set; }

        [Display(Name = "Nhập Lại Mật Khẩu Mới")]
        [Required(ErrorMessage = "Nhập lại Mật Khẩu Mới")]
        [Compare("MatKhauMoi", ErrorMessage = "nhập lại mkmới thất bại!")]
        [DataType(DataType.Password)]
        public string NhapLaiMatKhauMoi { get; set; }

        //DOI THONG TIN
        [Display(Name = "Email")]
        [Required(ErrorMessage = "thiếu Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ!")]
        public string Email { get; set; }

        [Display(Name = "HọTên")]
        [Required(ErrorMessage = "thiếu!")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "thiếu!")]
        public GioiTinh GioiTinh { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "thiếu!")]
        public DateTime NgaySinh { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "So Dien Thoai")]
        [Required(ErrorMessage = "Thiếu!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
         ErrorMessage = "sai! SDT phải gồm 10 số")]
        public string SDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Yeu Cau Nhap Dia Chi!")]
        public string DiaChi { get; set; }
       
    }
   
}