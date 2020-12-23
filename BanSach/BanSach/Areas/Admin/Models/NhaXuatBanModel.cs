using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class NhaXuatBanModel
    {
        [Key]
        public int MaNXB { get; set; }

        [Display(Name ="Tên Nhà Xuất Bản")]
        [Required(ErrorMessage ="Thiếu!")]
        public string TenNXB { get; set; }

        //[Required(ErrorMessage = "Thiếu!")]
        [Display(Name = " Địa Chỉ")]
        public string DiaChi { get; set; }

        [DataType(DataType.PhoneNumber)]
        //[Required(ErrorMessage = "Thiếu!")]
        [Display(Name = " SDT")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai số hoặc SDT phải gồm 10 số")]
        public string DienThoai { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
    }
}