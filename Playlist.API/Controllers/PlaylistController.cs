using Playlist.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Playlist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistService _playListService;

    public PlaylistController(IPlaylistService playListService) =>
        _playListService = playListService;

    [HttpGet]
    public async Task<List<PlaylistModel>> Get() =>
        await _playListService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<PlaylistModel>> Get(string id)
    {
        var playlist = await _playListService.GetAsync(id);

        if (playlist is null)
        {
            return NotFound();
        }

        return playlist;

    }

    [HttpPost]
    public async Task<IActionResult> Post(PlaylistModel newPlaylist)
    {
        await _playListService.CreateAsync(newPlaylist);

        return CreatedAtAction(nameof(Get), new { id = newPlaylist.Id }, newPlaylist);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, PlaylistModel updatedPlaylist)
    {
        var playList = await _playListService.GetAsync(id);

        if (playList is null)
        {
            return NotFound();
        }

        updatedPlaylist.Id = playList.Id;

        await _playListService.UpdateAsync(id, updatedPlaylist);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var playList = await _playListService.GetAsync(id);

        if (playList is null)
        {
            return NotFound();
        }

        await _playListService.RemoveAsync(id);

        return NoContent();
    }
}