using AutoMapper;
using TazkartiBusinessLayer.Models;
using TazkartiDataAccessLayer.DAOs.Stadium;
using TazkartiDataAccessLayer.Models;

namespace TazkartiBusinessLayer.Handlers;

public class StadiumHandler : IStadiumHandler
{
    private readonly IStadiumDao _stadiumDao;
    private readonly IMapper _mapper;
    
    public StadiumHandler(IStadiumDao stadiumDao, IMapper mapper)
    {
        _stadiumDao = stadiumDao;
        _mapper = mapper;
    }
    
    public async Task<StadiumModel?> GetStadiumByName(string name)
    {
        var stadium = await _stadiumDao.GetStadiumByNameAsync(name);
        if (stadium == null)
        {
            return null;
        }
        return _mapper.Map<StadiumModel>(stadium);
    }
    
    public async Task<StadiumModel?> AddStadium(StadiumModel stadium)
    {
        if (await _stadiumDao.IsStadiumExistsAsync(stadium.Name))
        {
            return null;
        }
        // validate stadium
        // 1) check if the stadium capacity is greater than vip capacity
        if (stadium.Capacity < stadium.VIPLength * stadium.VIPWidth)
        {
            return null;
        }
        var stadiumDbModel = _mapper.Map<StadiumDbModel>(stadium);
        var result = await _stadiumDao.AddStadiumAsync(stadiumDbModel);
        return _mapper.Map<StadiumModel>(result);
    }
    
    public async Task<bool> IsStadiumExists(string name)
    {
        return await _stadiumDao.IsStadiumExistsAsync(name);
    }
    
    public async Task<IEnumerable<StadiumModel>> GetStadiums(int page, int limit)
    {
        var stadiums = await _stadiumDao.GetStadiums(page, limit);
        return _mapper.Map<IEnumerable<StadiumModel>>(stadiums);
    }
}