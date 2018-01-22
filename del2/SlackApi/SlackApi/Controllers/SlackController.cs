using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackApi.Models;
using SlackApi.Models.Slack;

namespace SlackApi.Controllers
{
    [Route("api/[controller]")]
    public class SlackController : Controller
    {
        [HttpPost]
        public IActionResult Post(SlackPostModel slack)
        {
            if (slack.Text.ToLower() == "hi") {
                
                var slackMessage = new SlackMessage();
                slackMessage.response_type = ResponseType.ephemeral;
                slackMessage.text = "Hallo";

                return Ok(slackMessage);
            }

            return Ok("Hello world!");
        }
    }
}
