using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using SlackApi.ExternalServices.Interfaces;
using SlackApi.Models.Spotify;

namespace SlackApi.ExternalServices
{
    public class Spotify : ISpotify
    {
        private const string ApiEndpoint = "https://api.spotify.com/v1/search?";

        private static SpotifyTokenResponse _oAuthToken;
        private static string _clientId;
        private static string _clientSecret;


        public Spotify(IOptions<SuperConfig> config)
        {
            _clientId = config.Value.Spotify.ClientId;
            _clientSecret = config.Value.Spotify.ClientSecret;
        }

        public async Task<string> GetTrackUrl(string artist, string track)
        {
            var parameters = new
            {
                type = "track",
                market = "NO",
                limit = "1",
                q = $"artist:{HttpUtility.UrlEncode(artist)} track:{HttpUtility.UrlEncode(track)}"
            };

            SpotifyTrackSearchResponse result;
            try
            {
                result = await ApiEndpoint
                    .SetQueryParams(parameters)
                    .WithOAuthBearerToken(await GetAccessTokenAsync())
                    .GetJsonAsync<SpotifyTrackSearchResponse>();
            }
            catch (FlurlHttpException)
            {
                return null;
            }

            var url = result.Tracks.Items.SingleOrDefault()?.ExternalUrls?.Spotify;
            return url;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (_oAuthToken != null && _oAuthToken.CalulatedExpirationTime > DateTime.Now) return _oAuthToken.AccessToken;

            const string tokenEndpoint = "https://accounts.spotify.com/api/token";
            var result = await tokenEndpoint
                .WithBasicAuth(_clientId, _clientSecret)
                .PostUrlEncodedAsync(new
                {
                    grant_type = "client_credentials"
                })
                .ReceiveJson<SpotifyTokenResponse>();

            _oAuthToken = result;
            _oAuthToken.CalulatedExpirationTime = DateTime.Now.AddSeconds(result.ExpiresIn);
            return _oAuthToken.AccessToken;
        }
    }
}