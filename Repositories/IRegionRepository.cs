using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAll();
        public Task<Region?> GetById(int id);
        public Task UpdateRegion(Region region);
        public Task<Region> AddRegion(RegionDTO region);
        public Task DeleteRegion(int id);
    }
}
