using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniwaveSystem.Models
{
    public class ShippingOrder
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string CargoType { get; set; } = null!;  // Loại hàng hóa

        [Required]
        public string PickupAddress { get; set; } = null!; // Địa chỉ nơi đi

        [Required]
        public string DeliveryAddress { get; set; } = null!; // Địa chỉ nơi đến

        [Required]
        public double WeightKg { get; set; }

        [Required]
        public int LogisticRouteId { get; set; }

        [ForeignKey("LogisticRouteId")]
        public LogisticRoute LogisticRoute { get; set; } = null!;
    }
}
