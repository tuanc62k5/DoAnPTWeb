using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblCoSo")]
    public class tblCoSo
    {
        [Key]
        public int CS_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên cơ sở!")]
        public string? CS_TenCoSo { get; set; }
        public string? CS_DiaChi { get; set; }
        public string CS_TrangThai { get; set; } = "Hoạt động";
        public DateTime? CS_NgayTao { get; set; }
        
    }
}