using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1Practice.Models
{
    public class ItemGioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        public ItemGioHang(int MaSP)
        {
            using (MangaStoreEntities db = new MangaStoreEntities())
            {
                this.MaSP = MaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == MaSP);
                TenSP = sp.TenSP;
                HinhAnh = sp.HinhAnh;
                MoTa = sp.MoTa;
                DonGia = sp.DonGia.Value;
                this.SoLuong = 1;
                ThanhTien = DonGia * SoLuong;
            }
        }

        public ItemGioHang(int MaSP, int sl)
        {
            using (MangaStoreEntities db = new MangaStoreEntities())
            {
                this.MaSP = MaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == MaSP);
                TenSP = sp.TenSP;
                HinhAnh = sp.HinhAnh;
                MoTa = sp.MoTa;
                DonGia = sp.DonGia.Value;
                this.SoLuong = sl;
                ThanhTien = DonGia * SoLuong;
            }
        }

        public ItemGioHang()
        {

        }

    }
}