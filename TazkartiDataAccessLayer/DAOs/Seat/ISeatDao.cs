using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Seat;

public interface ISeatDao
{
    Task<SeatDbModel?> GetSeatByIdAsync(int id);
    
    Task<SeatDbModel?> AddSeatAsync(SeatDbModel seat);
    
}