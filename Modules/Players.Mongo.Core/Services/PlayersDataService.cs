using AutoMapper;
using Functions.Mongo.Features.DataService;
using Microsoft.Extensions.Logging;
using Players.Core.Models;
using Players.Core.Models.Commands;
using Players.Mongo.Core.Models;

namespace Players.Mongo.Core.Services;

public class PlayersDataService : DataService<CreatePlayerCommand, UpdatePlayerCommand, Player, PlayerDocument>, IPlayersDataService
{
    private readonly IPlayersDataSource _dataSource;
    private readonly IMapper            _mapper;

    public PlayersDataService(IPlayersDataSource dataSource, IMapper mapper, ILogger<PlayersDataService> logger) : base(dataSource, mapper, logger)
    {
        _dataSource  = dataSource;
        _mapper = mapper;
    }

    public async Task<Player?> FindByNameAsync(string playerName)
    {
        var player = await _dataSource.FindOneByNameAsync(playerName);
        
        return player == null ? null : _mapper.Map<Player>(player);
    }
}