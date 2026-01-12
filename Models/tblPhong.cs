using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblPhong")]
    public class tblPhong
    {
        [Key]
        public int P_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phòng!")]
        public string P_TenPhong { get; set; } = null!;
        public string? P_LoaiPhong { get; set; }
        public int? P_SLNguoi { get; set; }
        public string? P_TrangThai { get; set; }
        public decimal? P_GiaTien { get; set; }
        public string? P_MoTa { get; set; }
        public DateTime? P_NgayTao { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tòa KTX!")]
        public int? T_ID { get; set; }

        [ForeignKey("T_ID")]
        public virtual tblToa? Toa { get; set; } = null!;
    }
}