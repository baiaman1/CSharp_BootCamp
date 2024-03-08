using System;
using System.Collections.Generic;
using System.IO;
using d04.Model;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

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

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string bookReviewsFilePath = configuration["BookReviewsFilePath"]!;
            string movieReviewsFilePath = configuration["MovieReviewsFilePath"]!;

            if (args.Length > 0 && args[0] == "best")
            {
                // Best Book
                List<BookReview> bookReviews = LoadBookReviewsFromJson(bookReviewsFilePath, option);

                var bestBook = bookReviews.OrderBy(b => b.Rank).FirstOrDefault();
                Console.WriteLine("Best in books:");
                Console.WriteLine(bestBook);

                // Best Movie
                List<MovieReview> movieReviews = LoadMovieReviewsFromJson(movieReviewsFilePath, option);

                var bestMovie = movieReviews.FirstOrDefault(m => m.CriticsPick == 1);
                Console.WriteLine("Best in movie reviews:");
                if (bestMovie != null) Console.WriteLine(bestMovie);
            }
            else
            {
                // Books
                List<BookReview> bookReviews = LoadBookReviewsFromJson(bookReviewsFilePath, option);

                // Movies
                List<MovieReview> movieReviews = LoadMovieReviewsFromJson(movieReviewsFilePath, option);

                Console.WriteLine("Input search text:");
                string? searchText = Console.ReadLine()!;
                var foundBooks = bookReviews.Search(searchText);
                var foundMovies = movieReviews.Search(searchText);

                int bookCount = foundBooks.Count();
                int movieCount = foundMovies.Count();
                int itemsFound = bookCount+movieCount;

                Console.WriteLine($"\nItems found: {itemsFound}");
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
            }
        }

        public static List<BookReview> LoadBookReviewsFromJson(string filePath, JsonSerializerOptions option)
        {
            string MovieJson = File.ReadAllText(filePath);
            var books = JsonSerializer.Deserialize<BookReviewResponse>(MovieJson, option);
            List<BookReview> BookReviews = [];
            if(books != null) BookReviews = books.Results;
            return BookReviews;
        }

        public static List<MovieReview> LoadMovieReviewsFromJson(string filePath, JsonSerializerOptions option)
        {
            string MovieJson = File.ReadAllText(filePath);
            var movies = JsonSerializer.Deserialize<MovieReviewResponse>(MovieJson, option);
            List<MovieReview> movieReviews = [];
            if(movies != null) movieReviews = movies.Results;
            return movieReviews;
        }
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
