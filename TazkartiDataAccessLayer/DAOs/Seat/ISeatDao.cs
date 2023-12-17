using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Seat;

public interface ISeatDao
{
    Task<SeatDbModel?> GetSeatByMatchIdAndUserIdAndSeatNumberAsync(int matchId, int userId, int seatNumber);
    
    Task<SeatDbModel?> AddSeatAsync(SeatDbModel seat);
    
    Task<bool> DeleteSeatAsync(SeatDbModel seat);
    
}