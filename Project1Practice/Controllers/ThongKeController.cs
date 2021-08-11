using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    public class ThongKeController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: ThongKe
        public ActionResult Index()
        {
            //Lấy số lượng người truy cập từ application đã được tạo
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString();
            //Lấy số lượng người dùng đang online từ application đã được tạo
            ViewBag.SoLuongNguoiDangOnline = HttpContext.Application["SoLuongNguoiDangOnline"].ToString();
            ViewBag.TongDoanhThu = ThongKeTongDoanhThu();
            ViewBag.TongDDH = ThongKeDonHang();
            ViewBag.TongTV = ThongKeThanhVien();
            return View();
        }

        public decimal ThongKeTongDoanhThu()
        {
            //Thống kê theo tất cả doanh thu từ khi website thành lập
            decimal TongDoanhThu = db.ChiTietDonDatHangs.Sum(n => n.SoLuong * n.DonGia).Value;
            return TongDoanhThu;
        }

        public decimal ThongKeDoanhThuHangThang(int Thang, int Nam)
        {
            //Thống kê theo tất cả doanh thu từ khi website thành lập
            //List ra những đơn hàng nào có tháng, năm tương ứng
            var listDDH = db.DonDatHangs.Where(n => n.NgayDat.Value.Month == Thang && n.NgayDat.Value.Year == Nam);
            decimal TongDoanhThu = 0;
            //Duyetj chi tiết của đơn đặt hàng và tính tổng tiền của tất cả sản phẩm trong đơn hàng
            foreach(var item in listDDH)
            {
                TongDoanhThu += item.ChiTietDonDatHangs.Sum(n => n.SoLuong * n.DonGia).Value;
            }
            return TongDoanhThu;
        }

        public int ThongKeDonHang()
        {
            //Đếm đơn đặt hàng
            int SLDDH = db.DonDatHangs.Count();
            return SLDDH;
        }

        public int ThongKeThanhVien()
        {
            //Đếm số thành viên
            int SLTV = db.ThanhViens.Count();
            return SLTV;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}