namespace GuildOfThieves;

public class Game
{
    //loop
    //rooms
    
    //start

    public void Start()
    {
        Room room1 = new()
        {
            Name = "Outside the gates"
        };

        Room room2 = new()
        {
            Name = "Inside the gates"
        };

        Room room3 = new()
        {
            Name = "East side of mansion"
        };
        
        Loop();
    }

    private void Loop()
    {
        // read command
        // execute command
    }
}