﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = Roles.EFAManager)]
    public async Task<ActionResult<MatchDto>> AddMatch(AddMatchDto addMatch)
    {
        var matchModel = _mapper.Map<MatchModel>(addMatch);
        var result = await _matchHandler.AddMatch(matchModel);

        return result != null ? Ok(_mapper.Map<MatchDto>(result)) : BadRequest();
    }
}