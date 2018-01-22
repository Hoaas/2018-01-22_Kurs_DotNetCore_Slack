using System.Collections.Generic;

namespace SlackApi.Models.Slack
{

    public enum ResponseType {
        in_channel,
        ephemeral
    }
    
    public class SlackMessage
    {
        // If this is not set the response is only visible to the one that triggered the command.
        // The other option is ephemeral. That will have the same effect as null/empty.
        public ResponseType response_type { get; set; }
        public string text { get; set; }
        public List<SlackAttachment> attachments { get; set; } = new List<SlackAttachment>();
    }
}