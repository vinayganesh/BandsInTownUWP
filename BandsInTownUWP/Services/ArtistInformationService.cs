using BandsInTownUWP.IServices;
using AppConstants;
using System.Diagnostics;
using System.Threading.Tasks;
using HttpManager.DataContract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using BandsInTownUWP.Helpers;

namespace BandsInTownUWP.Services
{
    public class ArtistInformationService : IArtistInformationService
    {
        private IGeoCoderService _geoCoderService;

        public ArtistInformationService(IGeoCoderService geoCoderService)
        {
            _geoCoderService = geoCoderService;
        }

        public async Task<List<EventsBasdOnRadiusContract>> GetAristEventBasedOnDistanceFromLocation(string artistName, string radius)
        {
            var location = await _geoCoderService.GetLocationFromLatLong();

            //Url encoding skips special characters
            location = UrlEncodeHelper.UrlEncode(location);
            //Url encode skips space
            location = location.Replace(' ', '+');

            //http://api.bandsintown.com/artists/metallica/events/search.json?api_version=2.0&app_id=&app_id=WPhone&location=San+Francisco%2C+CA&radius=100
            var requestUrl = Constants.BaseURL + Constants.Artists + artistName + Constants.EventsSearchUrl+ Constants.ApiVersion + Constants.AppID +
                             Constants.EventsSearchLocation + location + Constants.EventsSearchRadius + radius;
            Debug.WriteLine(requestUrl);
            var eventsRawData = await HttpManager.HttpClientManager.Instance.Request(requestUrl);
            var eventsJsonData = JsonConvert.DeserializeObject<List<EventsBasdOnRadiusContract>>(eventsRawData);

            return eventsJsonData;
        }

        public async Task<List<EventsContract>> GetArtistEvents(string artistName)
        {
            var requestUrl = Constants.BaseURL + Constants.Artists + artistName + Constants.Events +
                             Constants.ApiVersion + Constants.AppID;
            Debug.WriteLine(requestUrl);

            var eventsRawData = await HttpManager.HttpClientManager.Instance.Request(requestUrl);
            var eventsJsonData = JsonConvert.DeserializeObject<List<EventsContract>>(eventsRawData);

            return eventsJsonData;

        }

        public async Task<ArtistContract> GetArtistInfo(string artistName)
        {
            var requestUrl = Constants.BaseURL + Constants.Artists + artistName + Constants.ApiVersion + Constants.AppID;
            Debug.WriteLine(requestUrl);

            var artistRawData = await HttpManager.HttpClientManager.Instance.Request(requestUrl);

            var artistJsonData = JsonConvert.DeserializeObject<ArtistContract>(artistRawData);

            return artistJsonData;
        }
    }
}
