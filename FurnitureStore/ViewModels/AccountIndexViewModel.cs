using FurnitureStore.Data.Models;
using Microsoft.Build.Framework;
namespace FurnitureStore.ViewModels;

public class AccountIndexViewModel
{
	[Required]
	public string Username { get; set; }
	[Required]
	public string Password { get; set; }
	public Worker? Worker { get; set; }
	public string? IsValid { get; set; }
}
