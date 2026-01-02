using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblToa")]
    public class tblToa
    {
        [Key]
        public int T_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tòa!")]
        public string T_TenToa { get; set; } = null!;
        public int? T_SoTang { get; set; }
        public string? T_TrangThai { get; set; }
        public DateTime T_NgayTao { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn cơ sở!")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn cơ sở!")]
        public int CS_ID { get; set; }

        [ForeignKey("CS_ID")]
        public virtual tblCoSo CoSo { get; set; } = null!;
    }
}
