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

    public async Task<UserModel> GetUserByUsername(string username)
    {
        var user = await _userDao.GetUserByUsernameAsync(username);
        return _mapper.Map<UserModel>(user);
    }

    public async Task<UserModel> GetUserByEmail(string email)
    {
        var user = await _userDao.GetUserByEmailAddressAsync(email);
        return _mapper.Map<UserModel>(user);
    }
    
    public async Task<UserModel> Register(RegisterModel registerModel)
    {
        if (await _userDao.IsUserExistsAsync(registerModel.Username))
        {
            throw new Exception("User already exists");
        }
        var user = _mapper.Map<UserDbModel>(registerModel);
        var result = await _userDao.AddUserAsync(user);
        return _mapper.Map<UserModel>(result);
    }
}