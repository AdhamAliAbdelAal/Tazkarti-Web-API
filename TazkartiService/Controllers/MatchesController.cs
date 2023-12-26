using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Handlers.Match;
using TazkartiBusinessLayer.Models;
using TazkartiBusinessLayer.Notifications;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiService.DTOs;

namespace TazkartiService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MatchesController: Controller 
{
    private readonly IMatchHandler _matchHandler;
    private readonly IMapper _mapper;
    private readonly SeatsNotificationsContext _seatsNotificationsContext;
    public MatchesController(IMatchHandler matchHandler, IMapper mapper, SeatsNotificationsContext seatsNotificationsContext)
    {
        _matchHandler = matchHandler;
        _mapper = mapper;
        _seatsNotificationsContext = seatsNotificationsContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMatches([FromQuery]int page=0, [FromQuery]int limit = 10)
    {
        var matches = await _matchHandler.GetMatches(page, limit);
        return Ok(_mapper.Map<IEnumerable<MatchDto>>(matches));
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<MatchDto>> GetMatchById([FromRoute]int id, [FromQuery] bool reservedByMe = false)
    {
        var match = await _matchHandler.GetMatchById(id);
        if (match == null)
        {
            return NotFound();
        }

        var matchDto = _mapper.Map<MatchDto>(match);
        if (reservedByMe)
        {
            try
            {
                var userId =  int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
                var seat = await _matchHandler.GetSeatReservedByUser(id, userId);
                matchDto.SeatReservedByMe = seat;
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
        return Ok(matchDto);
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
            await _seatsNotificationsContext.NotifySeatsReserved(id, seatNumber);
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
    
    // cancel reservation
    [HttpDelete]
    [Route("{id}/{seatNumber}")]
    [Authorize(Policy = "MustBeApprovedFan")]
    public async Task<IActionResult> CancelReservation(int id, int seatNumber)
    {
        var userId =  int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
        try
        {
            await _matchHandler.CancelSeatReservation(id, userId, seatNumber);
            await _seatsNotificationsContext.NotifySeatsCancelled(id, seatNumber);
            return Ok();
        }
        catch (SeatNotReservedException e)
        {
            return BadRequest(new {message = e.Message});
        }
        catch (CannotCancelReservationException e)
        {
            return Forbid(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, new {message = e.Message});
        }
    }

    [HttpPut]
    [Authorize(Policy = "MustBeApprovedEFAManager")]
    [Route("{id}")]
    public async Task<ActionResult<MatchDto>> UpdateMatch([FromRoute] int id,[FromBody] UpdateMatchDto matchDto)
    {
        try
        {
            var matchModel = _mapper.Map<MatchModel>(matchDto);
            var result = await _matchHandler.UpdateMatch(id, matchModel);
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
    
    [HttpDelete]
    [Authorize("MustBeApprovedEFAManager")]
    [Route("{id}")]
    public async Task<IActionResult> DeleteMatch([FromRoute] int id)
    {
        try
        {
            await _matchHandler.DeleteMatch(id);
            return Ok();
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