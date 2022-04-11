namespace Dices.Api;

public class InvalidDiceExpressionException : Exception
{
    public InvalidDiceExpressionException(string expression, string message) : base($"'{expression}' {message}")
    {
    }
    
    public InvalidDiceExpressionException() : base("Invalid dice expression")
    {
    }
    
}