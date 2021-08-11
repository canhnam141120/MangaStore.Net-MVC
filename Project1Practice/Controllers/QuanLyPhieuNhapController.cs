using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLyPhieuNhap")]
    public class QuanLyPhieuNhapController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: QuanLyPhieuNhap
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.MaNCC = db.NhaCungCaps;
            ViewBag.ListSP = db.SanPhams;
            return View();
        }
        [HttpPost]
        public ActionResult NhapHang(PhieuNhap model, IEnumerable<ChiTietPhieuNhap> listModel)
        {
            ViewBag.MaNCC = db.NhaCungCaps;
            ViewBag.ListSP = db.SanPhams;
            //Sau khi đã kiểm tra tất cả dữ liệu đầu vào
            //Gán DaXoa = false
            model.DaXoa = false;
            db.PhieuNhaps.Add(model);
            db.SaveChanges();

            SanPham sp;

            //Lấy mã phiếu nhập sau khi PhieuNhap được save trong database để gán cho listChiTietPhieuNhap
            foreach (var item in listModel)
            {
                //Gán MaPN cho tất cả ChiTietPhieuNhap
                item.MaPN = model.MaPN;
                //Cập nhật số lượng tồn trong kho
                sp = db.SanPhams.Single(n => n.MaSP == item.MaSP);
                sp.SoLuongTon += item.SoLuongNhap;
            }
            //Add list vào database
            db.ChiTietPhieuNhaps.AddRange(listModel);
            db.SaveChanges();

            return View();
        }
        [HttpGet]
        public ActionResult DSSPHetHang()
        {
            //Danh sách sản phẩm gần hết hàng
            var listSP = db.SanPhams.Where(n => n.DaXoa == false && n.SoLuongTon <= 5);
            return View(listSP);
        }
        [HttpGet]
        public ActionResult NhapHangDon(int? id)
        {

            //Tương tự như trang chỉnh sửa, nhưng ta không cần phải show hết các thuộc tính
            //Chỉ thuộc tính nào cần thiết thôi là số lượng tồn, hình ảnh
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            return View(sp);
        }
        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap pn, ChiTietPhieuNhap ctpn)
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", pn.MaNCC);

            //Sau khi đã kiểm tra tất cả dữ liệu đầu vào
            //Gán DaXoa = false
            pn.DaXoa = false;
            db.PhieuNhaps.Add(pn);
            db.SaveChanges();

            SanPham sp;

            //Lấy mã phiếu nhập sau khi PhieuNhap được save trong database để gán cho listChiTietPhieuNhap

            //Gán MaPN cho tất cả ChiTietPhieuNhap
            ctpn.MaPN = pn.MaPN;
            //Cập nhật số lượng tồn trong kho
            sp = db.SanPhams.Single(n => n.MaSP == ctpn.MaSP);
            sp.SoLuongTon += ctpn.SoLuongNhap;

            //Add list vào database
            db.ChiTietPhieuNhaps.Add(ctpn);
            db.SaveChanges();

            return View(sp);
        }

        //Giải phóng biến cho vùng nhớ
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}