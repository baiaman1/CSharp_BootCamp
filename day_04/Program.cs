using System;
using System.Collections.Generic;
using System.IO;
// using Newtonsoft.Json;
using d04.Model;
using System.Text.Json;
using System.Security.Cryptography;

namespace d04
{

    class Program
    {
        static void Main(string[] args)
        {

            var option = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            string BookJson = File.ReadAllText("book_reviews.json");
            var books = JsonSerializer.Deserialize<BookReviewResponse>(BookJson, option);
            List<BookReview> bookReviews = [];
            if(books != null) bookReviews = books.Results;

            string MovieJson = File.ReadAllText("movie_reviews.json");
            var movies = JsonSerializer.Deserialize<MovieReviewResponse>(MovieJson, option);
            List<MovieReview> movieReviews = [];
            if(movies != null) movieReviews = movies.Results;



            Console.WriteLine("Input search text:");
            string? searchText = Console.ReadLine();

            if (searchText != null)
            {
                var foundBooks = bookReviews.Search(searchText);
                var foundMovies = movieReviews.Search(searchText);
                int bookCount = foundBooks.Count();
                int movieCount = foundMovies.Count();

                Console.WriteLine($"\nItems found: {bookCount+movieCount}");
                Console.WriteLine($"\nBook search result [{bookCount}]:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine($"\nMovie search result [{movieCount}]:");
                foreach (var movie in foundMovies)
                {
                    Console.WriteLine(movie);
                }

                // IEnumerable<BookReview> obj ;
                // obj.Search;
            }
        }
    }

    public class BookReviewResponse
    {
        public List<BookReview> Results { get; set; } = [];
    }

    public class MovieReviewResponse
    {
        public List<MovieReview> Results { get; set; } = [];
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Search<T>(this IEnumerable<T> list, string search) where T : ISearchable
        {
            if (string.IsNullOrWhiteSpace(search))
                return list;

            string searchLower = search.ToLower();

            var foundItems = list.Where(item => item.Title.ToLower().Contains(searchLower))
                                 .OrderBy(item => item.Title);

            if (!foundItems.Any())
                Console.WriteLine($"There are no \"{search}\" in media today.");

            return foundItems;
        }
    }
}
