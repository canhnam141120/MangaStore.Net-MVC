using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1Practice.Models
{
    [MetadataTypeAttribute(typeof(ThanhVienMetadata))]
    public partial class ThanhVien
    {
        internal sealed class ThanhVienMetadata
        {
            public int MaThanhVien { get; set; }
            [Required(ErrorMessage = "Tài khoản không được để trống!")]
            [StringLength(15, ErrorMessage = "Tài khoản không được quá 15 ký tự!")]
            public string TaiKhoan { get; set; }
            [Required(ErrorMessage = "Mật khẩu không được để trống!")]
            public string MatKhau { get; set; }
            [Required(ErrorMessage = "Họ tên không được để trống!")]
            public string HoTen { get; set; }
            [Required(ErrorMessage = "Địa chỉ không được để trống!")]
            public string DiaChi { get; set; }
            [Required(ErrorMessage = "Email không được để trống!")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ!")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Số điện thoại không được để trống!")]
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Số điện thoại không hợp lệ!")]
            public string SoDienThoai { get; set; }
            public string CauHoi { get; set; }
            [Required(ErrorMessage = "Câu trả lời không được để trống!")]
            public string CauTraLoi { get; set; }
            public Nullable<int> MaLoaiTV { get; set; }

        }
    }
}