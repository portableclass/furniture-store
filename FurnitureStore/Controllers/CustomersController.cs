using FurnitureStore.Data.Interfaces;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace FurnitureStore.Controllers;

public class CustomersController : Controller
{
	private readonly IAllCustomers _customers;
	private readonly ILogger<CustomersController> _logger;

	public CustomersController(ILogger<CustomersController> logger, IAllCustomers allCustomers)
	{
		_customers = allCustomers;
		_logger = logger;
	}

	public IActionResult List()
	{
		var model = new CustomerListViewModel()
		{
			Customers = _customers.Customers
		};
		return View(model);
	}
}
