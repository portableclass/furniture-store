using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Repository;

public class ProductRepository : IAllProducts
{
	private readonly AppDataBaseContext _appDataBaseContent;
	public IEnumerable<Product> Products => _appDataBaseContent.Product.ToList();
	public Product GetProduct(int productId) => _appDataBaseContent.Product.FirstOrDefault(p => p.Id == productId);

	public ProductRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
