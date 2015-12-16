namespace HttpManager.DataContract
{
    public class ArtistContract
    {
        public string name { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public string facebook_tour_dates_url { get; set; }
        public string mbid { get; set; }
        public int upcoming_events_count { get; set; }
        public int tracker_count { get; set; }
    }
}
