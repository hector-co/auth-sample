using System;
using System.Collections.Generic;

namespace MyShop.Catalog.Domain.Model
{
    public partial class Category 
    {
        public Category ()
        {
            SubCategories = new List<Category>();
        }

        public int Id { get; set; }
        public List<Category> SubCategories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int DisplayOrder { get; set; }
        public int PublishedProductsCount { get; set; }
        public bool Active { get; set; }
    }
}