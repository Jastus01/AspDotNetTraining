using System.ComponentModel.DataAnnotations;
using Minimal.Filters;
using Minimal.Models;

namespace Minimal;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
            app.MapOpenApi();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.UseMiddleware<MySuperSimpleMiddlwareClass>();

        app.Use(async (context, next) =>
        {
            Console.WriteLine("Request handled by inline middleware component");
            await next(context);
            Console.WriteLine("Response handled ny inline middleware component");
        });

        app.Use(async (context, next) =>
        {
            Console.WriteLine($"Request : {context.Request.Method} {context.Request.Path}");
            await next();
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        });
        
        
        
        List<TodoItem> todoItems = new();

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = summaries[Random.Shared.Next(summaries.Length)]
                        })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");

        app.MapGet("/", () => "Hello World");

        app.MapGet("/employee/{id}", (int id) =>
        {
            var employee = EmployeeManager.Get(id);
            return Results.Ok(employee);
        });

        app.MapPost("/employees", (Employee employee) =>
        {
            EmployeeManager.Create(employee);
            return Results.Created();
        });

        app.MapPut("/employees", (Employee employee) =>
        {
            EmployeeManager.Update(employee);
            Results.Ok();
        });

        app.MapPatch("/updateEmployeeName", (Employee employee) =>
        {
            EmployeeManager.ChangeName(employee.Id, employee.Name);
            return Results.Ok();
        });

        app.MapDelete("/employee/{id}", (int id) =>
        {
            EmployeeManager.Delete(id);
            return TypedResults.Ok();
        });

        app.MapGet("/todoitems", () =>
            {
                return Results.Ok(todoItems);
            }
        );

        app.MapPost("/todoitems", (TodoItem item) =>
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(item);
            
            bool isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

            if (!isValid)
            {
                return Results.BadRequest(validationResults);
            }
            
            todoItems.Add(item);
            return Results.Created();
        }).AddEndpointFilter<CreateTodoFilter>();

        app.MapPatch("/updateTodoItemDueDate/{id:int:range(1, 100)}",
            (int id, DateTime newDueDate)
                =>
            {
                int index = todoItems.FindIndex(x => x.Id == id);
                
                if (index == -1)
                {
                    return Results.NotFound();
                }

                todoItems[index].DueDate = newDueDate;
                return Results.NoContent();
            });

        app.MapGet("/todoitems/{id}", (int id) =>
        {
            var index = todoItems.FindIndex(x => x.Id == id);
            
            if (index == -1)
            {
                return Results.NotFound();
            }

            return Results.Ok(todoItems[index]);
        });

        app.MapDelete("/todoitems/{id}", (int id) =>
        {
            int index = todoItems.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            
            todoItems.RemoveAt(index);
            return Results.NoContent();
        });

        app.Run();
    }
}