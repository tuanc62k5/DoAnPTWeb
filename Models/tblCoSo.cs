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

        [Required(ErrorMessage = "Vui lòng không để trống số tòa.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số tòa phải lớn hơn 0.")]
        public int? CS_SoToaKTX { get; set; }
    }
}