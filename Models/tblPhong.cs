using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblPhong")]
    public class tblPhong
    {
        [Key]
        public int P_ID { get; set; }
        public string? P_TenPhong { get; set; }
        public string? P_LoaiPhong { get; set; }
        public int P_SLNguoi { get; set; }
        public string? P_TrangThai { get; set; }
        public double P_GiaTien { get; set; }
        public string? P_MoTa { get; set; }
        public int T_ID { get; set; }

        [ForeignKey("T_ID")]
        public virtual tblToa? Toa { get; set; }
    }
}