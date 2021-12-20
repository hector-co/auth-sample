using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using MyShop.Catalog.Domain.Model;

namespace MyShop.Catalog.DataAccess.Ef.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly string _dbSchema;

        public CategoryConfiguration(string dbSchema)
        {
            _dbSchema = dbSchema;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", _dbSchema);
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(m => m.Description)
                .HasMaxLength(8000);
            builder.Property(m => m.Image)
                .HasMaxLength(256);
            builder.HasMany(m => m.SubCategories)
                .WithOne()
                .HasForeignKey(r => r.CategoryId);
        }
    }
}