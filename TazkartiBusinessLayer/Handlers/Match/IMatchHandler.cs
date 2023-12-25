using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Match;

public interface IMatchHandler
{
    public Task<MatchModel?> GetMatchById(int id);
    
    public Task<MatchModel?> AddMatch(MatchModel match);
    
    public Task<IEnumerable<MatchModel>> GetMatches(int page, int limit);
    
    public Task<bool> IsMatchExists(int id);
    
    public Task<SeatModel?> ReserveSeat(int matchId, int userId,int seatNumber);
    
    public Task<bool> CancelSeatReservation(int matchId, int userId,int seatNumber);
    
    public Task<MatchModel?> UpdateMatch(int id, MatchModel match);
    
    public Task<bool> IsSeatReservedByUser(int matchId, int userId, int seatNumber);
    
    public Task<bool> IsUserReservedSeatInMatch(int matchId, int userId);
    
    public Task<int> GetSeatReservedByUser(int matchId, int userId);
}