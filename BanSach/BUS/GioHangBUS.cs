using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class GioHangBUS
    {
        GioHangDAO giohangDAO = new GioHangDAO();

        public int Create(int maKhachHang)
        {
            return giohangDAO.Create(maKhachHang);
        }
        public bool Add(int magiohang, int masanpham, int soluong)
        {
            return giohangDAO.Add(magiohang, masanpham, soluong);
        }
        public DTO.GioHang GetList(int magiohang)
        {
            return giohangDAO.GetList(magiohang);
        }
        //xoa item in giohang
        public bool Delete(int maSp)
        {
            return giohangDAO.Delete(maSp);
        }
        //lay danh sach chi tiet giohang
        public List<DTO.ChiTietGioHang> dschitietgiohang(int id)
        {
            return giohangDAO.dschitietgiohang(id);
        }
    }
}