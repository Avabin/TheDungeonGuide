// data service type alias

global using DataService = Functions.Mongo.Features.DataService.IDataService<Characters.Core.Models.Commands.CreateCharacterCommand,
        Characters.Core.Models.Commands.UpdateCharacterCommand, Characters.Core.Models.Character,
        Characters.Mongo.Models.CharacterDocument>;
using Characters.Core.Models;
using Characters.Core.Models.Commands;
using Characters.Core.Models.Queries;
using Characters.Mongo.CommandHandlers;
using Characters.Mongo.Models;
using Characters.Mongo.QueryHandlers;
using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.Extensions;
using Functions.Mongo.Features;

var builder = Function.CreateBuilder(args, "TDG_", "Characters.Mongo");
builder.Services
       .AddDataServices(settings =>
        {
            settings.ConnectionString = builder.Configuration.GetConnectionString("Mongo");
            settings.DatabaseName     = "TheDungeonGuide";
        })
       .AddAutoMapper(x =>
                          x.AddProfile(new DataMapperProfile<CreateCharacterCommand, Character, UpdateCharacterCommand,
                                           CharacterDocument>()))
       .AddEventHandler<CreateCharacterCommandHandler, CreateCharacterCommand>()
       .AddEventHandler<UpdateCharacterCommandHandler, UpdateCharacterCommand>()
       .AddEventHandler<DeleteCharacterCommandHandler, DeleteCharacterCommand>()
       .AddEventHandler<GetCharactersQueryHandler, GetCharactersQuery>();
var app = builder.Build();

app.MapEvents();

app.Run();