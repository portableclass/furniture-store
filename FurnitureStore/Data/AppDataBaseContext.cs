using FurnitureStore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FurnitureStore.Data;

public class AppDataBaseContext : IdentityDbContext<User, Role, Guid>
{
	public DbSet<Product> Product { get; set; }
	public DbSet<Storage> Storage { get; set; }
	public DbSet<Order> Order { get; set; }
	public DbSet<Customer> Customer { get; set; }
	public DbSet<Worker> Worker { get; set; }
	public DbSet<Image> Image { get; set; }
	// public DbSet<User> User { get; set; }

	public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) {}
}
