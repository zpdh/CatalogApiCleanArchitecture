using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(24).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(128).IsRequired();
        builder.Property(t => t.Price).HasPrecision(10, 2).IsRequired();
        builder.Property(t => t.RegisterDate).IsRequired();
        
        builder.HasOne(e => e.Category).WithMany(p => p.Products).HasForeignKey(e => e.CategoryId);
    }
}