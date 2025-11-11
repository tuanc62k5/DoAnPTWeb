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
        public string? TK_TenDangNhap { get; set; }
        public string? TK_MatKhau { get; set; }
        public string? TK_Email { get; set; }

    }
}