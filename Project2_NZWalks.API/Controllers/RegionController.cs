using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetRegions()
        {
            var regionsFromDB = await dbContext.Regions.ToListAsync();

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
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var foundRegion = await dbContext.Regions.FindAsync(id);
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
        public async Task<IActionResult> AddRegion(AddRegionDto regionToAdd)
        {
            var regionToAddToDB = new Region
            {
                Code = regionToAdd.Code,
                Name = regionToAdd.Name,
                RegionImageURL = regionToAdd.RegionImageURL
            };

            await dbContext.Regions.AddAsync(regionToAddToDB);
            await dbContext.SaveChangesAsync();

            var newRegionDto = new RegionDto
            {
                Id = regionToAddToDB.Id,
                Code = regionToAddToDB.Code,
                Name = regionToAddToDB.Name,
                RegionImageURL = regionToAddToDB.RegionImageURL
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = newRegionDto.Id }, newRegionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(Guid id, AddRegionDto updatedRegion)
        {
            var regionToUpdate = await dbContext.Regions.FindAsync(id);
            if (regionToUpdate == null)
            {
                return NotFound();
            }

            regionToUpdate.Code = updatedRegion.Code;
            regionToUpdate.Name = updatedRegion.Name;
            regionToUpdate.RegionImageURL = updatedRegion.RegionImageURL;

            await dbContext.SaveChangesAsync();

            return Ok(regionToUpdate);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var foundRegion = await dbContext.Regions.FindAsync(id);
            if (foundRegion == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(foundRegion);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
