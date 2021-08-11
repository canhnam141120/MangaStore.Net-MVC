using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;
namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLyTruyen")]
    public class QuanLyTruyenController : Controller
    {
        // GET: QuanLyTruyen
        MangaStoreEntities db = new MangaStoreEntities();
        public ActionResult Index()
        {
            return View(db.Truyens);
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(Truyen t)
        {
            db.Truyens.Add(t);
            db.SaveChanges();
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
            Truyen t = db.Truyens.SingleOrDefault(n => n.MaTruyen == id);
            if (t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult ChinhSua(Truyen model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}