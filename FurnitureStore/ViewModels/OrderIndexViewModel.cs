using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using FurnitureStore.Data.Models;
namespace FurnitureStore.ViewModel;

public class OrderIndexViewModel
{
	public IEnumerable<Order> Orders { get; set; }
	public DateTime DateFrom { get; set; }
	public DateTime DateTo { get; set; }
	public int Iter = 1;
	public string RowBg { get; set; }
}
