using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Handlers;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    public readonly IMapper _mapper;
    public readonly IUserHandler _userHandler;
    
    public UsersController(IMapper mapper, IUserHandler userHandler)
    {
        _mapper = mapper;
        _userHandler = userHandler;
    }
    
    [HttpPatch]
    [Route("approve/{username}")]
    [Authorize(Roles= Roles.SiteAdministrator)]
    public async Task<ActionResult> Approve([FromRoute] string username)
    {
        bool approved = await _userHandler.ApproveUser(username);
        return approved ? Ok() : NotFound();
    }
    
    [HttpDelete]
    [Route("{username}")]
    [Authorize(Roles= Roles.SiteAdministrator)]
    public async Task<ActionResult> Delete([FromRoute] string username)
    {
        bool deleted = await _userHandler.DeleteUser(username);
        return deleted ? Ok() : NotFound();
    }

    [HttpGet]
    [Authorize(Roles= Roles.SiteAdministrator)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] int page = 0, [FromQuery] int limit = 10)
    {
        var users = await _userHandler.GetUsers(page, limit);
        return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
    }
    
    [HttpGet]
    [Route("{username}")]
    [Authorize(Roles= Roles.SiteAdministrator)]
    public async Task<ActionResult> Get([FromRoute] string username)
    {
        var user = await _userHandler.GetUserByUsername(username);
        return user == null ? NotFound() : Ok(_mapper.Map<UserDto>(user));
    }
}