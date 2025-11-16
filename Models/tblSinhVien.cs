using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblSinhVien")]
    public class tblSinhVien
    {
        [Key]
        public int SV_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên.")]
        public string? SV_MaSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên sinh viên.")]
        public string? SV_HoTen { get; set; }
        public string? SV_GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SV_NgaySinh { get; set; }
        public string? SV_DiaChi { get; set; }
        public string? SV_Email { get; set; }
        public string? SV_Sdt { get; set; }
        public int? P_ID { get; set; }

        [ForeignKey("P_ID")]
        public virtual tblPhong? Phong { get; set; }
        public int? TK_ID { get; set; }

        [ForeignKey("TK_ID")]
        public virtual tblTaiKhoan? TaiKhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phòng có trong danh sách!")]
        [NotMapped]
        [Display(Name ="Tên phòng")]
        public string? TenPhong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản có trong danh sách!")]
        [NotMapped]
        [Display(Name ="Tên tài khoản")]
        public string? TenDangNhap { get; set; }
    }
}