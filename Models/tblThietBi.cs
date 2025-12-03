using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblThietBi")]
    public class tblThietBi
    {
        [Key]
        public int TB_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thiết bị!")]
        public string? TB_TenThietBi { get; set; }
        public string? TB_MoTa { get ; set; }
        public string? TB_DonViTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng!")]
        public int? TB_SoLuong { get; set; }
        public string? TB_TinhTrang { get; set; }
        public string? TB_ViTriKho { get; set; }
        public DateTime? TB_NgayNhapKho { get; set; }
        public string? TB_GhiChu { get; set; }
    }
}