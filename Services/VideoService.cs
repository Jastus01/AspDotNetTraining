namespace Services;

public class VideoService : IVideoService
{
    public IEnumerable<Video> GetAll()
    {
        return new List<Video>{new Video{Id = 1000, Title = "Jaws"}};
    }

    public Video? Get(int id)
    {
        return null;
    }

    public void Upsert(Video video)
    {
        
    }
}