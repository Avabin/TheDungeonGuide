global using DataService =
    Functions.Mongo.Features.DataService.IDataService<Players.Core.Models.Commands.CreatePlayerCommand,
        Players.Core.Models.Commands.UpdatePlayerCommand, Players.Core.Models.Player,
        Players.Mongo.Models.PlayerDocument>;

using Functions.Infrastructure.Features;
using Functions.Mongo.Features;
using Players.Core.Models;
using Players.Core.Models.Commands;
using Players.Mongo.Models;

var builder = Function.CreateBuilder(args, "TDG_", "Players.Mongo");

builder.Services.AddDataServices(settings =>
{
    settings.ConnectionString = builder.Configuration.GetConnectionString("Mongo");
    settings.DatabaseName     = "TheDungeonGuide";
}).AddAutoMapper(x =>
                     x.AddProfile(new DataMapperProfile<CreatePlayerCommand, Player, UpdatePlayerCommand,
                                      PlayerDocument>()));
var app     = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();