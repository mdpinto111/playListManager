using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Playlist.API.Models;

public class User
{
    public string username { get; set; } = null!;

    public string password { get; set; } = null!;
}