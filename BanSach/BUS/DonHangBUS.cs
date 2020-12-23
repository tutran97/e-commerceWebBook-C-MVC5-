using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{

    public class DonHangBUS
    {
        DonHangDAO donhangDao = new DonHangDAO();
        public int Tao(DTO.KhachHangDTO khachhang, DTO.GioHang giohang)
        {
            return donhangDao.Tao(khachhang, giohang);
        }

        public DTO.DonHangDTO LayHoaDon(int maHD)
        {
            return donhangDao.LayHoaDon(maHD);
        }
        public List<DTO.DonHangDTO> LayDanhSach()
        {
            return donhangDao.LayDanhSach();
        }
        //timkiem
        public List<DTO.DonHangDTO> LayDanhSach(string timkiem)
        {
            return donhangDao.LayDanhSach(timkiem);
        }
        public List<DTO.DonHangDTO> LayDanhSach(int maKH)
        {
            return donhangDao.LayDanhSach(maKH);
        }
        public bool Delete(int maDH)
        {
            return donhangDao.Delete(maDH);
        }
        public List<DTO.ChiTietDonHangDTO> LayDSChiTietHoaDon(int maHD)
        {
            return donhangDao.LayDSChiTietHoaDon(maHD);
        }
        public List<DTO.ChiTietDonHangDTO> LayDSChiTietHoaDon()
        {
            return donhangDao.LayDSChiTietHoaDon();
        }

    }
    }
