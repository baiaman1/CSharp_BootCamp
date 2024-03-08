using System.Text.Json.Serialization;

namespace d04.Model
{
    public class MovieReview : ISearchable
    {
        public string Title { get; set; } = "";
        public int CriticsPick { get; set; }

        // public bool IsCriticsPick = CriticsPick == 1;

        public string SummaryShort { get; set; } = "";

        public Links? Link { get; set; }

        public override string ToString()
        {
            string strCriticsPick = CriticsPick == 1 ? "[NYT critic’s pick]" : "";
            string res = "";
            if (Link != null)
                res = $"- {Title} {strCriticsPick}\n{SummaryShort}\n{Link.Url}\n";
            return res;
        }

        public class Links
        {
            public string Url { get; set; } = "";
        }
    }

    public class MovieReviewResponse
    {
        public List<MovieReview> Results { get; set; } = [];
    }
}
