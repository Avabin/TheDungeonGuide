using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.Extensions;

var builder = Function.CreateBuilder(args, "TDG_", "Sessions.Api");
builder.Services
       .AddControllers();
var app     = builder.Build();
app.MapEvents("/events");
app.MapControllers();

app.Run();