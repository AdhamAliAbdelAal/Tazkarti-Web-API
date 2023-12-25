using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Profiles;

public class StadiumProfile : Profile
{
    public StadiumProfile()
    {
        CreateMap<StadiumModel, StadiumDbModel>();
        CreateMap<StadiumDbModel, StadiumModel>();
        CreateMap<StadiumModel, AddStadiumDto>();
        CreateMap<AddStadiumDto, StadiumModel>();
        CreateMap<StadiumModel, StadiumDto>();
        CreateMap<StadiumDto, StadiumModel>();
    }
}