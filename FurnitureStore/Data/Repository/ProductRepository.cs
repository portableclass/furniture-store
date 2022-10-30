using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FurnitureStore.Data.Repository;

public class ProductRepository : IAllProducts
{
	private readonly AppDataBaseContext _appDataBaseContent;

	public IEnumerable<Product> Products => _appDataBaseContent.Product
		.Include(i => i.Image)
		.Include(s => s.Storage);
	public Product? GetProduct(int? productId) => _appDataBaseContent.Product.Find(productId);

	public async Task CreateProduct(Product product)
	{
		await _appDataBaseContent.Product.AddAsync(product);
		await _appDataBaseContent.SaveChangesAsync();
	}
	public void DeleteProduct(int productId)
	{
		Product product = GetProduct(productId);
		_appDataBaseContent.Product.Remove(product);
		_appDataBaseContent.SaveChanges();
	}

	public ProductRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
