using AutoMapper;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs.Match;
using TazkartiDataAccessLayer.DAOs.Seat;
using TazkartiDataAccessLayer.DAOs.Stadium;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Match;

public class MatchHandler : IMatchHandler
{
    private readonly IMatchDao _matchDao;
    private readonly ISeatDao _seatDao;
    private readonly IMapper _mapper;
    private readonly IStadiumDao _stadiumDao;
    
    public MatchHandler(IMatchDao matchDao, ISeatDao seatDao, IMapper mapper, IStadiumDao stadiumDao)
    {
        _matchDao = matchDao;
        _seatDao = seatDao;
        _mapper = mapper;
        _stadiumDao = stadiumDao;
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
        // check that the match date is not in the past
        if (match.Date < DateTime.Now)
            throw new MatchDateInPastException();
        // check that the match is not be played in the stadium that will be played in the same date but with tolerance of 3 hours after and before
        var stadium = await _stadiumDao.GetStadiumByIdAsync(match.StadiumId, true);
        if (stadium == null)
            throw new StadiumNotFoundException(match.StadiumId);
        
        var matches = stadium.Matches;
        foreach (var m in matches)
        {
            if (m.Date.AddHours(4) > match.Date && m.Date.AddHours(-4) < match.Date)
                throw new MatchInSameStadiumInSameDateException();
        }
        
        var matchDbModel = _mapper.Map<MatchDbModel>(match);
        try
        {
            var result = await _matchDao.AddMatchAsync(matchDbModel);
            return _mapper.Map<MatchModel>(result);
        }
        catch (Exception e)
        {
            //check constraint exception
            if(e.InnerException.Message.Contains("CHECK constraint"))
                throw new SameHomeAndAwayTeamException();
            throw new Exception("Invalid match data");
        }
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

    public async Task<bool> CancelSeatReservation(int matchId, int userId, int seatNumber)
    {
        var seat = await _seatDao.GetSeatByMatchIdAndUserIdAndSeatNumberAsync(matchId, userId, seatNumber);
        if (seat == null)
        {
            throw new SeatNotReservedException();
        }
        var result = await _seatDao.DeleteSeatAsync(seat);
        return result;
    }

    public async Task<MatchModel?> UpdateMatch(int id, MatchModel match)
    {
        // check that the match date is not in the past
        if (match.Date < DateTime.Now)
            throw new MatchDateInPastException();
        // check that the match is not be played in the stadium that will be played in the same date but with tolerance of 3 hours after and before
        var stadium = await _stadiumDao.GetStadiumByIdAsync(match.StadiumId, true);
        if (stadium == null)
            throw new StadiumNotFoundException(match.StadiumId);
        
        var matches = stadium.Matches;
        foreach (var m in matches)
        {
            if (m.Date.AddHours(4) > match.Date && m.Date.AddHours(-4) < match.Date)
            {
                if (m.Id != id)
                    throw new MatchInSameStadiumInSameDateException();
            }
        }
        try
        {
            var matchDb = await _matchDao.GetMatchByIdAsync(id);
            if (matchDb == null)
                throw new MatchNotFoundException(match.Id);
            matchDb.Date = match.Date;
            matchDb.HomeTeamId = match.HomeTeamId;
            matchDb.AwayTeamId = match.AwayTeamId;
            matchDb.Referee = match.Referee;
            matchDb.Linesmen1 = match.Linesmen1;
            matchDb.Linesmen2 = match.Linesmen2;
            matchDb.StadiumId = match.StadiumId;
            await _matchDao.SaveChanges();
            var updatedMatch = await _matchDao.GetMatchByIdAsync(id);
            return _mapper.Map<MatchModel>(updatedMatch);
        }
        catch (Exception e)
        {
            //check constraint exception
            if(e.InnerException.Message.Contains("CHECK constraint"))
                throw new SameHomeAndAwayTeamException();
            throw new Exception("Invalid match data");
        }
    }

    public async Task<bool> IsSeatReservedByUser(int matchId, int userId, int seatNumber)
    {
        var seat = await _seatDao.GetSeatByMatchIdAndUserIdAndSeatNumberAsync(matchId, userId, seatNumber);
        return seat != null;
    }

    public async Task<bool> IsUserReservedSeatInMatch(int matchId, int userId)
    {
        var seat = await _seatDao.GetSeatByMatchIdAndUserIdAsync(matchId, userId);
        return seat != null;
    }
}