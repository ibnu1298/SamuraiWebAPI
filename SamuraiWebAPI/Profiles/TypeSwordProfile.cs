using AutoMapper;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.TypeSword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Profiles
{
    public class TypeSwordProfile : Profile
    {
        public TypeSwordProfile()
        {
            CreateMap<CreateDTO, TypeSword>();
            CreateMap<NameTypeSwordDTO, TypeSword>();

            CreateMap<ReadDTO, TypeSword>();
            CreateMap<TypeSword, ReadDTO>();

            CreateMap<TypeSword, TypeSwordDTO>();
            CreateMap<TypeSwordDTO, TypeSword>();

            CreateMap<createTypeSwordDTO, TypeSword>();
            CreateMap<TypeSword, createTypeSwordDTO>();

        }
    }
}
