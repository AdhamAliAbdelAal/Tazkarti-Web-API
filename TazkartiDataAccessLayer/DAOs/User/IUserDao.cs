using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs;

public interface IUserDao
{
    Task<UserDbModel?> GetUserByIdAsync(string id);
    
    Task<UserDbModel?> GetUserByUsernameAsync(string username);
    
    Task<UserDbModel?> GetUserByEmailAddressAsync(string emailAddress);
    
    Task<UserDbModel?> AddUserAsync(UserDbModel user);
    
    Task<bool> IsUserExistsAsync(string username);
}