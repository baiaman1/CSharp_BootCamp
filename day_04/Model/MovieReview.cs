using System.Text;
using Newtonsoft.Json;

namespace d04.Model
{
    class MovieReview : ISearchable
    {
        [JsonProperty("results")]
        public Result[]? Results {get; set;}
        // [JsonProperty("title")]
        public string Title { get; set; }

        public class Result
        {
            [JsonProperty("title")]
            public string? Title {get; set;}

            [JsonProperty("mpaa_rating")]
            public string? Rating {get; set;}

            [JsonProperty("critics_pick")]
            public int IsCriticsPick {get; set;}

            [JsonProperty("summary_short")]
            public string? SummaryShort {get; set;}

            // [JsonProperty("url")]
            // public string? Url {get; set;}

            [JsonProperty("link")]
            public Link? Links {get; set;}
        }
        public class Link
        {
            [JsonProperty("url")]
            public string? Url {get; set;}
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Results != null)
            foreach(var result in Results)
            {
                string IsCritics = result.IsCriticsPick == 1 ? "[NYT critic’s pick]" : "";
                if (result.Links != null)
                sb.AppendLine($"{result.Title} {IsCritics}\n{result.SummaryShort}\n{result.Links.Url}\n");
            }
            return sb.ToString();
        }
    }
}