using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using RazorPagesMovie.Data;

namespace RazorPages.Pages.Movies;

public class DetailsModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public DetailsModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public Movie Movie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is not null)
        {
            Movie = movie;

            return Page();
        }

        return NotFound();
    }
}