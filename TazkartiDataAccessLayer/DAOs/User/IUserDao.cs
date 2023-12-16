using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs;

public interface IUserDao
{
    Task<UserDbModel?> GetUserByUsernameAsync(string username);
    
    Task<UserDbModel?> GetUserByEmailAddressAsync(string emailAddress);
    
    Task<UserDbModel?> AddUserAsync(UserDbModel user);
    
    Task<bool> IsUserExistsAsync(string username);
    
    Task<bool> DeleteUserAsync(string username);

    Task<IEnumerable<UserDbModel>> GetUsers(int page, int limit);

    Task<int> SaveChanges();
}