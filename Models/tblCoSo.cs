using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn.Models
{
    [Table("tblCoSo")]
    public class tblCoSo
    {
        [Key]
        public int CS_ID { get; set; }
        public string? CS_TenCoSo { get; set; }
        public string? CS_DiaChi { get; set; }
        public int CS_SoToaKTX { get; set; }
    }
}