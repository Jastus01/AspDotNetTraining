namespace Minimal;

public class MySuperSimpleMiddlwareClass
{
    private readonly RequestDelegate _next;

    public MySuperSimpleMiddlwareClass(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Request handled by middleware component");

        await _next(context);
        
        Console.WriteLine("Response handled by middleware component");
    }

}