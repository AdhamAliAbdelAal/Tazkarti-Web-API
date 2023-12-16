using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs.Match;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Handlers.Match;

public class MatchHandler : IMatchHandler
{
    private readonly IMatchDao _matchDao;
    private readonly IMapper _mapper;
    
    public MatchHandler(IMatchDao matchDao, IMapper mapper)
    {
        _matchDao = matchDao;
        _mapper = mapper;
    }


    public async Task<MatchModel?> GetMatchById(int id)
    {
        var user = await _matchDao.GetMatchByIdAsync(id);
        if (user == null)
        {
            return null;
        }
        return _mapper.Map<MatchModel>(user);
    }

    public async Task<MatchModel?> AddMatch(MatchModel match)
    {
        var matchDbModel = _mapper.Map<MatchDbModel>(match);
        var result = await _matchDao.AddMatchAsync(matchDbModel);
        return _mapper.Map<MatchModel>(result);
    }

    public async Task<IEnumerable<MatchModel>> GetMatches(int page, int limit)
    {
        var matches = await _matchDao.GetMatches(page, limit);
        return _mapper.Map<IEnumerable<MatchModel>>(matches);
    }
}