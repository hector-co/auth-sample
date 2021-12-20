using System;
using System.Collections.Generic;
using MyShop.Catalog.Queries.Categories;

namespace MyShop.Catalog.Queries.Products
{
    public class ProductDto
    {
        public ProductDto()
        {
            Images = new List<string>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public CategoryDto SubCategory { get; set; }
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
