using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers;

public interface IUserHandler
{
    public Task<UserModel> GetUserByUsername(string username);
    public Task<UserModel> GetUserByEmail(string email);
    
    public Task<UserModel> Register(RegisterModel registerModel);
}