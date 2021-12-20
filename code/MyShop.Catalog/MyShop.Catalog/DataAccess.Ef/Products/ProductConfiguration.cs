using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using MyShop.Catalog.Domain.Model;

namespace MyShop.Catalog.DataAccess.Ef.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly string _dbSchema;

        public ProductConfiguration(string dbSchema)
        {
            _dbSchema = dbSchema;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", _dbSchema);
            builder.Ignore(m => m.Images);
            builder.Property(m => m.Images_Serialized);
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.Description)
                .HasMaxLength(8000);
            builder.HasOne(m => m.SubCategory)
                .WithMany()
                .HasForeignKey(r => r.SubCategoryId);
        }
    }
}