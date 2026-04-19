namespace NewspaperCMS.Helpers;

public class Settings
{
    public FrontPageSettings? FrontPage { get; set; }
}

public class FrontPageSettings
{ 
  public int NumberOfFrontPageOpinionPieces { get; set; } = 1;
  public int NumberOfHeadlineArticles { get; set; } = 1;
}