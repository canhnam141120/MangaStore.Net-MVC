using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLyNCC")]
    public class QuanLyNCCController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: QuanLyNCC
        public ActionResult Index()
        {
            return View(db.NhaCungCaps);
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(NhaCungCap ncc)
        {
            db.NhaCungCaps.Add(ncc);
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
            NhaCungCap ncc = db.NhaCungCaps.SingleOrDefault(n => n.MaNCC == id);
            if (ncc == null)
            {
                return HttpNotFound();
            }
            return View(ncc);
        }
        [HttpPost]
        public ActionResult ChinhSua(NhaCungCap model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}