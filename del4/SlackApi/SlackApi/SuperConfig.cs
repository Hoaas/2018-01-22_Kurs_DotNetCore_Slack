namespace SlackApi
{
public class SuperConfig
    {
        public OmdbConfig Omdb { get; set; }
        public SpotifyConfig Spotify { get; set; }
    }

    public class SpotifyConfig
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class OmdbConfig
    {
        public string ApiKey { get; set; }
    }
}