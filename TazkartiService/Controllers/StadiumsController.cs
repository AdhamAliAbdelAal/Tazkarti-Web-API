using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Handlers;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StadiumsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IStadiumHandler _stadiumHandler;
    
    public StadiumsController(IMapper mapper, IStadiumHandler stadiumHandler)
    {
        _mapper = mapper;
        _stadiumHandler = stadiumHandler;
    }
    
    [HttpGet]
    [Authorize(Policy = "MustBeApprovedEFAManager")]
    public async Task<ActionResult<IEnumerable<StadiumDto>>> GetStadiums([FromQuery] int page = 0, [FromQuery] int limit = 10)
    {
        var stadiums = await _stadiumHandler.GetStadiums(page, limit);
        return Ok(_mapper.Map<IEnumerable<StadiumDto>>(stadiums));
    }
    
    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult> GetStadium([FromRoute] string name)
    {
        var stadium = await _stadiumHandler.GetStadiumByName(name);
        return stadium == null ? NotFound() : Ok(_mapper.Map<StadiumDto>(stadium));
    }
    
    [HttpPost]
    [Authorize(Policy = "MustBeApprovedEFAManager")]
    public async Task<ActionResult<StadiumDto>> AddStadium([FromBody] AddStadiumDto addStadium)
    {
        var stadiumModel = _mapper.Map<StadiumModel>(addStadium);
        var result = await _stadiumHandler.AddStadium(stadiumModel);
        return result == null ? Conflict() : Created("", _mapper.Map<StadiumDto>(result));
    }
}