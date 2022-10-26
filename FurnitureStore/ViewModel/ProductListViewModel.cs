using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModel;

public class ProductListViewModel
{
	public IEnumerable<Product> Products { get; set; }
}