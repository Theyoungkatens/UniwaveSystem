namespace UniwaveSystem.DTOs
{
    public class LogisticRouteDto
    {
        public string FromLocation { get; set; } = null!;
        public string ToLocation { get; set; } = null!;
        public decimal BasePricePerKg { get; set; }
        public decimal ExtraPricePer0_1Kg { get; set; }
    }

}
