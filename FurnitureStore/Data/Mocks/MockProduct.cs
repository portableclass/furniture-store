using FurnitureStore.Data.Interfaces;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Mocks;
public class MockProduct : IAllProducts
{
    private readonly IAllStorages _storages = new MockStorage();

    public IEnumerable<Product> Products
    {
        get
        {
            return new List<Product>
            {
                new Product {
                    Name = "name1",
                    Description = "desc1",
                    Image = "img1",
                    Price = 100,
                    Storage = _storages.GetStorage(1)
                },
                new Product {
                    Name = "name2",
                    Description = "desc2",
                    Image = "img2",
                    Price = 200,
                    Storage = _storages.GetStorage(2)
                },
                new Product {
                    Name = "name3",
                    Description = "desc3",
                    Image = "img3",
                    Price = 300,
                    Storage = _storages.GetStorage(3)
                },
                new Product {
                    Name = "name4",
                    Description = "desc4",
                    Image = "img4",
                    Price = 400,
                    Storage = _storages.GetStorage(4)
                },
                new Product {
                    Name = "name5",
                    Description = "desc5",
                    Image = "img5",
                    Price = 500,
                    Storage = _storages.GetStorage(5)
                },
            };
        }
    }

    public Product GetProduct(int productId)
    {
        return Products.First();
    }
}