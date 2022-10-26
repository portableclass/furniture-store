using System;
namespace FurnitureStore.Data.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int PostalCode { get; set; }
        public List<Product> Products { get; set; }
    }
}

