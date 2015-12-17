using System.Collections.Generic;
using BandsInTownUWP.IServices;
using Caliburn.Micro;
using HttpManager.DataContract;

namespace BandsInTownUWP.ViewModels
{
    public class LandingPageViewModel : Screen
    {
        private IRecommendedArtists _recommendedArtists;
        private bool _isPaneOpen;
        private List<RecommendedArtistsContract.Datum> _recommendedArtistsList;

        public List<RecommendedArtistsContract.Datum> RecommendedArtists
        {
            get { return _recommendedArtistsList; }
            set
            {
                _recommendedArtistsList = value;
                NotifyOfPropertyChange(() => RecommendedArtists);
            }
        }

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set
            {
                _isPaneOpen = value;
                NotifyOfPropertyChange(() => IsPaneOpen);
            }
        }

        public LandingPageViewModel(IRecommendedArtists recommendedArtists)
        {
            _recommendedArtists = recommendedArtists;
        }

        protected override async void OnInitialize()
        {
            var recommendedArtists = await _recommendedArtists.GetRecommendedArtists();
            RecommendedArtists = recommendedArtists.data;
        }

        private void Open()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
