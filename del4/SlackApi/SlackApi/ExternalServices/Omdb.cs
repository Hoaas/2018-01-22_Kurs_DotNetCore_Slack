using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SlackApi.ExternalServices.Interfaces;
using SlackApi.Models.Omdb;

namespace SlackApi.ExternalServices
{
    public class Omdb : IOmdb
    {
        private static HttpClient _client = new HttpClient();
        private static string _apikey;
        
         public Omdb(IOptions<SuperConfig> config)
        {
            _apikey = config.Value.Omdb.ApiKey;
        }

        public async Task<OmdbResponse> Search(string query)
        {
            var url = $"http://www.omdbapi.com/?apikey={_apikey}&t={query}";

            var result = await _client.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<OmdbResponse>(result);

            return response;
        }
    }
}