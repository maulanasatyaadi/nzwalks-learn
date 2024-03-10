using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
