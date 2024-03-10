using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class WalkingPath
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int RegionId { get; set; }
        public required int DifficulityId { get; set; }

        // Relations
        public Region? Region { get; set; }
        public Difficulity? Difficulity { get; set; }
    }
}
