using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;
using BUS;
using DTO;
namespace BanSach.Controllers
{

    public class HoaDonController : BaseController
    {
        GioHangBUS giohangBus = new GioHangBUS();
        DonHangBUS hoadonBus = new DonHangBUS();
        KhachHangBUS khachangBus = new KhachHangBUS();
        SachBUS sachBus = new SachBUS();
       
        // GET: HoaDon

        //TRANG THANH TOAN-LAP HOA DON
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                bool ktra=true;//kiem tra so luong neu 2 nguoi cung mua so luong con moi Lap Hoa Don dc
                foreach(var item in giohangBus.dschitietgiohang(getCartId()) )
                {
                    if(item.SoLuong>sachBus.LaySach(item.MaSanPham).SoLuongTon)
                    {
                        ktra = false;
                    }
                }
                if(ktra==true)
                {
                    // neu co dang nhap thi tao hoa don luon
                    int madh = hoadonBus.Tao(khachangBus.LayKhachHang(int.Parse(Session["UserID"].ToString())), giohangBus.GetList(getCartId()));
                    return RedirectToAction("Detail", new { Id = madh });
                }
                else
                {
                    ModelState.AddModelError("","số lượng sản phẩm trong giỏ hàng của bạn không đủ vừa co người mua!");
                    return View();
                }
            }

            return View();
        }
        //ko co dang nhap
        [HttpPost]
        public ActionResult Index(ThongTinGiaoHangModel model)
        {
            // tao moel de user nhap thong tin mua hang

            if (ModelState.IsValid)
            {
                var khachhang = new DTO.KhachHangDTO()
                {
                    HoTen = model.HoTen,
                    DienThoai = model.SDT,
                    Email = model.Email,
                    DiaChi = model.DiaChi
                };

                bool ktra = true;
                foreach (var item in giohangBus.dschitietgiohang(getCartId()))
                {
                    if (item.SoLuong > sachBus.LaySach(item.MaSanPham).SoLuongTon)
                    {
                        ktra = false;
                    }
                }
                if (ktra == true)
                {
                    int MaHD = hoadonBus.Tao(khachhang, giohangBus.GetList(getCartId()));

                    return RedirectToAction("Detail", new { Id = MaHD });
                }
                else
                {
                    ModelState.AddModelError("", "số lượng sản phẩm trong giỏ hàng của bạn không đủ vừa có người mua!");
                    
                }

            }
            return View();
        }
        //TRANG THONG TIN HOA DON
        [HttpGet]
        public ActionResult Detail(int id)
        {
            //Lay thong tin hoa don trong DAO.HoaDon
            var hoadon = hoadonBus.LayHoaDon(id);
            var model = (new BanSach.Models.HoaDonModel()
            {
                MaDonHang = hoadon.MaDonHang,
                MaKH = hoadon.MaKH,
                NgayDat = hoadon.NgayDat,
                TinhTrangGiaoHang = hoadon.TinhTrangGiaoHang,
                //ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                //thong tin Giao
                HoTen=hoadon.HoTen,
                SDT=hoadon.SDT,
                Email=hoadon.Email,
                DiaChi=hoadon.DiaChi


            });

            //Show cho nguoi dung xem
            return View(model);
        }
        //xem don hang cua user dang nhap
        [HttpGet]
        public ActionResult DonHangCuaToi(int id)
        {
            if (Session["UserId"] != null)
            {
                var model = new List<DTO.DonHangDTO>();


                foreach (var hoadon in hoadonBus.LayDanhSach(id))
                {
                    model.Add(new DTO.DonHangDTO()
                    {
                        MaDonHang = hoadon.MaDonHang,
                        MaKH = hoadon.MaKH,
                        NgayDat = hoadon.NgayDat,
                        TinhTrangGiaoHang = hoadon.TinhTrangGiaoHang,
                        //thongtin
                        HoTen = hoadon.HoTen,
                        SDT = hoadon.SDT,
                        Email = hoadon.Email,
                        DiaChi = hoadon.DiaChi
                    });
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("dangnhap", "home");
            }
        }


        [HttpGet]
        public ActionResult XemChiTietDonHang(int id)
        {
            //if (Session["UserId"] != null)
            //{
                var model = new List<DTO.ChiTietDonHangDTO>();


                foreach (var hoadon in hoadonBus.LayDSChiTietHoaDon(id))
                {
                    model.Add(new DTO.ChiTietDonHangDTO()
                    {
                       MaDonHang=hoadon.MaDonHang,
                       MaSach=hoadon.MaSach,
                       SoLuong=hoadon.SoLuong,
                       DonGia=hoadon.DonGia
                       

                    });
                }
                return View(model);
            //}
            //else
            //{
            //    return RedirectToAction("dangnhap", "home");
            //}
        }

    }
}