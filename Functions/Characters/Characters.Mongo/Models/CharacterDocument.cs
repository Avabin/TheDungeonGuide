using Characters.Core.Models;
using Mongo;
using MongoDB.Bson;

namespace Characters.Mongo.Models;

public class CharacterDocument : CharacterBase, IDocument<string>
{
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
}