using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(24).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(128).IsRequired();
    }
}