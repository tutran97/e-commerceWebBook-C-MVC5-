using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.EF;
using DTO;
namespace DAO
{
    public class KhachHangDAO
    {
        BanSachDbContext Db = null;
        public KhachHangDAO()
        {
            Db = new BanSachDbContext();
        }
        //DANG NHAP
        public int Login(string tk, string mk)
        {
            int Result = 0;
            try
            {
                EF.KhachHang user = new EF.KhachHang();
                user = Db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == tk && x.MatKhau == mk);
                Result = user.MaKH;
            }
            catch
            {
            }

            return Result;
        }
        //LAY DANH SACH TAT CA KHACH HANG/USER
        public List<DTO.KhachHangDTO> LayDanhSach(string searchString)
        {
            IOrderedQueryable<KhachHang> model = Db.KhachHangs;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TaiKhoan.Contains(searchString) || x.HoTen.Contains(searchString)).OrderBy(x => x.MaKH);
                
            }
           
            var Result = (from kh in model
                          where kh.TrangThai == true
                          select new DTO.KhachHangDTO()
                          {
                              MaKH = kh.MaKH,
                              TaiKhoan=kh.TaiKhoan,
                              MatKhau=kh.MatKhau,
                              HoTen=kh.HoTen,
                              Email=kh.Email,
                              GioiTinh=kh.GioiTinh,
                              DienThoai=kh.DienThoai,
                              DiaChi=kh.DiaChi,
                              NgaySinh=kh.NgaySinh ?? new DateTime(),
                              TrangThai=true
                            
                          }).ToList();
            return Result;
        }
        //LAY THONG TIN 1 KHACH HANG
        public DTO.KhachHangDTO LayKhachHang(string tk)
        {
            var Result = (from khachhang in Db.KhachHangs
                          where khachhang.TaiKhoan == tk
                          select new DTO.KhachHangDTO()
                          {
                              MaKH = khachhang.MaKH,
                              TaiKhoan = khachhang.TaiKhoan,
                              MatKhau = khachhang.MatKhau,
                              HoTen = khachhang.HoTen,
                              NgaySinh =khachhang.NgaySinh ?? new DateTime(),//DateTime.Parse( khachhang.NgaySinh.ToString()),
                              GioiTinh = khachhang.GioiTinh,
                              Email = khachhang.Email,
                              DienThoai = khachhang.DienThoai,
                              DiaChi = khachhang.DiaChi,
                              MaLoaiKH = khachhang.MaLoaiKH ?? 2,//if null gan = 2
                              TrangThai =khachhang.TrangThai ?? true

                          }).First();
            return Result;
        }
        //lay user = id dung session
        public DTO.KhachHangDTO LayKhachHang(int ma)
        {
            var Result = (from khachhang in Db.KhachHangs
                          where khachhang.MaKH == ma
                          select new DTO.KhachHangDTO()
                          {
                              MaKH = khachhang.MaKH,
                              TaiKhoan = khachhang.TaiKhoan,
                              MatKhau = khachhang.MatKhau,
                              HoTen = khachhang.HoTen,
                              NgaySinh =khachhang.NgaySinh ?? new DateTime(),
                              GioiTinh = khachhang.GioiTinh,
                              Email = khachhang.Email,
                              DienThoai = khachhang.DienThoai,
                              DiaChi = khachhang.DiaChi,
                              MaLoaiKH=khachhang.MaLoaiKH ?? 2,//if null gan = 2
                              TrangThai = true
                              

                          }).First();
            return Result;
        }

        //THEM KHACH HANG dang ky
        public void ThemKH(DTO.KhachHangDTO user)
        {
            var userEF = new EF.KhachHang()
            {
                MaKH = user.MaKH,
                TaiKhoan = user.TaiKhoan,
                MatKhau = user.MatKhau,
                HoTen = user.HoTen,
                Email = user.Email,
                DienThoai = user.DienThoai,
                DiaChi = user.DiaChi,
                GioiTinh = user.GioiTinh,
                NgaySinh = DateTime.Parse(user.NgaySinh.ToShortDateString()),
                TrangThai = true,
                MaLoaiKH = 2
                
            };
            Db.KhachHangs.Add(userEF);

            Db.SaveChanges();
        }
        //EDIT
        public bool Edit(DTO.KhachHangDTO user)//LAY GET 
        {
            try
            {
                var userEdit = Db.KhachHangs.SingleOrDefault(x => x.MaKH == user.MaKH);//lay Sach trong Db de update
                                                                                       //Get du lieu cap nhat moi vao Sach Db
                //userEdit.MaKH = user.MaKH;
                //userEdit.TaiKhoan = user.TaiKhoan;
                userEdit.MatKhau = user.MatKhau;
                userEdit.HoTen = user.HoTen;
                userEdit.GioiTinh = user.GioiTinh;
                userEdit.Email = user.Email;//co the bi trung
                userEdit.NgaySinh = user.NgaySinh;
                userEdit.DienThoai = user.DienThoai;
                userEdit.DiaChi = user.DiaChi;
               // userEdit.TrangThai = true;
               

                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //xoa
        public bool Delete(int maKH)//LAY GET Sach
        {
            try
            {
                var kh = Db.KhachHangs.SingleOrDefault(x => x.MaKH == maKH);
                if (kh != null)
                {
                    kh.TrangThai = false;
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

        
   
       
        //Check Tai Khoan co Ton Tai Chua?!
        public bool CheckTaiKhoan(string tk)
        {
            return Db.KhachHangs.Count(x => x.TaiKhoan == tk) > 0;
        }
        //check email
        public bool CheckEmail(string e)
        {
            return Db.KhachHangs.Count(x => x.Email == e) > 0;
        }
        public bool CheckMatKhau(string mk)
        {
            return Db.KhachHangs.Count(x => x.MatKhau == mk) > 0;
        }
        
    }
}
