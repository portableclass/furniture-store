using FurnitureStore.Data.Interfaces;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace FurnitureStore.Controllers;

public class ProductsController : Controller
{
	private readonly IAllProducts _products;
	private readonly IAllStorages _storages;
	private readonly ILogger<ProductsController> _logger;

	public ProductsController(ILogger<ProductsController> logger, IAllProducts allProducts, IAllStorages allStorages)
	{
		_products = allProducts;
		_storages = allStorages;
		_logger = logger;
	}

	public IActionResult List()
	{
		var model = new ProductListViewModel
		{
			Products = _products.Products
		};
		return View(model);
	}
}

