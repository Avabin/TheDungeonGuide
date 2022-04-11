using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Dices.Api;

public class Dice
{
    private const  string DiceGroupName  = "dice";
    private const  string CountGroupName = "count";
    private static Regex  _regex         = new($@"^(?<{CountGroupName}>\d*)d(?<{DiceGroupName}>\d*)$");
    
    public int Count { get; }
    public int Value { get; }

    public Dice(string expression)
    {
        var groups = _regex.Match(expression).Groups;
        
        if (!groups.ContainsKey(CountGroupName)) throw new InvalidDiceExpressionException(expression, "Expression is missing dice count");
        if (!groups.ContainsKey(DiceGroupName)) throw new InvalidDiceExpressionException(expression, "Expression is missing dice value");
        
        if (!int.TryParse(groups[CountGroupName].Value, out var count)) throw new InvalidDiceExpressionException(expression, "Dice count is not an integer");
        if (!int.TryParse(groups[DiceGroupName].Value, out var value)) throw new InvalidDiceExpressionException(expression, "Dice value is not an integer");
        
        Count = count;
        Value = value;
    }
    
    // Roll the dice Count times and return the sum of the values
    public int Roll() => Enumerable.Range(1, Count).Select(x => Random.Shared.Next(1, Value + 1)).Sum();
    
}