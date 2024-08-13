using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<Walk> CreateWalk(Walk walk);
        Task<List<Walk>> GetAllWalks(
            String? walkName=null, 
            String sortBy=null, 
            bool isAscending=true,
            int page = 1,
            int pageSize = 5
        );
        Task <Walk?> GetWalkById(Guid id);
        Task<Walk?> UpdateWalk(Guid id, Walk walk);
        Task<Walk?> DeleteWalk(Guid id);
    }
}
