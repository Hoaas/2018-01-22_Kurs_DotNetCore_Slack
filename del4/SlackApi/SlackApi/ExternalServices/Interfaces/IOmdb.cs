using System.Threading.Tasks;
using SlackApi.Models.Omdb;

namespace SlackApi.ExternalServices.Interfaces
{
    public interface IOmdb
    {
         Task<OmdbResponse> Search(string query);
    }
}