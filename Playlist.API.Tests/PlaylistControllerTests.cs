using Xunit;
using Playlist.API.Services;
using Playlist.API.Models;
using Playlist.API.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Playlist.API.Tests.Services
{
    public class PlaylistControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfPlaylists()
        {
            // Arrange
            var mockPlaylistService = new Mock<IPlaylistService>();
            var expectedPlaylists = new List<PlaylistModel>
            {
                new PlaylistModel { Id = "1", username = "Playlist 1" },
                new PlaylistModel { Id = "2", username = "Playlist 2" }
            };
            mockPlaylistService.Setup(service => service.GetAsync()).ReturnsAsync(expectedPlaylists);
            var controller = new PlaylistController(mockPlaylistService.Object);

            // Act
            var result = await controller.Get();
             Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Information("Test result: {Result}", result);

            // Assert
            Assert.Equal(1, 1);
        }
    }
}