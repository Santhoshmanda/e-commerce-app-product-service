using AutoMapper;
using OGANI.ProductService.Infrastructure.Entities;
using Models = OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Infrastructure.MappingProfile
{
    public class ProductReviewMappingProfile :Profile
	{
		public ProductReviewMappingProfile()
		{
            CreateMap<Models.ProductReview, ProductReview>();
            CreateMap<ProductReview, Models.ProductReview>();
        }
	}
}

