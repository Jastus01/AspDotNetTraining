
using Env = System.Environment;
using Packt.Shared;

namespace PeopleApp;

partial class Program
{
    static void Main(string[] args)
    {
        ConfigureConsole();

        Person bob = new();
        
        Console.WriteLine(bob);
        
        Console.WriteLine(Env.OSVersion);
        Console.WriteLine(Env.MachineName);
        Console.WriteLine(Env.CurrentDirectory);
        Console.WriteLine("Hello, World!");
    }
}