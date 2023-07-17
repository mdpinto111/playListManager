using Playlist.API.Models;

namespace Playlist.API.Controllers;

public interface IPlaylistService
{
    Task<List<PlaylistModel>> GetAsync();
    Task<PlaylistModel?> GetAsync(string id);
    Task CreateAsync(PlaylistModel newPlaylist);
    Task UpdateAsync(string id, PlaylistModel updatedPlaylist);
    Task RemoveAsync(string id);        
}
