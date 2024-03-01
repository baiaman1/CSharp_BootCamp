using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Day04
{
    public class Book
    {
        [JsonProperty("results")]
        public Result[]? Results { get; set; }

        public class Result
        {
            [JsonProperty("book_details")]
            public BookDetail[]? BookDetails { get; set; }

            [JsonProperty("rank")]
            public int Rank { get; set; }

            [JsonProperty("list_name")]
            public string? ListName { get; set; }

            [JsonProperty("amazon_product_url")]
            public string? AmazonProductUrl { get; set; }
        }

        public class BookDetail
        {
            [JsonProperty("title")]
            public string? Title { get; set; }

            [JsonProperty("author")]
            public string? Author { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            if (Results != null)
            foreach(var result in Results)
            {
                if (result.BookDetails != null)
                foreach(var bookDatail in result.BookDetails)
                {
                    sb.AppendLine($"{bookDatail.Title} by {bookDatail.Author} [{result.Rank} on NYT’s {result.ListName}]\n{bookDatail.Description}\n{result.AmazonProductUrl}\n");
                }
            }
            return sb.ToString();
        }
    }
}