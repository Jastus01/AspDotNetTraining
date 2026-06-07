namespace ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        
        
        
        Console.WriteLine("Hello, World!");
    }
}