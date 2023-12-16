using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Stadium;

public interface IStadiumDao
{
    Task<StadiumDbModel?> GetStadiumByNameAsync(string name);
    
    Task<StadiumDbModel?> AddStadiumAsync(StadiumDbModel stadium);
    
    Task<bool> IsStadiumExistsAsync(string name);
    
    Task<IEnumerable<StadiumDbModel>> GetStadiums(int page, int limit);
}