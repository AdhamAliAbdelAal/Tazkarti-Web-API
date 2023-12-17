using TazkartiDataAccessLayer.DbContexts;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Seat;

public class SeatDao : ISeatDao
{
    private readonly TazkartiDbContext _context;

    public SeatDao(TazkartiDbContext context)
    {
        _context = context;
    }

    public async Task<SeatDbModel?> GetSeatByIdAsync(int id)
    {
        return await _context.Seats.FindAsync(id);
    }

    public async Task<SeatDbModel?> AddSeatAsync(SeatDbModel seat)
    {
        await _context.Seats.AddAsync(seat);
        await _context.SaveChangesAsync();
        return seat;
    }
}