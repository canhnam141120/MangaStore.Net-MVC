using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLySanPham")]
    public class QuanLySanPhamController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: QuanLySanPham
        public ActionResult Index()
        {
            return View(db.SanPhams.Where(n => n.DaXoa == false).OrderByDescending(n=>n.MaSP)); ;
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            //Load dropdown list 
            
            ViewBag.MaTruyen = new SelectList(db.Truyens.OrderBy(n => n.TenTruyen), "MaTruyen", "TenTruyen");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");

            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(SanPham sp, HttpPostedFileBase HinhAnh)
        {
            ViewBag.MaTruyen = new SelectList(db.Truyens.OrderBy(n => n.TenTruyen), "MaTruyen", "TenTruyen");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            if (HinhAnh.ContentLength > 0)
            {
                //Lấy tên hình ảnh
                var fileName = Path.GetFileName(HinhAnh.FileName);
                //Lấy hình ảnh chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Content/HinhAnhSP"), fileName);
                //Nếu thư mục chứ hình ảnh đó rồi thì xuất ra thông báo
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Upload = "Hình ảnh sản phẩm đã tồn tại";
                }
                else
                {
                    //Lấy hình ảnh đưa vào folder HinhAnhSP
                    HinhAnh.SaveAs(path);
                    sp.HinhAnh = fileName;
                }

                db.SanPhams.Add(sp);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ChinhSua(int? id)
        {
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

            //Load dropdown list 
            ViewBag.MaTruyen = new SelectList(db.Truyens.OrderBy(n => n.TenTruyen), "MaTruyen", "TenTruyen", sp.MaTruyen);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai", sp.MaLoaiSP);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sp.MaNXB);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            return View(sp);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSua(SanPham model)
        {
            ViewBag.MaTruyen = new SelectList(db.Truyens.OrderBy(n => n.TenTruyen), "MaTruyen", "TenTruyen", model.MaTruyen);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai", model.MaLoaiSP);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", model.MaNXB);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", model.MaNCC);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int? id)
        {
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

            //Load dropdown list 
            ViewBag.MaTruyen = new SelectList(db.Truyens.OrderBy(n => n.TenTruyen), "MaTruyen", "TenTruyen", sp.MaTruyen);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(n => n.TenLoai), "MaLoaiSP", "TenLoai", sp.MaLoaiSP);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sp.MaNXB);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            return View(sp);
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            db.SanPhams.Remove(sp);
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        //Giải phóng biến cho vùng nhớ
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