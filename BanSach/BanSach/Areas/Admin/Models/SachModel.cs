using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class SachModel
    {
        [Key]
        public int MaSach { get; set; }

        [Required(ErrorMessage = "Thiếu!")]
        [Display(Name = "Tên sách ")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Thiếu!")]
        [DataType(DataType.Currency)]
        [Display(Name = "Giá Bán ")]
        public double GiaBan { get; set; }

        [Range(0,100, ErrorMessage = "Nhập sai Phạm Vi!")]
        [Required(ErrorMessage = "Thiếu hoặc sai !")]
        [DataType(DataType.Currency)]
        [Display(Name = "% Giá Giảm ")]
        public double GiaGiam { get; set; }

        [Required(ErrorMessage = "Thiếu hoặc sai !")]
        [DataType(DataType.Currency)]
        [Display(Name = "Giá Gốc ")]
        public double GiaCu { get; set; }

        [Display(Name = "Mô Tả")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Thiếu!")]
        public string MoTa { get; set; }

        [Display(Name = "Ảnh")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Thiếu!")]
        public string AnhBia { get; set; }

        [Display(Name = "Ngày")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Thiếu!")]
        public DateTime NgayCapNhat { get; set; }

        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Thiếu!")]
        public int SoLuongTon { get; set; }

        [Display(Name = "Nhà Xuất Bản")]
        [Required(ErrorMessage = "Thiếu!")]
        public int MaNXB { get; set; }

        [Display(Name = "Chủ Đề")]
        [Required(ErrorMessage = "Thiếu!")]
        public int MaChuDe { get; set; }

        [Required(ErrorMessage = "Thiếu!")]
        [Display(Name = "Tác Giả")]
        public int MaTacGia { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
    }
}