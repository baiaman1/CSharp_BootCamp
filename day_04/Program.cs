using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using d04.Model;

namespace d04
{
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

    class Program
    {
        static void Main(string[] args)
        {
            List<BookReview> bookReviews = LoadBookReviewsFromJson("book_reviews.json");
            List<MovieReview> movieReviews = LoadMovieReviewsFromJson("movie_reviews.json");



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
            }
        }

        static List<BookReview> LoadBookReviewsFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<BookReviewResponse>(json);
            return new List<BookReview>(result.Results);
        }

        static List<MovieReview> LoadMovieReviewsFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<MovieReviewResponse>(json);
            return new List<MovieReview>(result.Results);
        }
    }

    public class BookReviewResponse
    {
        public List<BookReview> Results { get; set; }
    }

    public class MovieReviewResponse
    {
        public List<MovieReview> Results { get; set; }
    }
}
