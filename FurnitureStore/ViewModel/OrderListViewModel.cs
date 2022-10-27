using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModel;

public class OrderListViewModel
{
	public IEnumerable<Order> Orders { get; set; }
}
