using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Handlers;
using TazkartiBusinessLayer.Models;
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
    public async Task<ActionResult> Get([FromRoute] string username)
    {
        var user = await _userHandler.GetUserByUsername(username);
        return user == null ? NotFound() : Ok(_mapper.Map<UserDto>(user));
    }
    
    [HttpPatch]
    [Route("{username}")]
    [Authorize]
    public async Task<ActionResult<UserDto>> Update([FromRoute] string username, [FromBody] UpdateUserDto userDto)
    {
        try
        {
            // check if user called this endpoint is the same as the user to be updated
            // check if username claim is the same as the username in the route
            // get the username from the claims
            var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username");
            if (usernameClaim == null || usernameClaim.Value != username)
            {
                return Forbid("You are not allowed to update other users");
            }
            var userModel = _mapper.Map<UserModel>(userDto);
            var user = await _userHandler.UpdateUser(username, userModel);
            return Ok(_mapper.Map<UserDto>(user));
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new {message = e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(500, new {message = e.Message});
        }
    }
    
    [HttpGet]
    [Route("{username}/matches")]
    [Authorize("MustBeApprovedFan")]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches([FromRoute] string username)
    {
        
        var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username");
        if (usernameClaim == null || usernameClaim.Value != username)
        {
            return Forbid("You are not allowed to update other users");
        }
        var matches = await _userHandler.GetMatchesReservedByUser(username);
        return Ok(_mapper.Map<IEnumerable<MatchDto>>(matches));
    }
}