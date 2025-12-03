using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblBaoTriThietBi")]
    public class tblBaoTriThietBi
    {
        [Key]
        public int BTTB_ID { get; set; }
        public int TB_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng!")]
        public int BTTB_SoLuong { get; set; }
        public DateTime? BTTB_NgayBaoTri { get; set; }
        public string? BTTB_NoiDungBaoTri { get; set; }
        public decimal? BTTB_ChiPhi { get; set; }
        public string? BTTB_DonViThucHien { get; set; }
        public string? BTTB_GhiChu { get; set; }
        

        [ForeignKey("TB_ID")]
        public virtual tblThietBi? ThietBi { get; set; }
    }
}
