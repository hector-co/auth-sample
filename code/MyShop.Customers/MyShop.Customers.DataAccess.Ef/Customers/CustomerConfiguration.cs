using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using MyShop.Customers.Domain.Model;

namespace MyShop.Customers.DataAccess.Ef.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        private readonly string _dbSchema;

        public CustomerConfiguration(string dbSchema)
        {
            _dbSchema = dbSchema;
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", _dbSchema);
            builder.Property(m => m.Name)
                .HasMaxLength(200);
        }
    }
}