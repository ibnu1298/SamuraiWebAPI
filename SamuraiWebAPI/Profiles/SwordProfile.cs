using AutoMapper;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.Sword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<CreateSwordSamuraiDTO, Sword>();//Mapping for Create New Sword

            CreateMap<Sword, SwordDTO>();//Mapping for GetSword
            CreateMap<SwordDTO, Sword>();

            CreateMap<Sword, CreateSwordTypeDTO>();//Mapping For GetSwordWithType
            CreateMap<CreateSwordTypeDTO, Sword>();

            CreateMap<Sword, SwordElementDTO>();//Mapping For GetSwordWithElement
            CreateMap<SwordElementDTO, Sword>();

            CreateMap<CreateSwordDTO, Sword>();//Mapping Sword Only

            CreateMap<Sword, ReadSwordDTO>();//Mapping for GetSword
            CreateMap<ReadSwordDTO, Sword>();//Mapping for GetSword

            CreateMap<ReadSwordTypeDTO, Sword>();//Mapping for GetSword
            CreateMap<Sword, ReadSwordTypeDTO>();//Mapping for GetSword





        }
    }
}
