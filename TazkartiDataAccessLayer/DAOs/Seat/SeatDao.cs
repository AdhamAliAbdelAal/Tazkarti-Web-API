using Microsoft.EntityFrameworkCore;
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

    public async Task<SeatDbModel?> GetSeatByMatchIdAndUserIdAndSeatNumberAsync(int matchId, int userId, int seatNumber)
    {
        return await _context.Seats
            .FirstOrDefaultAsync(s => s.MatchId == matchId && s.UserId == userId && s.Number == seatNumber);
    }

    public async Task<SeatDbModel?> AddSeatAsync(SeatDbModel seat)
    {
        await _context.Seats.AddAsync(seat);
        await _context.SaveChangesAsync();
        return seat;
    }

    public async Task<bool> DeleteSeatAsync(SeatDbModel seat)
    {
        _context.Seats.Remove(seat);
        return await _context.SaveChangesAsync() > 0;
    }
}