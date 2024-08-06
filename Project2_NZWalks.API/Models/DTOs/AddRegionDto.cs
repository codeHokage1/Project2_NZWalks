namespace Project2_NZWalks.API.Models.DTOs
{
    public class AddRegionDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
