using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblThietBiPhong")]
    public class tblThietBiPhong
    {
        [Key]
        public int TBP_ID { get; set; }
        public int TB_ID { get; set; }
        public int P_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng giao!")]
        public int? TBP_SoLuongGiao { get; set; }
        public DateTime? TBP_NgayGiao { get; set; }
        public DateTime? TBP_NgayThuHoi { get; set; }
        public string? TBP_GhiChu { get; set; }

        [ForeignKey("TB_ID")]
        public virtual tblThietBi? ThietBi { get; set; }

        [ForeignKey("P_ID")]
        public virtual tblPhong? Phong { get; set; }
    }
}