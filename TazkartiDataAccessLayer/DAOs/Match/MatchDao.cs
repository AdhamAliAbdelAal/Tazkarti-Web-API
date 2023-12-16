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

    public async Task<MatchDbModel?> GetMatchByIdAsync(int id)
    {
        return await _context.Matches
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MatchDbModel?> AddMatchAsync(MatchDbModel match)
    {
        var matchEntry = await _context.Matches.AddAsync(match);
        await _context.SaveChangesAsync();
        return matchEntry.Entity;
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
            .ToListAsync();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}