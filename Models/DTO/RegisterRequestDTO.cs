using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public required string Password { get; set; }

        [Required]
        public required string[] Roles { get; set; }
    }
}
