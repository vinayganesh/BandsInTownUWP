using System.Collections.Generic;

namespace HttpManager.DataContract
{
    public class RecommendedArtistsContract
    {
        public List<Datum> data { get; set; }
        public Pages pages { get; set; }

        public class Datum
        {
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string thumb_url { get; set; }
            public string large_image_url { get; set; }
            public bool on_tour { get; set; }
            public string events_url { get; set; }
            public string sony_id { get; set; }
            public int tracker_count { get; set; }
            public bool verified { get; set; }
            public int media_id { get; set; }
        }

        public class Pages
        {
            public int current_page { get; set; }
            public int total_results { get; set; }
            public int results_per_page { get; set; }
            public string next_page_url { get; set; }
            public object previous_page_url { get; set; }
        }
    }
}
