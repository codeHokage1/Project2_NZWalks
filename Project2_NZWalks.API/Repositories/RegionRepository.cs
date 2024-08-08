using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project2_NZWalks.API.Data;
using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Repositories
{
    public class RegionRepository : IRegionInterface
    {
        private readonly NZWalksDbContext dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FindAsync(id);
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var regionToUpdate = await dbContext.Regions.FindAsync(id);
            if (regionToUpdate == null)
            {
                return null;
            }

            regionToUpdate.Code = region.Code;
            regionToUpdate.Name = region.Name;
            regionToUpdate.RegionImageURL = region.RegionImageURL;

            await dbContext.SaveChangesAsync();
            return regionToUpdate;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var regionToDelete = await dbContext.Regions.FindAsync(id);
            if (regionToDelete == null)
            {
                return null;
            }

            dbContext.Regions.Remove(regionToDelete);
            await dbContext.SaveChangesAsync();

            return regionToDelete;

        }
    }
}
