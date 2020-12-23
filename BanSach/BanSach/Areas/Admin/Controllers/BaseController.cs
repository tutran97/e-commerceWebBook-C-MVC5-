using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BUS;

namespace BanSach.Areas.Admin.Controllers
{

    public class BaseController : Controller
    {
        BUS.KhachHangBUS khachhangBus = new KhachHangBUS();



        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //neu ko dang nhap 
            if (Session["UserID"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "home", action = "dangnhap", Area = "" }));
            }
            else
            {  //neu ko phai admin tra ve trang dangnhap
                if (!khachhangBus.IsAdmin(int.Parse(Session["UserID"].ToString())))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "home", action = "dangnhap", Area = "" }));
                }
            }
            //duoc phep vao admin
            base.OnActionExecuting(filterContext);
            
        }
    }
}