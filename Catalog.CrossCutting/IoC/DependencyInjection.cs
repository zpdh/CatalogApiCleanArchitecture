using Catalog.Application.Interfaces;
using Catalog.Application.Mappings;
using Catalog.Application.Services;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Context;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connStr = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(options => options.UseMySql(connStr,
            ServerVersion.AutoDetect(connStr)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        
        services.AddAutoMapper(typeof(DTOMappingProfile));
        
        return services;
    }
}