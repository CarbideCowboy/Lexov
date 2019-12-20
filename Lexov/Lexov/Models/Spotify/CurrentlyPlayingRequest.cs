using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lexov.Models.Spotify
{
    public class CurrentlyPlayingRequest : ServiceRequest
    {
        public override string Url => "https://api.spotify.com/v1/me/player/currently-playing";
        public override HttpMethod Method => HttpMethod.Get;
        public override Dictionary<string, string> Headers => Lexov.Models.Headers.Spotify.Headers;

        public static async Task<CurrentlyPlaying> SendCurrentlyPlayingServiceRequest()
        {
            var currentlyPlayingRequest = new CurrentlyPlayingRequest();
            var r = await ServiceRequestHandler.MakeServiceCall<CurrentlyPlaying>(currentlyPlayingRequest, null);
            return r;
        }
    }
}
