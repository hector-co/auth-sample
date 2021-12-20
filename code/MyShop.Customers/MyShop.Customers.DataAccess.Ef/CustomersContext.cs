using Microsoft.EntityFrameworkCore;
using MyShop.Customers.DataAccess.Ef.Customers;

namespace MyShop.Customers.DataAccess.Ef
{
    public class CustomersContext : DbContext
    {
        public const string DbSchema = "customers";

        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder);
        }

        public static void Configure(ModelBuilder modelBuilder, string dbSchema = DbSchema)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration(dbSchema));
        }
    }
}