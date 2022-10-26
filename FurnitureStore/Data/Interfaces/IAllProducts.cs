using System;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        Product GetProduct(int productId);
    }
}

