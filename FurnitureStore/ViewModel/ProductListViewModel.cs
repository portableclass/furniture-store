using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModel;

public class ProductListViewModel
{
	public IEnumerable<Product> Products { get; set; }
	public string SortingField { get; set; }
	public string SortingTrend { get; set; }

}
