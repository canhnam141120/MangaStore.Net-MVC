﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project1Practice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            this.PhieuNhaps = new HashSet<PhieuNhap>();
            this.SanPhams = new HashSet<SanPham>();
        }


        [DisplayName("Mã Nhà Cung Cấp: ")]
        public int MaNCC { get; set; }
        [DisplayName("Tên Nhà Cung Cấp: ")]
        public string TenNCC { get; set; }
        [DisplayName("Địa Chỉ: ")]
        public string DiaChi { get; set; }
        [DisplayName("Email: ")]
        public string Email { get; set; }
        [DisplayName("Số Điện Thoại: ")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}