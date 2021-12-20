using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyShop.Customers.DataAccess.Ef
{
    internal class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersContext>
    {
        public CustomersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomersContext>();
            optionsBuilder.UseNpgsql(
                "Host=192.168.0.100;Database=MyShop;Username=postgres;Password=password",
                o => o.MigrationsHistoryTable("__EFMigrationsHistory", CustomersContext.DbSchema));

            return new CustomersContext(optionsBuilder.Options);
        }
    }
}