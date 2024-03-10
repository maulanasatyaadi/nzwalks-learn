namespace NZWalks.Models.DTO
{
    public class DifficulityDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int DifficulityScale { get; set; } = 0;
    }
}
