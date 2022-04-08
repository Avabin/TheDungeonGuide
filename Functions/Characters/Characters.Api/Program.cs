using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.Extensions;

var builder = Function.CreateBuilder(args, "TDG_", "Characters.Api")
                      .AddDefaultAuthentication();
builder.Services
       .AddControllers();
var app     = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapEvents("/events");
app.MapControllers();

app.Run();