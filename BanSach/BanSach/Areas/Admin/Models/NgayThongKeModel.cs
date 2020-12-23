using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanSach.Areas.Admin.Models
{
    public class NgayThongKeModel
    {

        [Display(Name = "Từ Ngày")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Đến Ngày")]
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }
        
    }
}