using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.Models;
using TazkartiService.DTOs;

namespace TazkartiBusinessLayer.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserDbModel, UserModel>();
        CreateMap<UserModel, UserDbModel>();
        CreateMap<UserModel, UserDto>();
    }
    
}