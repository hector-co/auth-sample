using Microsoft.EntityFrameworkCore;
using MyShop.Catalog.DataAccess.Ef.Categories;
using MyShop.Catalog.DataAccess.Ef.Products;

namespace MyShop.Catalog.DataAccess.Ef
{
    public class CatalogContext : DbContext
    {
        public const string DbSchema = "catalog";

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder);
        }

        public static void Configure(ModelBuilder modelBuilder, string dbSchema = DbSchema)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration(dbSchema));
            modelBuilder.ApplyConfiguration(new ProductConfiguration(dbSchema));
        }
    }
}