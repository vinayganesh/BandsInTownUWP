using System.Threading.Tasks;
using AppConstants;
using BandsInTownUWP.Helpers;
using BandsInTownUWP.IServices;
using HttpManager.DataContract;
using Newtonsoft.Json;

namespace BandsInTownUWP.Services
{
    public class JustAnnouncedEventsService : IJustAnnouncedEventsService
    {
        private IGeoCoderService _geoCoderService;

        public JustAnnouncedEventsService(IGeoCoderService geoCoderService)
        {
            _geoCoderService = geoCoderService;
        }

        public async Task<JustAccouncedEventsContract> GetJustAnnouncedEvents()
        {
            var location = await _geoCoderService.GetLocationFromLatLong();

            //Url encoding skips special characters
            location = UrlEncodeHelper.UrlEncode(location);
            //Url encode skips space
            location = location.Replace(' ', '+');

            var requestUrl = Constants.JustAccouncedUrl + location + Constants.JustAnnouncedRadius + Constants.JustAnnouncedEventsItemsPerPage;

            var rawPopularEvents = await HttpManager.HttpClientManager.Instance.Request(requestUrl);
            var jsonPopularEvents = JsonConvert.DeserializeObject<JustAccouncedEventsContract>(rawPopularEvents);

            return jsonPopularEvents;
        }
    }
}
