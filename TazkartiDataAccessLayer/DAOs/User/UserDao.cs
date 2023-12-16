using Microsoft.EntityFrameworkCore;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiDataAccessLayer.DbContexts;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs;

public class UserDao : IUserDao
{
    private readonly TazkartiDbContext _dbContext;
    public UserDao(TazkartiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDbModel?> GetUserByUsernameAsync(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        return user;
    }
    

    public async Task<UserDbModel?> GetUserByEmailAddressAsync(string emailAddress)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.EmailAddress == emailAddress);
        return user;
    }

    public async Task<UserDbModel?> AddUserAsync(UserDbModel user)
    {
        var result = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> IsUserExistsAsync(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.Username == username);
    }
    
    public async Task<bool> DeleteUserAsync(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        if (user == null)
        {
            return false;
        }
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    

    public async Task<IEnumerable<UserDbModel>> GetUsers(int page, int limit)
    {
        int skip = (page - 1) * limit;
        var users = await _dbContext.Users
            .Where(u => u.Role != Role.SiteAdministrator)
            .Skip(skip)
            .Take(limit)
            .ToListAsync();
        return users;
    }

    public async Task<int> SaveChanges()
    {
        return await _dbContext.SaveChangesAsync();
    }
}