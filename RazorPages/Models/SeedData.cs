using System.Globalization;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPages.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        DateTime.SpecifyKind(DateTime.Parse("1984-03-13"), DateTimeKind.Utc);
        
        using (var context = 
               new RazorPagesMovieContext(serviceProvider
                   .GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentException("Null RazorPagesMovieContext");
            }
            
            if(context.Movie.Any())
            {
                return; // Db has been seeded
            }
            
            context.Movie.AddRange(
                new Movie
                {
                    Name = "When Harry Met Sally",
                    ReleaseDate = DateTime.SpecifyKind(DateTime.Parse("1989-02-12"), DateTimeKind.Utc),
                    Genre = "Romantic Comey",
                    Price = 7.99m
                },
                new Movie
                {
                  Name = "Ghostbusters",
                  ReleaseDate = DateTime.SpecifyKind(DateTime.Parse("1984-03-13"), DateTimeKind.Utc),
                  Genre = "Comedy",
                  Price = 8.99m
                },
                new Movie
                {
                    Name = "Ghostbusters 2",
                    ReleaseDate = DateTime.SpecifyKind(DateTime.Parse("1986-04-15"), DateTimeKind.Utc),
                    Genre = "Comedy",
                    Price = 9.99m
                },
                new Movie
                {
                    Name = "Rio Bravo",
                    ReleaseDate = DateTime.SpecifyKind(DateTime.Parse("1959-04-15"), DateTimeKind.Utc),
                    Genre = "Western",
                    Price = 3.99m
                }
                );

            context.SaveChanges();
        }
    }
}