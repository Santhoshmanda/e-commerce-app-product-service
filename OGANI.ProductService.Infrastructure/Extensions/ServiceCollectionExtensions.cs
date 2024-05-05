using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Infrastructure.Persistance;
using OGANI.ProductService.Infrastructure.Repositories;

namespace OGANI.ProductService.Infrastructure.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddInfrastructure(this IServiceCollection  services, IConfiguration configuration)
		{
			services.AddDbContext<OganiDbContext>(
				options => options.UseSqlServer(configuration.GetConnectionString("DbContext") ?? ""));
			services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

        }


	}
}

