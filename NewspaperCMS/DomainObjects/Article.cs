namespace NewspaperCMS.DomainObjects;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public DateTime Published { get; set; }
    public bool IsPublished { get; set; }
    // comments
    
}