namespace Minimal;

public class TodoItemService
{
    private List<TodoItem> _todoItems = new ();

    public TodoItem? GetById(int id)
    {
        return _todoItems.FirstOrDefault(x => x.Id == id);
    }

    public List<TodoItem> GetTodoItems(bool pastDue, int priority)
    {
        var todoItemsQuery = _todoItems.AsQueryable();

        if (pastDue)
        {
            todoItemsQuery = todoItemsQuery.Where(x => x.DueDate <= DateTime.Now);
        }

        if (priority > 0)
        {
            todoItemsQuery = todoItemsQuery.Where(x => x.Priority == priority);
        }

        return todoItemsQuery.ToList();
    }
}