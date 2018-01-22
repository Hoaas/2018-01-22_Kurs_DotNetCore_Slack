using Newtonsoft.Json;

namespace SlackApi.Models.Slack
{
    public class SlackAttachmentField
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("short")]
        public bool Short { get; set; }
    }
}