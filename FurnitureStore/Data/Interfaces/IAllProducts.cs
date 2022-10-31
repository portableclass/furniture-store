using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Interfaces;

public interface IAllProducts
{
	IEnumerable<Product> Products { get; }
	Product? GetProduct(int? productId);
	Task CreateProduct(Product product);
	void DeleteProduct(int productId);
	IEnumerable<Product> ProductsOrderBy(string sortingField, string sortingTrend);
	Task Update(Product product);
}
