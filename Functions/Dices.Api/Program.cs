using Dices.Api;
using Functions.Infrastructure.Features;

var builder = Function.CreateBuilder(args, "TDG_", "Dices.Api", false)
                      .AddDefaultAuthentication();

var app = builder.Build();

app.MapGet("/", (string expression) =>
{
    try
    {
        var dice = new Dice(expression);
        return Results.Ok(dice.Roll());
    }
    catch (InvalidDiceExpressionException e)
    {
        return Results.BadRequest(new { error = e.Message });
    }
});

app.Run();