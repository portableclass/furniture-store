using FurnitureStore.Data.Interfaces;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FurnitureStore.Controllers;

[Authorize(Policy = "User")]
public class CustomersController : Controller
{
	private readonly IAllCustomers _customers;
	private readonly ILogger<CustomersController> _logger;

	public CustomersController(ILogger<CustomersController> logger, IAllCustomers allCustomers)
	{
		_customers = allCustomers;
		_logger = logger;
	}

	public IActionResult Index()
	{
		var model = new CustomerIndexViewModel()
		{
			Customers = _customers.Customers
		};
		return View(model);
	}
}
