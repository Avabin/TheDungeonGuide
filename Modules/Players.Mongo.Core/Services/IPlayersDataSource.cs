using Functions.Mongo.Features.DataSource;
using Players.Core.Models;
using Players.Mongo.Core.Models;

namespace Players.Mongo.Core.Services;

public interface IPlayersDataSource : IMongoDataSource<PlayerDocument>
{
    Task<PlayerDocument?> FindOneByNameAsync(string playerName);
}