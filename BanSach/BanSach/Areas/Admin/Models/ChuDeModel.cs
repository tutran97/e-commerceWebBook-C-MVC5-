using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class ChuDeModel
    {
        [Key]
        public int MaChuDe { get; set; }

        [Required(ErrorMessage = "Thiếu!")]
        [Display(Name = "Tên Chủ Đề ")]
        //[Required(ErrorMessage = "Yeu Cau Nhap Tai Khoan!")]
        public string TenChuDe { get; set; }

        [Display(Name = "Trạng Thái")]
        //[Required(ErrorMessage = "Thiếu!")]
        public bool TrangThai { get; set; }

    }
}