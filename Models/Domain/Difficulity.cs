using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class Difficulity
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int DifficulityScale { get; set; } = 0;
    }
}
