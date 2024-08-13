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

        public async Task<List<Walk>> GetAllWalks(
            string? walkName = null, 
            string? sortBy = null, 
            bool isAscending=true,
            int page = 1,
            int pageSize = 5
        )
        {
            var allWalks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            // filtering
            if (walkName !=  null)
            {
                allWalks = allWalks.Where(x => x.Name.Contains(walkName));
            }

            // sorting 
            if (sortBy != null)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)){
                    allWalks = isAscending ? 
                        allWalks.OrderBy(x => x.Name) : 
                        allWalks.OrderByDescending(x => x.Name);
                }
            }

            //pagination
            var skip = (page - 1) * pageSize;
            return await allWalks.Skip(skip).Take(pageSize).ToListAsync();
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

        public async Task<Walk?> UpdateWalk(Guid id, Walk walk)
        {
            var foundWalk = await dbContext.Walks
                .FirstOrDefaultAsync(x => x.Id == id);
            if (foundWalk == null)
            {
                return null;
            }

            foundWalk.Name = walk.Name;
            foundWalk.Description = walk.Description;
            foundWalk.LengthInKM = walk.LengthInKM;
            foundWalk.WalkImageURL = walk.WalkImageURL;
            foundWalk.RegionId = walk.RegionId;
            foundWalk.DifficultyId = walk.DifficultyId;
            await dbContext.SaveChangesAsync();
            return foundWalk;
        }

        public async Task<Walk?> DeleteWalk(Guid id)
        {
            var foundWalk = await dbContext.Walks.FindAsync(id);
            if (foundWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(foundWalk);
            await dbContext.SaveChangesAsync();
            return foundWalk;
        }
    }
}
