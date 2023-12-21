using AutoMapper;
using TazkartiBusinessLayer.Exceptions;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs.Team;

namespace TazkartiBusinessLayer.Handlers.Team;

public class TeamHandler: ITeamHandler
{
    private readonly ITeamDao _teamDao;
    private readonly IMapper _mapper;
    public TeamHandler(ITeamDao teamDao, IMapper mapper)
    {
        _teamDao = teamDao;
        _mapper = mapper;
    }
    public async Task<TeamModel> GetTeamById(int id)
    {
        var team = await _teamDao.GetTeamById(id);
        if (team == null)
        {
            throw new TeamNotFoundException(id);
        }
        return _mapper.Map<TeamModel>(team);
    }

    public async Task<IEnumerable<TeamModel>> GetTeams(int page, int limit)
    {
        var teams = await _teamDao.GetTeams(page, limit);
        return _mapper.Map<IEnumerable<TeamModel>>(teams);
    }
}