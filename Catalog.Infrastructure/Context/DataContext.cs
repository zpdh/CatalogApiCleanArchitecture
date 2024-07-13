using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}