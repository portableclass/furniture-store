using Microsoft.Build.Framework;
namespace FurnitureStore.ViewModel;

public class AccountIndexViewModel
{
	[Required]
	public string Username { get; set; }
	[Required]
	public string Password { get; set; }
}
