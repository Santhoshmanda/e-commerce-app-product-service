using System;
using Microsoft.Extensions.DependencyInjection;
using OGANI.ProductService.Application.Services;
using OGANI.ProductService.Domain.Interfaces;

namespace OGANI.ProductService.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductService, Services.ProductService>();
			return services;
        }
	}
}

