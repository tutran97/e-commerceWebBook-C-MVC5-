using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;
using DTO;
using BUS;
using Newtonsoft.Json;

namespace BanSach.Controllers
{
    public class GioHangController : BaseController
    {
        GioHangBUS giohangBus = new GioHangBUS();
        SachBUS sachBUS = new SachBUS();
        
        // GET: GioHang
        [HttpGet]
        public ActionResult Index()
        {
            var dto = giohangBus.GetList(getCartId());

            var model = new GioHangHeader()
            {
                MaGioHang = dto.MaGioHang,
                MaKH = dto.MaKH,
                NgayTao = dto.NgayTao,
                Line = new List<GioHangLine>()
            };
            //chi tiet Gio Hang
            if(dto.SanPham != null)
            {
                foreach (var line in dto.SanPham)
                {

                    model.Line.Add(new GioHangLine()
                    {
                        MaGioHang = model.MaGioHang,
                        MaSanPham = line.MaSanPham,
                        TenSanPham = sachBUS.LaySach(line.MaSanPham).TenSach,
                        GiaBan = sachBUS.LaySach(line.MaSanPham).GiaBan,
                        HinhAnh = sachBUS.LaySach(line.MaSanPham).AnhBia,
                        SoLuong = line.SoLuong
                    });
                }
            }

            return View(model);
        }
        //them item vao gioHang addMVC lay item can them = bo vao ham addBus
        public ActionResult Add(DTO.ChiTietGioHang model)
        {
           
            int maGioHang = getCartId();
            //deu kien So Luong
            if(model.SoLuong<=sachBUS.LaySach(model.MaSanPham).SoLuongTon && model.SoLuong >0)//chan soluong ngay BUTTON chitietsanpham
            {
                
                giohangBus.Add(maGioHang, model.MaSanPham, model.SoLuong);
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Số Lượng Không Đủ!");
            return RedirectToAction("chitietsanpham/"+model.MaSanPham,"sach");
            
        }

        //xoa item trog Gio Hang
        public bool Delete(int id)
        {
            return giohangBus.Delete(id);
            
        }
       //thong bao

        
        //[HttpPost]
        //public ActionResult Index(string id)
        //{
        //    List<ItemGioHangModel> listItem = new List<ItemGioHangModel>();
        //    HttpCookie Cookie = HttpContext.Request.Cookies[CartCookies];// lấy cookie
        //    if (Cookie != null)// check cookies có value nếu cookie not null
        //    {
        //        string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
        //        ViewBag.ValueCookie = ValueCookie;// show value cookie to View
        //        listItem = JsonConvert.DeserializeObject<List<ItemGioHangModel>>(ValueCookie);// convert json to  list object

        //        #region addNew
        //        //do something
        //        //just random
        //        ItemGioHangModel Item = new ItemGioHangModel();
        //        Random random = new Random();
        //        Guid g = Guid.NewGuid();
        //        Item.gMaSach = random.Next();
        //        Item.gTenSach = Convert.ToBase64String(g.ToByteArray());
        //        Item.gSoLuong = random.Next();
        //        listItem.Add(Item);// add object to List
        //                                   //do something
        //        #endregion

        //        //convert từ List<> to =>  json string
        //        string jsonItem = JsonConvert.SerializeObject(listItem, Formatting.Indented);
        //        //cookie
        //        HttpCookie cookie = new HttpCookie(CartCookies);// create 
        //        cookie.Value = Server.UrlEncode(jsonItem);//Encode dịch  mã  các ký tự đặc biệt, từ string  => tham khảo http://www.aspnut.com/reference/encoding.asp
        //        HttpContext.Response.Cookies.Add(cookie);// cookie mới đè lên cookie cũ
        //        ViewBag.ValueCookie = cookie.Value;// show value cookie to View
        //    }
        //    else//cookie chưa có / cookie is null 
        //    {
        //        #region addNew
        //        //do something
        //        //just random
        //        ItemGioHangModel Item = new ItemGioHangModel();
        //        Random random = new Random();
        //        Guid g = Guid.NewGuid();
        //        Item.gMaSach = random.Next();
        //        Item.gTenSach = Convert.ToBase64String(g.ToByteArray());
        //        Item.gSoLuong = random.Next();
        //        listItem.Add(Item);// add object to List
        //                           //do something
        //        #endregion

        //        //convert từ List<> to =>  json string
        //        string jsonItem = JsonConvert.SerializeObject(listItem, Formatting.Indented);
        //        //cookie
        //        HttpCookie cookie = new HttpCookie(CartCookies);// create 
        //        cookie.Value = Server.UrlEncode(jsonItem);//Encode dịch  mã  các ký tự đặc biệt, từ string  => tham khảo http://www.aspnut.com/reference/encoding.asp
        //        HttpContext.Response.Cookies.Add(cookie);// cookie mới đè lên cookie cũ
        //        listItem.Add(Item);// add object to List
        //        ViewBag.ValueCookie = cookie.Value;// show value cookie to View
        //    }
        //    return View(listItem);
        //}

        //Them Item vao GioHang
        //public ActionResult ThemItem(int IDitem, int soluong)
        //{
        //    //tao cookie ID CartCookies
          
        //    var giohang = Cookie;
        //    //neu co gio hang r
        //    if (giohang != null)
        //    {
        //        var sach = new SachBUS().LaySach(IDitem);
        //        var list = new List<ItemGioHangModel>();
        //        string ValueCookie = Server.UrlDecode(Cookie.Value);//Decode dịch ngược mã  các ký tự đặc biệt tham khảo http://www.aspnut.com/reference/encoding.asp
        //        ViewBag.ValueCookie = ValueCookie;// show value cookie to View
        //        list = JsonConvert.DeserializeObject<List<ItemGioHangModel>>(ValueCookie);

        //        if(list.Exists(x=>x.gSach.MaSach==IDitem))
        //        {
        //            foreach (var item in list)
        //            {
        //                if (item.gSach.MaSach == IDitem)
        //                {
        //                    item.gSoLuong += soluong;
        //                }
        //            }
                   
        //        }
        //        else
        //        {
        //            // tao moi doi tuong
        //            var item = new ItemGioHangModel();
        //            item.gSach = sach;
        //            item.gSoLuong = soluong;
        //            list.Add(item);
        //        }
        //        ViewBag.ValueCookie = list;

        //    }
        //    //nguoc lai chua co Gio Hang
        //    else
        //    {
        //        // tao moi doi tuong
        //        var item = new ItemGioHangModel();
        //        item.gSach.MaSach = IDitem;
        //        item.gSoLuong = soluong;
        //        var list = new List<ItemGioHangModel>();
        //        list.Add(item);
        //        //gan vao cookie
        //        ViewBag.ValueCookie = list;

        //    }
        //    return RedirectToAction("Index");
        //}
        //LAY GIO HANG
        //public List<ItemGioHangModel> LayGioHang()
        //{
        //    List<ItemGioHangModel> lisGioHang = Session["GioHangModel"] as List<ItemGioHangModel>;
        //    if(lisGioHang==null)
        //    {
        //        //neu Gio Hang chua Ton Tai thi tien Hanh Tao listGioHang( seddionGioHang)
        //        //Session tac dung: Save lai toan bo Trang tru khi tat template
        //        lisGioHang = new List<ItemGioHangModel>();
        //        Session["GioHangModel"] = lisGioHang;
        //    }
        //    return lisGioHang;
        //}
        ////Them Gio Hang
        //public ActionResult ThemGioHang(int MaSach,string ustrURL)
        //{
        //    //KTRA 
        //    Sach sach = Db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
        //    if(sach==null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;

        //    }
        //   // if(MaSach!=)
        //    //lay sesion ra de save
        //    List<ItemGioHangModel> lisGioHang = LayGioHang();
        //    //ktra ton tai trog Session[GioHang] CHUA de ++ soluong
        //    ItemGioHangModel SanPham = lisGioHang.Find(n=>n.gMaSach==MaSach);
        //    if(SanPham==null)
        //    {
        //        SanPham = new ItemGioHangModel(MaSach);
        //        return Redirect(ustrURL);//tRUYEN LOad lai VAO Trang gIO HANG
        //    }
        //    else
        //    {
        //        SanPham.gSoLuong++;
        //        return Redirect(ustrURL);
        //     }
        //}
        ////cAP Nhat Gio Hang
        //public ActionResult CapNhatGioHang(int MaSach,FormCollection f)//dung control trong form
        //{
        //    //Ktra MaSach Nguoi dung Get SAI MaSach k
        //    Sach sach = Db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
        //    if(sach==null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    //Lay Gio Hang de biet
        //    List<ItemGioHangModel> lisGioHang = LayGioHang();
        //    //neu ton tai cho sua soluong
        //    ItemGioHangModel SanPham = lisGioHang.Find(n => n.gMaSach == MaSach);//ktra Ton Tai trog session k r se cho Cap Nhat
        //    if(SanPham != null)
        //    {
        //        SanPham.gSoLuong = int.Parse(f["txtSoLuong"].ToString());

        //    }
        //   return View("GioHang");

        //}
        ////Xoa Gio Hang
        //public ActionResult XoaGioHang(int MaSach)
        //{
        //    //Ktra MaSach Nguoi dung Get SAI MaSach k
        //    Sach sach = Db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
        //    if (sach == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    //Lay Gio Hang de biet
        //    List<ItemGioHangModel> lisGioHang = LayGioHang();
        //    ItemGioHangModel SanPham = lisGioHang.Find(n => n.gMaSach == MaSach);//ktra Ton Tai trog session k r se cho Cap Nhat
        //    if (SanPham != null)
        //    {
        //        lisGioHang.RemoveAll(n => n.gMaSach == MaSach);
        //    }
        //    if(lisGioHang.Count==0)
        //    {
        //        return RedirectToAction("TrangChu","Home");
        //    }
        //    return RedirectToAction("GioHang");
        //}
        ////phut38 myclass Xay dung trang gio hang
        //public ActionResult GioHang()
        //{
        //    if(Session["GioHang"]==null)
        //    {
        //        return RedirectToAction("TrangChu", "Home");
        //    }
        //    List<ItemGioHangModel> lisGioHang = LayGioHang();
        //    return View(lisGioHang);
        //}
        ////tinh Tong So Luong va TOng Tien
        ////Tong So Luong
        //private int TongSoLuong()
        //{
        //    int iTongSoLuong = 0;
        //    List<ItemGioHangModel> lisGioHang = Session["GioHangModel"] as List<ItemGioHangModel>;
        //    if(lisGioHang!=null)
        //    {
        //        iTongSoLuong = lisGioHang.Sum(n => n.gSoLuong);
        //    }
        //    return iTongSoLuong;
        //}
        ////Tong tien
        //private double TongTien()
        //{
        //    double dTongTien = 0;
        //    List<ItemGioHangModel> lisGioHang = Session["GioHangModel"] as List<ItemGioHangModel>;
        //    if (lisGioHang != null)
        //    {
        //        dTongTien = lisGioHang.Sum(n => n.gThanhTien);
        //    }
        //    return dTongTien;

        //}

    }
}