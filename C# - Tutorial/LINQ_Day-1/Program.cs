using System;
namespace LINQ_Day_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            Movie movieObj = new Movie();
            movieList = movieObj.GetMovies();

            foreach (var movie in movieList)
            {
                Console.WriteLine($"{movie.Id}. {movie.Title} -|- {movie.Genre} -|- Rating: {movie.Rating}");
            }

            Console.WriteLine("******************************************************************");

            MethodSyntax methodSyntax = new MethodSyntax();
            QuerySyntax querySyntax = new QuerySyntax();

            // LINQ Query   
            // 1. Get movies with a rating above 8.0
            querySyntax.GetMoviesWithRatingAbove8(movieList);
            methodSyntax.GetMoviesWithRatingAbove8(movieList);
            Console.WriteLine("******************************************************************");

            // 2. Retrieve movie titles along with their genres
            querySyntax.GetMovieTitleWithGenres(movieList);
            methodSyntax.GetMovieTitleWithGenre(movieList);
            Console.WriteLine("******************************************************************");

            // 3. Use SELECTMANY to get a flat list of all directors
            querySyntax.GetAllDirectors(movieList);
            methodSyntax.GetAllDirectors(movieList);
            Console.WriteLine("******************************************************************");

            // 4. Retrive the total number of movies available.
            methodSyntax.GetTotalNumberOfMovies(movieList);
            Console.WriteLine("******************************************************************");

            // 5. Get highest & lowest rating movie
            methodSyntax.GetHighestAndLowestRating(movieList);
            Console.WriteLine("******************************************************************");

            // 6. Sort movies by rating descending, then by title.
            querySyntax.SortMoivesByRatingDescending(movieList);
            methodSyntax.SortMoviesByRatingAndTitle(movieList);
            Console.WriteLine("******************************************************************");

            // 7. Group movies by Genre
            querySyntax.GroupMoviesByGenres(movieList);
            methodSyntax.GroupByMovieGenre(movieList);
            Console.WriteLine("******************************************************************");

            // 8. Find the average rating of all movies (handling nullable values).
            querySyntax.AvrageRatingOfAllMovie(movieList);
            methodSyntax.GetAverageRating(movieList);
            Console.WriteLine("******************************************************************");

            // 9. Count how many movies each director has directed.
            querySyntax.CountMoviesOfEachDirector(movieList);
            methodSyntax.CountMoviesDirectedByEachDirector(movieList);
            Console.WriteLine("******************************************************************");

            // 10. Find the director who has directed the most movies.
            querySyntax.GetLMostMoviesDirected(movieList);
            methodSyntax.GetDirectorWithMostMovies(movieList);
            Console.WriteLine("******************************************************************");
        }
    }
}