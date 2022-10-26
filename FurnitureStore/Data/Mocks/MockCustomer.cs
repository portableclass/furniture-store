using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Mocks;
public class MockCustomer : IAllCustomers
{
    public IEnumerable<Customer> Customers
    {
        get
        {
            return new List<Customer>
            {
                new Customer {
                    Name = "customer1",
                    Patronymic = "patronymic1",
                    Surname = "surname1",
                    Phone = "79999999991",
                    City = "city1",
                    Street = "street1",
                    House = "1",
                    PostalCode = 192340,
                    Discount = 10
                },
                new Customer {
                    Name = "customer2",
                    Patronymic = "patronymic2",
                    Surname = "surname2",
                    Phone = "79999999992",
                    City = "city2",
                    Street = "street2",
                    House = "2",
                    PostalCode = 192340,
                    Discount = 20
                },
                new Customer {
                    Name = "customer3",
                    Patronymic = "patronymic3",
                    Surname = "surname3",
                    Phone = "79999999993",
                    City = "city3",
                    Street = "street3",
                    House = "3",
                    PostalCode = 192340,
                    Discount = 30
                },
                new Customer {
                    Name = "customer4",
                    Patronymic = "patronymic4",
                    Surname = "surname4",
                    Phone = "79999999994",
                    City = "city4",
                    Street = "street4",
                    House = "4",
                    PostalCode = 192340,
                    Discount = 40
                },
                new Customer {
                    Name = "customer5",
                    Patronymic = "patronymic5",
                    Surname = "surname5",
                    Phone = "79999999995",
                    City = "city5",
                    Street = "street5",
                    House = "5",
                    PostalCode = 192340,
                    Discount = 50
                },
            };
        }
    }

    public Customer GetCustomer(int customerId)
    {
        return Customers.First();
    }
}