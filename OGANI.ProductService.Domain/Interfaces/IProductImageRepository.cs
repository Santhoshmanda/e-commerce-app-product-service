using System;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Domain.Interfaces
{
	public interface IProductImageRepository
	{
        Task<ProductImage?> GetImageByImageId(int imageId);
        Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(int productId);
		Task<ProductImage> AddImageAsync(ProductImage productImage);
		Task UpdateImageAsync(ProductImage productImage);
		Task<bool> DeleteImageAsync(int productImageId);
	}
}

