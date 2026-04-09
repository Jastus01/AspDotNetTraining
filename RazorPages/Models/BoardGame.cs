using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models;

public class BoardGame
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [DataType(DataType.Date)] public DateOnly ReleaseDate { get; set; }

    public string? Category { get; set; }
    public decimal Price { get; set; }
    public int MinimumPlayers { get; set; }
    public int MaximumPlayers { get; set; }
    public int Duration { get; set; }
    public int Difficulty { get; set; }
    public int MinimumAge { get; set; }
}