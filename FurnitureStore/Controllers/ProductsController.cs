using FurnitureStore.Data;
using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using FurnitureStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.Controllers;

[Authorize(Policy = "User")]
public class ProductsController : Controller
{
	private readonly IAllProducts _products;
	private readonly IAllImages _images;
	private readonly IAllStorages _storages;
	private readonly ILogger<ProductsController> _logger;
	private readonly AppDataBaseContext _ctx;

	public ProductsController(
		AppDataBaseContext ctx,
		ILogger<ProductsController> logger,
		IAllProducts allProducts,
		IAllImages allImages,
		IAllStorages allStorages
	)
	{
		_ctx = ctx;
		_products = allProducts;
		_storages = allStorages;
		_images = allImages;
		_logger = logger;
	}

	[HttpGet]
	public IActionResult List()
	{
		var model = new ProductListViewModel
		{
			Products = _products.Products
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult List(ProductListViewModel model)
	{

		return View(model);
	}

	[HttpGet]
	public IActionResult Details(int? id)
	{
		Product? product = _products.GetProduct(id);
		if (product != null) return View(product);
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Details(Product product)
	{
		// if (product.Id != 0)
		// {
		//
		// }
		// else
		// {
			if (!ModelState.IsValid)
				return View(product);

			var img = new Image()
			{
				Name = product.Name,
				File = product.Image.File
			};
			await _images.CreateImage(img);

			var temp = new Product()
			{
				Name = product.Name,
				Description = product.Description,
				Image = img,
				Price = product.Price,
				StorageId = 1,
			};

			await _products.CreateProduct(temp);
			return RedirectToAction(nameof(Complete));
		// }
	}

	public IActionResult Complete()
	{
		return View();
	}

	public IActionResult Delete(int id)
	{
		_products.DeleteProduct(id);
		return RedirectToAction(nameof(List));
	}
}
