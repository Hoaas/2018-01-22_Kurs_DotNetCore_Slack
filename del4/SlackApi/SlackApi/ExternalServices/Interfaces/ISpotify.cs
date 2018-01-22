using System.Threading.Tasks;

namespace SlackApi.ExternalServices.Interfaces
{
    public interface ISpotify
    {
         Task<string> GetTrackUrl(string artist, string track);
    }
}