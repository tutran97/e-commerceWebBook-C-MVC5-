using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using BUS;
using DTO;
using BanSach.Areas.Admin.Models;

namespace BanSach.Areas.Admin.Controllers
{
    public class QLNhaXuatBanController : BaseController
    {
        NhaXuatBanBUS nxbBus = new NhaXuatBanBUS();
        SachBUS sachBus = new SachBUS();
        //LAY DANH SACH TAC GIA
        // GET: Admin/nxb
        [HttpGet]
        public ActionResult Index(int? page, string timkiem)
        {
            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = nxbBus.LayDanhSach(timkiem).ToPagedList(pageNumber, pageSize);

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
        public ActionResult ThemNXB()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNXB(NhaXuatBanModel model)
        {
            if (ModelState.IsValid)
            {
                var nxbDTO = new DTO.NhaXuatBanDTO()
                {
                    MaNXB = model.MaNXB,
                    TenNXB = model.TenNXB,
                    DienThoai = model.DienThoai,
                    DiaChi = model.DiaChi,
                    TrangThai=true

                };
                nxbBus.ThemNXB(nxbDTO);
                return RedirectToAction("index", "qlnhaxuatban", new { Areas = "admin" });
            }
            return View();

        }

        //CAP NHAT CHU DE
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var nxb = new DTO.NhaXuatBanDTO();
            //BUS.laysach(masach) => DTO
            nxb = nxbBus.LayNXB(id);
            // DTO => Model
            NhaXuatBanModel nxbModel = new NhaXuatBanModel()
            {
                
                MaNXB = nxb.MaNXB,
                TenNXB = nxb.TenNXB,
                DienThoai = nxb.DienThoai,
                DiaChi = nxb.DiaChi,
               TrangThai=nxb.TrangThai
                

            };
            return View(nxbModel);
            //Return view(model)
        }
        [HttpPost]
        public ActionResult Sua(NhaXuatBanModel model)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                var nxb = new DTO.NhaXuatBanDTO(); // Tao sach DTO
                                                   // Bo gia tri tu MOdel => DTO
                nxb.MaNXB = model.MaNXB;
                nxb.TenNXB = model.TenNXB;
                nxb.DienThoai = model.DienThoai;
                nxb.DiaChi = model.DiaChi;
                nxb.TrangThai = model.TrangThai;
                //GOi ham trong BUS
                bool kq = nxbBus.Edit(nxb);
                if (kq)
                {
                    return RedirectToAction("index", "qlnhaxuatban", new { Areas = "admin" });
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
            if (id > 0)
            {
                var model = nxbBus.LayNXB(id);
                
                nxbBus.Delete(model);
                return RedirectToAction("index", "qlnhaxuatban", new { Controller = "admin" });
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
                var model = nxbBus.LayNXB(id);


                nxbBus.DeleteLuon(model);
                return RedirectToAction("index", "qlnhaxuatban", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }
    }
}