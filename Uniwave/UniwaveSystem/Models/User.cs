﻿using System.ComponentModel.DataAnnotations;

namespace UniwaveSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        public int Role { get; set; }
    }
}
