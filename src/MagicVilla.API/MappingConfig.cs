using AutoMapper;
using MagicVilla.API.Models;
using MagicVilla.API.Models.DTO;

namespace MagicVilla.API;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Vila, VilaDTO>().ReverseMap();
        CreateMap<Vila, CriacaoVilaDTO>().ReverseMap();
        CreateMap<Vila, AtualizacaoVilaDTO>().ReverseMap();
    }
}
