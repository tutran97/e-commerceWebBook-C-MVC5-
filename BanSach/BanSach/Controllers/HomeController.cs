using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;
using BUS;
using Facebook;
using System.Configuration;
using DTO;
using PagedList;
using PagedList.Mvc;
using BanSach.Common;

namespace BanSach.Controllers
{
    public class HomeController : BaseController
    {
        private KhachHangBUS KhachHangBus = null;
        GioHangBUS giohangBUS = new GioHangBUS();
        DonHangBUS hoadonBus = new DonHangBUS();
        private SachBUS sachBus = new SachBUS();
        private TacGiaBUS tacgiaBus = new TacGiaBUS();
        private ChuDeBUS chudeBus = new ChuDeBUS();
        private NhaXuatBanBUS nxbBus = new NhaXuatBanBUS();

        public HomeController()
        {
            KhachHangBus = new KhachHangBUS();
        }
        

        public ActionResult Index()
        {
            return View();
        }

        //DANG NHAP
        [HttpGet]//KTRA USER TỒN TẠI
        public ActionResult DangNhap()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");//VÀO TRANG CHỦ
            }
            return View();//RESET LẠI view hàm ĐĂNG NHẬP
        }
        //XỮ LÝ Dữ liệu MODEL truyền vào
        [HttpPost]
        public ActionResult DangNhap(LoginModel model)
        {
            if (ModelState.IsValid)//phải hợp lệ
            {
                if (KhachHangBus.Login(model.TaiKhoan, Encryptor.MD5Hash(model.MatKhau)) > 0)
                {
                    var user = KhachHangBus.LayKhachHang(model.TaiKhoan);// Trường Hợp dùng biến string cho hàm laykhachhang(string)

                    if (user.MaKH > 0 && user.TrangThai==true)
                    {
                        Session["UserId"] = user.MaKH;
                        Session["UserName"] = user.TaiKhoan;
                        //Session["UserLoai"] = user.MaLoaiKH;
                        if(user.MaLoaiKH==1)
                        {
                            Session["UserLoai"] = user.TaiKhoan;
                        }
                        else
                        {
                            Session["UserLoai"] = null;
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "tài khoản không tồn tại");//thông báo Ra view
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");//thông báo Ra view
                }
            }
            return View();
        }

        //DANG XUẤT
        public ActionResult DangXuat()
        {
            if (Session["UserId"] != null)
            {
                Session["UserId"] = null;
                Session["UserName"] = null;
                Session["UserLoai"] = null;
            }

            return RedirectToAction("Index", "Home");
        }


        //DANG KÝ
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(RegisterModel Rmodel)
        {
            if (ModelState.IsValid)
            {
                //var khBus = new KhachHangBUS();
                if (KhachHangBus.CheckTaiKhoan(Rmodel.TaiKhoan))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (KhachHangBus.CheckEmail(Rmodel.Email))
                {
                    ModelState.AddModelError("", "Email đă tồn tại");
                }
                else
                {
                    var user = new KhachHangDTO();
                    //MaKH ID da setting tu dong tang o SQL nen k co trung\
                    user.TaiKhoan = Rmodel.TaiKhoan;
                    user.MatKhau =Encryptor.MD5Hash(Rmodel.MatKhau);
                    user.HoTen = Rmodel.HoTen;
                    user.DienThoai = Rmodel.SDT;
                    if (Rmodel.GioiTinh == GioiTinh.Nam)
                    {
                        user.GioiTinh = "nam";
                    }
                    else
                    {
                        user.GioiTinh = "nữ";
                    }
                    user.Email = Rmodel.Email;
                    user.DiaChi = Rmodel.DiaChi;
                    user.NgaySinh = Rmodel.NgaySinh;
                    user.TrangThai = true;
                    KhachHangBus.ThemKH(user);
                    if (KhachHangBus.LayKhachHang(user.TaiKhoan) != null)
                    {
                        var id = KhachHangBus.LayKhachHang(user.TaiKhoan);
                        Session["UserId"] = id.MaKH;
                        Session["UserName"] = id.TaiKhoan;
                        //Session["UserLoai"] = id.MaLoaiKH;
                        return RedirectToAction("index", "home", "Đăng Ký Thành Công! ^^ ");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng Ký Không Thành Công");
                    }
                }
            }

            return View(Rmodel);
        }

        //Xuat THong Tin Khach Hang user

        public ActionResult ThongTinKhachHang(int id)
        {
            if (Session["UserId"] != null)
            {
                var user = KhachHangBus.LayKhachHang(id);
                var model = (new KhachHangDTO()
                {
                    MaKH = user.MaKH,
                    HoTen = user.HoTen,
                    TaiKhoan = user.TaiKhoan,
                    MatKhau = user.MatKhau,
                    Email = user.Email,
                    GioiTinh = user.GioiTinh,
                    DiaChi = user.DiaChi,
                    DienThoai = user.DienThoai,
                    NgaySinh = user.NgaySinh,//
                    TrangThai = true

                });
                return View(model);
            }
            else
            {
                return RedirectToAction("index");
            }

        }
        //Doi mat khau
        [HttpGet]
        public ActionResult doithongtin(int id)
        {
            
            //if(ModelState.IsValid)
            //{
                if(Session["UserId"] != null)
                {
                    var user = KhachHangBus.LayKhachHang(id);
                    var model= new doimatkhauModel();
                    model.MaKH = user.MaKH;
                    model.TaiKhoan = user.TaiKhoan;
                    model.HoTen = user.HoTen;
                    model.MatKhauMoi = null;
                    model.Email = user.Email;
                    if (user.GioiTinh == "nam")
                    {
                        model.GioiTinh = GioiTinh.Nam;
                    }
                    else
                    {
                        model.GioiTinh = GioiTinh.Nữ;
                    }
                    model.DiaChi = user.DiaChi;
                    model.SDT = user.DienThoai;
                    model.NgaySinh = user.NgaySinh;//
                    return View(model);
                }
                else
                {
                    return RedirectToAction("dangnhap", "home");
                }
                
            //}
            //return View();

        }

        [HttpPost]
        public ActionResult doithongtin(doimatkhauModel model)
        {
            if(ModelState.IsValid)
            {
                if (Session["UserId"] != null)// kiem tra form hop le
                {
                    var user = new DTO.KhachHangDTO(); // Tao sach DTO
                                                       // Bo gia tri tu MOdel => DTO
                                                       //user.TaiKhoan = model.TaiKhoan;
                    user.MaKH = model.MaKH;
                    if (!KhachHangBus.CheckMatKhau(Encryptor.MD5Hash(model.MatKhau)))
                    {
                        ModelState.AddModelError("", "mật khẩu không Chính xác!");
                    }
                    else
                    {
                        user.MatKhau = Encryptor.MD5Hash(model.MatKhauMoi);
                        user.HoTen = model.HoTen;
                        user.DienThoai = model.SDT;
                        if (model.GioiTinh == GioiTinh.Nam)
                        {
                            user.GioiTinh = "nam";
                        }
                        else
                        {
                            user.GioiTinh = "nữ";
                        }
                        user.Email = model.Email;
                        user.DiaChi = model.DiaChi;
                        user.NgaySinh = model.NgaySinh;
                        user.TrangThai = true;
                        Session["UserId"] = user.MaKH;
                        //GOi ham trong BUS
                        bool kq = KhachHangBus.Edit(user);

                        if (kq)
                        {
                            return RedirectToAction("thongtinkhachhang/" + Session["UserId"], "home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cập Nhật Thất Bại !");
                        }
                    }
                    
                    return View(model);
                }
            }
            
            return View(model);

        }

        [HttpGet]
        public ActionResult Index(string timkiem, int? page)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);//fix Bể Trang tam thoi cho page = 2

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


            return View(model.OrderByDescending(x => x.NgayCapNhat).ToPagedList(pageNumber, pageSize));
        }



        //PHAN THONG TIN WEB
        public ActionResult gioithieu()
        {
            return View();
        }
        public ActionResult dichvu()
        {
            return View();
        }
        public ActionResult lienhe()
        {
            return View();
        }

    }

}
