using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_1
{
    internal class QuerySyntax
    {
        public void GetMoviesWithRatingAbove8(List<Movie> movieList)
        {
            var movies = from movie in movieList
                        where movie.Rating > 8.0
                        select movie.Title;
            Console.WriteLine("----- Movies With Rating Above 8.0 -----");
            foreach(var i in movies)
            {
                Console.WriteLine(i);
            }
        }

        public void GetMovieTitleWithGenres(List<Movie> movieList) 
        {
            Console.WriteLine("----- Movies With Genres -----");
            var movies = from movie in movieList
                         select new 
                         { 
                             movie.Title, 
                             movie.Genre 
                         };
            foreach(var i in movies)
            {
                Console.WriteLine($"Title: {i.Title} | Genres: {i.Genre}");
            }
        }

        public void GetAllDirectors(List<Movie> movieList)
        {
            Console.WriteLine("----- Get All Directors -----");
            var directorList = from movie in movieList
                               from director in movie.Directors
                               select director;

            foreach(var director in directorList)
            {
                Console.WriteLine(director);
            }
        }

        public void SortMoivesByRatingDescending(List<Movie> movieList)
        {
            var sortList = from movie in movieList
                           orderby movie.Rating descending, movie.Title descending
                           select new 
                           { 
                               movie.Rating, 
                               movie.Title
                           };
            Console.WriteLine("----- Sort by Movie Rating -----");

            foreach (var i in sortList)
            {
                Console.WriteLine($"Rating: {i.Rating} | Title: {i.Title}");
            }
        }

        public void GroupMoviesByGenres(List<Movie> movieList) 
        {
            var groupsList = from movie in movieList
                             group movie by movie.Genre into groupName
                             select groupName;
                            
            foreach( var i in groupsList)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Cateory: "+i.Key);
                Console.WriteLine("-----------------------");
                foreach (var movie in i)
                {
                    Console.WriteLine($"{movie.Title}");
                }   
            }
        }

        public void AvrageRatingOfAllMovie(List<Movie> movieList)
        {
            var average = (from movie in movieList
                          where movie.Rating.HasValue
                          select movie.Rating.Value).Average();
            Console.WriteLine("----- Overall Average Rating -----");
            Console.WriteLine($"Average rating of all movie {average}");
        }

        public void CountMoviesOfEachDirector(List<Movie> movieList)
        {
            var countMovies = from movie in movieList
                              from director in movie.Directors 
                              group movie by director into directorGroup
                              select new
                              {
                                  Director = directorGroup.Key,
                                  MovieCount = directorGroup.Count()
                              };

            Console.WriteLine("----- Movie Count By Director -----");
            foreach ( var movie in countMovies)
            {
                Console.WriteLine($"{movie.Director} | No. of Movies: {movie.MovieCount}");
            }
        }

        public void GetLMostMoviesDirected(List<Movie> movieList)
        {
            var directedList = from movie in movieList
                           from director in movie.Directors
                           group movie by director into movieGroup
                           select new
                           {
                               Director = movieGroup.Key,
                               MovieCount = movieGroup.Count()
                           };

            var maxMovies = directedList.Max(x => x.MovieCount );

            var topDirector = from d in directedList
                              where d.MovieCount == maxMovies
                              select d.Director;
            Console.WriteLine("----- Most Directed Movie By Director -----");

            Console.WriteLine($"Most Movies Directed: {topDirector.First()} | No. of Movies: {maxMovies}");
        }
    }
}
