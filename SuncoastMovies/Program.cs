using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SuncoastMovies
{
    class SuncoastMoviesContext : DbContext
    {
        // "Movies" is our table over in the database world
        // "Movie" is our C# class in .NET world
        // "DbSet" is like database powered `List`
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");
        }
    }

    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PrimaryDirector { get; set; }
        public int YearReleased { get; set; }
        public string Genre { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get a new context that will connect to the database
            var context = new SuncoastMoviesContext();

            // Not too different from code we've seen before
            //
            // var transactionCount = transactions.Count();
            var moviesCount = context.Movies.Count();

            Console.WriteLine($"There are {moviesCount} movies in our database");

            foreach (var movie in context.Movies)
            {
                Console.WriteLine($"There is a movie named {movie.Title}");
            }

        }
    }
}
