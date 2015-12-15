using System.Collections.Generic;

namespace HttpManager.DataContract
{
    public class EventsBasdOnRadiusContract
    {
        public int id { get; set; }
        public string title { get; set; }
        public string datetime { get; set; }
        public string formatted_datetime { get; set; }
        public string formatted_location { get; set; }
        public string ticket_url { get; set; }
        public string ticket_type { get; set; }
        public string ticket_status { get; set; }
        public string on_sale_datetime { get; set; }
        public string facebook_rsvp_url { get; set; }
        public string description { get; set; }
        public List<Artist> artists { get; set; }
        public Venue venue { get; set; }

        public class Artist
        {
            public string name { get; set; }
            public string mbid { get; set; }
            public string image_url { get; set; }
            public string thumb_url { get; set; }
            public string facebook_tour_dates_url { get; set; }
            public object facebook_page_url { get; set; }
            public int tracker_count { get; set; }
            public string url { get; set; }
            public string website { get; set; }
        }

        public class Venue
        {
            public string name { get; set; }
            public string city { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    }
}
