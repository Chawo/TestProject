using AutoMapper;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Models.File, Entities.DTO.FileDto>();
        }
    }
}
