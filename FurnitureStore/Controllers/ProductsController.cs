using System;
using FurnitureStore.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace FurnitureStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _products;
        private readonly IAllStorages _storages;

        public ProductsController(IAllProducts allProducts, IAllStorages allStorages)
        {
            _products = allProducts;
            _storages = allStorages;
        }

        public ViewResult List()
        {
            var products = _products.Products;
            return View(products);
        }
    }
}

