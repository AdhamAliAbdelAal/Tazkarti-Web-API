using TazkartiBusinessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Team;

public interface ITeamHandler
{
    public Task<TeamModel> GetTeamById(int id);
    
    public Task<IEnumerable<TeamModel>> GetTeams(int page, int limit);
}