namespace UniwaveSystem.DTOs
{
    public class ShippingOrderCreateDto
    {
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string CargoType { get; set; } = null!;
        public string PickupAddress { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public double WeightKg { get; set; }
        public int LogisticRouteId { get; set; }
    }
}
