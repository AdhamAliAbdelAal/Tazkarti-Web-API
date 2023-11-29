using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs;
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
}