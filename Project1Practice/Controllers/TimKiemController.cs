using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;
using PagedList;
namespace Project1Practice.Controllers

{
    public class TimKiemController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            //Thực hiện chức năng phân trang
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            var listSP = db.SanPhams.Where(n => n.TenSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(listSP.OrderBy(n => n.TenSP).ToPagedList(pageIndex, pageSize));
        }
        
        [HttpPost]
        public ActionResult TimKiem(string sTuKhoa, int? page,FormCollection f)
        {
            //Gọi về hàm get tìm kiếm
            return RedirectToAction("KetQuaTimKiem", new {@sTuKhoa = sTuKhoa});
        }

        public ActionResult KQTimKiemPartial(string sTuKhoa)
        {
            var listSP = db.SanPhams.Where(n => n.TenSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return PartialView(listSP.OrderBy(n => n.TenSP));
        }
    }
}