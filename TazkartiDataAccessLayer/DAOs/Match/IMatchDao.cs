using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Match;

public interface IMatchDao
{
    Task<MatchDbModel?> GetMatchByIdAsync(int id, bool includeSeats = false, bool includeStadium = false, bool includeTeams = false);
    
    Task<MatchDbModel?> AddMatchAsync(MatchDbModel match);
    
    Task<bool> IsMatchExistsAsync(int id);
    
    Task<IEnumerable<MatchDbModel>> GetMatches(int page, int limit);
    
    Task<int> SaveChanges();
}