using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_NZWalks.API.Data;
using Project2_NZWalks.API.Models.DTOs;
using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetRegions()
        {
            var regionsFromDB = dbContext.Regions.ToList();

            var regionsToSend = new List<RegionDto>();
            foreach(var region in regionsFromDB)
            {
                regionsToSend.Add(new RegionDto
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageURL = region.RegionImageURL
                });
            }

            return Ok(regionsToSend);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionById(Guid id)
        {
            var foundRegion = dbContext.Regions.Find(id);
            if (foundRegion == null)
            {
                return NotFound();
            }

            var regionToSend = new RegionDto
            {
                Id = foundRegion.Id,
                Code = foundRegion.Code,
                Name = foundRegion.Name,
                RegionImageURL = foundRegion.RegionImageURL
            };

            return Ok(regionToSend);
        }

        [HttpPost]
        public IActionResult AddRegion(AddRegionDto regionToAdd)
        {
            var regionToAddToDB = new Region
            {
                Code = regionToAdd.Code,
                Name = regionToAdd.Name,
                RegionImageURL = regionToAdd.RegionImageURL
            };

            dbContext.Regions.Add(regionToAddToDB);
            dbContext.SaveChanges();

            var newRegionDto = new RegionDto
            {
                Id = regionToAddToDB.Id,
                Code = regionToAddToDB.Code,
                Name = regionToAddToDB.Name,
                RegionImageURL = regionToAddToDB.RegionImageURL
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = newRegionDto.Id }, newRegionDto);
        }
    }
}
