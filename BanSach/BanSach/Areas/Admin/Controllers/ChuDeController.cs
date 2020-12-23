
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanSach.Areas.Admin.Models;
using BUS;
using DTO;
using PagedList;
using PagedList.Mvc;

namespace BanSach.Areas.Admin.Controllers
{
    public class ChuDeController : BaseController
    {
        ChuDeBUS chuDeBus = new ChuDeBUS();
        SachBUS sachBus = new SachBUS();
        //LAY DANH SACH CHU DE
        // GET: Admin/ChuDe
        [HttpGet]
        public ActionResult Index(string timkiem, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            var model = chuDeBus.LayDanhSach(timkiem).ToPagedList(pageNumber, pageSize);
            ViewBag.timkiem = timkiem;
            return View(model);
        }
        //LẤY THÔNG TIN
        // GET: Admin/ChuDe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //THEM CHU DE
        // GET: Admin/ChuDe/ThemChuDe
        [HttpGet]
        public ActionResult ThemChuDe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemChuDe(ChuDeModel model)
        {
            if (ModelState.IsValid)
            {
                var chudeDTO = new DTO.ChuDeDTO()
                {
                    MaChuDe = model.MaChuDe,
                    TenChuDe = model.TenChuDe,
                    TrangThai = model.TrangThai
                    
                };
                chuDeBus.ThemChuDe(chudeDTO);
                return RedirectToAction("index", "chude", new { Areas = "admin" });
            }
            return View();

        }

        //CAP NHAT CHU DE
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var chude = new DTO.ChuDeDTO();
            //BUS.laysach(masach) => DTO
            chude = chuDeBus.LayChuDe(id);
            // DTO => Model
            ChuDeModel chudeModel = new ChuDeModel()
            {
                MaChuDe = chude.MaChuDe,
                TenChuDe= chude.TenChuDe,
                TrangThai = true
            };
            return View(chudeModel);
            //Return view(model)
        }
        [HttpPost]
        public ActionResult Sua(ChuDeModel model)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                var chude = new DTO.ChuDeDTO(); // Tao sach DTO
                // Bo gia tri tu MOdel => DTO
                chude.MaChuDe = model.MaChuDe;
                chude.TenChuDe = model.TenChuDe;
                chude.TrangThai = model.TrangThai;
                //GOi ham trong BUS
                bool kq = chuDeBus.Edit(chude);
                if (kq)
                {
                    return RedirectToAction("index", "ChuDe", new { Areas = "admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại !");
                }
            }
            return View(model);

        }

        //xoa chu de
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            if(id>0)
            {
                var model = chuDeBus.LayChuDe(id);
                
                
                chuDeBus.Delete(model);
                return RedirectToAction("index","chude", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }
            
            return View();
        }
        //xoa luon
        [HttpGet]
        public ActionResult XoaLuon(int id)
        {
            if (id > 0)
            {
                var model = chuDeBus.LayChuDe(id);


                chuDeBus.DeleteLuon(model);
                return RedirectToAction("index", "chude", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }
    }
}
