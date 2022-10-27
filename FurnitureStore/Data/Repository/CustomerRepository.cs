using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
namespace FurnitureStore.Data.Repository;

public class CustomerRepository : IAllCustomers
{
	private readonly AppDataBaseContext _appDataBaseContent;
	public IEnumerable<Customer> Customers => _appDataBaseContent.Customer.ToList();
	public Customer GetCustomer(int customerId) => _appDataBaseContent.Customer.FirstOrDefault(c => c.Id == customerId);

	public CustomerRepository(AppDataBaseContext content)
	{
		_appDataBaseContent = content;
	}
}
