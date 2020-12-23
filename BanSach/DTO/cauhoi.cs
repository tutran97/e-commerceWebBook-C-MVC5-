using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//23-6 / LOC tham so truyen vao ngay timkiem ban 24-6
namespace DTO
{
    class cauhoi
    {
        //Sach DTO va Sach EF khac nhau ???
        //dto MODEL la cua minh , DTO la giong SQL
    }
}
//post la lay du lieu tu model ve su dung
//get la gan dl model cho DTO
//Controller
//Request.Cookies
//Request.Cookies["id"];
//View
//@Request.Cookies
//@Request.Cookies["id"]
//Model
//HttpContext.Current.Request.Cookies
//HttpContext.Current.Request.Cookies["id"];
//Tạo mới Cookie
//Các thuộc tính và phương thức của Cookie
//Value
//Giá trị của Cookie
//myCookie.Value = "ABCD123";
//Name
//Tên của Cookie
//myCookie.Name = "ids";
//Expires
//Thời hạn tồn tại của Cookie
//myCookie.Expires = DateTime.Now.AddDays(1);
//Values.Add(Key, Value)
//Thêm 1 giá trị
//myCookie.Values.Add("id2", "DEF345");
//Values[Key] = Value
//Thêm mới hoặc thay thế 1 giá trị
//myCookie.Values["id"] = "ABCDEF";
//Chú ý: để xóa 1 cookie
//myCookie.Expires = DateTime.Now.AddDays(-1);