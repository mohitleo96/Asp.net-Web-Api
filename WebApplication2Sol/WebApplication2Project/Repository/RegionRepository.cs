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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDBContext.Regions.ToListAsync();
        }
    }
}
