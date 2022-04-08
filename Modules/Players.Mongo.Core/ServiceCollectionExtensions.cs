using Functions.Mongo.Features;
using Microsoft.Extensions.DependencyInjection;
using Players.Core.Models;
using Players.Core.Models.Commands;
using Players.Mongo.Core.Models;
using Players.Mongo.Core.Services;

namespace Players.Mongo.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayers(this IServiceCollection services, string connectionString,
                                                string                  databaseName)
    {
        services
           .AddDataServices(settings =>
            {
                settings.ConnectionString = connectionString;
                settings.DatabaseName     = databaseName;
            })
           .AddTransient<IPlayersDataService, PlayersDataService>()
            .AddTransient<IPlayersDataSource, PlayersDataSource>()
           .AddAutoMapper(x =>
                              x.AddProfile(new DataMapperProfile<CreatePlayerCommand, Player, UpdatePlayerCommand,
                                               PlayerDocument>()));

        return services;
    }
}