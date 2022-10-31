using FurnitureStore.Data.Interfaces;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FurnitureStore.Controllers;

[Authorize(Policy = "User")]
public class OrdersController : Controller
{
	private readonly IAllOrders _orders;
	private readonly ILogger<OrdersController> _logger;

	public OrdersController(ILogger<OrdersController> logger, IAllOrders allOrders)
	{
		_orders = allOrders;
		_logger = logger;
	}

	public IActionResult List()
	{
		var model = new OrderListViewModel()
		{
			Orders = _orders.Orders
		};
		return View(model);
	}
}
