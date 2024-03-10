﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
