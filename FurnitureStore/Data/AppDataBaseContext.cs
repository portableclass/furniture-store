using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace FurnitureStore.Data;

public class AppDataBaseContext : DbContext
{
	public DbSet<Product> Product { get; set; }
	public DbSet<Storage> Storage { get; set; }
	public DbSet<Order> Order { get; set; }
	public DbSet<Customer> Customer { get; set; }
	public DbSet<Worker> Worker { get; set; }

	public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) {}
}
