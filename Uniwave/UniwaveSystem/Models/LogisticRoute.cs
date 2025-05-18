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
        public decimal Price { get; set; }
    }
}
