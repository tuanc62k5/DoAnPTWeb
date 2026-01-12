using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblHopDong")]
    public class tblHopDong
    {
        [Key]
        public int HD_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn mã hợp đồng!")]
        public string HD_MaHopDong { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn sinh viên!")]
        public int? SV_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phòng!")]
        public int? P_ID { get; set; }

        public DateTime? HD_NgayBatDau { get; set; }
        public DateTime? HD_NgayKetThuc { get; set; }
        public decimal? HD_GiaPhong { get; set; }
    
        [Required(ErrorMessage = "Vui lòng nhập trạng thái!")]
        public string? HD_TrangThai { get; set; }
        public DateTime HD_NgayTao { get; set; }
        public string? HD_GhiChu { get; set; }

        [ForeignKey("SV_ID")]
        public virtual tblSinhVien? SinhVien { get; set; }
        
        [ForeignKey("P_ID")]
        public virtual tblPhong? Phong { get; set; }
    }
}