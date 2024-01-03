using AutoMapper;
using MagicVilla.Models;
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

            CreateMap<NumeroVilla, NumeroVillaDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaCreateDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaUpdateDto>().ReverseMap();

            CreateMap<Usuario,UsuarioDto>().ReverseMap();
            CreateMap<Usuario,UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario,UsuarioUpdateDto>().ReverseMap();
        }
    }
}