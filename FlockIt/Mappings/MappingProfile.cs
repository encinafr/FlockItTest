using AutoMapper;
using FlockIt.Dtos;
using FlockIt.Entities;

namespace FlockIt.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StateDto, State>().ReverseMap();
        }
    }
    
}
