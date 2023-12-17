using AutoMapper;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs.Match;
using TazkartiDataAccessLayer.DAOs.Seat;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Match;

public class MatchHandler : IMatchHandler
{
    private readonly IMatchDao _matchDao;
    private readonly ISeatDao _seatDao;
    private readonly IMapper _mapper;
    
    public MatchHandler(IMatchDao matchDao, ISeatDao seatDao, IMapper mapper)
    {
        _matchDao = matchDao;
        _seatDao = seatDao;
        _mapper = mapper;
    }


    public async Task<MatchModel?> GetMatchById(int id)
    {
        var user = await _matchDao.GetMatchByIdAsync(id);
        if (user == null)
        {
            return null;
        }
        return _mapper.Map<MatchModel>(user);
    }

    public async Task<MatchModel?> AddMatch(MatchModel match)
    {
        var matchDbModel = _mapper.Map<MatchDbModel>(match);
        MatchDbModel? result = null;
        try
        {
            result = await _matchDao.AddMatchAsync(matchDbModel);
        }
        catch (Exception e)
        {
            return null;
        }
        return _mapper.Map<MatchModel>(result);
    }

    public async Task<IEnumerable<MatchModel>> GetMatches(int page, int limit)
    {
        var matches = await _matchDao.GetMatches(page, limit);
        return _mapper.Map<IEnumerable<MatchModel>>(matches);
    }
    
    public async Task<bool> IsMatchExists(int id)
    {
        return await _matchDao.IsMatchExistsAsync(id);
    }

    public async Task<SeatModel?> ReserveSeat(int matchId, int userId, int seatNumber)
    {
        var match = await _matchDao.GetMatchByIdAsync(matchId, false, true, false);
        if(match == null)
            throw new MatchNotFoundException(matchId);
        int capacity = match.Stadium.Capacity;
        if (seatNumber > capacity || seatNumber < 1)
        {
            throw new SeatNotFoundException(capacity);
        }
        var seat = new SeatModel()
        {
            MatchId = matchId,
            UserId = userId,
            Number = seatNumber,
            ReservedAt = DateTime.Now
        };
        var seatDbModel = _mapper.Map<SeatDbModel>(seat);
        try
        {
            var result = await _seatDao.AddSeatAsync(seatDbModel);
            var reservedSeat = _mapper.Map<SeatModel>(result);
            return reservedSeat;
        }
        catch (Exception e)
        {
            // if error message contains "UNIQUE constraint" then seat is already reserved or user already reserved a seat in this match so return null
            if(e.InnerException.Message.Contains("UNIQUE constraint"))
                throw new ResvervedSeatOrUserException();
            throw;
        }
    }
}