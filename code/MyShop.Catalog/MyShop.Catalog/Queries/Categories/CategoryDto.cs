using System;
using System.Collections.Generic;

namespace MyShop.Catalog.Queries.Categories
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            SubCategories = new List<CategoryDto>();
        }

        public int Id { get; set; }
        public List<CategoryDto> SubCategories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int DisplayOrder { get; set; }
        public int PublishedProductsCount { get; set; }
        public bool Active { get; set; }
    }
}
