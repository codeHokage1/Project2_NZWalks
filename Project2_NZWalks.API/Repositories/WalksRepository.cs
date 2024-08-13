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
    }
}
