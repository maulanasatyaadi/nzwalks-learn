using NZWalks.Models.Domain;

namespace NZWalks.Models.DTO
{
    public class WalkingPathDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required RegionDTO Region { get; set; }
        public required DifficulityDTO Difficulity { get; set; }
    }
}
