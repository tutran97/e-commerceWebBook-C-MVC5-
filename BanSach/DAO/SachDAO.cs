using DAO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{

    public class SachDAO
    {
        BanSachDbContext Db = null;
        public SachDAO()
        {
            Db = new BanSachDbContext();
        }


        public List<DTO.SachDTO> LayDanhSach()
        {

            var Result = (from sach in Db.Saches
                          where sach.TrangThai == true
                          select new DTO.SachDTO()
                          {

                              MaSach = sach.MaSach,
                              TenSach = sach.TenSach,
                              GiaCu=sach.GiaCu ??0,
                              GiaBan = sach.GiaBan ?? 0,
                              MoTa = sach.MoTa,
                              AnhBia = sach.AnhBia,
                              NgayCapNhat = sach.NgayCapNhat ?? new DateTime(),
                              SoLuongTon = sach.SoLuongTon ?? 0,
                              MaNXB = sach.MaNXB ?? 0,//MaNXB = sach.MaNXB ?? 0,
                              MaChuDe = sach.MaChuDe ?? 0,
                              MaTacGia = sach.MaTacGia ?? 0,
                          }).OrderByDescending(x => x.NgayCapNhat).ToList();
            return Result;
        }
        //tim kiem
        public List<DTO.SachDTO> LayDanhSach(string timkiem)
        {
            var Result = (from sach in Db.Saches
                          where sach.TrangThai == true
                          select new DTO.SachDTO()
                          {
                              MaSach = sach.MaSach,
                              TenSach = sach.TenSach,
                              GiaCu=sach.GiaCu??0,
                              GiaBan = sach.GiaBan ?? 0,
                              MoTa = sach.MoTa,
                              AnhBia = sach.AnhBia,
                              NgayCapNhat = sach.NgayCapNhat ?? new DateTime(),
                              SoLuongTon = sach.SoLuongTon ?? 0,
                              MaNXB = sach.MaNXB ?? 0,//MaNXB = sach.MaNXB ?? 0,
                              MaChuDe = sach.MaChuDe ?? 0,
                              MaTacGia = sach.MaTacGia ?? 0,
                          }).ToList();

            if(!string.IsNullOrEmpty(timkiem))
            {
                Result = Result.FindAll(x => x.TenSach.ToLower().Contains(timkiem));
            }
            

            return Result;
        }
        //lay 1 Sach
        public DTO.SachDTO LaySach(int maSach)
        {
            var Result = (from sach in Db.Saches
                          where sach.MaSach == maSach
                          select new DTO.SachDTO()
                          {
                              MaSach = sach.MaSach,
                              TenSach = sach.TenSach,
                              GiaCu=sach.GiaCu??0,
                              GiaBan = sach.GiaBan ?? 0,
                              MoTa = sach.MoTa,
                              AnhBia = sach.AnhBia,
                              NgayCapNhat = sach.NgayCapNhat ?? new DateTime(),
                              SoLuongTon = sach.SoLuongTon ?? 0,
                              MaNXB = sach.MaNXB ?? 0,
                              MaChuDe = sach.MaChuDe ?? 0,
                              MaTacGia = sach.MaTacGia ?? 0,
                          }).First();
            return Result;
        }
        //Them San Pham
        public void ThemSach(DTO.SachDTO sach)
        {
            try
            {
                var sachEF = new EF.Sach()
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    GiaCu=sach.GiaCu,
                    GiaBan = sach.GiaBan,
                    MoTa = sach.MoTa,
                    AnhBia = sach.AnhBia,
                    NgayCapNhat = DateTime.Parse(sach.NgayCapNhat.ToShortDateString()),
                    SoLuongTon = sach.SoLuongTon,
                    MaNXB = sach.MaNXB,
                    MaChuDe = sach.MaChuDe,
                    MaTacGia = sach.MaTacGia,
                    TrangThai = true
                };
                Db.Saches.Add(sachEF);

                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Edit(DTO.SachDTO sach)//LAY GET Sach
        {
            try
            {
                var SachEdit = Db.Saches.SingleOrDefault(x => x.MaSach == sach.MaSach);//lay Sach trong Db de update
                                                                                       //Get du lieu cap nhat moi vao Sach Db
                SachEdit.TenSach = sach.TenSach;
                SachEdit.GiaCu = sach.GiaCu;
                SachEdit.GiaBan = sach.GiaBan;
                SachEdit.MoTa = sach.MoTa;
                SachEdit.AnhBia = sach.AnhBia;
                //SachEdit.NgayCapNhat = sach.NgayCapNhat;
                SachEdit.SoLuongTon = sach.SoLuongTon;
                //deu kien het Hang an di
                
                SachEdit.MaNXB = sach.MaNXB;
                SachEdit.MaChuDe = sach.MaChuDe;
                SachEdit.MaTacGia = sach.MaTacGia;
                //SachEdit.TrangThai = sach.TrangThai;

                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Xoa Sach
        public bool Delete(int maSach)//LAY GET Sach
        {
            try
            {
                var sach = Db.Saches.SingleOrDefault(x => x.MaSach == maSach);
                if (sach != null)
                {
                   
                    sach.TrangThai=false;
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

        //tim kiem Sach
        public EF.Sach ViewDetail(int maSach)//Ho tro Tim Kiem
        {
            return Db.Saches.Find(maSach);
        }

    }
}
