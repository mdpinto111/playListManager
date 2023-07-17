namespace Playlist.API.Models;

public class PlaylistDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;

    public PlaylistDatabaseSettings(
        string conStr, string dbN, string collN)
    {
        ConnectionString = conStr;
        DatabaseName = dbN;
        CollectionName = collN;
    }
}