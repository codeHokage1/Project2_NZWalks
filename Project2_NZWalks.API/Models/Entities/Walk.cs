namespace Project2_NZWalks.API.Models.Entities
{
    public class Walk
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }

        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}
