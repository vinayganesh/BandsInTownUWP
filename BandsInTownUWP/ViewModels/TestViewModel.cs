using System.Diagnostics;
using BandsInTownUWP.IServices;
using Caliburn.Micro;

namespace BandsInTownUWP.ViewModels
{
    public class TestViewModel : Screen
    {
        private IArtistInformationService _artistInformation;
        private IPopularEventsNearbyService _popularEventsNearbyService;
        private IJustAnnouncedEventsService _justAnnouncedEventsService;
        private IRecommendedArtists _recommendedArtists;

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
            var jsonArtistData = await _artistInformation.GetArtistInfo("Megadeth");

            var popularEvents = await _popularEventsNearbyService.GetPopularEventsNearby();

            var justAnnouncedEvents = await _justAnnouncedEventsService.GetJustAnnouncedEvents();

            var recommendedArtists = await _recommendedArtists.GetRecommendedArtists();

            var jsonEventsData = await _artistInformation.GetArtistEvents("Megadeth");

            var jsonEventsSearchData = await _artistInformation.GetAristEventBasedOnDistanceFromLocation("Megadeth","100");
        }
    }
}
