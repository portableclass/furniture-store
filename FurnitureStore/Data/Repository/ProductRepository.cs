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

	public IEnumerable<Product> ProductsOrderBy(string sortingField, string sortingTrend)
	{
		return sortingTrend switch
		{
			"1" => sortingField switch
			{
				"1" => _appDataBaseContent.Product.OrderBy(p => p.Name).Include(i => i.Image).Include(s => s.Storage),
				"2" => _appDataBaseContent.Product.OrderBy(p => p.Price).Include(i => i.Image).Include(s => s.Storage),
				"3" => _appDataBaseContent.Product.OrderBy(p => p.Description)
					.Include(i => i.Image)
					.Include(s => s.Storage),
				_ => _appDataBaseContent.Product.Include(i => i.Image).Include(s => s.Storage)
			},
			"2" => sortingField switch
			{
				"1" => _appDataBaseContent.Product.OrderByDescending(p => p.Name)
					.Include(i => i.Image)
					.Include(s => s.Storage),
				"2" => _appDataBaseContent.Product.OrderByDescending(p => p.Price)
					.Include(i => i.Image)
					.Include(s => s.Storage),
				"3" => _appDataBaseContent.Product.OrderByDescending(p => p.Description)
					.Include(i => i.Image)
					.Include(s => s.Storage),
				_ => _appDataBaseContent.Product.OrderByDescending(p => p.Name)
					.Include(i => i.Image)
					.Include(s => s.Storage)
			},
			_ => _appDataBaseContent.Product.Include(i => i.Image).Include(s => s.Storage)
		};
	}
	public Product? GetProduct(int? productId) => _appDataBaseContent.Product.FindAsync(productId).GetAwaiter().GetResult();

	public async Task CreateProduct(Product product)
	{
		await _appDataBaseContent.Product.AddAsync(product);
		await _appDataBaseContent.SaveChangesAsync();
	}
	public async Task Update(Product product)
	{
		_appDataBaseContent.Product.Update(product);
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
