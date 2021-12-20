using System;
using System.Collections.Generic;

namespace MyShop.Catalog.Domain.Model
{
    public partial class Product 
    {
        public Product ()
        {
            Images = new List<string>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Category SubCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public float Price { get; set; }
        public float? Stock { get; set; }
        public bool Published { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool Active { get; set; }
    }
}