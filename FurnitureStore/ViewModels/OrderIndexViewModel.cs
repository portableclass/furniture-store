using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModels;

public class OrderIndexViewModel
{
	public IEnumerable<Order> Orders { get; set; }
	public DateTime DateFrom { get; set; }
	public DateTime DateTo { get; set; }
}
