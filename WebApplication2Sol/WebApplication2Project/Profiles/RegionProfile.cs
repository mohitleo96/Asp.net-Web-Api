using AutoMapper;
using System.Runtime.InteropServices;

namespace WebApplication2Project.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile() 
        {
            //CretaeMap<From,To>
            //this is enough if the fields of Region and RegionDTO be same
            //but in this case it is different so.. we have to add
            CreateMap<Models.domain.Region, Models.DTO.RegionDTO>()
                .ForMember(
                     dest => dest.Region_Code,options=> options.MapFrom(src=>src.Code)
                          )
                .ForMember(
                      dest => dest.LocalArea, options => options.MapFrom(src => src.Area)
                      )
                .ForMember(
                     dest => dest.FullName, options => options.MapFrom(src => src.Name)
                          )
                .ForMember(
                      dest => dest.Latitute, options => options.MapFrom(src => src.Lat)
                      )
                 .ForMember(
                      dest => dest.Longitude, options => options.MapFrom(src => src.Long)
                      )
                  .ForMember(
                      dest => dest.Overall_Population, options => options.MapFrom(src => src.Population)
                      )
                  //it helps to convert DTO to domain if it is requried
                  .ReverseMap();
        }
    }
}
