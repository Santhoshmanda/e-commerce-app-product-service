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
	public class ProductImageRepository : IProductImageRepository
    {
        private readonly OganiDbContext _oganiDBContext;
        private readonly IMapper _mapper;

		public ProductImageRepository(OganiDbContext oganiDbContext, IMapper mapper)
		{
            _oganiDBContext = oganiDbContext;
            _mapper = mapper;
		}

        public async Task<ProductImage> AddImageAsync(ProductImage productImage)
        {
            var imageEntity = _mapper.Map<db_entities.ProductImage>(productImage);
             _oganiDBContext.Add(imageEntity);
            await _oganiDBContext.SaveChangesAsync();
            productImage.ImageId=imageEntity.ImageId;
            return productImage;
            
        }

        public async Task<bool> DeleteImageAsync(int productImageId)
        {
            var image = _oganiDBContext.ProductImages.Find(productImageId);
            if (image != null)
            {
                _oganiDBContext.ProductImages.Remove(image);
                await _oganiDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductImage?> GetImageByImageId(int imageId)
        {

            return await _oganiDBContext.ProductImages
                .ProjectTo<ProductImage>(_mapper.ConfigurationProvider)
                .AsNoTracking().FirstOrDefaultAsync(image=>image.ImageId==imageId);
            
        }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(int productId)
        {
            return await _oganiDBContext.ProductImages
               .ProjectTo<ProductImage>(_mapper.ConfigurationProvider)
               .AsNoTracking().Where(image => image.ProductId == productId).ToListAsync();

        }

        public async Task UpdateImageAsync(ProductImage productImage)
        {
            _oganiDBContext.Entry(productImage).State = EntityState.Modified;
            await _oganiDBContext.SaveChangesAsync();
        }
    }
}

