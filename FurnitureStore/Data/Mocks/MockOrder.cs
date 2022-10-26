using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Mocks;
public class MockOrder : IAllOrders
{
    private readonly IAllCustomers _customers = new MockCustomer();
    private readonly IAllWorkers _workers = new MockWorker();

    public IEnumerable<Order> Orders
    {
        get
        {
            return new List<Order>
            {
                new Order
                {
                    Date = new DateTime(2022, 1, 1),
                    Customer = _customers.GetCustomer(1),
                    Worker = _workers.GetWorker(1),
                },
                new Order
                {
                    Date = new DateTime(2022, 1, 2),
                    Customer = _customers.GetCustomer(2),
                    Worker = _workers.GetWorker(2),
                },
                new Order
                {
                    Date = new DateTime(2022, 1, 2),
                    Customer = _customers.GetCustomer(2),
                    Worker = _workers.GetWorker(2),
                },
                new Order
                {
                    Date = new DateTime(2022, 1, 3),
                    Customer = _customers.GetCustomer(3),
                    Worker = _workers.GetWorker(3),
                },
                new Order
                {
                    Date = new DateTime(2022, 1, 4),
                    Customer = _customers.GetCustomer(4),
                    Worker = _workers.GetWorker(4),
                },
                new Order
                {
                    Date = new DateTime(2022, 1, 5),
                    Customer = _customers.GetCustomer(5),
                    Worker = _workers.GetWorker(5),
                },
            };
        }
    }

    public Order GetOrder(int orderId)
    {
        return Orders.First();
    }
}