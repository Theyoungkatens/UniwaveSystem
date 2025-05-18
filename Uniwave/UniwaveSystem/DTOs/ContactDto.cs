using System.ComponentModel.DataAnnotations;

namespace UniwaveSystem.DTOs
{
    public class ContactDto
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;
    }
}
