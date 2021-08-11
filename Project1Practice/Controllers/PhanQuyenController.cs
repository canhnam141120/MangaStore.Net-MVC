using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "PhanQuyen")]
    public class PhanQuyenController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();

        // GET: PhanQuyen
        public ActionResult Index()
        {
            return View(db.LoaiThanhViens);
        }
        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(LoaiThanhVien ltv)
        {
            db.LoaiThanhViens.Add(ltv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PhanQuyen(int? id)
        {
            //Lấy mã loại TV dựa vào id
            if(id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            LoaiThanhVien ltv = db.LoaiThanhViens.SingleOrDefault(n => n.MaLoaiTV == id);
            if (ltv == null)
            {
                return HttpNotFound();
            }
            //Lấy ra danh sách quyền
            ViewBag.MaQuyen = db.Quyens;
            //Lấy ra danh sách quyền của loại thành viên đó
            ViewBag.LoaiTVQuyen = db.LoaiThanhVien_Quyen.Where(n => n.MaLoaiTV == id);
            return View(ltv);
        }

        [HttpPost]
        public ActionResult PhanQuyen(int? MaLTV, IEnumerable<LoaiThanhVien_Quyen> listPhanQuyen)
        {
            //Trường hơp: nếu đã tiến hành phân quyền rồi nhưng muốn phân quyền lại
            //Bước 1: Xóa những quyền của loại TV đó
            var listDaPhanQuyen = db.LoaiThanhVien_Quyen.Where(n => n.MaLoaiTV == MaLTV);
            if(listDaPhanQuyen.Count() != 0)
            {
                db.LoaiThanhVien_Quyen.RemoveRange(listDaPhanQuyen);
                db.SaveChanges();
            }
            if(listPhanQuyen != null)
            {
                //Kiểm tra list danh sách quyền được check
                foreach (var item in listPhanQuyen)
                {
                    item.MaLoaiTV = int.Parse(MaLTV.ToString());
                    //Nếu được check thì insert dữ liệu vào bảng phân quyền
                    db.LoaiThanhVien_Quyen.Add(item);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}