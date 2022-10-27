using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

public class ProductRepository : IAllProducts
{
	private readonly AppDataBaseContent _appDataBaseContent;

	public ProductRepository(AppDataBaseContent content)
	{
		_appDataBaseContent = content;
	}

	public IEnumerable<Product> Products => _appDataBaseContent.Product.Include(p=>p);
	public Product GetProduct(int productId) => _appDataBaseContent.Product.FirstOrDefault(p => p.Id == productId);
}
