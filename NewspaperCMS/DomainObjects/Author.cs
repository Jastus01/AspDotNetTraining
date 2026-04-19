namespace NewspaperCMS.DomainObjects;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public object? Photo { get; set; }
    
}