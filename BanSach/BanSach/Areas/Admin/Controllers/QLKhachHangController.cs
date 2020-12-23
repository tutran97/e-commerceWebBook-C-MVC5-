using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BUS;
using DTO;
using BanSach.Areas.Admin.Models;
using BanSach.Models;
using BanSach.Common;

namespace BanSach.Areas.Admin.Controllers
{
    public class QLKhachHangController : BaseController
    {
        //Khai Bao Bien doi tuong BUS
        KhachHangBUS khachhangBus = new KhachHangBUS();

        //lay danh sach Doi Tuong cho trang index
        // GET: Admin/QLKhachHang
        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = khachhangBus.LayDanhSach(searchString).ToPagedList(pageNumber, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        // cap nhat
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var kh = new DTO.KhachHangDTO();
            //BUS.laysach(masach) => DTO
            kh = khachhangBus.LayKhachHang(id);
            // DTO => Model
            KhachHangEditModel modelKhachHangEdit = new KhachHangEditModel();

            modelKhachHangEdit.MaKH = kh.MaKH;
            modelKhachHangEdit.TaiKhoan = kh.TaiKhoan;
            modelKhachHangEdit.MatKhau =Encryptor.MD5Hash(kh.MatKhau);
            modelKhachHangEdit.HoTen = kh.HoTen;
            if (kh.GioiTinh == "nam")
            {
                modelKhachHangEdit.GioiTinh = GioiTinh.Nam;
            }
            else
            {
                modelKhachHangEdit.GioiTinh = GioiTinh.Nữ;
            }
            modelKhachHangEdit.Email = kh.Email;
            modelKhachHangEdit.DiaChi = kh.DiaChi;
            modelKhachHangEdit.SDT = kh.DienThoai;
            modelKhachHangEdit.NgaySinh = kh.NgaySinh;
            return View(modelKhachHangEdit);
            //Return view(model)
        }
        [HttpPost]
        public ActionResult Sua(KhachHangEditModel model)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                var kh = new DTO.KhachHangDTO(); // Tao sach DTO
                // Bo gia tri tu MOdel => DTO
                kh.MaKH = model.MaKH;
                kh.TaiKhoan = model.TaiKhoan;
                kh.MatKhau = Encryptor.MD5Hash(model.MatKhau) ;
                kh.HoTen = model.HoTen;
                if (model.GioiTinh == GioiTinh.Nam)
                {
                    kh.GioiTinh = "nam";
                }
                else
                {
                    kh.GioiTinh ="nữ";
                }
                kh.Email = model.Email;
                kh.DiaChi = model.DiaChi;
                kh.DienThoai = model.SDT;
                kh.NgaySinh = model.NgaySinh;
                //GOi ham trong BUS
                bool kq = khachhangBus.Edit(kh);
                if (kq)
                {
                    return RedirectToAction("index", "qlkhachhang", new { Areas = "admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại !");
                }
            }
            return View(model);

        }
        //XOA
        [HttpGet]
        public ActionResult Xoa(int id)
        {

            if (id > 0)
            {
                var model = khachhangBus.LayKhachHang(id);

                khachhangBus.Delete(model.MaKH);
                return RedirectToAction("index", "qlkhachhang", new { Controller = "admin" });
            }
            else
            {
                ModelState.AddModelError("", "Thất Bại !");
            }

            return View();
        }
    }
}