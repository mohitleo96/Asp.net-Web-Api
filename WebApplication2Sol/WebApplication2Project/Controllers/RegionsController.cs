using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2Project.Models.domain;
using WebApplication2Project.Models.DTO;
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
        public async Task<IActionResult> GetAllRegionsAsync()


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


        [HttpGet]
        //Route helps to insert only Guid value in  id.
        [Route("{id:guid}")]
        // So we need to get an action name in return CreatedAtAction()
        [ActionName("GetRegionAsync")]
        //So now it get the data based on id from the database.
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
           var region = await regionRepository.GetAsync(id);

            //Here we use store value in AutoMapper so it matches with the DTOfields.
            //Automapper also helps to reduce code beacause we written only one time and use multiple times.
             
           var regionDTO1= mapper.Map<Models.DTO.RegionDTO>(region);
            return Ok(regionDTO1);
        }
      
        //So use HTTPPost because we add some data into server.
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //we do manually without AutoMapper
            //First Convert addRegionRequest to DomainModel
            var region = new Models.domain.Region()
            {
                Code = addRegionRequest.Region_Code,
                Name = addRegionRequest.FullName,
                Lat = addRegionRequest.Latitute,
                Long = addRegionRequest.Longitude,
                Area = addRegionRequest.LocalArea,
                Population = addRegionRequest.Overall_Population,

            };

            //Pass Details to repository
           region = await regionRepository.AddAsync(region);
            //if null then Not Found
            if (region == null)
            {
                return NotFound();
            }

            //Convert back to DTO
            var regionDTO2 = new Models.DTO.RegionDTO()
            {
                Id = region.Id,
                Region_Code = region.Code,
                FullName = region.Name,
                LocalArea = region.Area,
                Latitute = region.Lat,
                Longitude = region.Long,
                Overall_Population = region.Population,
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO2.Id }, regionDTO2);
        }
        
        
        [HttpDelete]
        //Route helps to insert only Guid value in  id.
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            //Get region from Database
            var region = await regionRepository.DeleteAsync(id);
            //if null notfound
            if(region==null)
            {
                return NotFound();
            }
            //convert response back to DTO
            var regionDTO3 = new Models.DTO.RegionDTO()
            {
                Id = region.Id,
                Region_Code = region.Code,
                FullName = region.Name,
                LocalArea = region.Area,
                Latitute = region.Lat,
                Longitude = region.Long,
                Overall_Population = region.Population,
            };
            //Return OK response
            return Ok(regionDTO3); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            //Convert DTO to Domain
            var region = new Models.domain.Region()
            {
                Code = updateRegionRequest.Region_Code,
                Name =updateRegionRequest.FullName,
                Lat = updateRegionRequest.Latitute,
                Long =updateRegionRequest.Longitude,
                Area = updateRegionRequest.LocalArea,
                Population = updateRegionRequest.Overall_Population,
            };
            //Update region using Repository
            region = await regionRepository.UpdateAsync(id, region);
            //if null then Not Found
            if (region==null)
            {
                return NotFound();
            }
            //Convert Domain back to DTO
            var regionDTO4 = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Region_Code = region.Code,
                FullName = region.Name,
                LocalArea = region.Area,
                Latitute = region.Lat,
                Longitude = region.Long,
                Overall_Population = region.Population,
            };
            //Return Ok response
            return Ok(regionDTO4);
        }
    }

}
