using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{

    public class SachBUS
    {
        SachDAO sachDao = new SachDAO();
        public List<DTO.SachDTO> LayDanhSach()
        {

            return sachDao.LayDanhSach();
        }
        public DTO.SachDTO LaySach(int maSach)
        {

            return sachDao.LaySach(maSach);
        }
        public void ThemSach(DTO.SachDTO sach)
        {
            sachDao.ThemSach(sach);
        }
        public bool Edit(DTO.SachDTO sach)
        {
            return sachDao.Edit(sach);
        }
        public bool Delete(int maSach)//LAY GET Sach
        {
            return sachDao.Delete(maSach);

        }
        //tim kiems
        public List<DTO.SachDTO> LayDanhSach(string timkiem)
        {
            return sachDao.LayDanhSach(timkiem);
        }
    }
}
