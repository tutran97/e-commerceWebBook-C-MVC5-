using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{

    public class KhachHangBUS
    {
        KhachHangDAO KhachHangDao = new KhachHangDAO();

        //DANG NHAP
        public int Login(string tk, string mk)
        {
            return KhachHangDao.Login(tk, mk);
        }
        //lay MaKH
        //lay danh sach
        public List<DTO.KhachHangDTO> LayDanhSach(string searchString)
        {
            return KhachHangDao.LayDanhSach(searchString);
        }
        //lay thong tin 1 khach hang(user)=tai khoan
        public DTO.KhachHangDTO LayKhachHang(string taikhoan)
        {
            return KhachHangDao.LayKhachHang(taikhoan);
        }
        //lay thong tin 1 khach hang(user)=id
        public DTO.KhachHangDTO LayKhachHang(int ma)
        {
            return KhachHangDao.LayKhachHang(ma);
        }
        //add
        public void ThemKH(DTO.KhachHangDTO user)
        {
            KhachHangDao.ThemKH(user);
        }
        //edit
        public bool Edit(DTO.KhachHangDTO user)
        {
            return KhachHangDao.Edit(user);
        }
        //xoa
        public bool Delete(int maKH)//LAY GET Sach
        {
            return KhachHangDao.Delete(maKH);

        }
        //check tai khoan
        public bool CheckTaiKhoan(string tk)
        {
            return KhachHangDao.CheckTaiKhoan(tk);

        }
        //check email
        public bool CheckEmail(string e)
        {
            return KhachHangDao.CheckEmail(e);
        }
        //check mk
        public bool CheckMatKhau(string mk)
        {
            return KhachHangDao.CheckMatKhau(mk);

        }
        //check ADMIN
        public bool IsAdmin(int ID)
        {
            return KhachHangDao.LayKhachHang(ID).MaLoaiKH == 1;
        }
    }
}
