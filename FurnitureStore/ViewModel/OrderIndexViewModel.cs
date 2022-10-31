using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModel;

public class OrderIndexViewModel
{
	public IEnumerable<Order> Orders { get; set; }
}
