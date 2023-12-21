using AutoMapper;
using TazkartiBusinessLayer.Auth;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Handlers;

public class UserHandler : IUserHandler
{
    private readonly IMapper _mapper;
    private readonly IUserDao _userDao;

    public UserHandler(IMapper mapper, IUserDao userDao)
    {
        _mapper = mapper;
        _userDao = userDao;
    }

    public async Task<UserModel?> GetUserByUsername(string username)
    {
        var user = await _userDao.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return null;
        }
        return _mapper.Map<UserModel>(user);
    }

    public async Task<UserModel?> GetUserByEmail(string email)
    {
        var user = await _userDao.GetUserByEmailAddressAsync(email);
        return _mapper.Map<UserModel>(user);
    }
    
    public async Task<UserModel?> Register(RegisterModel registerModel)
    {
        if (await _userDao.IsUserExistsAsync(registerModel.Username))
        {
            return null;
        }
        var user = _mapper.Map<UserDbModel>(registerModel);
        var result = await _userDao.AddUserAsync(user);
        return _mapper.Map<UserModel>(result);
    }
    
    public async Task<bool> CheckIfUserExists(string username)
    {
        return await _userDao.IsUserExistsAsync(username);
    }
    
    public async Task<bool> DeleteUser(string username)
    {
        return await _userDao.DeleteUserAsync(username);
    }

    public async Task<UserModel?> UpdateUser(string username, UserModel userModel)
    {
        var user = await _userDao.GetUserByUsernameAsync(username);
        if (user == null)
        {
            throw new UserNotFoundException(username);
        }
        user.FirstName = userModel.FirstName;
        user.LastName = userModel.LastName;
        user.BirthDate = userModel.BirthDate;
        user.Gender = userModel.Gender;
        user.City = userModel.City;
        user.Address = userModel.Address;
        user.Password = PasswordHasherUtility.HashPassword(userModel.Password);
        await _userDao.SaveChanges();
        return _mapper.Map<UserModel>(user);
    }

    public async Task<bool> ApproveUser(string username)
    {
        var user = await _userDao.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return false;
        }
        user.Status = UserStatus.Approved;
        int updates = await _userDao.SaveChanges();
        return updates == 1;
    }

    public async Task<IEnumerable<UserModel>> GetUsers(int page, int limit)
    {
        var users = await _userDao.GetUsers(page, limit);
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
}