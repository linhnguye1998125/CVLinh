using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_NQL.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string TENDN { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MATKHAU { get; set; }

        public bool RememberMe { get; set; }
    }

    //public class UserAccount
    //{
    //    [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
    //    public string TenDN { get; set; }

    //    [Required(ErrorMessage = "Mời nhập mật khẩu")]
    //    public string MatKhau { get; set; }

    //    [Required(ErrorMessage = "Mời nhập tên khách hàng")]
    //    public string TenKH { get; set; }

    //    [Required(ErrorMessage = "Mời nhập điạ chi")]
    //    public string diachi { get; set; }

    //    [Required(ErrorMessage = "Mời nhập ngày sinh")]
    //    public DateTime Ngaysinh { get; set; }

    //    [Required(ErrorMessage = "Mời chọn giới tính")]
    //    public int gioitinh { get; set; }

    //    [Required(ErrorMessage = "Mời nhập Email")]
    //    public string email { get; set; }

    //}

    public class DoiMatKhauModel
    {
        [Required(ErrorMessage = "Mật khẩu cũ không đúng")]
        public string MatKhauCu { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu mới")]
        public string MatKhauMoi { get; set; }


        [NotMapped]
        [Required(ErrorMessage = "Xác nhận lại mật khẩu mới")]
        [CompareAttribute("MatKhauMoi", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string nhaplai { get; set; }

    }

}