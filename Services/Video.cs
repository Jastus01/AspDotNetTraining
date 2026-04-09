namespace Services;

public class Video : IDomainObject
{
    public int Id { get; set; }
    public required string Title { get; set; }
}