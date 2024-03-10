using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<WalkingPath, AddWalkingPathDTO>().ReverseMap();
            CreateMap<WalkingPath, WalkingPathDTO>().ReverseMap();
            CreateMap<Difficulity, DifficulityDTO>().ReverseMap();
        }
    }
}
