using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Models.DTOs
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }

    }
}
