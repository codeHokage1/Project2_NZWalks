using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Repositories
{
    public interface IRegionInterface
    {
        Task<List<Region>> GetRegionsAsync();
    }
}
