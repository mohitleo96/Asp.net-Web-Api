using WebApplication2Project.Models.domain;

namespace WebApplication2Project.Repository
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
    }
}
