using Project2_NZWalks.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project2_NZWalks.API.Models.DTOs
{
    public class AddWalkDto
    {
        [Required]

        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public double LengthInKM { get; set; }
        public string? WalkImageURL { get; set; }

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

    }
}
