using System.Collections.Generic;
using System.Diagnostics;
using BandsInTownUWP.IServices;
using Caliburn.Micro;
using HttpManager.DataContract;

namespace BandsInTownUWP.ViewModels
{
    public class ArtistInfoViewModel : Screen
    {
        private RecommendedArtistsContract.Datum _artist;
        public RecommendedArtistsContract.Datum Parameter { get; set; }
        private IArtistInformationService _artistInformationService;
        private List<EventsContract> _events;

        public RecommendedArtistsContract.Datum Artist
        {
            get { return _artist; }
            set
            {
                if (value.Equals(_artist)) return;
                _artist = value;
                NotifyOfPropertyChange(() => Artist);
            }
        }

        public List<EventsContract> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                NotifyOfPropertyChange(() => Events);
            }
        }

        public ArtistInfoViewModel(IArtistInformationService artistInformationService)
        {
            _artistInformationService = artistInformationService;
        }

        protected async override void OnInitialize()
        {
            Events = await _artistInformationService.GetArtistEvents(Parameter.name);
        }
    }
}
