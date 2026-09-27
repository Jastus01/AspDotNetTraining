using System.Collections.Concurrent;

namespace Minimal2;

public class OrderRepository
{
    public ConcurrentQueue<Order> Orders { get; private set; }

    public OrderRepository(OrderRetrievalService orderRetrievalService)
    {
        var retrievedOrders = orderRetrievalService.LoadOrders();

        foreach (Order order in retrievedOrders)
        {
            Orders.Enqueue(order);
        }
    }

    public void SaveOrder(Order order)
    {
        Orders.Enqueue(order);
    }
}