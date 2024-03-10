using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public interface IWalkingPathRepository
    {
        public Task<List<WalkingPath>> GetAll(string? filterOn, string? filterQuery, string? orderBy, bool isAscending);
        public Task<WalkingPath?> GetById(int id);
        public Task UpdateWalkingPath(int id, UpdateWalkingPathDTO walkingPath);
        public Task<WalkingPath> AddWalkingPath(AddWalkingPathDTO walkingPath);
        public Task DeleteWalkingPath(int id);
    }
}
