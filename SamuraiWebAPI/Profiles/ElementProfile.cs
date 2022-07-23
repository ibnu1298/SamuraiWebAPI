using AutoMapper;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Profiles
{
    public class ElementProfile : Profile
    {
        public ElementProfile()
        {
            CreateMap<CreateDTO, Element>();

            CreateMap<ReadDTO, Element>();
            CreateMap<Element, ReadDTO>();


        }
    }
}
