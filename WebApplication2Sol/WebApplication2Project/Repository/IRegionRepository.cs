using WebApplication2Project.Models.domain;

namespace WebApplication2Project.Repository
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();

        //This GetAsync will get a single region
        //and we will get the single region based on the ID of the region.
        Task<Region> GetAsync(Guid id);

        //adding new data
        Task<Region> AddAsync(Region region);  

        //daleting the data
        Task<Region> DeleteAsync(Guid id);

        //Updating the Data
        Task<Region> UpdateAsync(Guid id, Region region);
    }
}
