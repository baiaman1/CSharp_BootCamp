using Newtonsoft.Json;

namespace d04.Model
{
    public class BookReview : ISearchable
    {
        [JsonProperty("book_details")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public BookDetail[] BookDetails { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public string Title => BookDetails[0].Title;

        public override string ToString()
        {   
            var book = BookDetails[0];
            return $"- {book.Title} by {book.Author} [{book.Rank} on NYT’s {book.ListName}]\n{book.Description}\n{book.Url}\n";
        }
    }

    public class BookDetail
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        [JsonProperty("author")]
        public string Author { get; set; } = "";

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("list_name")]
        public string ListName { get; set; } = "";

        [JsonProperty("description")]
        public string Description { get; set; } = "";

        [JsonProperty("amazon_product_url")]
        public string Url { get; set; } = "";
    }
}
