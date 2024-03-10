using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class AddWalkingPathDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum 100 characters long")]
        public required string Name { get; set; }

        [Required]
        public required int RegionId { get; set; }
        
        [Required]
        public required int DifficulityId { get; set; }
    }
}
