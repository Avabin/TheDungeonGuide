
using Functions.Infrastructure.Features;
using Functions.Mongo.Features;
using Players.Core.Models;
using Players.Core.Models.Commands;
using Players.Mongo.Core;

var builder = Function.CreateBuilder(args, "TDG_", "Players.Mongo");

builder.Services.AddPlayers(builder.Configuration.GetConnectionString("Mongo"), "TheDungeonGuide");
var app     = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();