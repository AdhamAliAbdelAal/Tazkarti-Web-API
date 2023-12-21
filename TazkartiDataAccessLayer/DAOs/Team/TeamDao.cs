using Microsoft.EntityFrameworkCore;
using TazkartiDataAccessLayer.DbContexts;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Team;

public class TeamDao: ITeamDao
{
    private readonly TazkartiDbContext _context;
    public TeamDao(TazkartiDbContext context)
    {
        _context = context;
    }
    public async Task<TeamDbModel?> GetTeamById(int id)
    {
        return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TeamDbModel>> GetTeams(int page, int limit)
    {
        return await _context.Teams
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }
}