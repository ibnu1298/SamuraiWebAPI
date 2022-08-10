using AutoMapper;
using SamuraiWebAPI.Dtos.Demon;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Profiles
{
    public class DemonProfile : Profile
    {
        public DemonProfile()
        {
            CreateMap<CreateDemonDTO, Demon>();

            CreateMap<ReadDemonDTO, Demon>();
            CreateMap<Demon, ReadDemonDTO>();

            CreateMap<Demon, DemonWithElementsDTO>();
            CreateMap<DemonWithElementsDTO, Demon>();
        }
    }
}
