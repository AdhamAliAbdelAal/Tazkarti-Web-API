using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiService.Profiles;

public class AuthProfile: Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterDto, RegisterModel>();
        CreateMap<RegisterModel, UserModel>();
        CreateMap<RegisterModel, UserDbModel>();
    }
    
}