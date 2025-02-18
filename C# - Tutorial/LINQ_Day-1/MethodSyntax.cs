using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_1
{
    internal class MethodSyntax
    {
        public void GetMoviesWithRatingAbove8(List<Movie> movieList)
        {
            var moviesWithRatingAbove8 = movieList.Where(movie => movie.Rating > 8.0);
            Console.WriteLine("\n--- Movies with rating above 8.0 --- ");
            foreach (var movie in moviesWithRatingAbove8)
            {
                Console.WriteLine($"{movie.Id}. {movie.Title} | Rating: {movie.Rating}");
            }
        }

        public void GetMovieTitleWithGenre(List<Movie> movieList)
        {
            var movieTitleWithGenre = movieList.Select(movie => new { movie.Title, movie.Genre });
            Console.WriteLine("\n--- Movie Titles with Genre --- ");
            foreach (var movie in movieTitleWithGenre)
            {
                Console.WriteLine($"{movie.Title} | {movie.Genre}");
            }
        }

        public void GetAllDirectors(List<Movie> movieList)
        {
            var directors = movieList.SelectMany(movie => movie.Directors);
            Console.WriteLine("\n--- All Directors --- ");
            foreach (var director in directors)
            {
                Console.WriteLine(director);
            }
        }

        public void GetTotalNumberOfMovies(List<Movie> movieList)
        {
            var noOfMovies = movieList.Count();
            Console.WriteLine($"\n--> Total number of movies available: {noOfMovies}");
        }

        public void GetHighestAndLowestRating(List<Movie> movieList)
        {
            var highestRating = movieList.Max(movie => movie.Rating);
            Console.WriteLine($"\n--> Highest rating movie: {highestRating}");

            var lowestRating = movieList.Min(movie => movie.Rating);
            Console.WriteLine($"\n--> Lowest rating movie: {lowestRating}");
        }

        public void SortMoviesByRatingAndTitle(List<Movie> movieList)
        {
            var sortedMovies = movieList.OrderByDescending(movie => movie.Rating).ThenBy(movie => movie.Title);

            Console.WriteLine("\n--- Movies sorted by rating descending, then by title --- ");
            foreach (var movie in sortedMovies)
            {
                Console.WriteLine($"{movie.Id}. {movie.Title} | Rating: {movie.Rating}");
            }
        }

        public void GroupByMovieGenre(List<Movie> movieList)
        {
            var movieGroupByGenre = movieList.GroupBy(movie => movie.Genre);

            Console.WriteLine("\n--- Movies grouped by Genre --- ");
            foreach (var group in movieGroupByGenre)
            {
                Console.WriteLine($"\nGenre: {group.Key}");
                foreach (var movie in group)
                {
                    Console.WriteLine($"{movie.Id}. {movie.Title} | Rating: {movie.Rating}");
                }
            }
        }

        public void GetAverageRating(List<Movie> movieList)
        {
            var averageRating = movieList.Average(movie => movie.Rating ?? 0);

            Console.WriteLine($"\n--> Average rating of all movies: {averageRating}");
            foreach (var movie in movieList)
            {
                Console.WriteLine($"{movie.Id}. {movie.Title} -|- {movie.Genre} -|- Rating: {movie.Rating}");
            }
        }

        public void CountMoviesDirectedByEachDirector(List<Movie> movieList)
        {
            var directorCount = movieList.SelectMany(movie => movie.Directors)
                                        .GroupBy(director => director)
                                        .Select(group => new 
                                        { 
                                            Director = group.Key, 
                                            Count = group.Count() 
                                        });

            Console.WriteLine("\n--- Count of movies directed by each director --- ");
            foreach (var director in directorCount)
            {
                Console.WriteLine($"{director.Director} | Count: {director.Count}");
            }
        }

        public void GetDirectorWithMostMovies(List<Movie> movieList)
        {
            var directorCount = movieList.SelectMany(movie => movie.Directors)
                                         .GroupBy(director => director)
                                         .Select(group => new 
                                         { 
                                             Director = group.Key, 
                                             Count = group.Count() 
                                         });

            var directorWithMostMovies = directorCount.OrderByDescending(director => director.Count).First();

            Console.WriteLine($"\n--> Director with most movies: {directorWithMostMovies.Director} | Count: {directorWithMostMovies.Count}");
        }
    }
}
