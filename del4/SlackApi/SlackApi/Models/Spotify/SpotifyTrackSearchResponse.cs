using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackApi.Models.Spotify
{
    public class SpotifyTrackSearchResponse
    {
        public Tracks Tracks { get; set; }
    }

    public class Tracks
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }

    public class Item
    {
        public Album Album { get; set; }
        public List<Artist1> Artists { get; set; }
        public string[] AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        [JsonProperty(PropertyName = "External_Ids")]
        public ExternalIds ExternalIds { get; set; }
        [JsonProperty(PropertyName = "External_Urls")]
        public ExternalUrls2 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        [JsonProperty(PropertyName = "Preview_Url")]
        public string PreviewUrl { get; set; }
        [JsonProperty(PropertyName = "Track_Number")]
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Album
    {
        [JsonProperty(PropertyName = "Album_Type")]
        public string AlbumType { get; set; }
        public List<Artist> Artists { get; set; }
        [JsonProperty(PropertyName = "Available_Markets")]
        public List<string> AvailableMarkets { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Artist
    {
        public ExternalUrls1 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalUrls1
    {
        public string Spotify { get; set; }
    }

    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class ExternalIds
    {
        public string Isrc { get; set; }
    }

    public class ExternalUrls2
    {
        public string Spotify { get; set; }
    }

    public class Artist1
    {
        public ExternalUrls3 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalUrls3
    {
        public string Spotify { get; set; }
    }

}
