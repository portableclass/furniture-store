using System;
namespace FurnitureStore.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int PostalCode { get; set; }
        public ushort Discount { get; set; }
    }
}

