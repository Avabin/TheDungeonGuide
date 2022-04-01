using Sessions.Core.Models;
using Functions.Mongo.Features;
using MongoDB.Bson;

namespace Sessions.Mongo.Models;

public class SessionDocument : SessionBase, IDocument<string>
{
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
}