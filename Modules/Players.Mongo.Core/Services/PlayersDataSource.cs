using Functions.Mongo.Features.DataSource;
using Functions.Mongo.Features.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Players.Mongo.Core.Models;

namespace Players.Mongo.Core.Services;

public class PlayersDataSource : MongoDataSource<PlayerDocument>, IPlayersDataSource
{
    public PlayersDataSource(IOptions<MongoSettings> options, ILogger<PlayersDataSource> logger) : base(options, logger)
    {
    }

    public async Task<PlayerDocument?> FindOneByNameAsync(string playerName)
    {
        var filter = Builders<PlayerDocument>.Filter.Eq(x => x.Name, playerName);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }
}