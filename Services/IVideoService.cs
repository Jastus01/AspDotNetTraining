namespace Services;

public interface IVideoService
{
    public IEnumerable<Video> GetAll();
}