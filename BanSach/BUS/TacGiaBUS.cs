using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class TacGiaBUS
    {
        TacGiaDAO tgDAO = new TacGiaDAO();
        public List<TacGiaDTO> LayDanhSach()
        {
            return tgDAO.LayDanhSach();
        }
        //timkiem
        public List<TacGiaDTO> LayDanhSach(string timkiem)
        {
            return tgDAO.LayDanhSach(timkiem);
        }
        public DTO.TacGiaDTO LayTG(int maTG)
        {
            return tgDAO.LayTacGia(maTG);
        }
        public void ThemTacGia(DTO.TacGiaDTO tg)
        {
            tgDAO.ThemTacGia(tg);
        }
        public bool Edit(DTO.TacGiaDTO tg)
        {
            return tgDAO.Edit(tg);
        }
        public bool Delete(DTO.TacGiaDTO tg)//LAY GET Sach
        {
            return tgDAO.Delete(tg);

        }
        //Xoa Chu De Luon
        public bool DeleteLuon(DTO.TacGiaDTO tg)//LAY GET Sach
        {
            return tgDAO.DeleteLuon(tg);
        }
            public void ViewDetail(int maTG)//Ho tro Tim Kiem
        {
            tgDAO.ViewDetail(maTG);
        }

        //LAY Danh Sach San Pham cua Cua TacGia ID do
        public List<DTO.SachDTO> ListByTacGiaId(int id,string timkiem)
        {
            return tgDAO.ListByTacGiaId(id,timkiem);
        }
    }
}
