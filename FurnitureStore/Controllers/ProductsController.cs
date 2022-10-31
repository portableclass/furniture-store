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

	public ProductsController(
		ILogger<ProductsController> logger,
		IAllProducts allProducts,
		IAllImages allImages,
		IAllStorages allStorages
	)
	{
		_products = allProducts;
		_storages = allStorages;
		_images = allImages;
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Index()
	{
		var model = new ProductIndexViewModel
		{
			Products = _products.Products
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult Index(ProductIndexViewModel model)
	{
		var newModel = new ProductIndexViewModel()
		{
			Products = _products.ProductsOrderBy(model.SortingField, model.SortingTrend)
		};
		return View(newModel);
	}

	[HttpGet]
	public IActionResult Details(int? id)
	{
		Product? product = _products.GetProduct(id);
		if (product != null)
		{
			ViewBag.ActionType = "Edit";
			return View(product);
		}
		ViewBag.ActionType = "Create";
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Details(Product product)
	{
		if (product.Id != 0)
		{
			ViewBag.ActionType = "Edit";
			// if (product.Image == null)
			// {
			// 	int id = 0;
			// 	Product? t2 = _products.GetProduct(product.Id);
			// 	if (t2 != null)
			// 		product.ImageId = t2.ImageId;
			//
			// 	// var update = new Product()
			// 	// {
			// 	// 	Id = product.Id,
			// 	// 	Name = product.Name,
			// 	// 	Description = product.Description,
			// 	// 	ImageId = id,
			// 	// 	Price = product.Price,
			// 	// 	StorageId = 1
			// 	// };
			// 	await _products.Update(product);
			// 	return RedirectToAction(nameof(Complete));
			// }


			await _products.Update(product);
			return RedirectToAction(nameof(Complete));
		}

		ViewBag.ActionType = "Create";
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
	}

	public IActionResult Complete()
	{
		return View();
	}

	public IActionResult Delete(int id)
	{
		_products.DeleteProduct(id);
		return RedirectToAction(nameof(Index));
	}
}
