using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
using PagedList;
using PagedList.Mvc;

namespace BanSach.Areas.Admin.Controllers
{
    public class QLHoaDonController : Controller
    {
        SachBUS sachBus = new SachBUS();
        KhachHangBUS khachhangBus = new KhachHangBUS();
        DonHangBUS hoadonBus = new DonHangBUS();

        // GET: Admin/QLHoaDon
        public ActionResult Index(int? page,string timkiem)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            var model = hoadonBus.LayDanhSach(timkiem).OrderByDescending(x => x.NgayDat).ToPagedList(pageNumber, pageSize);
            ViewBag.timkiem = timkiem;
            return View(model);
        }
        //xoa=hoanthanh
        [HttpGet]
        public ActionResult Xoa(int id)
        {

            if (id > 0)
            {
                var model = hoadonBus.LayHoaDon(id);

                hoadonBus.Delete(model.MaDonHang);
                return RedirectToAction("index", "qlhoadon", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }

    }
}