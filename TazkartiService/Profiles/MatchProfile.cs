using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Profiles;

public class MatchProfile: Profile
{
    public MatchProfile()
    {
        CreateMap<MatchModel, MatchDbModel>();
        CreateMap<MatchDbModel, MatchModel>();
        CreateMap<MatchModel, AddMatchDto>();
        CreateMap<AddMatchDto, MatchModel>();
        CreateMap<MatchModel, MatchDto>();
        CreateMap<MatchDto, MatchModel>();
        CreateMap<MatchModel,UpdateMatchDto>();
        CreateMap<UpdateMatchDto, MatchModel>();
    }
}