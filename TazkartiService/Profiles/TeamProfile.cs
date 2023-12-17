using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Profiles;

public class TeamProfile: Profile
{
    public TeamProfile()
    {
        CreateMap<TeamModel, TeamDbModel>();
        CreateMap<TeamDbModel, TeamModel>();
        CreateMap<TeamModel, TeamDto>();
        CreateMap<TeamDto, TeamModel>();
    }
}