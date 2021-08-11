using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;
using PagedList;

namespace Project1Practice.Controllers
{
    public class SanPhamController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: SanPham
        
        [ChildActionOnly]
        public ActionResult SanPhamStyle1Partial()
        {

            return PartialView();
        }

        public ActionResult SanPhamStyle2Partial()
        {
            return PartialView();
        }

        public ActionResult ChiTietSanPham(int? MaSP, int? page)
        {
            if(MaSP == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 3;
            int pageIndex = (page ?? 1);
            
            var listBinhLuan = db.BinhLuans.Where(n => n.MaSP == MaSP);

            var sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaSP = MaSP;
            ViewBag.SP = sp;
            ViewBag.Page = page;
            return View(listBinhLuan.OrderByDescending(n => n.NgayBinhLuan).ToPagedList(pageIndex, pageSize));
        }
        [HttpPost]
        public ActionResult BinhLuan(BinhLuan bl)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == bl.MaSP);
            sp.LuotBinhLuan += 1;
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;

            bl.NgayBinhLuan = DateTime.Now;
            db.BinhLuans.Add(bl);
            db.SaveChanges();
            return RedirectToAction("ChiTietSanPham", new { @MaSP = bl.MaSP });
        }

        [HttpPost]
        public ActionResult BinhChon(int MaSP)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            sp.LuotBinhChon += 1;
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ChiTietSanPham", new { @MaSP = MaSP });
        }

        public ActionResult MenuStandeePartial()
        {
            var listTr = db.Truyens;
            var spTop = db.SanPhams.OrderByDescending(n => n.SoLanMua);
            ViewBag.spTop = spTop;
            return PartialView(listTr);
        }

        public ActionResult MenuBottomPartial()
        {
            var spHot = db.SanPhams.OrderByDescending(n => n.LuotBinhChon);
            return PartialView(spHot);
        }

        public ActionResult SanPham(int? MaLoaiSP, int? page)
        {
            if(MaLoaiSP == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var listSP = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP);
            if(listSP.Count() == 0)
            {
                return HttpNotFound();
            }
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            //Thực hiện chức năng phân trang
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            ViewBag.LoaiSP = listSP;
            ViewBag.MaLoaiSP = MaLoaiSP;
            return View(listSP.OrderBy(n=>n.MaSP).ToPagedList(pageIndex, pageSize));
        }

        public ActionResult SanPhamAll(int? page)
        {
            var listSP = db.SanPhams;
            if (listSP.Count() == 0)
            {
                return HttpNotFound();
            }
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            //Thực hiện chức năng phân trang
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            return View(listSP.OrderByDescending(n => n.MaSP).ToPagedList(pageIndex, pageSize));
        }

        public ActionResult SanPhamByType(int? MaTruyen, int? page)
        {
            if (MaTruyen == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var listSP = db.SanPhams.Where(n => n.MaTruyen == MaTruyen);
            if (listSP.Count() == 0)
            {
                return HttpNotFound();
            }
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            //Thực hiện chức năng phân trang
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            ViewBag.Truyen = listSP;
            ViewBag.MaTruyen = MaTruyen;
            return View(listSP.OrderBy(n => n.MaSP).ToPagedList(pageIndex, pageSize));
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