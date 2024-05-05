using System;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Domain.Interfaces
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<Product?> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
    }
}

