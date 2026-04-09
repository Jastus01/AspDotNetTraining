using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPagesMovie.Data;

namespace RazorPages.Pages.Movies;

public class CreateModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public CreateModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    [BindProperty] public Movie Movie { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();


        Movie.ReleaseDate = new DateTime(Movie.ReleaseDate.Ticks, DateTimeKind.Utc);

        _context.Movie.Add(Movie);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}