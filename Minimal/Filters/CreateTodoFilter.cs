namespace Minimal.Filters;

public class CreateTodoFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var todoItem = context.GetArgument<TodoItem>(0);

        if (todoItem.Assignee == "Joe bloggs")
        {
            return Results.Problem("Joe Bloggs cannot be assigned a todo item");
        }

        return await next(context);
    }
}