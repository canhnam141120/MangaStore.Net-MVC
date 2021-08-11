using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "Quantri")]
    public class QuanLyQuyenController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: QuanLyQuyen
        public ActionResult Index()
        {
            return View(db.Quyens);
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(Quyen q)
        {
            db.Quyens.Add(q);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(string maQuyen)
        {
            if (maQuyen == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            Quyen q = db.Quyens.SingleOrDefault(n => n.MaQuyen == maQuyen);
            if (q == null)
            {
                return HttpNotFound();
            }
            return View(q);
        }
        [HttpPost]
        public ActionResult ChinhSua(Quyen model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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