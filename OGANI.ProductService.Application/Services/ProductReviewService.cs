using System;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Application.Services
{
	public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _productReviewRepository;
		public ProductReviewService(IProductReviewRepository productReviewRepository)
		{
            _productReviewRepository = productReviewRepository;
		}

        public  async Task<ProductReview?> CreateReviewAsync(ProductReview productReview)
        {
            return await _productReviewRepository.CreateReviewAsync(productReview);
        }

        public async Task<bool> DeleteReviewAsync(int productReviewId)
        {
            return await _productReviewRepository.DeleteReviewAsync(productReviewId);
        }

        public async Task<IEnumerable<ProductReview>> GetReviewsByProductIdAsync(int productReviewId)
        {
            return await _productReviewRepository.GetReviewsByProductIdAsync(productReviewId);
        }

        public async Task UpdateReviewAsync(ProductReview productReview)
        {
             await _productReviewRepository.UpdateReviewAsync(productReview);
        }
    }
}

