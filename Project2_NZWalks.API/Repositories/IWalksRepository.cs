using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<Walk> CreateWalk(Walk walk);
        Task<List<Walk>> GetAllWalks();
        Task <Walk?> GetWalkById(Guid id);
    }
}
