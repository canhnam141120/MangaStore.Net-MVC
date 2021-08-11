using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLyNXB")]
    public class QuanLyNXBController : Controller
    {
        // GET: QuanLyNXB
        MangaStoreEntities db = new MangaStoreEntities();
        public ActionResult Index()
        {
            return View(db.NhaXuatBans);
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(NhaXuatBan nxb)
        {
            db.NhaXuatBans.Add(nxb);
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
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == id);
            if (nxb == null)
            {
                return HttpNotFound();
            }
            return View(nxb);
        }
        [HttpPost]
        public ActionResult ChinhSua(NhaXuatBan model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}