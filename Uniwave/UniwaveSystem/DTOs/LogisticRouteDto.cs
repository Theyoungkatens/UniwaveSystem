namespace UniwaveSystem.DTOs
{
    public class LogisticRouteDto
    {
        public string FromLocation { get; set; } = null!;
        public string ToLocation { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
