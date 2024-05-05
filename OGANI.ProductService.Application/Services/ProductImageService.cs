using System;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Application.Services
{
	public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
		public ProductImageService(IProductImageRepository productImageRepository)
		{
            _productImageRepository = productImageRepository;
		}

        public async Task<ProductImage> AddImageAsync(ProductImage productImage)
        {
            return await _productImageRepository.AddImageAsync(productImage);
        }

        public async Task<bool> DeleteImageAsync(int productImageId)
        {
            return await _productImageRepository.DeleteImageAsync(productImageId);
        }

        public async Task<ProductImage?> GetImageByImageId(int imageId)
        {
            return await _productImageRepository.GetImageByImageId(imageId);
        }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(int productId)
        {
            return await _productImageRepository.GetImagesByProductIdAsync(productId);
        }

        public async Task UpdateImageAsync(ProductImage productImage)
        {
             await _productImageRepository.UpdateImageAsync(productImage);
        }
    }
}

