using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class TacGiaModel
    {
        [Key]
        public int MaTacGia { get; set; }


        [Display(Name ="Tên tác giả")]
        [Required(ErrorMessage ="thiếu!")]
        public string TenTacGia { get; set; }

        [Display(Name = "Nhập Địa Chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Nhập Tiểu sử")]
        public string TieuSu { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = " SDT")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "sai số hoặc SDT phải gồm 10 số")]
        public string DienThoai { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
    }
}