using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblSinhVien")]
    public class tblSinhVien
    {
        [Key]
        public int SV_ID { get; set; }
        public string? SV_MaSV { get; set; }
        public string? SV_HoTen { get; set; }
        public string? SV_GioiTinh { get; set; }
    }
}