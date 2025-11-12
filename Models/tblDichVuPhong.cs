using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblDichVuPhong")]
    public class tblDichVuPhong
    {
        [Key]
        public int DVP_ID { get; set; }
        public int P_ID { get; set; }
        public int DV_ID { get; set; }
        public int? DVP_SoLuong { get; set; }
        public int? DVP_ThanhTien { get; set; }
        public DateTime? DVP_ThoiGian { get; set; }
    }
}