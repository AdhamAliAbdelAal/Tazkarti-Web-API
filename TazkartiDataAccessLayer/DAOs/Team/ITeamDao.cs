using System.Collections;
using TazkartiDataAccessLayer.Models;

namespace TazkartiDataAccessLayer.DAOs.Team;

public interface ITeamDao
{
    public Task<TeamDbModel?> GetTeamById(int id);
    
    public Task<IEnumerable<TeamDbModel>> GetTeams(int page, int limit);
}