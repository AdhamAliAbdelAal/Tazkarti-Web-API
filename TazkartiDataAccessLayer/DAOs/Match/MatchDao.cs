using Microsoft.EntityFrameworkCore;
using TazkartiDataAccessLayer.DbContexts;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Match;

public class MatchDao : IMatchDao
{
    private readonly TazkartiDbContext _context;

    public MatchDao(TazkartiDbContext context)
    {
        _context = context;
    }

    public async Task<MatchDbModel?> GetMatchByIdAsync(int id, bool includeSeats = true, bool includeStadium = true, bool includeTeams = true)
    {
        var query = _context.Matches.AsQueryable();
        if (includeSeats)
            query = query.Include(m => m.Seats);
        if (includeStadium)
            query = query.Include(m => m.Stadium);
        if (includeTeams)
            query = query.Include(m => m.HomeTeam).Include(m => m.AwayTeam);
        var match = await query.FirstOrDefaultAsync(m => m.Id == id);
        return match;
    }

    public async Task<MatchDbModel?> AddMatchAsync(MatchDbModel match)
    {
        var matchEntry = await _context.Matches.AddAsync(match);
        await _context.SaveChangesAsync();
        return await GetMatchByIdAsync(matchEntry.Entity.Id);
    }
    public async Task<bool> IsMatchExistsAsync(int id)
    {
        return await _context.Matches.AnyAsync(m => m.Id == id);
    }
    public async Task<IEnumerable<MatchDbModel>> GetMatches(int page, int limit)
    {
        return await _context.Matches
            .Skip((page - 1) * limit)
            .Take(limit)
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.Stadium)
            .ToListAsync();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteMatchAsync(int id)
    {
        var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
        if (match == null)
            return false;
        _context.Matches.Remove(match);
        await _context.SaveChangesAsync();
        return true;
    }
}