using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers;

public interface IUserHandler
{
    public Task<UserModel?> GetUserByUsername(string username);
    public Task<UserModel?> GetUserByEmail(string email);
    
    public Task<UserModel?> Register(RegisterModel registerModel);
    
    public Task<bool> CheckIfUserExists(string username);
    
    public Task<bool> DeleteUser(string username);
    
    public Task<bool> ApproveUser(string username);

    public Task<IEnumerable<UserModel>> GetUsers(int page, int limit);
}