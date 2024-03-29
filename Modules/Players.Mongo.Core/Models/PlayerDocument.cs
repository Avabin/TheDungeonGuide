﻿using Functions.Mongo.Features;
using MongoDB.Bson;
using Players.Core.Models;

namespace Players.Mongo.Core.Models;

public class PlayerDocument : PlayerBase, IDocument<string>
{
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
}