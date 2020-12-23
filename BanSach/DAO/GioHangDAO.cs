using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO.EF;

namespace DAO
{
    public class GioHangDAO
    {
        BanSachDbContext db = new BanSachDbContext();

        public int Create(int makhachhang)
        {
            int maGioHang = 0;

            var giohang = new EF.GioHang()
            {
                NgayTao = DateTime.Now
            };

            try
            {
                db.GioHangs.Add(giohang);
                db.SaveChanges();
                //co Db r gán mã = mã tự động tăng sẽ tự phát sinh trog Db để trả về giá trị
                maGioHang = giohang.MaGioHang;
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return maGioHang;
        }


        public bool Add(int magiohang, int masanpham, int soluong)
        {
            try
            {
                var cartLine = Get(magiohang, masanpham);//ktra xem co item do trog gio hang chua
                //neu item ton tai trong Gio thì +soluong
                if (cartLine != null)
                {
                    //fix so luong 21/6 ktra soluong voi nhau
                    if (db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong>=(db.Saches.SingleOrDefault(x=>x.MaSach==masanpham).SoLuongTon - db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong) || db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong <= (db.Saches.SingleOrDefault(x => x.MaSach == masanpham).SoLuongTon - db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong))//slitemGioHang<=slItemSach-sl itemGioHang
                    {
                        if(soluong<= (db.Saches.SingleOrDefault(x => x.MaSach == masanpham).SoLuongTon - db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong))
                        {
                            db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham).SoLuong += soluong;
                           
                        }
                    }
                }
                //tao moi
                else
                {
                    var chitietgiohang = new EF.ChiTietGioHang()
                    {
                        MaGioHang = magiohang,
                        MaSanPham = masanpham,
                        SoLuong = soluong
                    };
                    db.ChiTietGioHangs.Add(chitietgiohang);
                }

                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //lay danh sach GioHang
        public DTO.GioHang GetList(int id)
        {
            var result = new DTO.GioHang();
            try
            {
                result = (from giohang in db.GioHangs
                          where giohang.MaGioHang == id
                          select new DTO.GioHang()
                          {
                              MaGioHang = giohang.MaGioHang,
                              MaKH = giohang.MaKH ?? 0,
                              NgayTao = giohang.NgayTao
                          }).First();
                result.SanPham = (from sanpham in db.ChiTietGioHangs
                                  where sanpham.MaGioHang == result.MaGioHang
                                  select new DTO.ChiTietGioHang()
                                  {
                                      MaSanPham = sanpham.MaSanPham,
                                      SoLuong = sanpham.SoLuong
                                  }).ToList();

            }
            catch
            {
            }
            return result;
        }


        private EF.ChiTietGioHang Get(int magiohang, int masanpham)
        {
            try
            {
                return db.ChiTietGioHangs.SingleOrDefault(x => x.MaGioHang == magiohang && x.MaSanPham == masanpham);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        //xoa item trong giohang
        public bool Delete(int maSp)
        {

            try
            {
                var item = db.ChiTietGioHangs.SingleOrDefault(x => x.MaSanPham == maSp);
                if (item != null)
                {
                    db.ChiTietGioHangs.Remove(item);
                    db.SaveChanges();
                    return true;
                }
               

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //lay danh sach chitietgiohang
        public List<DTO.ChiTietGioHang> dschitietgiohang(int id)
        {
            var result = new List<DTO.ChiTietGioHang>();
            try
            {
                result = (from sanpham in db.ChiTietGioHangs
                              where sanpham.MaGioHang == id
                              select new DTO.ChiTietGioHang()
                              {
                                  MaSanPham = sanpham.MaSanPham,
                                  SoLuong = sanpham.SoLuong
                              }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
