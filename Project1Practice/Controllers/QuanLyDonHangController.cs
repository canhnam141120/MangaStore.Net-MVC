using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;
using System.Net.Mail;

namespace Project1Practice.Controllers
{
    [Authorize(Roles = "QuanLyDonHang")]
    public class QuanLyDonHangController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        // GET: QuanLyDonHang
        public ActionResult ChuaThanhToan()
        {
            var list = db.DonDatHangs.Where(n => n.DaThanhToan == false).OrderBy(n => n.NgayDat);
            return View(list);
        }

        public ActionResult ChuaGiao()
        {
            var list = db.DonDatHangs.Where(n => n.TinhTrangGiaoHang == false && n.DaThanhToan == true).OrderBy(n => n.NgayDat);
            return View(list);
        }

        public ActionResult DaGiaoDaThanhToan()
        {
            var list = db.DonDatHangs.Where(n => n.DaThanhToan == true && n.TinhTrangGiaoHang == true);
            return View(list);
        }

        [HttpGet]
        public ActionResult DuyetDonHang(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            DonDatHang model = db.DonDatHangs.SingleOrDefault(n => n.MaDDH == id);
            //Kiểm tra đơn đặt hàng có tồn tại hay không
            if(model== null)
            {
                return HttpNotFound();
            }
            //Lấy danh sách chi tiết đơn hàng để hiển thị cho người dùng thấy
            var listChiTiet = db.ChiTietDonDatHangs.Where(n => n.MaDDH == id);
            ViewBag.ListChiTiet = listChiTiet;
            return View(model);
        }

        [HttpPost]
        public ActionResult DuyetDonHang(DonDatHang ddh)
        {
            //Truy vấn lấy ra dữ liệu của đơn hàng đó
            DonDatHang ddhUpdate = db.DonDatHangs.SingleOrDefault(n => n.MaDDH == ddh.MaDDH);
            ddhUpdate.DaThanhToan = ddh.DaThanhToan;
            ddhUpdate.TinhTrangGiaoHang = ddh.TinhTrangGiaoHang;
            ddhUpdate.NgayGiao = ddh.NgayGiao;
            db.SaveChanges();
            //Lấy danh sách chi tiết đơn hàng để hiển thị cho người dùng thấy
            var listChiTiet = db.ChiTietDonDatHangs.Where(n => n.MaDDH == ddh.MaDDH);
            ViewBag.ListChiTiet = listChiTiet;
            //Gửi khách hàng 1 mail để xác nhận việc thanh toán
            GuiEmail("Xác nhận đơn hàng của hệ thống MangaStore!", 
                "namnche141707@fpt.edu.vn", "canhnamakashi@gmail.com", 
                "canhnamakashi1", 
                "Xin chào "+ ddhUpdate.KhachHang.TenKH  + "Đơn hàng của bạn đã được duyệt thành công! Ngày giao dự kiến: " + ddhUpdate.NgayGiao.Value.ToString("dd/MM/yyyy")
                );

            return View(ddhUpdate);
        }

        public void GuiEmail(string Title, string ToEmail, string FromEmail, string PassWord, string Content)
        {
            //Gửi mail
            MailMessage mail = new MailMessage();
            mail.To.Add(ToEmail); //Địa chỉ nhận
            mail.From = new MailAddress(ToEmail); //Địa chỉ gửi
            mail.Subject = Title; //Tiêu đề gửi
            mail.Body = Content; //Nội dung
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Host gửi của Gmail
            smtp.Port = 587; //Port gửi của Gmail
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
                (FromEmail, PassWord); //Tài khoản & Password người gửi
            smtp.EnableSsl = true; //Kích hoạt giao tiếp an toàn SSL
            smtp.Send(mail); //Gửi mail đi
        }
        

    }
}