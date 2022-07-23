using AutoMapper;
using SamuraiWebAPI.Dtos;
using SamuraiWebAPI.Dtos.Samurai;
using SamuraiWebAPI.Dtos.TypeSword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<CreateDTO, Samurai>();//Mapping for Create New Samurai

            CreateMap<Samurai, ReadDTO>();//Mapping for GetSamurai
            CreateMap<ReadDTO, Samurai>();

            CreateMap<SamuraiBattleDTO, Samurai>();//Mapping For GetSamuraiWithBattles
            CreateMap<Samurai, SamuraiBattleDTO>();

            CreateMap<SamuraiSwordElementDTO, Samurai>();//Mapping For SamuraiSwordElementDTO = Model Samurai
            CreateMap<Samurai, SamuraiSwordElementDTO>();


            CreateMap<CreateSamuraiSword, Samurai>();
            CreateMap<Samurai, CreateSamuraiSword>();

            CreateMap<ReadSamuraiSword, Samurai>();
            CreateMap<Samurai, ReadSamuraiSword>();

            CreateMap<NameTypeSwordDTO, TypeSword>();
            

        }
    }
}
