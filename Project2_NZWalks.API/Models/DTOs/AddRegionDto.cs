using System.ComponentModel.DataAnnotations;

namespace Project2_NZWalks.API.Models.DTOs
{
    public class AddRegionDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public required string Code { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
