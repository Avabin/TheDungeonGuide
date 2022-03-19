namespace Sessions.Core.Models;

public abstract class SessionBase
{
    public string OwnerId { get; set; } = "";
    public string Name    { get; set; } = "";
}