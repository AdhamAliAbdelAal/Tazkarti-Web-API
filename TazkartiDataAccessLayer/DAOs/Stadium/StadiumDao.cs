using Microsoft.EntityFrameworkCore;
using TazkartiDataAccessLayer.DbContexts;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Stadium;

public class StadiumDao : IStadiumDao
{
    private readonly TazkartiDbContext _context;

    public StadiumDao(TazkartiDbContext context)
    {
        _context = context;
    }

    public async Task<StadiumDbModel?> GetStadiumByNameAsync(string name)
    {
        return await _context.Stadiums
            .FirstOrDefaultAsync(s => s.Name == name);
    }

    public async Task<StadiumDbModel?> AddStadiumAsync(StadiumDbModel stadium)
    {
        var stadiumEntry = await _context.Stadiums.AddAsync(stadium);
        await _context.SaveChangesAsync();
        return stadiumEntry.Entity;
    }

    public async Task<bool> IsStadiumExistsAsync(string name)
    {
        return await _context.Stadiums.AnyAsync(s => s.Name == name);
    }

    public async Task<IEnumerable<StadiumDbModel>> GetStadiums(int page, int limit)
    {
        return await _context.Stadiums
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}