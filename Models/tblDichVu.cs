using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblDichVu")]
    public class tblDichVu
    {
        [Key]
        public int DV_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên dịch vụ.")]
        public string? DV_TenDichVu { get; set; }
        public string? DV_MoTa { get; set; }
        public decimal? DV_DonGia { get; set; }
        public string? DV_DonViTinh { get; set; }
        public string? DV_TrangThai { get; set; }
    }
}