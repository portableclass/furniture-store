using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Data.Repository;

public class CustomerRepository : IAllCustomers
{
	private readonly AppDataBaseContent _appDataBaseContent;

	public CustomerRepository(AppDataBaseContent content)
	{
		_appDataBaseContent = content;
	}

	public IEnumerable<Customer> Customers => _appDataBaseContent.Customer.Include(c => c);
	public Customer GetCustomer(int customerId) => _appDataBaseContent.Customer.FirstOrDefault(c => c.Id == customerId);
}
