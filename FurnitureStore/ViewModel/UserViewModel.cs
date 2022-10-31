using FurnitureStore.Data.Models;
using Microsoft.Build.Framework;

namespace FurnitureStore.ViewModel;

public class UserViewModel
{
	public Guid Id { get; set; }
	[Required]
	public string Username { get; set; }
	[Required]
	public string Password { get; set; }
	// public Role Role { get; set; }
	public int WorkerId { get; set; }
	public virtual Worker? Worker { get; set; }
	[Required]
	public string ReturnUrl { get; set; }
}
