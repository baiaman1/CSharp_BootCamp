using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace d04.Model
{
    public class BookReview : ISearchable
    {
        public string Title { get; set; }
        public Result[]? Results { get; set; }

        public class Result
        {
            public BookDetail[]? BookDetails { get; set; }

            public int Rank { get; set; }

            public string? ListName { get; set; }

            public string? AmazonProductUrl { get; set; }
        }

        public class BookDetail
        {
            public string? Title { get; set; }

            public string? Author { get; set; }

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
            // return $"{Title} by {Author} [{Rank} on NYT’s {ListName}]\n{SummaryShort}\n{Url}\n";

        }
    }
}