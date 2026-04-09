namespace Minimal.Models;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Salary { get; set; }

    public string? Address
    {
        get => field;
        set => field = value;
    }

    public string? City { get; set; }

    public string? Region
    {
        get => field;
        set => field = value;
    }
    
    public string? PostalCode { get; set; }

    public string? Country
    {
        get => field;
        set => field = value;
    }

    public string? Phone
    {
        get => field;
        set => field = value;
    }
}