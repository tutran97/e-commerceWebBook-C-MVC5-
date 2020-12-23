using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO.EF;

namespace DAO
{
    public class TacGiaDAO
    {
        BanSachDbContext Db = null;
        public TacGiaDAO()
        {
            Db = new BanSachDbContext();
        }


        //Lay Danh Sach NXB
        public List<DTO.TacGiaDTO> LayDanhSach()
        {
            var Result = new List<DTO.TacGiaDTO>();
            try
            {
                Result = (from tacgia in Db.TacGias
                          where tacgia.TrangThai==true
                          select new DTO.TacGiaDTO()
                          {
                              MaTacGia = tacgia.MaTacGia,
                              TenTacGia=tacgia.TenTacGia,
                              DiaChi=tacgia.DiaChi,
                              TieuSu=tacgia.TieuSu,
                              DienThoai=tacgia.DienThoai,
                              TrangThai=true
                             
                          }
                    ).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        //lay dánh ach admin
        public List<DTO.TacGiaDTO> LayDanhSach(string timkiem)
        {
            var Result = new List<DTO.TacGiaDTO>();
            try
            {
                Result = (from tacgia in Db.TacGias
                          //where tacgia.TrangThai == true
                          select new DTO.TacGiaDTO()
                          {
                              MaTacGia = tacgia.MaTacGia,
                              TenTacGia = tacgia.TenTacGia,
                              DiaChi = tacgia.DiaChi,
                              TieuSu = tacgia.TieuSu,
                              DienThoai = tacgia.DienThoai,
                              TrangThai = tacgia.TrangThai ??true

                          }
                    ).ToList();
                if (!string.IsNullOrEmpty(timkiem))
                {
                    Result = Result.FindAll(x => x.TenTacGia.ToLower().Contains(timkiem));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        //lay 1 Chu De
        public DTO.TacGiaDTO LayTacGia(int maTG)
        {
            var Result = (from tacgia in Db.TacGias
                          where tacgia.MaTacGia == maTG
                          select new DTO.TacGiaDTO()
                          {
                              MaTacGia = tacgia.MaTacGia,
                              TenTacGia = tacgia.TenTacGia,
                              DiaChi = tacgia.DiaChi,
                              TieuSu=tacgia.TieuSu,
                              DienThoai = tacgia.DienThoai,
                              TrangThai=tacgia.TrangThai ??true
                          }).First();
            return Result;
        }
        //Them NXB
        public void ThemTacGia(DTO.TacGiaDTO tg)
        {
            var tgEF = new EF.TacGia()
            {
                MaTacGia = tg.MaTacGia,
                TenTacGia = tg.TenTacGia,
                DiaChi = tg.DiaChi,
                TieuSu = tg.TieuSu,
                DienThoai = tg.DienThoai,
                TrangThai=true
                
            };
            Db.TacGias.Add(tgEF);
            Db.SaveChanges();
        }
        //Sua NXB
        public bool Edit(DTO.TacGiaDTO tg)//LAY GET Sach
        {
            try
            {
                var tgEdit = Db.TacGias.SingleOrDefault(x => x.MaTacGia == tg.MaTacGia);//lay Sach trong Db de update
                                                                                        //Get du lieu cap nhat moi vao Sach Db
                tgEdit.MaTacGia = tg.MaTacGia;
                tgEdit.TenTacGia = tg.TenTacGia;
                tgEdit.DiaChi = tg.DiaChi;
                tgEdit.TieuSu = tg.TieuSu;
                tgEdit.DienThoai = tg.DienThoai;
                tgEdit.TrangThai = tg.TrangThai;
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Xoa NXB
        public bool Delete(DTO.TacGiaDTO tg)//LAY GET Sach
        {
            try
            {
                var tgDelete = Db.TacGias.SingleOrDefault(x => x.MaTacGia == tg.MaTacGia);
                if (tgDelete != null)
                {
                    tgDelete.TrangThai = false;
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
        public bool DeleteLuon(DTO.TacGiaDTO tg)//LAY GET Sach
        {
            try
            {
                var tgDelete = Db.TacGias.SingleOrDefault(x => x.MaTacGia == tg.MaTacGia);
                //doi nhung cuon sach thanh Chu De MAC DINH
                //lay DS nhung cuon sach co chu de dang Xoa
                var Result = new List<DTO.SachDTO>();
                Result = (from sach in Db.Saches
                          where sach.MaTacGia == tg.MaTacGia
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
                    if (item.MaTacGia == tg.MaTacGia)
                    {

                        item.MaTacGia = 42;//gan lại mã mặc định
                        SachDAO sach = new SachDAO();
                        sach.Edit(item);
                        //Db.SaveChanges();
                    }
                }
                //ko dc xoa chu de MAC DINH
                if (tgDelete.MaTacGia!= 42)
                {
                    Db.TacGias.Remove(tgDelete);
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
        public EF.TacGia ViewDetail(int maTG)//Ho tro Tim Kiem
        {
            return Db.TacGias.Find(maTG);
        }

        //LAY Danh Sach San Pham cua Cua TacGia ID do
        public List<DTO.SachDTO> ListByTacGiaId(int maTg,string timkiem)
        {
            var Result = (from sach in Db.Saches
                          where sach.MaTacGia == maTg
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
                          }).ToList();
            if (!string.IsNullOrEmpty(timkiem))
            {
                Result = Result.FindAll(x => x.TenSach.ToLower().Contains(timkiem));
            }
            return Result;
          
        }
    }
}
