namespace Minimal2;

public class ProductRepository
{
    public List<Product> Products { get; private set; }

    public ProductRepository(ProductRetrievalService productRetrievalService)
    {
        Products = productRetrievalService.LoadProducts();
    }
    
}