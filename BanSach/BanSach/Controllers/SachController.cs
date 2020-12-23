using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BanSach.Controllers
{
    public class SachController : BaseController
    {
        private SachBUS sachBus = new SachBUS();
        private TacGiaBUS tacgiaBus = new TacGiaBUS();
        private ChuDeBUS chudeBus = new ChuDeBUS();
        private NhaXuatBanBUS nxbBus = new NhaXuatBanBUS();

        
        //// GET: Sach
        //public ActionResult Index(int? page)
        //{
        //    int pageSize = 8;
        //    int pageNumber = (page ?? 1);//fix Bể Trang tam thoi cho page = 2

        //    var model = new List<BanSach.Models.SachDetail>();

        //    foreach (var sach in sachBus.LayDanhSach())
        //    {
        //        model.Add(new BanSach.Models.SachDetail()
        //        {
        //            MaSach = sach.MaSach,
        //            TenSach = sach.TenSach,
        //            AnhBia = sach.AnhBia,
        //            ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
        //            GiaBan = sach.GiaBan,
        //            SoLuongTon = sach.SoLuongTon,
        //            MoTa = sach.MoTa,
        //            NgayCapNhat = sach.NgayCapNhat,
        //            NhaXuatBan = nxbBus.LayNXB(sach.MaNXB).TenNXB,
        //            TacGia = tacgiaBus.LayTG(sach.MaTacGia).TenTacGia
        //        });
        //    }


        //    return View(model.ToPagedList(pageNumber, pageSize));
        //}
    
        [HttpGet]
        public ActionResult Index(string timkiem, int? page, string find = "macdinh")
        {
            Session["find"] = find;
            Session["sort"] = "?find="+find;
            int pageSize = 12 ;
            int pageNumber = (page ?? 1);//fix Bể Trang tam thoi cho page = 2
            
            if(!string.IsNullOrEmpty(timkiem))
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
            if(find == "tangdan")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderBy(x => x.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            if(find=="giamdan")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderByDescending(x => x.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            if (find =="az")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderBy(x => x.TenSach).ToPagedList(pageNumber, pageSize));
            }
            if (find =="za")
            {
                ViewBag.timkiem = timkiem;
                return View(model.OrderByDescending(x => x.TenSach).ToPagedList(pageNumber, pageSize));
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



        //CHI TIET SAN PHAM
        public ActionResult ChiTietSanPham(int id)
        {
           
            var sach=sachBus.LaySach(id);
                var model=(new BanSach.Models.SachDetail()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                    GiaBan = sach.GiaBan,
                    SoLuongTon = sach.SoLuongTon,
                    MoTa = sach.MoTa,
                    NgayCapNhat = sach.NgayCapNhat,
                    NhaXuatBan = nxbBus.LayNXB(sach.MaNXB).TenNXB,
                    TacGia = tacgiaBus.LayTG(sach.MaTacGia).TenTacGia
                });

            return View(model);
        }
        //LAY Danh Sach San Pham cua Cua Chu De ID do
        public ActionResult ChuDe(int id,int? page,string timkiem, string find = "macdinh")
        {
            Session["find"] = find;
            Session["sort"] = "?find=" + find;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            //timkiem
            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }
            //--
            var chude = new ChuDeBUS().LayChuDe(id);
            ViewBag.ChuDe = chude;
            var list = new ChuDeBUS().ListByChuDeId(id, timkiem);
            var model = new List<BanSach.Models.SachDetail>();
            foreach (var sach in list)
            {
                model.Add(new BanSach.Models.SachDetail()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                    GiaCu = sach.GiaCu,
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
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        //LAY Danh Sach San Pham cua Cua nxb ID do
        public ActionResult nhaxuatban(int id, int? page, string timkiem, string find = "macdinh")
        {
            Session["find"] = find;
            Session["sort"] = "?find=" + find;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            //timkiem
            if (!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }
            //--
            var nxb = new NhaXuatBanBUS().LayNXB(id);
            ViewBag.NhaXuatBan = nxb;
            var list = new NhaXuatBanBUS().ListByNXBId(id, timkiem);
            var model = new List<BanSach.Models.SachDetail>();
            foreach (var sach in list)
            {
                model.Add(new BanSach.Models.SachDetail()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                    GiaCu = sach.GiaCu,
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
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        //LAY Danh Sach San Pham cua Cua Chu De ID do
        public ActionResult TacGia(int id, int? page, string timkiem, string find = "macdinh")
        {
            Session["find"] = find;
            Session["sort"] = "?find=" + find;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            //tim kiem
            if(!string.IsNullOrEmpty(timkiem))
            {
                timkiem = timkiem.ToLower();
            }

            var tacgia = new TacGiaBUS().LayTG(id);
            ViewBag.TacGia = tacgia;
            var list = new TacGiaBUS().ListByTacGiaId(id,timkiem);
            var model = new List<BanSach.Models.SachDetail>();
            foreach (var sach in list)
            {
                model.Add(new BanSach.Models.SachDetail()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    AnhBia = sach.AnhBia,
                    ChuDe = chudeBus.LayChuDe(sach.MaChuDe).TenChuDe,
                    GiaCu = sach.GiaCu,
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
            return View(model.ToPagedList(pageNumber, pageSize));
        }

    }
}