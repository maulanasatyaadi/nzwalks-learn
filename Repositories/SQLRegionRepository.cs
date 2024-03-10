using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public class SQLRegionRepository(NZWalksDBContext dbContext) : IRegionRepository
    {
        public async Task<Region> AddRegion(RegionDTO region)
        {
            var newRegion = new Region
            {
                Name = region.Name
            };

            await dbContext.Regions.AddAsync(newRegion);
            await dbContext.SaveChangesAsync();
            return newRegion;
        }

        public async Task DeleteRegion(int id)
        {
            var region = await dbContext.Regions.FindAsync(id);

            if (region != null)
            {
                dbContext.Regions.Remove(region);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Region>> GetAll()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetById(int id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateRegion(Region region)
        {
            var foundRegion = await dbContext.Regions.FindAsync(region.Id);

            if (foundRegion != null)
            {
                foundRegion.Name = region.Name;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
