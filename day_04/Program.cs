using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using d04.Model;
// using Newtonsoft.Json;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };
            string json = File.ReadAllText("book_reviews.json");
            var books = JsonSerializer.Deserialize<BookReview>(json, options);
            if (books != null) Console.WriteLine(books);

            // string json = File.ReadAllText("movie_reviews.json");
            // var movie = JsonConvert.DeserializeObject<Movie>(json);
            // if (movie != null) Console.WriteLine(movie.ToString());
        }
    }
}