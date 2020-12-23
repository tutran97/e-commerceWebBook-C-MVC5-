using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    [Serializable]
    public class UserLogin
    {
        public int MaKH { get; set; }
        public string TaiKhoan { get; set; }
    }
}
