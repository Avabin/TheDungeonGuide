using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.Extensions;
using Players.Core.Models.Commands;
using Players.Core.Models.Queries;
using Players.Mongo.CommandHandlers;
using Players.Mongo.Core;
using Players.Mongo.QueryHandlers;

var builder = Function.CreateBuilder(args, "TDG_", "Players.Mongo");

builder.Services
       .AddEventHandler<CreatePlayerCommandHandler, CreatePlayerCommand>()
       .AddEventHandler<DeletePlayerCommandHandler, DeletePlayerCommand>()
       .AddEventHandler<UpdatePlayerCommandHandler, UpdatePlayerCommand>()
       .AddEventHandler<GetPlayerQueryHandler, GetPlayerQuery>()
       .AddEventHandler<GetPlayersQueryHandler, GetPlayersQuery>()
       .AddPlayers(builder.Configuration.GetConnectionString("Mongo"), "TheDungeonGuide");
var app     = builder.Build();

app.MapEvents();

app.Run();