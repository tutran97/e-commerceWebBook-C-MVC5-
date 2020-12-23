using DAO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class ChuDeDAO
    {
        BanSachDbContext Db = null;
        public ChuDeDAO()
        {
            Db = new BanSachDbContext();
        }
        //lay danh sach
        public List<ChuDeDTO> LayDanhSach()
        {
           
            var Result = new List<DTO.ChuDeDTO>();
            try
            {
                Result = (from chude in Db.ChuDes
                          where chude.TrangThai == true
                          select new DTO.ChuDeDTO()
                          {
                              TenChuDe = chude.TenChuDe,
                              MaChuDe = chude.MaChuDe,
                              TrangThai = true,

                          }
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        //Lay Danh Sach Chu De dung cho tim kiem admin
        public List<ChuDeDTO> LayDanhSach(string timkiem)
        {
            
            var Result = new List<DTO.ChuDeDTO>();
            try
            {
                Result = (from chude in Db.ChuDes
                          //where chude.TrangThai==true
                          select new DTO.ChuDeDTO()
                          {
                              TenChuDe = chude.TenChuDe,
                              MaChuDe=chude.MaChuDe,
                              TrangThai=chude.TrangThai ?? true
                              
                          }
                    ).ToList();
                if (!string.IsNullOrEmpty(timkiem))
                {
                    Result = Result.FindAll(x => x.TenChuDe.ToLower().Contains(timkiem));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        //lay 1 Chu De
        public DTO.ChuDeDTO LayChuDe(int maChuDe)
        {
            var Result = (from chude in Db.ChuDes
                          where chude.MaChuDe == maChuDe
                          select new DTO.ChuDeDTO()
                          {
                              MaChuDe = chude.MaChuDe,
                              TenChuDe = chude.TenChuDe,
                              TrangThai = chude.TrangThai ?? true
                          }).First();
            return Result;
        }
        //Them Chu De
        public void ThemChuDe(DTO.ChuDeDTO chude)
        {
            var ChuDeEF = new EF.ChuDe()
            {
                MaChuDe = chude.MaChuDe,
                TenChuDe = chude.TenChuDe,
                TrangThai = true
            };
            Db.ChuDes.Add(ChuDeEF);

            Db.SaveChanges();
        }
        //Sua Chu De
        public bool Edit(DTO.ChuDeDTO chude)//LAY GET Sach
        {
            try
            {
                var ChuDeEdit = Db.ChuDes.SingleOrDefault(x => x.MaChuDe == chude.MaChuDe);//lay Sach trong Db de update
                                                                                           //Get du lieu cap nhat moi vao Sach Db
                ChuDeEdit.MaChuDe = chude.MaChuDe;
                ChuDeEdit.TenChuDe = chude.TenChuDe;
                ChuDeEdit.TrangThai = chude.TrangThai;
                
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Xoa Chu De
        public bool Delete(DTO.ChuDeDTO chude)//LAY GET Sach
        {
            try
            {
                var ChuDeDelete = Db.ChuDes.SingleOrDefault(x => x.MaChuDe == chude.MaChuDe);
                if(ChuDeDelete!=null)
                {
                    ChuDeDelete.TrangThai = false;
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
        public bool DeleteLuon(DTO.ChuDeDTO chude)//LAY GET Sach
        {
            try
            {
                var ChuDeDelete = Db.ChuDes.SingleOrDefault(x => x.MaChuDe == chude.MaChuDe);
                //doi nhung cuon sach thanh Chu De MAC DINH
                //lay DS nhung cuon sach co chu de dang Xoa
                var Result = new List<DTO.SachDTO>();
                Result = (from sach in Db.Saches
                            where sach.MaChuDe == chude.MaChuDe
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
                foreach (var item in Result )
                {
                    if(item.MaChuDe==chude.MaChuDe)
                    {

                        item.MaChuDe = 35;//gan lại mã mặc định
                        SachDAO sach = new SachDAO();
                        sach.Edit(item);
                        //Db.SaveChanges();
                    }
                }
                //ko dc xoa chu de MAC DINH
                if(ChuDeDelete.MaChuDe!=35)
                {
                    Db.ChuDes.Remove(ChuDeDelete);
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
        //tim Chu De
        public EF.ChuDe ViewDetail(int maChuDe)//Ho tro Tim Kiem
        {
            return Db.ChuDes.Find(maChuDe);
        }
        //LAY Danh Sach San Pham cua Cua Chu De ID do
        public List<DTO.SachDTO> ListByChuDeId(int maChuDe,string timkiem)
        {
            var Result = (from sach in Db.Saches
                          where sach.MaChuDe == maChuDe
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
                              TrangThai=sach.TrangThai ?? true // !!!
                          }).ToList();
            if (!string.IsNullOrEmpty(timkiem))
            {
                Result = Result.FindAll(x => x.TenSach.ToLower().Contains(timkiem));
            }
            return Result;
        }

    }
}
