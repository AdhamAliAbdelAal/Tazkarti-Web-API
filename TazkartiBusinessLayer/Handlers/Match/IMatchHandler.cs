using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Match;

public interface IMatchHandler
{
    public Task<MatchModel?> GetMatchById(int id);
    
    public Task<MatchModel?> AddMatch(MatchModel match);
    
    public Task<IEnumerable<MatchModel>> GetMatches(int page, int limit);
}