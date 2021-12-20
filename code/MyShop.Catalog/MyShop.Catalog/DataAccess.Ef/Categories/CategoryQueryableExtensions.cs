using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MyShop.Catalog.Domain.Model;

namespace MyShop.Catalog.DataAccess.Ef.Categories
{
    internal static class CategoryQueryableExtensions
    {
        internal static IQueryable<Category> AddIncludes
            (this IQueryable<Category> queryable)
        {
            return queryable
                .Include(m => m.SubCategories)
                ;
        }
    }
}