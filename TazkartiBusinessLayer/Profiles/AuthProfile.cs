using AutoMapper;
using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterModel, UserModel>();
    }
    
}