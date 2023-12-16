using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers;

public interface IStadiumHandler
{
    public Task<StadiumModel?> GetStadiumByName(string name);
    
    public Task<StadiumModel?> AddStadium(StadiumModel stadium);
    
    public Task<bool> IsStadiumExists(string name);
    
    public Task<IEnumerable<StadiumModel>> GetStadiums(int page, int limit);
    
}