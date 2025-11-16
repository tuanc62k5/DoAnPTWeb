using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoAn.Models;

namespace DoAn.Models
{
    [Table("tblTaiKhoan")]
    public class tblTaiKhoan
    {
        [Key]
        public int TK_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        public string? TK_HoVaTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string? TK_TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string? TK_MatKhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TK_NgaySinh { get; set; }
        public string? TK_DiaChi { get; set; }
        public string? TK_DienThoai { get; set; }
        public string? TK_Email { get; set; }

    }
}