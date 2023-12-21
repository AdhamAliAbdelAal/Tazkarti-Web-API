using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Handlers.Team;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeamsController: Controller
{
    private readonly ITeamHandler _teamHandler;
    private readonly IMapper _mapper;
    
    public TeamsController(ITeamHandler teamHandler, IMapper mapper)
    {
        _teamHandler = teamHandler;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        try
        {
            var team = await _teamHandler.GetTeamById(id);
            return Ok(_mapper.Map<TeamDto>(team));
        }
        catch (TeamNotFoundException e)
        {
            return NotFound(new
            {
                message = e.Message
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                message = "Internal Server Error"
            });
        }
        
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams(int page, int limit)
    {
        var teams = await _teamHandler.GetTeams(page, limit);
        return Ok(_mapper.Map<IEnumerable<TeamDto>>(teams));
    }
}