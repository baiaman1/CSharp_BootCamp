using Newtonsoft.Json;

namespace d04.Model
{
    public class MovieReview : ISearchable
    {
        public string Title { get; set; } = "";

        public bool IsCriticsPick { get; set; }

        public string SummaryShort { get; set; } = "";

        public Links? Link { get; set; }

        public override string ToString()
        {
            string criticsPick = IsCriticsPick ? "[NYT critic’s pick]" : "";
            string res = "";
            if (Link != null)
                res = $"- {Title} {criticsPick}\n{SummaryShort}\n{Link.Url}\n";
            return res;
        }

        public class Links
        {
            public string Url { get; set; } = "";
        }
    }
}
