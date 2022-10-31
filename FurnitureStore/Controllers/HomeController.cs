using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.Controllers;

[Authorize(Policy = "User")]
public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index() => View();
}
