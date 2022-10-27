using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Interfaces;

public interface IAllOrders
{
	IEnumerable<Order> Orders { get; }
	Order GetOrder(int orderId);
}
