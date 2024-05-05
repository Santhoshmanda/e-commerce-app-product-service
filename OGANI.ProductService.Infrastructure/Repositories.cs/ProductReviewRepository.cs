using System;
using AutoMapper;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;
using db_entities=OGANI.ProductService.Infrastructure.Entities;
using OGANI.ProductService.Infrastructure.Persistance;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace OGANI.ProductService.Infrastructure.Repositories
{
	public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;

		public ProductReviewRepository(OganiDbContext oganiDbContext, IMapper mapper)
		{
            _oganiDbContext = oganiDbContext;
            _mapper = mapper;
		}

        public async Task<ProductReview?> CreateReviewAsync(ProductReview productReview)
        {
            var reviewEntity = _mapper.Map<db_entities.ProductReview>(productReview);
            _oganiDbContext.Add(reviewEntity);
            await _oganiDbContext.SaveChangesAsync();
            productReview.ReviewId = reviewEntity.ReviewId;
            return productReview;

        }

        public async Task<bool> DeleteReviewAsync(int productReviewId)
        {
            var review = _oganiDbContext.ProductReviews.Find(productReviewId);
            if (review != null)
            {
                _oganiDbContext.ProductReviews.Remove(review);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductReview>> GetReviewsByProductIdAsync(int productId)
        {
            return await _oganiDbContext.ProductReviews
                 .ProjectTo<ProductReview>(_mapper.ConfigurationProvider)
                 .Where(productreview => productreview.ProductId == productId).ToListAsync();
        }

        public async Task UpdateReviewAsync(ProductReview productReview)
        {
            _oganiDbContext.Entry(productReview).State = EntityState.Modified;
             await _oganiDbContext.SaveChangesAsync();
        }
    }
}

