using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPagesMovie.Data;

public class RazorPagesMovieContext : DbContext
{
    public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; } = default!;
}