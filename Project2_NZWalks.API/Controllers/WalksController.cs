using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_NZWalks.API.Models.DTOs;
using Project2_NZWalks.API.Models.Entities;
using Project2_NZWalks.API.Repositories;

namespace Project2_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepository walksRepo;

        public WalksController(IMapper mapper, IWalksRepository walksRepo)
        {
            this.mapper = mapper;
            this.walksRepo = walksRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk(AddWalkDto walkToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walkToAddToDB = mapper.Map<Walk>(walkToAdd);
            var addedWalk = await walksRepo.CreateWalk(walkToAddToDB);

            var addedWalkDto = mapper.Map<WalkDTO>(addedWalk);

            return StatusCode(201, addedWalkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var walksFromDB = await walksRepo.GetAllWalks();

            var walksToSend = mapper.Map<List<WalkDTO>>(walksFromDB);
            return Ok(walksToSend);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walkFromDb = await walksRepo.GetWalkById(id);
            if (walkFromDb == null)
            {
                return NotFound();
            }

            var walkToSend = mapper.Map<WalkDTO>(walkFromDb);
            return Ok(walkToSend);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWalk(Guid id, AddWalkDto walkToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var walkToUpdateInDB = mapper.Map<Walk>(walkToUpdate);
            var updatedWalk = await walksRepo.UpdateWalk(id, walkToUpdateInDB);
            if(updatedWalk == null)
            {
                return NotFound();
            }

            var updatedWalkDto = mapper.Map<WalkDTO>(updatedWalk);
            return Ok(updatedWalkDto);          
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walkToDelete = await walksRepo.DeleteWalk(id);
            if (walkToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
