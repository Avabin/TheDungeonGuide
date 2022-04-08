global using DataService = Functions.Mongo.Features.DataService.IDataService<Players.Core.Models.Commands.CreatePlayerCommand,
        Players.Core.Models.Commands.UpdatePlayerCommand, Players.Core.Models.Player,
        Players.Mongo.Core.Models.PlayerDocument>;

using Players.Core.Models;
namespace Players.Mongo.Core.Services;

public interface IPlayersDataService : DataService
{
        Task<Player?> FindByNameAsync(string playerName);
}