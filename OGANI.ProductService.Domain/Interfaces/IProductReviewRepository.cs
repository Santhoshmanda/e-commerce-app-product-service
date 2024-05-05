using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Domain.Interfaces
{
    public interface IProductReviewRepository
	{
		Task<IEnumerable<ProductReview>> GetReviewsByProductIdAsync(int productReviewId);
		Task<ProductReview?> CreateReviewAsync(ProductReview productReview);
		Task UpdateReviewAsync(ProductReview productReview);
		Task<bool> DeleteReviewAsync(int productReviewId);
	}
}

