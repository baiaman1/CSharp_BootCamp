using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace d04.Model
{
    public class BookReview : ISearchable
    {
        public string ListName { get; set; } = "";
        public int Rank { get; set; }

        [JsonPropertyName("amazon_product_url")]
        public string Url { get; set; } = "";
        public BookDetail[] BookDetails { get; set; } = [];
        public string Title => BookDetails[0].Title;

        public override string ToString()
        {
            if (BookDetails.Length == 0)
                return "No data available.";
            var book = BookDetails[0];
            return $"- {Title} by {book.Author} [{Rank} on NYT’s {ListName}]\n{book.SummaryShort}\n{Url}\n";
        }
    }

    public class BookDetail
    {
        public string Title { get; set; } = "";

        public string Author { get; set; } = "";

        [JsonPropertyName("description")]
        public string SummaryShort { get; set; } = "";
    }


    public class BookReviewResponse
    {
        public List<BookReview> Results { get; set; } = [];
    }
}
