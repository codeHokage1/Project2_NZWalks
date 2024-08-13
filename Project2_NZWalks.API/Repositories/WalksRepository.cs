using Microsoft.EntityFrameworkCore;
using Project2_NZWalks.API.Data;
using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalksRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateWalk(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetWalkById(Guid id)
        {
            var foundWalk = await dbContext.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
            if(foundWalk == null)
            {
                return null;
            }

            return foundWalk;
        }
    }
}
