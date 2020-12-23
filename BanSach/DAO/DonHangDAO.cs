using DAO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DonHangDAO
    {
        SachDAO sachDao = new SachDAO();
        BanSachDbContext Db = null;
        public DonHangDAO()
        {
            Db = new BanSachDbContext();
        }

        //Lay Danh Sach Hoa Don - server where true
        public List<DTO.DonHangDTO> LayDanhSach()
        {
            var Result = (from donhang in Db.DonHangs
                          //where donhang.TinhTrangGiaoHang == true
                          select new DTO.DonHangDTO()
                          {

                              MaDonHang = donhang.MaDonHang,
                              NgayDat = donhang.NgayDat ?? new DateTime(),
                              TinhTrangGiaoHang = donhang.TinhTrangGiaoHang ?? true,
                              MaKH = donhang.MaKH ?? 0,
                              //thongtin
                              HoTen = donhang.HoTen,
                              SDT = donhang.SDT,
                              Email = donhang.Email,
                              DiaChi = donhang.DiaChi

                          }).ToList();
            return Result;
        }
        //Lay Danh Sach Hoa Don - server where true-timkiem
        public List<DTO.DonHangDTO> LayDanhSach(string timkiem)
        {
            var Result = (from donhang in Db.DonHangs
                              //where donhang.TinhTrangGiaoHang == true
                          select new DTO.DonHangDTO()
                          {

                              MaDonHang = donhang.MaDonHang,
                              NgayDat = donhang.NgayDat ?? new DateTime(),
                              TinhTrangGiaoHang = donhang.TinhTrangGiaoHang ?? true,
                              MaKH = donhang.MaKH ?? 0,
                              //thongtin
                              HoTen = donhang.HoTen,
                              SDT = donhang.SDT,
                              Email = donhang.Email,
                              DiaChi = donhang.DiaChi

                          }).ToList();
            if (!string.IsNullOrEmpty(timkiem))
            {
                Result = Result.FindAll(x => x.HoTen.ToLower().Contains(timkiem));
            }
            return Result;
        }
        //lay danh sach don hang cho client = id MaKH
        public List<DTO.DonHangDTO> LayDanhSach(int maKH)
        {
            var Result = (from donhang in Db.DonHangs
                          where donhang.MaKH == maKH
                          select new DTO.DonHangDTO()
                          {

                              MaDonHang = donhang.MaDonHang,
                              NgayDat = donhang.NgayDat ?? new DateTime(),
                              TinhTrangGiaoHang = donhang.TinhTrangGiaoHang ?? true,
                              MaKH = donhang.MaKH ?? 0,
                              //thongtin
                              HoTen = donhang.HoTen,
                              SDT = donhang.SDT,
                              Email = donhang.Email,
                              DiaChi = donhang.DiaChi

                          }).ToList();
            return Result;
        }
        //lay DS chi tiet Hoa Don = id maHD
        public List<DTO.ChiTietDonHangDTO> LayDSChiTietHoaDon(int maHD)
        {

            var Result = (from sanpham in Db.ChiTietDonHangs
                          where sanpham.MaDonHang == maHD
                          select new DTO.ChiTietDonHangDTO()
                          {
                              MaDonHang=sanpham.MaDonHang,
                              MaSach = sanpham.MaSach,
                              DonGia = sanpham.DonGia ?? 0,
                              SoLuong = sanpham.SoLuong ?? 0
                          }).ToList();
            return Result;
        }
        //lay DS chitiet HoaDon phan nay Thong KE Thanh Tien
        public List<DTO.ChiTietDonHangDTO> LayDSChiTietHoaDon()
        {
            var Result = (from sanpham in Db.ChiTietDonHangs
                          
                          select new DTO.ChiTietDonHangDTO()
                          {
                              MaDonHang = sanpham.MaDonHang,
                              MaSach = sanpham.MaSach,
                              DonGia = sanpham.DonGia ?? 0,
                              SoLuong = sanpham.SoLuong ?? 0
                          }).ToList();
            return Result;
        }


            //lay 1 Hoa Don = id maHD
            public DTO.DonHangDTO LayHoaDon(int maHD)
        {
            var Result = (from donhang in Db.DonHangs
                          where donhang.MaDonHang == maHD
                          select new DTO.DonHangDTO()
                          {

                              MaDonHang = donhang.MaDonHang,
                              NgayDat = donhang.NgayDat ?? new DateTime(),
                              TinhTrangGiaoHang = donhang.TinhTrangGiaoHang ?? true,
                              MaKH = donhang.MaKH ?? 0,
                              //thongtin
                              HoTen = donhang.HoTen,
                              SDT = donhang.SDT,
                              Email = donhang.Email,
                              DiaChi = donhang.DiaChi

                          }).First();
            Result.SanPham = (from sanpham in Db.ChiTietDonHangs
                              where sanpham.MaDonHang == Result.MaDonHang
                              select new DTO.ChiTietDonHangDTO()
                              {
                                  MaSach = sanpham.MaSach,
                                  DonGia =sanpham.DonGia ?? 0,
                                  SoLuong = sanpham.SoLuong ?? 0
                              }).ToList();
            return Result;
        }


        //Lap Hoa Don
        public int Tao(DTO.KhachHangDTO khachhang, DTO.GioHang giohang)
        {

            try
            {//lap hoa don
                if (giohang.SanPham.Count() > 0)
                {
                    var hoadon = new EF.DonHang()
                    {
                        //MaKH=NULL( Truong Hop Ko K dang nhap)
                        TinhTrangGiaoHang = true,//11:40-16/6/2019
                        NgayDat = DateTime.Now,
                       // NgayGiao = null,
                        HoTen=khachhang.HoTen,
                        SDT=khachhang.DienThoai,
                        Email=khachhang.Email,
                        DiaChi=khachhang.DiaChi
                        

                    };
                    //gan de bit cua tai khoan dang nhap nao xemlichsu
                    if (khachhang.MaKH > 0)
                    {
                        hoadon.MaKH = khachhang.MaKH;

                    }


                    Db.DonHangs.Add(hoadon);
                    Db.SaveChanges();

                    //lap chi tiet hoa don
                    if (hoadon.MaDonHang > 0)
                    {
                        foreach (var item in giohang.SanPham)//đổ item giohang sang item hoadon
                        {
                            var chitiethoadon = new EF.ChiTietDonHang()
                            {
                                MaDonHang = hoadon.MaDonHang,
                                MaSach = item.MaSanPham,
                                SoLuong = item.SoLuong,
                                DonGia = sachDao.LaySach(item.MaSanPham).GiaBan

                            };
                            //cap nhat so luong cho SanPham Ton Kho
                            var soluongcapnhat = sachDao.LaySach(item.MaSanPham).SoLuongTon - chitiethoadon.SoLuong;
                            var SachEF = Db.Saches.SingleOrDefault(x => x.MaSach == item.MaSanPham);
                            var sachCapNhatSL = new DTO.SachDTO()
                            {
                                MaSach=SachEF.MaSach,
                                TenSach = SachEF.TenSach,
                                GiaBan = SachEF.GiaBan ?? 0,
                                MoTa = SachEF.MoTa,
                                AnhBia = SachEF.AnhBia,
                                SoLuongTon = soluongcapnhat ?? 0,
                                MaNXB = SachEF.MaNXB ?? 0,
                                MaChuDe = SachEF.MaChuDe ?? 0,
                                MaTacGia = SachEF.MaTacGia ?? 0
                            };
                            var sach = sachDao.Edit(sachCapNhatSL);

                            Db.ChiTietDonHangs.Add(chitiethoadon);
                            Db.SaveChanges();

                        }

                        //thanh cong xoa gio hang
                        var CTGioHang = Db.ChiTietGioHangs.ToList().FindAll(x => x.MaGioHang == giohang.MaGioHang);
                        foreach (var item in CTGioHang)
                        {
                            Db.ChiTietGioHangs.Remove(item);
                            Db.SaveChanges();
                        }

                        return hoadon.MaDonHang;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }


        //xoa don hang = hoan thanh
        public bool Delete(int maDH)
        {
            try
            {
                var donhang = Db.DonHangs.SingleOrDefault(x => x.MaDonHang == maDH);
                if (donhang != null)
                {

                    donhang.TinhTrangGiaoHang = false;
                    Db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
