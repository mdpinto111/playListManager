using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Playlist.API.Models;

public class PlaylistModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string username { get; set; } = null!;

    public List<String> items { get; set; }
}