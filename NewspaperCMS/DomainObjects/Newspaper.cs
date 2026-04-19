namespace NewspaperCMS.DomainObjects;

public class Newspaper
{
    public string Title { get; set; }
    //front page
    public Article Headline { get; set; }
    
    public List<Article> OpinionPieces { get; set; } 
    //sections
    //opinion pieces
}