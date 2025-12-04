using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblDatPhong")]
    public class tblDatPhong
    {
        [Key]
        public int DP_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn sinh viên!")]
        public int? SV_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phòng!")]
        public int? P_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày đặt!")]
        public DateTime? DP_NgayDat { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập trạng thái!")]
        public string? DP_TrangThai { get; set; }
        public string? DP_GhiChu { get; set; }
        public string? DP_NguoiTao { get; set; }
        public DateTime? DP_ThoiGianTao { get; set; }
        public string? DP_NguoiSua { get; set; }
        public DateTime? DP_ThoiGianSua { get; set; }

        [ForeignKey("SV_ID")]
        public virtual tblSinhVien? SinhVien { get; set; }
        
        [ForeignKey("P_ID")]
        public virtual tblPhong? Phong { get; set; }
    }
}