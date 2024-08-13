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
            var walkToAddToDB = mapper.Map<Walk>(walkToAdd);
            var addedWalk = await walksRepo.CreateWalk(walkToAddToDB);

            var addedWalkDto = mapper.Map<WalkDTO>(addedWalk);

            return StatusCode(201, addedWalkDto);
        }
    }
}
