using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackApi.ExternalServices;
using SlackApi.Models;
using SlackApi.Models.Slack;

namespace SlackApi.Controllers
{
    [Route("api/[controller]")]
    public class SlackController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(SlackPostModel slack)
        {
            if (slack.Command.ToLower() == "/omdb")
            {
                var omdbResponse = await CreateOmdbResponse(slack.Text);
                return Ok(omdbResponse);
            }

            return Ok();
        }

        public async Task<SlackMessage> CreateOmdbResponse(string query)
        {
            var omdb = new Omdb();
            var result = await omdb.Search(query);
            
            var slackMessage = new SlackMessage();
            slackMessage.response_type = ResponseType.ephemeral;


            slackMessage.attachments.Add(new SlackAttachment
                {
                    Title = result.Title,
                    TitleLink = result.Website,
                    Text = result.Plot
                }
            );

            var ratingAttachments = result.Ratings.Select(r => 
                new SlackAttachment
                {
                    Title = r.Source,
                    Text = r.Value
                }
            );

            slackMessage.attachments.AddRange(ratingAttachments);
            slackMessage.attachments.Add(new SlackAttachment
                {
                    ImageUrl = result.Poster,
                }
            );
            slackMessage.attachments.Add(new SlackAttachment
                {
                    Footer = result.Actors
                }
            );
            return slackMessage;
        }
    }
}
