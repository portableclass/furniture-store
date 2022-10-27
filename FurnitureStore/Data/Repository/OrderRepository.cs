using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Repository;

public class OrderRepository : IAllOrders
{
	private readonly AppDataBaseContext _appDataBaseContent;
	public IEnumerable<Order> Orders => _appDataBaseContent.Order.ToList();
	public Order GetOrder(int orderId) => _appDataBaseContent.Order.FirstOrDefault(o => o.Id == orderId);

	public OrderRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
