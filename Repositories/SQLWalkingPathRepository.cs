using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public class SQLWalkingPathRepository(NZWalksDBContext dbContext) : IWalkingPathRepository
    {
        public async Task<WalkingPath> AddWalkingPath(AddWalkingPathDTO walkingPath)
        {
            var newWalkingPath = new WalkingPath
            {
                Name = walkingPath.Name,
                DifficulityId = walkingPath.DifficulityId,
                RegionId = walkingPath.RegionId
            };

            await dbContext.WalkingPaths.AddAsync(newWalkingPath);
            await dbContext.SaveChangesAsync();

            var currentWalkingPath = await dbContext.WalkingPaths
                .Include(x => x.Difficulity)
                .Include(x => x.Region)
                .FirstOrDefaultAsync(x => x.Id == newWalkingPath.Id);

            return currentWalkingPath!;
        }

        public async Task DeleteWalkingPath(int id)
        {
            var walkingPath = await dbContext.WalkingPaths.FirstOrDefaultAsync(x => x.Id == id);

            if (walkingPath != null)
            {
                dbContext.WalkingPaths.Remove(walkingPath);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<WalkingPath>> GetAll(string? filterOn, string? filterQuery, string? orderBy, bool isAsceding)
        {
            var walkingPath = dbContext.WalkingPaths
                .Include(x => x.Difficulity)
                .Include(x => x.Region)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                if (filterOn.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    walkingPath = walkingPath.Where(x => x.Name.Contains(filterQuery));
                }
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    walkingPath = isAsceding ? walkingPath.OrderBy(x => x.Name) : walkingPath.OrderByDescending(x => x.Name);
                }
            }

            walkingPath = walkingPath.Take(3);

            return await walkingPath.ToListAsync();
        }

        public async Task<WalkingPath?> GetById(int id)
        {
            return await dbContext.WalkingPaths
                .Include(x => x.Difficulity)
                .Include(x => x.Region)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateWalkingPath(int id, UpdateWalkingPathDTO walkingPath)
        {
            var foundWalkingPath = await dbContext.WalkingPaths.FirstOrDefaultAsync(x => x.Id == id);

            if (foundWalkingPath != null)
            {
                foundWalkingPath.Name = walkingPath.Name;
                foundWalkingPath.DifficulityId = walkingPath.DifficulityId;
                foundWalkingPath.RegionId = walkingPath.RegionId;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
