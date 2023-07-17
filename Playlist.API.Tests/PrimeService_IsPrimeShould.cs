using Xunit;
using Playlist.API.Services;

namespace Playlist.API.Tests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var playlistService = new PlaylistService();
            bool result = playlistService.GetAsync(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}