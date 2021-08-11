using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using System.Web.Security;

namespace Project1Practice.Controllers
{
    public class HomeController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: Home
        public ActionResult Index()
        {

            var listHOT = db.SanPhams.OrderByDescending(n => n.LuotBinhChon);
            ViewBag.listHOT = listHOT;

            var listSPM = db.SanPhams.OrderByDescending(n => n.MaSP);
            ViewBag.listSPM = listSPM;

            return View();
        }
        public ActionResult MenuPartial()
        {
            var listTr = db.Truyens;
            return PartialView(listTr);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {

            string taikhoan = f["txtTaikhoan"].ToString();
            string matkhau = f["txtMatKhau"].ToString();
            //Truy vấn kiểm tra đăng nhập lấy thông tin thành viên
            ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
            if (tv != null)
            {
                //Lấy ra list quyền của thành viên tương ứng với loại thành viên
                var listQuyen = db.LoaiThanhVien_Quyen.Where(n => n.MaLoaiTV == tv.MaLoaiTV);
                string Quyen = "";
                if(listQuyen.Count() != 0)
                {
                    foreach (var item in listQuyen)
                    {
                        Quyen += item.Quyen.MaQuyen + ","; //Quyền được lưu dưới dạng chuỗi
                    }
                    Quyen = Quyen.Substring(0, Quyen.Length - 1); //Cắt đi dấu , cuối cùng
                    PhanQuyen(tv.TaiKhoan, Quyen);
                    Session["TaiKhoan"] = tv;
                    return RedirectToAction("Index");
                }
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index");
            }
            ViewBag.ThongBao = "Đăng nhập không thành công!";
            return View();
        }

        public void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();

            var ticket = new FormsAuthenticationTicket(1,
                TaiKhoan, //user
                DateTime.Now, //begin
                DateTime.Now.AddHours(3), //Timeout
                false, //Remember?
                Quyen, //Permission.. "admin" or for more than one
                FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv, FormCollection f)
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            //Kiểm tra Captcha hợp lệ
            if (this.IsCaptchaValid("Captcha không hợp lệ"))
            {
                if (ModelState.IsValid)
                {
                    if (tv.MatKhau == f["NhapLaiMatKhau"].ToString())
                    {
                        ViewBag.ThongBao = "Đăng ký thành công";
                        db.ThanhViens.Add(tv);
                        db.SaveChanges();
                        return View();
                    }
                    {
                        ViewBag.XacThucMatKhau = "Mật khẩu không khớp!";
                    }
                }
                ViewBag.ThongBao = "Đăng ký thất bại!";
            }
            else
            {
                ViewBag.ThongBao = "Mã Captcha không hợp lệ!";
            }
            return View();
        }

        public List<string> LoadCauHoi()
        {
            List<string> listCauHoi = new List<string>();
            listCauHoi.Add("Con vật mà bạn yêu thích?");
            listCauHoi.Add("Ca sĩ mà bạn yêu thích?");
            listCauHoi.Add("Hiện tại bạn đang làm công việc gì?");
            return listCauHoi;
        }
              

        public ActionResult Contact()
        {
            return View();
        }

        //Tạo trang ngăn chặn quyền truy cập
        public ActionResult LoiPhanQuyen()
        {
            return View();
        }
    }

}