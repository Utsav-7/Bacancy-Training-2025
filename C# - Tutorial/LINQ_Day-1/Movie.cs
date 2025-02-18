using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_1
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; }
        public List<string> Directors { get; set; }

        public static List<Movie> movieList = new List<Movie>();

        public Movie(){}

        public Movie(int id, string title, string genre, double? rating, List<string> directors)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Rating = rating;
            Directors = directors;
        }

        public static void InitializeMovies()
        {
            movieList.Add(new Movie(1, "The Godfather", "Crime", 9.2, new List<string> { "Francis Ford Coppola" }));
            movieList.Add(new Movie(2, "The Shawshank Redemption", "Drama", 9.3, new List<string> { "Frank Darabont" }));
            movieList.Add(new Movie(3, "The Dark Knight", "Action", null, new List<string> { "Christopher Nolan" }));
            movieList.Add(new Movie(4, "The Lord of the Rings", "Adventure", 8.9, new List<string> { "Peter Jackson" }));
            movieList.Add(new Movie(5, "Pulp Fiction", "Crime", 8.9, new List<string> { "Quentin Tarantino" }));
            movieList.Add(new Movie(6, "Forrest Gump", "Drama", 8.8, new List<string> { "Robert Zemeckis" }));
            movieList.Add(new Movie(7, "Inception", "Action", 8.8, new List<string> { "Christopher Nolan" }));
            movieList.Add(new Movie(8, "Jungle Book", "Adventure", null, new List<string> { "Jon Favreau" }));
            movieList.Add(new Movie(9, "The Lord of the Rings: The Two Towers", "Adventure", 8.7, new List<string> { "Peter Jackson" }));
            movieList.Add(new Movie(10, "Star Wars: Episode V", "Action", 8.7, new List<string> { "Irvin Kershner" }));
            movieList.Add(new Movie(11, "The Matrix", "Action", 8.7, new List<string> { "Lana Wachowski", "Lilly Wachowski" }));
            movieList.Add(new Movie(12, "Fast & Furious 7", "Action", 7.2, new List<string> { "James Wan" }));
            movieList.Add(new Movie(13, "One Flew Over the Cuckoo's Nest", "Drama", null, new List<string> { "Milos Forman" }));
            movieList.Add(new Movie(14, "Seven Samurai", "Adventure", 8.6, new List<string> { "Akira Kurosawa" }));
            movieList.Add(new Movie(15, "The Social Network", "Biography", 7.7, new List<string> { "David Fincher" }));
            movieList.Add(new Movie(16, "The Silence of the Lambs", "Crime", null, new List<string> { "Jonathan Demme" }));
            movieList.Add(new Movie(17, "Interstellar", "Adventure", 8.6, new List<string> { "Christopher Nolan" }));
            movieList.Add(new Movie(18, "Steve Jobs", "Biography", 7.2, new List<string> { "Danny Boyle" }));
            movieList.Add(new Movie(19, "The Founder", "Biography", null, new List<string> { "John Lee Hancock" }));
            movieList.Add(new Movie(20, "Final Destination", "Horror", 6.7, new List<string> { "James Wong" }));

        }

        public List<Movie> GetMovies()
        {
            Movie.InitializeMovies();
            return movieList;
        }
    }
}
