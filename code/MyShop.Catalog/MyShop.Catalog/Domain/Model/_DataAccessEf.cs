using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MyShop.Catalog.Domain.Model
{
    public partial class Category
    {
        internal int? CategoryId { get; set; }
    }

    public partial class Product
    {
        internal int SubCategoryId { get; set; }
        internal string Images_Serialized
        {
            get { return JsonSerializer.Serialize(Images); }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Images = JsonSerializer.Deserialize<List<string>>(value);
            }
        }
    }

}