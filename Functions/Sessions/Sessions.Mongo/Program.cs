// data service type alias

global using DataService = Functions.Mongo.Features.DataService.IDataService<Sessions.Core.Models.Commands.CreateSessionCommand,
    Sessions.Core.Models.Commands.UpdateSessionCommand, Sessions.Core.Models.Session,
    Sessions.Mongo.Models.SessionDocument>;
using Sessions.Core.Models;
using Sessions.Core.Models.Commands;
using Sessions.Core.Models.Queries;
using Sessions.Mongo.CommandHandlers;
using Sessions.Mongo.Models;
using Sessions.Mongo.QueryHandlers;
using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.Extensions;
using Functions.Mongo.Features;

var builder = Function.CreateBuilder(args, "TDG_", "Sessions.Mongo");
builder.Services
       .AddDataServices(settings =>
        {
            settings.ConnectionString = builder.Configuration.GetConnectionString("Mongo");
            settings.DatabaseName     = "TheDungeonGuide";
        })
       .AddAutoMapper(x =>
                          x.AddProfile(new DataMapperProfile<CreateSessionCommand, Session, UpdateSessionCommand,
                                           SessionDocument>()))
       .AddEventHandler<CreateSessionCommandHandler, CreateSessionCommand>()
       .AddEventHandler<UpdateSessionCommandHandler, UpdateSessionCommand>()
       .AddEventHandler<DeleteSessionCommandHandler, DeleteSessionCommand>()
       .AddEventHandler<GetSessionsQueryHandler, GetSessionsQuery>();
var app = builder.Build();

app.MapEvents();

app.Run();