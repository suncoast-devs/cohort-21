using System;
using System.Collections.Generic;
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
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Role> Roles { get; set; }

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

        // The RatingId (foreign key)
        public int RatingId { get; set; }

        //
        //     Data Type (the Rating class)
        //      |
        //      |     Name Of The Property
        //      |       |
        //      v       v
        public Rating Rating { get; set; }

        // This is the related list of roles we an use (if properly used with Include)
        //
        // Since a Movie "has many" Roles we setup this code. Teaches
        // Entity Framework that single Movie object can see "many" (List) Roles (each being a Role object)
        public List<Role> Roles { get; set; }
    }

    class Rating
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }

        // This is the related list of roles we an use (if properly used with Include)
        //
        // Since a Movie "has many" Roles we setup this code. Teaches
        // Entity Framework that single Movie object can see "many" (List) Roles (each being a Role object)
        public List<Role> Roles { get; set; }
    }

    class Role
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }

        // This is the column in the database
        public int MovieId { get; set; }
        // This is the related object we can use from our code (if properly used with Include)
        public Movie Movie { get; set; }


        // This is the column in the database
        public int ActorId { get; set; }
        // This is the related object we can use from our code (if properly used with Include)
        public Actor Actor { get; set; }
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

            // Makes a new collection of movies but each movie knows the associated Rating object
            var moviesWithRatingsRolesAndActors = context.Movies.
                                                    // from our movie, please include the associated Rating object
                                                    Include(movie => movie.Rating).
                                                    // ... and from our movie, please include the associated Roles LIST
                                                    Include(movie => movie.Roles).
                                                    // THEN for each of roles, please include the associated Actor object
                                                    ThenInclude(role => role.Actor);
            foreach (var movie in moviesWithRatingsRolesAndActors)
            {
                if (movie.Rating == null)
                {
                    Console.WriteLine($"There is a movie named {movie.Title}");
                }
                else
                {
                    Console.WriteLine($"Movie {movie.Title} - {movie.Rating.Description}");
                }

                foreach (var role in movie.Roles)
                {
                    Console.WriteLine($" - {role.CharacterName} is played by {role.Actor.FullName}");
                }
            }


            var newMovie = new Movie
            {
                Title = "SpaceBalls",
                PrimaryDirector = "Mel Brooks",
                Genre = "Comedy",
                YearReleased = 1987,
                RatingId = 2
            };

            // dinos.Add(newDino);
            // transactions.Add(newTransaction);
            context.Movies.Add(newMovie);
            context.SaveChanges();

            // Search for a movie by name. FirstOrDefault takes a function to use to compare the movies and returns the first record that matches, or if nothing matches, returns null.
            // This is the same as we used with LINQ against a List, but this time it is searching the database.
            var existingMovie = context.Movies.FirstOrDefault(movie => movie.Title == "SpaceBalls");

            // If we found an existing movie.
            if (existingMovie != null)
            {
                // Change the title of this movie.
                existingMovie.Title = "SpaceBalls - the best movie ever";

                // Ask the context to save changes.
                context.SaveChanges();
            }

            var existingMovieToDelete = context.Movies.FirstOrDefault(movie => movie.Title == "Cujo");

            // If we found an existing movie.
            if (existingMovieToDelete != null)
            {
                // Remove the existing movie from the collection
                context.Movies.Remove(existingMovieToDelete);

                // Ask the context to save changes, in this case deleting the record.
                context.SaveChanges();
            }

        }
    }
}
