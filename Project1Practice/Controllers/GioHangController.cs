using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Practice.Models;

namespace Project1Practice.Controllers
{
    public class GioHangController : Controller
    {
        MangaStoreEntities db = new MangaStoreEntities();
        public List<ItemGioHang> LayGioHang()
        {
            //Giỏ hàng đã tồn tại
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if(listGioHang == null)
            {
                //Nếu session giỏ hàng không tồn tại
                listGioHang = new List<ItemGioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        public ActionResult ThemGioHang(int MaSP, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng
            List<ItemGioHang> listGioHang = LayGioHang();
            ItemGioHang check = listGioHang.SingleOrDefault(n => n.MaSP == MaSP) ;
            if(check != null)
            {
                //Kiểm tra số lượng tồn trước khi cho khách hàng mua hàng
                if(sp.SoLuongTon < check.SoLuong)
                {
                    return View("ThongBao");
                }
                check.SoLuong++;
                check.ThanhTien = check.SoLuong * check.DonGia;
                return Redirect(strURL);
            }
            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            listGioHang.Add(itemGH);
            return Redirect(strURL);
        }

        public double TinhTongSoLuong()
        {
            List<ItemGioHang> listGH = Session["GioHang"] as List<ItemGioHang>;
            if(listGH == null)
            {
                return 0;
            }
            return listGH.Sum(n => n.SoLuong);
        }

        public decimal TinhTongTien()
        {
            List<ItemGioHang> listGH = Session["GioHang"] as List<ItemGioHang>;
            if (listGH == null)
            {
                return 0;
            }
            return listGH.Sum(n => n.ThanhTien);
        }
        


        // GET: GioHang
        public ActionResult XemGioHang()
        {
            //Lấy giỏ hàng
            List<ItemGioHang> listGH = LayGioHang();
            return View(listGH);
        }

        public ActionResult GioHangPartial()
        {
            if(TinhTongSoLuong() == 0)
            {
                ViewBag.TongSL = 0;
                ViewBag.TongT = 0;
                return PartialView();
            }
            ViewBag.TongSL = TinhTongSoLuong();
            ViewBag.TongT = TinhTongTien();
            return PartialView();
        }

        public ActionResult SuaGioHang(int MaSP)
        {
            //Kiểm tra session giỏ hàng tồn tại chưa
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Kiểm tra sản phẩm có tồn tại trong CSDL hay không
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy list giỏ hàng từ session
            List<ItemGioHang> listGH = LayGioHang();
            //Kiểm tra sản pẩm có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = listGH.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Lấy list giỏ hàng tạo giao diện
            ViewBag.GioHang = listGH;
            //Nếu tồn tại rồi
            return View(spCheck);
        }

        //Xử lý cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGioHang(ItemGioHang itemGH)
        {
            //Kiểm tra số lượng tồn
            SanPham spCheck = db.SanPhams.Single(n => n.MaSP == itemGH.MaSP);
            if(spCheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            //Cập nhật số lượng trong session giỏ hàng
            //Bước 1: Lấy List<ItemGioHang> từ session["GioHang"]
            List<ItemGioHang> listGH = LayGioHang();
            //Bước 2: Lấy sản phẩm cần cập nhật từ trong List<ItemGioHang> ra
            ItemGioHang itemGHUpdate = listGH.Find(n => n.MaSP == itemGH.MaSP);
            //Bước 3: Tiến hành cập nhật lại số lượng cùng thành tiền
            itemGHUpdate.SoLuong = itemGH.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;

            return RedirectToAction("XemGioHang");
        }

        public ActionResult XoaGioHang(int MaSP)
        {
            //Kiểm tra session giỏ hàng tồn tại chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Kiểm tra sản phẩm có tồn tại trong CSDL hay không
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy list giỏ hàng từ session
            List<ItemGioHang> listGH = LayGioHang();
            //Kiểm tra sản pẩm có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = listGH.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Xóa item trong giỏ hàng
            listGH.Remove(spCheck);

            return Redirect("XemGioHang");
        }

        public ActionResult DatHang(KhachHang kh)
        {
            //Kiểm tra session giỏ hàng tồn tại chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang newKH = new KhachHang();
            if (Session["TaiKhoan"] == null)
            {
                //Thêm khách hàng vào bảng khách hàng đối với khách hàng chưa có tài khoản
                newKH = kh;
                db.KhachHangs.Add(newKH);
                db.SaveChanges();
            }
            else
            {
                ThanhVien tv = Session["TaiKhoan"] as ThanhVien;
                newKH.TenKH = tv.HoTen;
                newKH.SoDienThoai = tv.SoDienThoai;
                newKH.DiaChi = tv.DiaChi;
                newKH.MaThanhVien = tv.MaThanhVien;
                newKH.Email = tv.Email;
                db.KhachHangs.Add(newKH);
                db.SaveChanges();
            }

            //Thêm đơn hàng
            DonDatHang ddh = new DonDatHang();
            ddh.MaKH = newKH.MaKH;
            ddh.NgayDat = DateTime.Now;
            ddh.TinhTrangGiaoHang = false;
            ddh.DaThanhToan = false;
            ddh.UuDai = 0;
            ddh.DaHuy = false;
            ddh.DaXoa = false;
            db.DonDatHangs.Add(ddh);
            db.SaveChanges();

            //Thêm chi tiết đơn hàng
            List<ItemGioHang> listGH = LayGioHang();
            foreach (var item in listGH)
            {
                ChiTietDonDatHang ctdh = new ChiTietDonDatHang();
                ctdh.MaDDH = ddh.MaDDH;
                ctdh.MaSP = item.MaSP;
                ctdh.TenSP = item.TenSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                db.ChiTietDonDatHangs.Add(ctdh);
                SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == item.MaSP);
                sp.SoLanMua += item.SoLuong;
            }
            
            db.SaveChanges();
            Session["GioHang"] = null;
            ViewBag.ThanhCong = "Đặt hàng thành công";
            return RedirectToAction("XemGioHang");
        }
    }
}