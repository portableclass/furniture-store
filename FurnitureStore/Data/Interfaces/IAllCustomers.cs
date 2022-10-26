using System;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Interfaces
{
    public interface IAllCustomers
    {
        IEnumerable<Customer> Customers { get; }
        Customer GetCustomer(int customerId);
    }
}

