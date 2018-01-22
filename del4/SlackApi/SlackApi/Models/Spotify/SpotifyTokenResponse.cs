using System;
using Newtonsoft.Json;

namespace SlackApi.Models.Spotify
{
    public class SpotifyTokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        public DateTime CalulatedExpirationTime { get; set; }
    }
}