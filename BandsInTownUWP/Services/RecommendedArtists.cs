using System.Threading.Tasks;
using AppConstants;
using BandsInTownUWP.IServices;
using HttpManager.DataContract;
using Newtonsoft.Json;

namespace BandsInTownUWP.Services
{
    public class RecommendedArtists :IRecommendedArtists
    {
        public async Task<RecommendedArtistsContract> GetRecommendedArtists()
        {
            var requestUrl = Constants.RecommendedArtistsUrl + Constants.RecommendedArtistsPerPage;

            var rawRecommendedArtists = await HttpManager.HttpClientManager.Instance.Request(requestUrl);
            var jsonRecommendedArtists = JsonConvert.DeserializeObject<RecommendedArtistsContract>(rawRecommendedArtists);

            return jsonRecommendedArtists;
        }
    }
}
