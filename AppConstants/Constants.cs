namespace AppConstants
{
    public static class Constants
    {
        public static readonly string BaseURL = "http://api.bandsintown.com";
        public static readonly string Artists = "/artists/";
        public static readonly string ApiVersion = "?api_version=2.0";
        public static readonly string AppID = "&app_id=WPhone";
        public static readonly string Events = "/events.json";
        public static readonly string PopularEventsUrl = "https://app.bandsintown.com/events/popular?location=";
        public static readonly string PopularEventsRadius = "&radius=75";
        public static readonly string PopularEventsItemsPerPage = "&per_page=27&authenticate=false";
        public static readonly string JustAccouncedUrl = "https://app.bandsintown.com/events/just_announced?location=";
        public static readonly string JustAnnouncedRadius = "&radius=75";
        public static readonly string JustAnnouncedEventsItemsPerPage = "&per_page=15&authenticate=false";
        public static readonly string RecommendedArtistsUrl = "http://app.bandsintown.com/artists/recommended?popular=true";
        public static readonly string RecommendedArtistsPerPage = "&per_page=50&authenticate=false";
        public static readonly string EventsSearchUrl= "/events/search.json";
        public static readonly string EventsSearchLocation = "&location=";
        public static readonly string EventsSearchRadius = "&radius=";


    }
}

