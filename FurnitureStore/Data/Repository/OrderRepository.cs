using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

public class OrderRepository : IAllOrders
{
	private readonly AppDataBaseContent _appDataBaseContent;

	public OrderRepository(AppDataBaseContent content)
	{
		_appDataBaseContent = content;
	}

	public IEnumerable<Order> Orders => _appDataBaseContent.Order.Include(o => o);
	public Order GetOrder(int orderId) => _appDataBaseContent.Order.FirstOrDefault(o => o.Id == orderId);
}
