using Playlist.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Playlist.API.Services;

public class PlaylistService
{
    private readonly IMongoCollection<PlaylistModel> _playlistCollection;

    public PlaylistService(
        IOptions<PlaylistDatabaseSettings> playlistDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            playlistDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            playlistDatabaseSettings.Value.DatabaseName);

        _playlistCollection = mongoDatabase.GetCollection<PlaylistModel>(
            playlistDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<PlaylistModel>> GetAsync() =>
        await _playlistCollection.Find(_ => true).ToListAsync();

    public async Task<PlaylistModel?> GetAsync(string id) =>
        await _playlistCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PlaylistModel newPlaylist) =>
        await _playlistCollection.InsertOneAsync(newPlaylist);

    public async Task UpdateAsync(string id, PlaylistModel updatedPlaylist) =>
        await _playlistCollection.ReplaceOneAsync(x => x.Id == id, updatedPlaylist);

    public async Task RemoveAsync(string id) =>
        await _playlistCollection.DeleteOneAsync(x => x.Id == id);
}