namespace NewspaperCMS.DomainObjects;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public DateTime PublishedOn { get; set; }
    public bool IsPublished { get; set; }
    // images
    // videos
    // audio
    // comments
    // revisions
    // tags

    public List<Tag> GetTags()
    {
        return new List<Tag>();
    }
    
}