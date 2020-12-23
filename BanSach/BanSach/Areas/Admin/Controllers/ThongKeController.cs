using BanSach.Areas.Report;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BanSach.Areas.Admin.Controllers
{
    public class ThongKeController : BaseController
    {
        DataSet1 ds = new DataSet1();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
           
            return View();//truyen vao view cho nay ák

        }
        public ActionResult Report()
        {

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(4800);
            reportViewer.Height = Unit.Percentage(4800);

            /*,KhachHang,ChiTietDonHang where DonHang.MaKH=KhachHang.MaKH and ChiTietDonHang.MaDonHang=DonHang.MaDonHang*/
            //cai nay cua form nen xai thuan
            string conn = @"Data Source=.;Initial Catalog=QuanLyBanSach;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT  DonHang.MaDonHang, DonHang.TinhTrangGiaoHang, DonHang.NgayDat, DonHang.NgayGiao, DonHang.MaKH, DonHang.HoTen, DonHang.SDT, DonHang.Email, DonHang.DiaChi, ChiTietDonHang.MaDonHang AS Expr1,ChiTietDonHang.MaSach, ChiTietDonHang.SoLuong, ChiTietDonHang.DonGia FROM  DonHang INNER JOIN ChiTietDonHang ON DonHang.MaDonHang = ChiTietDonHang.MaDonHang", con);
            adp.Fill(ds, ds.DataTable1.TableName);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Areas\Report\Report1.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
            ViewBag.Report = reportViewer;

            return View();
        }
       
        [HttpPost]
        //tao report HOA DON
        public ActionResult Report(Models.NgayThongKeModel ntk)
        {
            if (ModelState.IsValid)// kiem tra form hop le
            {
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(4800);
                reportViewer.Height = Unit.Percentage(4800);

                /*,KhachHang,ChiTietDonHang where DonHang.MaKH=KhachHang.MaKH and ChiTietDonHang.MaDonHang=DonHang.MaDonHang*/
                //cai nay cua form nen xai thuan
                string conn = @"Data Source=.;Initial Catalog=QuanLyBanSach;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter adp = new SqlDataAdapter("SELECT  DonHang.MaDonHang, DonHang.TinhTrangGiaoHang, DonHang.NgayDat, DonHang.NgayGiao, DonHang.MaKH, DonHang.HoTen, DonHang.SDT, DonHang.Email, DonHang.DiaChi, ChiTietDonHang.MaDonHang AS Expr1,ChiTietDonHang.MaSach, ChiTietDonHang.SoLuong, ChiTietDonHang.DonGia FROM  DonHang INNER JOIN ChiTietDonHang ON DonHang.MaDonHang = ChiTietDonHang.MaDonHang where DonHang.NgayDat between '" + ntk.NgayBatDau + "' and '" + ntk.NgayKetThuc + "'  ", con);
                adp.Fill(ds, ds.DataTable1.TableName);
                reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Areas\Report\Report1.rdlc";
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
                ViewBag.Report = reportViewer;
            }
            else
            {
                ModelState.AddModelError("", "CHƯA NHẬP NGÀY!");
            }
            
            return View();
        }
    }
}
