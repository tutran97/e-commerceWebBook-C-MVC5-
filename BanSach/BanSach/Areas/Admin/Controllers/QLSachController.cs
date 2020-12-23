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
    public class QLSachController : BaseController
    {
        SachBUS sachBus = new SachBUS();
        TacGiaBUS tacgiaBus = new TacGiaBUS();
        ChuDeBUS chudeBus = new ChuDeBUS();
        NhaXuatBanBUS nxbBus = new NhaXuatBanBUS();

        [HttpGet]
        public ActionResult Index(string timkiem, int? page, string find = "macdinh")
        {
            Session["find"] = find;
            Session["sort"] = "?find=" + find;

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            var model = new List<BanSach.Models.SachDetail>();

            foreach (var sach in sachBus.LayDanhSach(timkiem))
            {
                model.Add(new BanSach.Models.SachDetail()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                    GiaCu=sach.GiaCu,
                    GiaBan = sach.GiaBan,
                    SoLuongTon = sach.SoLuongTon,
                    MoTa = sach.MoTa,
                    NgayCapNhat = sach.NgayCapNhat,
                    NhaXuatBan = nxbBus.LayNXB(sach.MaNXB).TenNXB,
                    TacGia = tacgiaBus.LayTG(sach.MaTacGia).TenTacGia
                });
            }
            //sap xep
            if (find == "tangdan")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderBy(x => x.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            if (find == "giamdan")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderByDescending(x => x.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            if (find == "ngaymoi")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderByDescending(x => x.NgayCapNhat).ToPagedList(pageNumber, pageSize));
            }
            if (find == "ngaycu")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderBy(x => x.NgayCapNhat).ToPagedList(pageNumber, pageSize));
            }

            ViewBag.timkiem = timkiem;
            return View(model.OrderByDescending(x => x.NgayCapNhat).ToPagedList(pageNumber, pageSize));
        }

        //Them Moi Sach
        [HttpGet]
        public ActionResult ThemSach()
        {
            //Lay danh sach tac gia de lay dc tên
            
            SetViewBag();

            return View();
        }
        [HttpPost]
        public ActionResult ThemSach(SachModel model)
        {
            if (ModelState.IsValid)
            {
                var sachDT = new DTO.SachDTO()
                {
                    MaSach = model.MaSach,
                    TenSach = model.TenSach,
                    GiaCu=model.GiaCu,
                    GiaBan = model.GiaCu*(model.GiaGiam/100),
                    GiaGiam=model.GiaGiam,
                    MoTa = model.MoTa,
                    AnhBia = model.AnhBia,
                    NgayCapNhat = model.NgayCapNhat,
                    SoLuongTon = model.SoLuongTon,
                    MaNXB = model.MaNXB,
                    MaChuDe = model.MaChuDe,
                    MaTacGia= model.MaTacGia,
                    TrangThai = true
                };
                if(model.GiaGiam==0)
                {
                    sachDT.GiaBan = sachDT.GiaCu;
                }
                sachBus.ThemSach(sachDT);
                return RedirectToAction("index", "qlsach", new { Areas = "admin" });
            }
            SetViewBag();
            return View(model);

        }
        //cap nhat sach
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var sach = new DTO.SachDTO();
            //BUS.laysach(masach) => DTO
            sach = sachBus.LaySach(id);
            // DTO => Model
            SachModel sachModel = new SachModel()
            {
                MaSach=sach.MaSach,
                TenSach = sach.TenSach,
                GiaBan =sach.GiaBan /*sach.GiaCu * (sach.GiaGiam / 100)*/,
                GiaGiam = sach.GiaGiam,
                GiaCu=sach.GiaCu,
                MoTa = sach.MoTa,
                AnhBia = sach.AnhBia,
                //NgayCapNhat = sach.NgayCapNhat,
                SoLuongTon = sach.SoLuongTon,
                MaNXB = sach.MaNXB,
                MaChuDe = sach.MaChuDe,
                MaTacGia=sach.MaTacGia,
                TrangThai = true
            };
            SetViewBag();

            return View(sachModel);
            //Return view(model)
        }
        [HttpPost]
        public ActionResult Sua(SachModel model)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                var Sach = new DTO.SachDTO(); // Tao sach DTO
                // Bo gia tri tu MOdel => DTO
                Sach.MaSach = model.MaSach;
                Sach.TenSach = model.TenSach;
                Sach.GiaCu = model.GiaCu;
                Sach.GiaGiam = model.GiaGiam;
                Sach.GiaBan = model.GiaCu * (model.GiaGiam / 100);
                Sach.MaChuDe = model.MaChuDe;
                Sach.MaNXB = model.MaNXB;
                Sach.MaTacGia = model.MaTacGia;
                Sach.MoTa = model.MoTa;
               // Sach.NgayCapNhat = model.NgayCapNhat;
                Sach.SoLuongTon = model.SoLuongTon;
                Sach.AnhBia = model.AnhBia;
                //GOi ham trong BUS
                if (model.GiaGiam == 0)
                {
                    Sach.GiaBan = model.GiaCu;
                }
                bool kq=sachBus.Edit(Sach);
                if(kq)
                {
                    return RedirectToAction("index", "qlsach", new { Areas = "admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại !");
                }
            }
            SetViewBag();
            return View(model);

        }
      
        [HttpGet]
        public ActionResult Xoa(int id)
        {

            if (id > 0)
            {
                var model = sachBus.LaySach(id);
                
                sachBus.Delete(model.MaSach);
                return RedirectToAction("index", "qlsach", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }

        private void SetViewBag(int? selectedId = null)
        {
            ViewBag.MaTacGia = new SelectList(tacgiaBus.LayDanhSach(), "MaTacGia", "TenTacGia", selectedId);
            ViewBag.MaChuDe = new SelectList(chudeBus.LayDanhSach(), "MaChuDe", "TenChuDe", selectedId);
            ViewBag.MaNXB = new SelectList(nxbBus.LayDanhSach(), "MaNXB", "TenNXB", selectedId);
        }
    }
}