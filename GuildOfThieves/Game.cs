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
            Name = "Outside the gates",
            ShortDescription = "",
            Description = ""
        };

        Room room2 = new()
        {
            Name = "Inside the gates",
            ShortDescription = "",
            Description = ""
        };

        Room room3 = new()
        {
            Name = "Main Entrance",
            ShortDescription = "",
            Description = ""
        };
        
        Room room4 = new()
        {
            Name = "East side of mansion",
            ShortDescription = "",
            Description = ""
        };
        
        Loop();
    }

    private void Loop()
    {
        //get examine open close unlock n, s, e, w, up, down, climb
        
        // read command
        // execute command
    }
}