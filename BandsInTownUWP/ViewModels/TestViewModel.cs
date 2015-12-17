using System.Collections.Generic;
using BandsInTownUWP.IServices;
using BandsInTownUWP.Services;
using Caliburn.Micro;

namespace BandsInTownUWP.ViewModels
{
    public class TestViewModel : Screen
    {
        private IArtistInformationService _artistInformation;
        private IPopularEventsNearbyService _popularEventsNearbyService;
        private IJustAnnouncedEventsService _justAnnouncedEventsService;
        private IRecommendedArtists _recommendedArtists;
        private List<RecommendedArtists> _recommendedArtistsList;
        private string _imageUrl;
        private string _bandName;

        public List<RecommendedArtists> RecommendedArtists
        {
            get { return _recommendedArtistsList; }
            set
            {
                _recommendedArtistsList = value;
                NotifyOfPropertyChange(() => RecommendedArtists);
            }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                NotifyOfPropertyChange(() => ImageUrl);
            }
        }

        public string BandName
        {
            get { return _bandName; }
            set
            {
                _bandName = value;
                NotifyOfPropertyChange(() => BandName);
            }
        }

        public TestViewModel(IArtistInformationService artistInformation,
            IPopularEventsNearbyService popularEventsNearbyService,
            IJustAnnouncedEventsService justAnnouncedEventsService,
            IRecommendedArtists recommendedArtists)
        {
            _artistInformation = artistInformation;
            _popularEventsNearbyService = popularEventsNearbyService;
            _justAnnouncedEventsService = justAnnouncedEventsService;
            _recommendedArtists = recommendedArtists;
        }

        protected override void OnInitialize()
        {
           TestTheServices();
        }

        public async void TestTheServices()
        {
            //var jsonArtistData = await _artistInformation.GetArtistInfo("Megadeth");

            //var popularEvents = await _popularEventsNearbyService.GetPopularEventsNearby();

            //var justAnnouncedEvents = await _justAnnouncedEventsService.GetJustAnnouncedEvents();

            var recommendedArtists = await _recommendedArtists.GetRecommendedArtists();

            foreach (var k in recommendedArtists.data)
            {
                ImageUrl = k.image_url;
                BandName = k.name;
            }

            
            //var jsonEventsData = await _artistInformation.GetArtistEvents("Megadeth");

            //var jsonEventsSearchData = await _artistInformation.GetAristEventBasedOnDistanceFromLocation("Megadeth","100");
        }
    }
}
