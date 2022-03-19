using EventHandler.Infrastructure.Features;
using EventHandler.Infrastructure.Features.Extensions;

var builder = Function.CreateBuilder(args, "DLS_", "DeadLetterSink");
builder.Services.AddEventing(builder.Configuration.GetSection("Eventing"));
var app     = builder.Build();

app.MapEvents();

app.Run();