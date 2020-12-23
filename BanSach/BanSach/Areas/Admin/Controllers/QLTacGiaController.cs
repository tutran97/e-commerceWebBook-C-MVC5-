using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using PagedList;
using PagedList.Mvc;
using BanSach.Areas.Admin.Models;

namespace BanSach.Areas.Admin.Controllers
{
    public class QLTacGiaController : BaseController
    {
        TacGiaBUS tacgiaBus = new TacGiaBUS();
        SachBUS sachBus = new SachBUS();
        //LAY DANH SACH TAC GIA
        // GET: Admin/ChuDe
        [HttpGet]
        public ActionResult Index(int? page,string timkiem)
        {
            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = tacgiaBus.LayDanhSach(timkiem).ToPagedList(pageNumber, pageSize);

            ViewBag.timkiem = timkiem;
            return View(model);
        }
        //LẤY THÔNG TIN
        // GET: Admin/TacGia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //THEM TAC GIA
        // GET: Admin/TacGia/ThemTacGia
        [HttpGet]
        public ActionResult ThemTacGia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTacGia(TacGiaModel model)
        {
            if (ModelState.IsValid)
            {
                var tacgiaDTO = new DTO.TacGiaDTO()
                {
                    MaTacGia = model.MaTacGia,
                    TenTacGia = model.TenTacGia,
                    TieuSu = model.TieuSu,
                    DienThoai=model.DienThoai,
                    DiaChi=model.DiaChi,
                    TrangThai=model.TrangThai

                };
                tacgiaBus.ThemTacGia(tacgiaDTO);
                return RedirectToAction("index", "qltacgia", new { Areas = "admin" });
            }
            return View();

        }

        //CAP NHAT CHU DE
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var tacgia = new DTO.TacGiaDTO();
            //BUS.laysach(masach) => DTO
            tacgia = tacgiaBus.LayTG(id);
            // DTO => Model
            TacGiaModel tacgiaModel = new TacGiaModel()
            {
                MaTacGia = tacgia.MaTacGia,
                TenTacGia = tacgia.TenTacGia,
                TieuSu=tacgia.TieuSu,
                DienThoai=tacgia.DienThoai,
                DiaChi=tacgia.DiaChi,
                TrangThai=true
            };
            return View(tacgiaModel);
            //Return view(model)
        }
        [HttpPost]
        public ActionResult Sua(TacGiaModel model)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                var tacgia = new DTO.TacGiaDTO(); // Tao sach DTO
                                                  // Bo gia tri tu MOdel => DTO
                tacgia.MaTacGia = model.MaTacGia;
                tacgia.TenTacGia = model.TenTacGia;
                tacgia.TieuSu = model.TieuSu;
                tacgia.DienThoai = model.DienThoai;
                tacgia.DiaChi = model.DiaChi;
                tacgia.TrangThai = model.TrangThai;
                //GOi ham trong BUS
                bool kq = tacgiaBus.Edit(tacgia);
                if (kq)
                {
                    return RedirectToAction("index", "qltacgia", new { Areas = "admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại !");
                }
            }
            return View(model);

        }

        //xoa 
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            if (id > 0)
            {
                var model = tacgiaBus.LayTG(id);
               
                tacgiaBus.Delete(model);
                return RedirectToAction("index", "qltacgia", new { Controller = "admin" });
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
                var model = tacgiaBus.LayTG(id);
                tacgiaBus.DeleteLuon(model);
                return RedirectToAction("index", "qltacgia", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }
    }
}