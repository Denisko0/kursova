using System;
using System.Collections.Generic;
using System.Linq;

namespace TopMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();

            // Add some sample movies
            movies.Add(new Movie("The Shawshank Redemption", "Drama", 9.3));
            movies.Add(new Movie("The Godfather", "Crime, Drama", 9.2));
            movies.Add(new Movie("The Godfather: Part II", "Crime, Drama", 9.0));
            movies.Add(new Movie("The Dark Knight", "Action, Crime, Drama", 9.0));
            movies.Add(new Movie("12 Angry Men", "Drama", 8.9));
            movies.Add(new Movie("Schindler's List", "Biography, Drama, History", 8.9));
            movies.Add(new Movie("The Lord of the Rings: The Return of the King", "Action, Adventure, Drama", 8.9));
            movies.Add(new Movie("Pulp Fiction", "Crime, Drama", 8.9));
            movies.Add(new Movie("The Good, the Bad and the Ugly", "Western", 8.8));
            movies.Add(new Movie("Fight Club", "Drama", 8.8));

            Console.WriteLine("Welcome to the Top Movies app!");
            Console.WriteLine("Enter a genre to see the top 3 movies in that genre, or type 'all' to see the top 10 movies of all genres:");

            string input = Console.ReadLine();

            if (input.ToLower() == "all")
            {
                movies = movies.OrderByDescending(m => m.Rating).ToList();
                Console.WriteLine("Top 10 movies of all genres:");
            }
            else
            {
                movies = movies.Where(m => m.Genre.ToLower().Contains(input.ToLower())).OrderByDescending(m => m.Rating).ToList();
                Console.WriteLine($"Top 3 movies in the {input.ToLower()} genre:");
            }

            int count = 1;
            foreach (Movie movie in movies.Take(10))
            {
                Console.WriteLine($"{count}. {movie.Title} ({movie.Genre}) - {movie.Rating}");
                count++;
            }
        }
    }

    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        public Movie(string title, string genre, double rating)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
        }
    }
}
