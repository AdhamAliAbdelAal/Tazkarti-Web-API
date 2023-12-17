﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Handlers.Match;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchesController: Controller 
{
    private readonly IMatchHandler _matchHandler;
    private readonly IMapper _mapper;
    
    public MatchesController(IMatchHandler matchHandler, IMapper mapper)
    {
        _matchHandler = matchHandler;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMatches([FromQuery]int page=0, [FromQuery]int limit = 10)
    {
        var matches = await _matchHandler.GetMatches(page, limit);
        return Ok(_mapper.Map<IEnumerable<MatchDto>>(matches));
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<MatchDto>> GetMatchById(int id)
    {
        var match = await _matchHandler.GetMatchById(id);
        if (match == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<MatchDto>(match));
    }
    
    [HttpPost]
    [Authorize(Policy = "MustBeApprovedEFAManager")]
    public async Task<ActionResult<MatchDto>> AddMatch(AddMatchDto addMatch)
    {
        try
        {
            var matchModel = _mapper.Map<MatchModel>(addMatch);
            var result = await _matchHandler.AddMatch(matchModel);
            return Ok(_mapper.Map<MatchDto>(result));
        }
        catch (MatchDateInPastException e)
        {
            return BadRequest(new {message = e.Message});
        }
        catch (MatchInSameStadiumInSameDateException e)
        {
            return Conflict(new {message = e.Message});
        }
        catch (StadiumNotFoundException e)
        {
            return NotFound(new {message = e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(500, new {message = e.Message});
        }
    }
    
    [HttpPost]
    [Route("{id}/{seatNumber}")]
    [Authorize(Policy = "MustBeApprovedFan")]
    public async Task<ActionResult<SeatDto>> ReserveSeat(int id, int seatNumber)
    {
        var userId =  int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
        try
        {
            var seat = await _matchHandler.ReserveSeat(id, userId, seatNumber);
            return Ok(_mapper.Map<SeatDto>(seat));
        }
        catch (ResvervedSeatOrUserException e)
        {
            return Conflict(new {message = e.Message});
        }
        catch (SeatNotFoundException e)
        {
            return BadRequest(new {message = e.Message});
        }
        catch (MatchNotFoundException e)
        {
            return NotFound(new {message = e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(500, new {message = e.Message});
        }
    }
}