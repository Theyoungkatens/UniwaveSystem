using System.ComponentModel.DataAnnotations;

namespace UniwaveSystem.DTOs
{
    public class BlogDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public string? Tags { get; set; }

        public string? Image { get; set; }

        [Required]
        public string Category { get; set; } = null!;
    }
}
