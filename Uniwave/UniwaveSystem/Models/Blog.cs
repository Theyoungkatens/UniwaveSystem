using System.ComponentModel.DataAnnotations;

namespace UniwaveSystem.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string? Tags { get; set; }

        public string? Image { get; set; }

        public string? Category { get; set; }
    }
}
