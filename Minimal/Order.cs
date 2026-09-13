namespace Minimal;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime DeliveryDate { get; set; }
}