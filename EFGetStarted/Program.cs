

using Microsoft.EntityFrameworkCore;

namespace EFGetStarted;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new BloggingContext();

        db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        await db.SaveChangesAsync();
        var blog = await db.Blogs.OrderBy(b => b.BlogId).FirstAsync();
        
        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
        await db.SaveChangesAsync();
        db.Remove(blog);
        await db.SaveChangesAsync();
        
        Console.WriteLine("Hello, World!");
    }
}