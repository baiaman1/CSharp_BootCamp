using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            // string json = File.ReadAllText("book_reviews.json");
            // var books = JsonConvert.DeserializeObject<Book>(json);
            // if (books != null) Console.WriteLine(books.ToString());

            string json = File.ReadAllText("movie_reviews.json");
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            if (movie != null) Console.WriteLine(movie.ToString());
        }
    }
}