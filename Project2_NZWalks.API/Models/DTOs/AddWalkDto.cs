using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Models.DTOs
{
    public class AddWalkDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

    }
}
