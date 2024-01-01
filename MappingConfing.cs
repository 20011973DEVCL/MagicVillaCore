using AutoMapper;
using MagicVilla.Models.Dto;
using MagicVillaNetCore.Models;

namespace MagicVilla
{
    public class MappingConfing:Profile
    {
        public MappingConfing()
        {
            CreateMap<Villa,VillaDto>();
            CreateMap<VillaDto,Villa>();

            CreateMap<Villa,VillaCreateDto>().ReverseMap();
            CreateMap<Villa,VillaUpdateDto>().ReverseMap();

        }
    }
}