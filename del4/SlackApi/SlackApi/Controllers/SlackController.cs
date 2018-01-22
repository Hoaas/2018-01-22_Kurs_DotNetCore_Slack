using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackApi.ExternalServices;
using SlackApi.ExternalServices.Interfaces;
using SlackApi.Models;
using SlackApi.Models.Slack;

namespace SlackApi.Controllers
{
    [Route("api/[controller]")]
    public class SlackController : Controller
    {
        private readonly IOmdb _omdb;
        private readonly ISpotify _spotify;

        public SlackController(IOmdb omdb, ISpotify spotify)
        {
            _omdb = omdb;
            _spotify = spotify;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(SlackPostModel slack)
        {
            if (slack.Command.ToLower() == "/omdb")
            {
                var omdbResponse = await CreateOmdbResponse(slack.Text);
                return Ok(omdbResponse);
            }

            if (slack.Command.ToLower() == "/spotify")
            {
                var spotifyResponse = await CreateSpotifyResponse(slack.Text);
                return Ok(spotifyResponse);
            }

            return Ok();
        }

        private async Task<SlackMessage> CreateSpotifyResponse(string text)
        {
            var artistAndTrack = text.Split("-");
            if (artistAndTrack.Length != 2)
            {
                return new SlackMessage { text = "Sorry, må søke på formatet 'artist - sang' (f.eks. /spotify Michael Jackson - Thriller)" };
            }

            var trackUrl = await _spotify.GetTrackUrl(artist: artistAndTrack[0].Trim(), track: artistAndTrack[1].Trim());
            
            var response = new SlackMessage();
            response.text = trackUrl;
            return response;
        }

        public async Task<SlackMessage> CreateOmdbResponse(string query)
        {
            var result = await _omdb.Search(query);
            
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
