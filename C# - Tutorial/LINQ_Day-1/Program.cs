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

            QueriesMethodSyntax methodSyntax = new QueriesMethodSyntax();

            // LINQ Query   
            // 1. Get movies with a rating above 8.0
            methodSyntax.GetMoviesWithRatingAbove8(movieList);
            Console.WriteLine("**********************************************************************");

            // 2. Retrieve movie titles along with their genres
            methodSyntax.GetMovieTitleWithGenre(movieList);
            Console.WriteLine("**********************************************************************");

            // 3. Use SELECTMANY to get a flat list of all directors
            methodSyntax.GetAllDirectors(movieList);
            Console.WriteLine("**********************************************************************");

            // 4. Retrive the total number of movies available.
            methodSyntax.GetTotalNumberOfMovies(movieList);
            Console.WriteLine("**********************************************************************");

            // 5. Get highest & lowest rating movie
            methodSyntax.GetHighestAndLowestRating(movieList);
            Console.WriteLine("**********************************************************************");

            // 6. Sort movies by rating descending, then by title.
            methodSyntax.SortMoviesByRatingAndTitle(movieList);
            Console.WriteLine("**********************************************************************");

            // 7. Group movies by Genre
            methodSyntax.GroupByMovieGenre(movieList);
            Console.WriteLine("**********************************************************************");

            // 8. Find the average rating of all movies (handling nullable values).
            methodSyntax.GetAverageRating(movieList);
            Console.WriteLine("**********************************************************************");

            // 9. Count how many movies each director has directed.
            methodSyntax.CountMoviesDirectedByEachDirector(movieList);
            Console.WriteLine("**********************************************************************");

            // 10. Find the director who has directed the most movies.
            methodSyntax.GetDirectorWithMostMovies(movieList);
            Console.WriteLine("**********************************************************************");
        }
    }
}