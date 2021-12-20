using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MyShop.Catalog.Domain.Model;

namespace MyShop.Catalog.DataAccess.Ef.Products
{
    internal static class ProductQueryableExtensions
    {
        internal static IQueryable<Product> AddIncludes
            (this IQueryable<Product> queryable)
        {
            return queryable
                .Include(m => m.SubCategory)
                ;
        }
    }
}