using Xunit;
using Playlist.API.Services;
using Playlist.API.Models;
using Playlist.API.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Sinks.XUnit;


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

            Assert.IsType<List<PlaylistModel>>(result);
            Assert.True(result != null && expectedPlaylists.Count == result.Count);
        }

        [Fact]
        public async Task Get_ReturnListNoExist()
        {
            // Arrange
            var mockPlaylistService = new Mock<IPlaylistService>();
            var expectedPlaylists = new List<PlaylistModel> ();
            mockPlaylistService.Setup(service => service.GetAsync()).ReturnsAsync(expectedPlaylists);
            var controller = new PlaylistController(mockPlaylistService.Object);
                     
            // Act
            var result = await controller.Get();

            Assert.False(result.Count > 0);
        }
    }
}