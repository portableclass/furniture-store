using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModels;

public class ProductIndexViewModel
{
	public IEnumerable<Product> Products { get; set; }
	public string SortingField { get; set; }
	public string SortingTrend { get; set; }
	public string ExportType { get; set; }

}
