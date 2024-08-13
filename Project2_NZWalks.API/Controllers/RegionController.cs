using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2_NZWalks.API.CustomActionFilters;
using Project2_NZWalks.API.Data;
using Project2_NZWalks.API.Models.DTOs;
using Project2_NZWalks.API.Models.Entities;
using Project2_NZWalks.API.Repositories;

namespace Project2_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionInterface regionInterface;
        private readonly IMapper mapper;

        public RegionController(NZWalksDbContext dbContext, IRegionInterface regionInterface, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionInterface = regionInterface;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regionsFromDB = await regionInterface.GetRegionsAsync();

            var regionsToSend = mapper.Map<List<RegionDto>>(regionsFromDB);

            return Ok(regionsToSend);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var foundRegion = await regionInterface.GetRegionByIdAsync(id);
            if (foundRegion == null)
            {
                return NotFound();
            }

            var regionToSend = mapper.Map<RegionDto>(foundRegion);

            return Ok(regionToSend);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddRegion(AddRegionDto regionToAdd)
        {
            var regionToAddToDB = mapper.Map<Region>(regionToAdd);

            regionToAddToDB = await regionInterface.CreateRegionAsync(regionToAddToDB);

            var newRegionDto = mapper.Map<RegionDto>(regionToAddToDB);

            return CreatedAtAction(nameof(GetRegionById), new { id = newRegionDto.Id }, newRegionDto);
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion(Guid id, AddRegionDto updatedRegion)
        {
            var updatedRegionToDB = mapper.Map<Region>(updatedRegion);
            return Ok(await regionInterface.UpdateRegionAsync(id, updatedRegionToDB));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var foundRegion = await regionInterface.DeleteRegionAsync(id);
            if (foundRegion == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
