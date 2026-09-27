using Microsoft.AspNetCore.Mvc;

namespace Minimal2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMyServices();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        app.MapGet("/getProductById/{id}", (
                int id,
                [FromServices] ProductRetrievalService productRetrievalService
                ) =>
            {
                var productRepository = new ProductRepository(productRetrievalService);

                return Results.Ok(productRepository.Products.FirstOrDefault(x => x.Id == id));
            }
        );

        app.MapPost(
            "/order",
            (Order order, 
                    [FromServices] DeliveryDateBookingService deliveryDateBookingService,
                    [FromServices] OrderRepository orderRepository) =>
            {
                order.DeliveryDate = deliveryDateBookingService.GetNextAvailableDate();
                orderRepository.SaveOrder(order);

            });
        
        

        app.Run();
    }
}