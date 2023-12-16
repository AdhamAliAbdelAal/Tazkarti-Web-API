using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Profiles;

public class SeatProfile: Profile
{
    public SeatProfile()
    {
        CreateMap<SeatModel, SeatDbModel>();
        CreateMap<SeatDbModel, SeatModel>();
        CreateMap<SeatModel, SeatDto>();
        CreateMap<SeatDto, SeatModel>();
    }
}