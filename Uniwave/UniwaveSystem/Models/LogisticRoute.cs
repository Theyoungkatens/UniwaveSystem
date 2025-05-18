using System.ComponentModel.DataAnnotations;

namespace UniwaveSystem.Models
{
    public class LogisticRoute
    {
        public int Id { get; set; }

        [Required]
        public string FromLocation { get; set; } = null!;

        [Required]
        public string ToLocation { get; set; } = null!;

        [Required]
        public decimal BasePricePerKg { get; set; }  // Ví dụ 156600 cho 1kg

        [Required]
        public decimal ExtraPricePer0_1Kg { get; set; }  // Ví dụ 443 VNĐ cho mỗi 0.1kg tăng thêm
    }

}
