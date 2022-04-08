using Functions.Mongo.Features;

namespace Players.Core.Models;

public class Player : PlayerBase, IDocument<string>
{
    public string Id { get; set; } = "";
}