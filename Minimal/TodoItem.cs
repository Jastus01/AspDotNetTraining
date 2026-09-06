using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

namespace Minimal;

public class TodoItem
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Assignee { get; set; }
    public int Priority { get; set; }
    public bool IsComplete { get; set; }

    public static async ValueTask<TodoItem> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        try
        {
            string requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

            TodoItem? todoItem = JsonSerializer.Deserialize<TodoItem>(requestBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (todoItem is null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid JSON");
                return new TodoItem();
            }

            var validationResults = new List<ValidationResult>();

            var validationContext = new ValidationContext(todoItem);

            if (!Validator.TryValidateObject(
                    todoItem,
                    validationContext, 
                    validationResults,
                    validateAllProperties: true
                    ))
            {
                context.Response.StatusCode = 400;

                var errorMessages = string.Join("; ", validationResults.Select(x => x.ErrorMessage));
                await context.Response.WriteAsync(errorMessages);
                return new TodoItem();
            }

            return todoItem;
        }
        catch (JsonException e)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid JSON");
            return new TodoItem();
        }
    }
}