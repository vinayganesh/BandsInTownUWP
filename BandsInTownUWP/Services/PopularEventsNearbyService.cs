using System.Threading.Tasks;
using AppConstants;
using BandsInTownUWP.Helpers;
using BandsInTownUWP.IServices;
using HttpManager.DataContract;
using Newtonsoft.Json;

namespace BandsInTownUWP.Services
{
    public class PopularEventsNearbyService : IPopularEventsNearbyService
    {
        private IGeoCoderService _geoCoderService;

        public PopularEventsNearbyService(IGeoCoderService geoCoderService)
        {
            _geoCoderService = geoCoderService;
        }

        public async Task<PopularEventsContract> GetPopularEventsNearby()
        {
            var location = await _geoCoderService.GetLocationFromLatLong();

            //Url encoding skips special characters
            location = UrlEncodeHelper.UrlEncode(location);
            //Url encode skips space
            location = location.Replace(' ', '+');

            var requestUrl = Constants.PopularEventsUrl + location + Constants.PopularEventsRadius + Constants.PopularEventsItemsPerPage;

            var rawPopularEvents = await HttpManager.HttpClientManager.Instance.Request(requestUrl);
            var jsonPopularEvents = JsonConvert.DeserializeObject<PopularEventsContract>(rawPopularEvents);

            return jsonPopularEvents;
        }
    }
}
