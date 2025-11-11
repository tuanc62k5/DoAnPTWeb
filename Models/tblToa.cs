using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblToa")]
    public class tblToa
    {
        [Key]
        public int T_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tòa.")]
        public string? T_TenToa { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số tầng.")]
        [Range(1, 100, ErrorMessage = "Số tầng phải từ 1 đến 100.")]
        public int? T_SoTang { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng phòng.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phòng phải lớn hơn 0.")]
        public int? T_SLPhong { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn cơ sở.")]
        public int? CS_ID { get; set; }

        [ForeignKey("CS_ID")]
        public virtual tblCoSo? CoSo { get; set; }
    }
}
