using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlackApi.Models.Omdb;

namespace SlackApi.ExternalServices
{
    public class Omdb
    {
        private static HttpClient _client = new HttpClient();
        private const string apikey = ""; // TODO: Enter API-KEY here!
        
        public async Task<OmdbResponse> Search(string query)
        {
            var url = $"http://www.omdbapi.com/?apikey={apikey}&t={query}";

            var result = await _client.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<OmdbResponse>(result);

            return response;
        }
    }
}