using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO.EF;

namespace DAO
{
    public class NhaXuatBanDAO
    {
        BanSachDbContext Db = null;
        public NhaXuatBanDAO()
        {
            Db = new BanSachDbContext();
        }
        //Lay Danh Sach NXB
        public List<NhaXuatBanDTO> LayDanhSach()
        {
            var Result = new List<DTO.NhaXuatBanDTO>();
            try
            {
                Result = (from nxb in Db.NhaXuatBans
                          where nxb.TrangThai==true
                          select new DTO.NhaXuatBanDTO()
                          {
                              MaNXB = nxb.MaNXB,
                              TenNXB=nxb.TenNXB,
                              DiaChi=nxb.DiaChi,
                              DienThoai=nxb.DienThoai,
                              TrangThai=true
                          }
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        //timkiem
        public List<NhaXuatBanDTO> LayDanhSach(string timkiem)
        {
            var Result = new List<DTO.NhaXuatBanDTO>();
            try
            {
                Result = (from nxb in Db.NhaXuatBans
                         // where nxb.TrangThai == true
                          select new DTO.NhaXuatBanDTO()
                          {
                              MaNXB = nxb.MaNXB,
                              TenNXB = nxb.TenNXB,
                              DiaChi = nxb.DiaChi,
                              DienThoai = nxb.DienThoai,
                              TrangThai = nxb.TrangThai ??true
                          }
                    ).ToList();
                if (!string.IsNullOrEmpty(timkiem))
                {
                    Result = Result.FindAll(x => x.TenNXB.ToLower().Contains(timkiem));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        //lay 1 Chu De
        public DTO.NhaXuatBanDTO LayNXB(int maNXB)
        {
            var Result = (from nhaxuatban in Db.NhaXuatBans
                         where nhaxuatban.MaNXB == maNXB
                          select new DTO.NhaXuatBanDTO()
                          {
                              MaNXB = nhaxuatban.MaNXB,
                              TenNXB = nhaxuatban.TenNXB,
                              DiaChi = nhaxuatban.DiaChi,
                              DienThoai=nhaxuatban.DienThoai,
                              TrangThai=nhaxuatban.TrangThai??true
                              
                          }).First();
            return Result;
        }
        //Them NXB
        public void ThemNhaXuatBan(DTO.NhaXuatBanDTO nxb)
        {
            var nxbEF = new EF.NhaXuatBan()
            {
                MaNXB = nxb.MaNXB,
                TenNXB = nxb.TenNXB,
                DiaChi = nxb.DiaChi,
                DienThoai = nxb.DienThoai,
                TrangThai=true
            };
            Db.NhaXuatBans.Add(nxbEF);

            Db.SaveChanges();
        }
        //Sua NXB
        public bool Edit(DTO.NhaXuatBanDTO nxb)//LAY GET Sach
        {
            try
            {
                var nxbEdit = Db.NhaXuatBans.SingleOrDefault(x => x.MaNXB == nxb.MaNXB);//lay Sach trong Db de update
                                                                                        //Get du lieu cap nhat moi vao Sach Db
                nxbEdit.MaNXB = nxb.MaNXB;
                nxbEdit.TenNXB = nxb.TenNXB;
                nxbEdit.DiaChi = nxb.DiaChi;
                nxbEdit.DienThoai = nxb.DienThoai;
                nxbEdit.TrangThai = nxb.TrangThai;

                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Xoa NXB
        public bool Delete(DTO.NhaXuatBanDTO nxb)//LAY GET Sach
        {
            try
            {
                var nxbDelete = Db.NhaXuatBans.SingleOrDefault(x => x.MaNXB == nxb.MaNXB);
                if (nxbDelete != null)
                {
                    nxbDelete.TrangThai = false;
                    Db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Xoa Chu De Luon
        public bool DeleteLuon(DTO.NhaXuatBanDTO nxb)//LAY GET Sach
        {
            try
            {
                var nxbDelete = Db.NhaXuatBans.SingleOrDefault(x => x.MaNXB == nxb.MaNXB);
                //doi nhung cuon sach thanh Chu De MAC DINH
                //lay DS nhung cuon sach co chu de dang Xoa
                var Result = new List<DTO.SachDTO>();
                Result = (from sach in Db.Saches
                          where sach.MaNXB == nxb.MaNXB
                          select new DTO.SachDTO()
                          {
                              MaSach = sach.MaSach,
                              TenSach = sach.TenSach,
                              GiaBan = sach.GiaBan ?? 0,
                              MoTa = sach.MoTa,
                              AnhBia = sach.AnhBia,
                              NgayCapNhat = sach.NgayCapNhat ?? new DateTime(),
                              SoLuongTon = sach.SoLuongTon ?? 0,
                              MaNXB = sach.MaNXB ?? 0,//MaNXB = sach.MaNXB ?? 0,
                              MaChuDe = sach.MaChuDe ?? 0,
                              MaTacGia = sach.MaTacGia ?? 0,
                              TrangThai = sach.TrangThai ?? true // !!!
                          }
                    ).ToList();
                //duyet tung Sach Edit bo lai Db
                foreach (var item in Result)
                {
                    if (item.MaNXB == nxb.MaNXB)
                    {

                        item.MaNXB = 22;//gan lại mã mặc định
                        SachDAO sach = new SachDAO();
                        sach.Edit(item);
                        //Db.SaveChanges();
                    }
                }
                //ko dc xoa chu de MAC DINH
                if (nxbDelete.MaNXB != 22)
                {
                    Db.NhaXuatBans.Remove(nxbDelete);
                    Db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        //tim NXB
        public EF.NhaXuatBan ViewDetail(int maNXB)//Ho tro Tim Kiem
        {
            return Db.NhaXuatBans.Find(maNXB);
        }
        //LAY Danh Sach San Pham cua Cua NXB ID do
        public List<DTO.SachDTO> ListByNXBId(int IDnxb,string timkiem)
        {
            var Result = (from sach in Db.Saches
                          where sach.MaNXB == IDnxb
                          select new DTO.SachDTO()
                          {

                              MaSach = sach.MaSach,
                              TenSach = sach.TenSach,
                              GiaBan = sach.GiaBan ?? 0,
                              MoTa = sach.MoTa,
                              AnhBia = sach.AnhBia,
                              NgayCapNhat = sach.NgayCapNhat ?? new DateTime(),
                              SoLuongTon = sach.SoLuongTon ?? 0,
                              MaNXB = sach.MaNXB ?? 0,//MaNXB = sach.MaNXB ?? 0,
                              MaChuDe = sach.MaChuDe ?? 0,
                              MaTacGia = sach.MaTacGia ?? 0,
                              TrangThai=sach.TrangThai ?? true
                          }).ToList();
            if (!string.IsNullOrEmpty(timkiem))
            {
                Result = Result.FindAll(x => x.TenSach.ToLower().Contains(timkiem));
            }
            return Result;
        }
    }
}
