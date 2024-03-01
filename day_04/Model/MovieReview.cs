using Newtonsoft.Json;

namespace d04.Model
{
    public class MovieReview : ISearchable
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        [JsonProperty("critics_pick")]
        public bool IsCriticsPick { get; set; }

        [JsonProperty("summary_short")]
        public string SummaryShort { get; set; } = "";

        [JsonProperty("link")]
        public Link? Url { get; set; }

        public override string ToString()
        {
            string criticsPick = IsCriticsPick ? "[NYT critic’s pick]" : "";
            string res = "";
            if (Url != null) res = $"- {Title} {criticsPick}\n{SummaryShort}\n{Url.Url}\n";
            return res;
        }

        public class Link
        {
            [JsonProperty("url")]
            public string Url { get; set; } = "";
        }
    }
}
