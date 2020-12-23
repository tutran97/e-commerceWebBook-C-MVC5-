using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChuDeBUS
    {
        ChuDeDAO chudeDao = new ChuDeDAO();
        public List<ChuDeDTO> LayDanhSach()
        {
            return chudeDao.LayDanhSach();
        }
        public List<ChuDeDTO> LayDanhSach(string timkiem)
        {
            return chudeDao.LayDanhSach(timkiem);
        }
        public DTO.ChuDeDTO LayChuDe(int maChuDe)
        {

            return chudeDao.LayChuDe(maChuDe);
        }
        public void ThemChuDe(DTO.ChuDeDTO chude)
        {
            chudeDao.ThemChuDe(chude);
        }
        public bool Edit(DTO.ChuDeDTO chude)
        {
            return chudeDao.Edit(chude);
        }
        public bool Delete(DTO.ChuDeDTO chude)//LAY GET Sach
        {
            return chudeDao.Delete(chude);

        }
        //xoa luon
        public bool DeleteLuon(DTO.ChuDeDTO chude)//LAY GET Sach
        {
            return chudeDao.DeleteLuon(chude);
        }
            public void ViewDetail(int maChuDe)//Ho tro Tim Kiem
        {
            chudeDao.ViewDetail(maChuDe);
        }
        //LAY Danh Sach San Pham cua Cua Chu De ID do
        public List<DTO.SachDTO> ListByChuDeId(int id,string timkiem)
        {
            return chudeDao.ListByChuDeId(id,timkiem);
        }
    }
}
