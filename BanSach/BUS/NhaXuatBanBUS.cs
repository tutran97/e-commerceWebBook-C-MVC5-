using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhaXuatBanBUS
    {
        NhaXuatBanDAO nxbDAO = new NhaXuatBanDAO();
        public List<NhaXuatBanDTO> LayDanhSach()
        {
            return nxbDAO.LayDanhSach();
        }
        //timkiem
        public List<NhaXuatBanDTO> LayDanhSach(string timkiem)
        {
            return nxbDAO.LayDanhSach(timkiem);
        }
        public DTO.NhaXuatBanDTO LayNXB(int maNXB)
        {
            return nxbDAO.LayNXB(maNXB);
        }
        public void ThemNXB(DTO.NhaXuatBanDTO nxb)
        {
            nxbDAO.ThemNhaXuatBan(nxb);
        }
        public bool Edit(DTO.NhaXuatBanDTO nxb)
        {
            return nxbDAO.Edit(nxb);
        }
        public bool Delete(DTO.NhaXuatBanDTO nxb)//LAY GET Sach
        {
            return nxbDAO.Delete(nxb);

        }
        //Xoa Chu De Luon
        public bool DeleteLuon(DTO.NhaXuatBanDTO nxb)//LAY GET Sach
        {
            return nxbDAO.DeleteLuon(nxb);
        }
            public void ViewDetail(int maNXB)//Ho tro Tim Kiem
        {
            nxbDAO.ViewDetail(maNXB);
        }
        //LAY Danh Sach San Pham cua Cua Chu De ID do
        public List<DTO.SachDTO> ListByNXBId(int id,string timkiem)
        {
            return nxbDAO.ListByNXBId(id,timkiem);
        }
    }
}
