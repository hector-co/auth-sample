using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyShop.Catalog.DataAccess.Ef
{
    internal class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
            optionsBuilder.UseNpgsql(
                "Host=192.168.0.100;Database=MyShop;Username=postgres;Password=password",
                o => o.MigrationsHistoryTable("__EFMigrationsHistory", CatalogContext.DbSchema));

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}