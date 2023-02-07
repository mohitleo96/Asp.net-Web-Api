using Microsoft.EntityFrameworkCore;
using WebApplication2Project.Data;
using WebApplication2Project.Models.domain;

namespace WebApplication2Project.Repository
{
    public class RegionRepository : IRegionRepository
    {
        //to assign a private readonly field
        private NZWalksDBContext nZWalksDBContext;

        //so we want to talk with database and fetch the data from it so for that we create constructor
        //And from program.cs we get the DBContext class name.
        public RegionRepository(NZWalksDBContext nZWalksDBContext)
        {
            //to assign a private readonly field
            this.nZWalksDBContext= nZWalksDBContext;
        }
        public async Task<Region> AddAsync(Region region)
        {
             region.Id= Guid.NewGuid();
            await nZWalksDBContext.AddAsync(region);
            await nZWalksDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            //to search the id data is available or not.
            var region = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region==null)
            {
                return null;
            }
            //delete the region
            nZWalksDBContext.Regions.Remove(region);
            await nZWalksDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDBContext.Regions.ToListAsync();
        }
        public async Task<Region> GetAsync(Guid id)
        {
            //firstoedefault helps to get the ID if id matches is return
            //the value if not it return null value.
            return await nZWalksDBContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
           var existingRegion = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existingRegion==null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat= region.Lat;
            existingRegion.Long= region.Long;
            existingRegion.Population= region.Population;

            await nZWalksDBContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
