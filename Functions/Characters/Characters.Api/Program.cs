using EventHandler.Infrastructure.Features;
using EventHandler.Infrastructure.Features.Extensions;

var builder = Function.CreateBuilder(args, "TDG_", "Characters.Api");
builder.Services
       .AddControllers();
var app     = builder.Build();
app.MapEvents("/events");
app.MapControllers();

app.Run();