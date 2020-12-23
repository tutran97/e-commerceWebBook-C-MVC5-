using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;

namespace BanSach.Controllers
{
    public class BaseController : Controller
    {

        GioHangBUS giohangBUS = new GioHangBUS();

        public int getCartId()//gan ID cho gio hang cung la ID Cookies
        {
            int cartId = 0;

            // trình duyệt co id gio hang Trog db r
            if (Request.Cookies["MaGioHang"] != null)
            {
                cartId = int.Parse(Request.Cookies["MaGioHang"].Value.ToString());//IDgiohang= đã co trong cookies
            }
            //ko co san Tao MOI
            else
            {   //tao giohang voi ID moi tu ham Create
                Response.Cookies["MaGioHang"].Value = giohangBUS.Create(Session["UserId"] != null ? int.Parse(Session["UserId"].ToString()) : 0).ToString();
                Response.Cookies["MaGioHang"].Expires = DateTime.Now.AddDays(30);//gioi han ton tai cua cookies
            }

            return cartId;
        }
    }
}