using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2Project.Models.domain;
using WebApplication2Project.Repository;

namespace WebApplication2Project.Controllers
{
    //Add some attribute for telling the controller it is ApiController

    [ApiController]

    //now use the route configuration it will be the end
    //point we can specify any name but here it is for 
    //region controller so we use regions or Controller.

    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
           this.regionRepository=regionRepository;
            this.mapper=mapper;
        }

        [HttpGet]
        //So now it get all the data from the database.
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            //return Region DTO methods

            //var regionsDTO=new List<Models.DTO.RegionDTO>();

            //regions.ToList().ForEach(Region=>
            //{
            //    var regionDTO = new Models.DTO.RegionDTO()
            //    {
            //        Id = Region.Id,
            //       Region_Code=Region.Code,
            //        FullName = Region.Name,
            //        LocalArea = Region.Area,
            //        Latitute = Region.Lat,
            //        Longitude = Region.Long,
            //        Overall_Population = Region.Population,

            //    };
            //    regionsDTO.Add(regionDTO);
            //});

            var regionsDTO=mapper.Map<List<Models.DTO.RegionDTO>>(regions);
            return Ok(regionsDTO);
        }
    }
}
